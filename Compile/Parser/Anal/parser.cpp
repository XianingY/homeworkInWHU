#include "parser.h"
#include "error.h"
#include <stdexcept>
#include <iostream>

using namespace std;

// ���캯������ʼ���ʷ��������͵�ǰ Token
Parser::Parser(Lexer& lexer) : lexer(lexer), currentToken(lexer.getNextToken()) {}

// ��ʼ�﷨����
void Parser::parse() {
    try {
        program();  // ��������
        cout << "The code is correct." << endl;
    }
    catch (const runtime_error& e) {
        cerr << "Grammar error: " << e.what() << endl;
    }
}

// ��������
void Parser::program() {
    match(TOKEN_PROGRAM); 
    match(TOKEN_IDENTIFIER); 
    match(TOKEN_SEMICOLON);   
    block();                 // ���������
    match(TOKEN_DOT);       
}

// ���������
void Parser::block() {
    match(TOKEN_BEGIN);      
    statementList();         // ��������б�
    match(TOKEN_END);       
}

// ��������б�
void Parser::statementList() {

    statement();             // ����һ�����
    if (currentToken.type == TOKEN_SEMICOLON) {
        match(TOKEN_SEMICOLON);  // ƥ��ֺ�

        if (currentToken.type == TOKEN_END )
            return;
        statement();             // ������һ�����
    }


    if (currentToken.type != TOKEN_END)
        statementList();         // �ݹ��������б�
}

// �������
void Parser::statement() {
    if (currentToken.type == TOKEN_VAR) {
        variableDeclaration();  // ������������
    }
    else if (currentToken.type == TOKEN_IDENTIFIER) {
        assignment();           // ������ֵ���
    }

    else if (currentToken.type == TOKEN_IF) {
        ifStatement();          // �����������
    }

    else if (currentToken.type == TOKEN_WHILE) {
        whileStatement();       // ����ѭ�����
    }


    else {
        THROW_ERROR("Unexpected token: " + currentToken.value);
    }
}

// ������������
void Parser::variableDeclaration() {
    match(TOKEN_VAR);           
    match(TOKEN_IDENTIFIER);    
    match(TOKEN_ASSIGN);       
    expression();               // �������ʽ
}

// ������ֵ���
void Parser::assignment() {
    match(TOKEN_IDENTIFIER);    
    match(TOKEN_ASSIGN);        
    expression();              
}

// �����������
void Parser::ifStatement() {
    match(TOKEN_IF);            
    condition();                // ��������
    match(TOKEN_BEGIN);          
    statementList();            // ��������б�
    match(TOKEN_END);
    if (currentToken.type == TOKEN_ELSE) {
        match(TOKEN_ELSE);
        match(TOKEN_BEGIN);
        statementList();
        match(TOKEN_END);          
    }
}

// ����ѭ�����
void Parser::whileStatement() {
    match(TOKEN_WHILE);        
    condition();                // ��������
    match(TOKEN_BEGIN);       
    statementList();            // ��������б�
    match(TOKEN_END);          
}

// ��������
void Parser::condition() {
    if (currentToken.type == TOKEN_NOT) {
        match(currentToken.type); 
        condition();              // ��������
    }
    expression();  // �������ʽ
    if (currentToken.type == TOKEN_EQUAL || currentToken.type == TOKEN_LESS ||
            currentToken.type == TOKEN_GREATER) {
        match(currentToken.type);  
        expression();             
    }
    // �����߼������
    while (currentToken.type == TOKEN_AND || currentToken.type == TOKEN_OR) {
        match(currentToken.type);  
        condition();              
    }
}

// �������ʽ
void Parser::expression() {
    term();                     // ������
    while (currentToken.type == TOKEN_PLUS || currentToken.type == TOKEN_MINUS) {
        match(currentToken.type);  // +-
        term();                     // ������
    }
}

// ������
void Parser::term() {
    factor();                   // ��������
    while (currentToken.type == TOKEN_MULTIPLY || currentToken.type == TOKEN_DIVIDE) {
        match(currentToken.type);  // */
        factor();                   // ��������
    }
}

// ��������
void Parser::factor() {
    if (currentToken.type == TOKEN_IDENTIFIER || currentToken.type == TOKEN_NUMBER) {
        match(currentToken.type);  // ƥ���ʶ��������
    }
    else if (currentToken.type == TOKEN_LPAREN) {
        match(TOKEN_LPAREN);       // ƥ��������
        condition();              // �������ʽ
    }
    else if (currentToken.type == TOKEN_RPAREN) {
        match(TOKEN_RPAREN);       // ƥ��������
    }
    else {
        THROW_ERROR("Unexpected token in factor: " + currentToken.value);
    }
}

// ƥ�� Token
void Parser::match(TokenType expected) {
    if (currentToken.type == expected) {
        currentToken = lexer.getNextToken();  // ��ȡ��һ�� Token
    }
    else {
        THROW_ERROR("Expected token: " + tokenTypeToString(expected) + ", but got: " + currentToken.value);
    }
}

// Token ����ת��Ϊ�ַ���
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