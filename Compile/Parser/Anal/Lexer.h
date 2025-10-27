#pragma once
#ifndef LEXER_H
#define LEXER_H

#include <string>
#include "token.h"  // 包含 Token 相关定义

// 词法分析器类
class Lexer {
public:
    Lexer(const std::string& input);  // 构造函数，接收输入字符串
    Token getNextToken();             // 获取下一个 Token

private:
    std::string input;  // 输入字符串
    size_t pos;         // 当前字符位置

    // 读取不同类型的 Token
    Token readIdentifier();           // 读取标识符或关键字
    Token readNumber();               // 读取数字
    Token readOperator();             // 读取运算符
    Token readRelationalOperator();   // 读取关系运算符
    Token readPunctuation();          // 读取标点符号
};

#endif