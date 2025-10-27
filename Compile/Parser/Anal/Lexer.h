#pragma once
#ifndef LEXER_H
#define LEXER_H

#include <string>
#include "token.h"  // ���� Token ��ض���

// �ʷ���������
class Lexer {
public:
    Lexer(const std::string& input);  // ���캯�������������ַ���
    Token getNextToken();             // ��ȡ��һ�� Token

private:
    std::string input;  // �����ַ���
    size_t pos;         // ��ǰ�ַ�λ��

    // ��ȡ��ͬ���͵� Token
    Token readIdentifier();           // ��ȡ��ʶ����ؼ���
    Token readNumber();               // ��ȡ����
    Token readOperator();             // ��ȡ�����
    Token readRelationalOperator();   // ��ȡ��ϵ�����
    Token readPunctuation();          // ��ȡ������
};

#endif