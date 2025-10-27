#include "parser.h"
#include "error.h"
#include <stdexcept>
#include <iostream>

using namespace std;

// 构造函数，初始化词法分析器和当前 Token
Parser::Parser(Lexer& lexer) : lexer(lexer), currentToken(lexer.getNextToken()) {}

// 开始语法分析
void Parser::parse() {
    try {
        program();  // 解析程序
        cout << "The code is correct." << endl;
    }
    catch (const runtime_error& e) {
        cerr << "Grammar error: " << e.what() << endl;
    }
}

// 解析程序
void Parser::program() {
    match(TOKEN_PROGRAM); 
    match(TOKEN_IDENTIFIER); 
    match(TOKEN_SEMICOLON);   
    block();                 // 解析代码块
    match(TOKEN_DOT);       
}

// 解析代码块
void Parser::block() {
    match(TOKEN_BEGIN);      
    statementList();         // 解析语句列表
    match(TOKEN_END);       
}

// 解析语句列表
void Parser::statementList() {

    statement();             // 解析一条语句
    if (currentToken.type == TOKEN_SEMICOLON) {
        match(TOKEN_SEMICOLON);  // 匹配分号

        if (currentToken.type == TOKEN_END )
            return;
        statement();             // 解析下一条语句
    }


    if (currentToken.type != TOKEN_END)
        statementList();         // 递归解析语句列表
}

// 解析语句
void Parser::statement() {
    if (currentToken.type == TOKEN_VAR) {
        variableDeclaration();  // 解析变量声明
    }
    else if (currentToken.type == TOKEN_IDENTIFIER) {
        assignment();           // 解析赋值语句
    }

    else if (currentToken.type == TOKEN_IF) {
        ifStatement();          // 解析条件语句
    }

    else if (currentToken.type == TOKEN_WHILE) {
        whileStatement();       // 解析循环语句
    }


    else {
        THROW_ERROR("Unexpected token: " + currentToken.value);
    }
}

// 解析变量声明
void Parser::variableDeclaration() {
    match(TOKEN_VAR);           
    match(TOKEN_IDENTIFIER);    
    match(TOKEN_ASSIGN);       
    expression();               // 解析表达式
}

// 解析赋值语句
void Parser::assignment() {
    match(TOKEN_IDENTIFIER);    
    match(TOKEN_ASSIGN);        
    expression();              
}

// 解析条件语句
void Parser::ifStatement() {
    match(TOKEN_IF);            
    condition();                // 解析条件
    match(TOKEN_BEGIN);          
    statementList();            // 解析语句列表
    match(TOKEN_END);
    if (currentToken.type == TOKEN_ELSE) {
        match(TOKEN_ELSE);
        match(TOKEN_BEGIN);
        statementList();
        match(TOKEN_END);          
    }
}

// 解析循环语句
void Parser::whileStatement() {
    match(TOKEN_WHILE);        
    condition();                // 解析条件
    match(TOKEN_BEGIN);       
    statementList();            // 解析语句列表
    match(TOKEN_END);          
}

// 解析条件
void Parser::condition() {
    if (currentToken.type == TOKEN_NOT) {
        match(currentToken.type); 
        condition();              // 解析条件
    }
    expression();  // 解析表达式
    if (currentToken.type == TOKEN_EQUAL || currentToken.type == TOKEN_LESS ||
            currentToken.type == TOKEN_GREATER) {
        match(currentToken.type);  
        expression();             
    }
    // 处理逻辑运算符
    while (currentToken.type == TOKEN_AND || currentToken.type == TOKEN_OR) {
        match(currentToken.type);  
        condition();              
    }
}

// 解析表达式
void Parser::expression() {
    term();                     // 解析项
    while (currentToken.type == TOKEN_PLUS || currentToken.type == TOKEN_MINUS) {
        match(currentToken.type);  // +-
        term();                     // 解析项
    }
}

// 解析项
void Parser::term() {
    factor();                   // 解析因子
    while (currentToken.type == TOKEN_MULTIPLY || currentToken.type == TOKEN_DIVIDE) {
        match(currentToken.type);  // */
        factor();                   // 解析因子
    }
}

// 解析因子
void Parser::factor() {
    if (currentToken.type == TOKEN_IDENTIFIER || currentToken.type == TOKEN_NUMBER) {
        match(currentToken.type);  // 匹配标识符或数字
    }
    else if (currentToken.type == TOKEN_LPAREN) {
        match(TOKEN_LPAREN);       // 匹配左括号
        condition();              // 解析表达式
    }
    else if (currentToken.type == TOKEN_RPAREN) {
        match(TOKEN_RPAREN);       // 匹配右括号
    }
    else {
        THROW_ERROR("Unexpected token in factor: " + currentToken.value);
    }
}

// 匹配 Token
void Parser::match(TokenType expected) {
    if (currentToken.type == expected) {
        currentToken = lexer.getNextToken();  // 获取下一个 Token
    }
    else {
        THROW_ERROR("Expected token: " + tokenTypeToString(expected) + ", but got: " + currentToken.value);
    }
}

// Token 类型转换为字符串
string Parser::tokenTypeToString(TokenType type) {
    switch (type) {
    case TOKEN_PROGRAM: return "program";
    case TOKEN_BEGIN: return "begin";
    case TOKEN_END: return "end";
    case TOKEN_IF: return "if";
    case TOKEN_FI: return "fi";
    case TOKEN_THEN: return "then";
    case TOKEN_ELSE: return "else";
    case TOKEN_WHILE: return "while";
    case TOKEN_DO: return "do";
    case TOKEN_DONE: return "done";
    case TOKEN_VAR: return "var";
    case TOKEN_PRINT: return "print";
    case TOKEN_IDENTIFIER: return "identifier";
    case TOKEN_NUMBER: return "number";
    case TOKEN_ASSIGN: return ":=";
    case TOKEN_PLUS: return "+";
    case TOKEN_MINUS: return "-";
    case TOKEN_MULTIPLY: return "*";
    case TOKEN_DIVIDE: return "/";
    case TOKEN_EQUAL: return "=";
    case TOKEN_LESS: return "<";
    case TOKEN_GREATER: return ">";
    case TOKEN_LPAREN: return "(";
    case TOKEN_RPAREN: return ")";
    case TOKEN_SEMICOLON: return ";";
    case TOKEN_COMMA: return ",";
    case TOKEN_DOT: return ".";
    case TOKEN_EOF: return "EOF";
    case TOKEN_AND: return "and";  
    case TOKEN_OR: return "or";    
    case TOKEN_NOT: return "not";  
    default: return "unknown";
    }
}