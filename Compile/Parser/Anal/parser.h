#ifndef PARSER_H
#define PARSER_H

#include "lexer.h"
#include "token.h"

// �﷨��������
class Parser {
public:
    Parser(Lexer& lexer);  // ���캯�������մʷ�������
    void parse();          // ��ʼ�﷨����

private:
    Lexer& lexer;          // �ʷ�����������
    Token currentToken;    // ��ǰ Token

    // �﷨�����������
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
    void match(TokenType expected);  // ƥ�� Token
    std::string tokenTypeToString(TokenType type);  // Token ����ת��Ϊ�ַ���
};

#endif