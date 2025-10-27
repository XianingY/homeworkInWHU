#ifndef PARSER_H
#define PARSER_H

#include "lexer.h"
#include "token.h"

// 语法分析器类
class Parser {
public:
    Parser(Lexer& lexer);  // 构造函数，接收词法分析器
    void parse();          // 开始语法分析

private:
    Lexer& lexer;          // 词法分析器引用
    Token currentToken;    // 当前 Token

    // 语法规则解析方法
    void program();
    void block();
    void statementList();
    void statement();
    void variableDeclaration();
    void assignment();
    void ifStatement();
    void whileStatement();
    void condition();
    void expression();
    void term();
    void factor();
    void match(TokenType expected);  // 匹配 Token
    std::string tokenTypeToString(TokenType type);  // Token 类型转换为字符串
};

#endif