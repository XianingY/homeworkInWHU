#include "lexer.h"
#include "error.h"
#include <unordered_map>
#include <stdexcept>

using namespace std;

// 构造函数，初始化输入字符串和当前位置
Lexer::Lexer(const string& input) : input(input), pos(0) {}

// 获取下一个 Token
Token Lexer::getNextToken() {
    while (pos < input.size() && isspace(input[pos])) pos++; // 跳过空白字符

    if (pos >= input.size()) return { TOKEN_EOF, "" };  // 如果到达输入末尾，返回 EOF

    char current = input[pos];

    // 根据当前字符判断 Token 类型
    if (isalpha(current)) {
        return readIdentifier();  // 读取标识符或关键字
    }
    else if (isdigit(current)) {
        return readNumber();      // 读取数字
    }
    else if (current == ':') {
        pos++;
        if (pos < input.size() && input[pos] == '=') {
            pos++;
            return { TOKEN_ASSIGN, ":=" };  // 读取赋值符号 ":="
        }
        THROW_ERROR("Unexpected character after ':'");
    }
    else if (current == '+' || current == '-' || current == '*' || current == '/') {
        return readOperator();  // 读取运算符
    }
    else if (current == '=' || current == '<' || current == '>') {
        return readRelationalOperator();  // 读取关系运算符
    }
    else if (current == '(' || current == ')' || current == ';' || current == '.' || current == ',') {
        return readPunctuation();  // 读取标点符号
    }
    else {
        THROW_ERROR("Unknown character: " + string(1, current));
    }
}

// 读取标识符或关键字
Token Lexer::readIdentifier() {
    size_t start = pos;
    while (pos < input.size() && isalnum(input[pos])) pos++;
    string value = input.substr(start, pos - start);

    static unordered_map<string, TokenType> keywords = {
        {"program", TOKEN_PROGRAM},
        {"begin", TOKEN_BEGIN},
        {"end", TOKEN_END},
        {"if", TOKEN_IF},
        {"fi", TOKEN_FI},
        {"then", TOKEN_THEN},
        {"else", TOKEN_ELSE},
        {"while", TOKEN_WHILE},
        {"do", TOKEN_DO},
        {"done", TOKEN_DONE},
        {"var", TOKEN_VAR},
        {"print", TOKEN_PRINT},
        {"and", TOKEN_AND},  
        {"or", TOKEN_OR},    
        {"not", TOKEN_NOT}   
    };

    if (keywords.find(value) != keywords.end()) {
        return { keywords[value], value };
    }
    else {
        return { TOKEN_IDENTIFIER, value };
    }
}
// 读取数字
Token Lexer::readNumber() {
    size_t start = pos;
    while (pos < input.size() && isdigit(input[pos])) pos++;  // 读取连续的数字
    string value = input.substr(start, pos - start);
    return { TOKEN_NUMBER, value };
}

// 读取运算符
Token Lexer::readOperator() {
    char op = input[pos++];
    switch (op) {
    case '+': return { TOKEN_PLUS, "+" };
    case '-': return { TOKEN_MINUS, "-" };
    case '*': return { TOKEN_MULTIPLY, "*" };
    case '/': return { TOKEN_DIVIDE, "/" };
    default: THROW_ERROR("Unknown operator: " + string(1, op));
    }
}

// 读取关系运算符
Token Lexer::readRelationalOperator() {
    char op = input[pos++];
    if (op == '=') return { TOKEN_EQUAL, "=" };
    if (op == '<') {
        if (pos < input.size() && input[pos] == '>') {
            pos++;
            return { TOKEN_EQUAL, "<>" };  // 不等于
        }
        else if (pos < input.size() && input[pos] == '=') {
            pos++;
            return { TOKEN_EQUAL, "<=" };  // 小于等于
        }
        else {
            return { TOKEN_LESS, "<" };    // 小于
        }
    }
    else if (op == '>') {
        if (pos < input.size() && input[pos] == '=') {
            pos++;
            return { TOKEN_EQUAL, ">=" };  // 大于等于
        }
        else {
            return { TOKEN_GREATER, ">" };  // 大于
        }
    }
    THROW_ERROR("Unknown relational operator: " + string(1, op));
}

// 读取标点符号
Token Lexer::readPunctuation() {
    char punct = input[pos++];
    switch (punct) {
    case '(': return { TOKEN_LPAREN, "(" };
    case ')': return { TOKEN_RPAREN, ")" };
    case ';': return { TOKEN_SEMICOLON, ";" };
    case '.': return { TOKEN_DOT, "." };
    case ',': return { TOKEN_COMMA, "," };
    default: THROW_ERROR("Unknown punctuation: " + string(1, punct));
    }
}