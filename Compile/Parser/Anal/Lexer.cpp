#include "lexer.h"
#include "error.h"
#include <unordered_map>
#include <stdexcept>

using namespace std;

// ���캯������ʼ�������ַ����͵�ǰλ��
Lexer::Lexer(const string& input) : input(input), pos(0) {}

// ��ȡ��һ�� Token
Token Lexer::getNextToken() {
    while (pos < input.size() && isspace(input[pos])) pos++; // �����հ��ַ�

    if (pos >= input.size()) return { TOKEN_EOF, "" };  // �����������ĩβ������ EOF

    char current = input[pos];

    // ���ݵ�ǰ�ַ��ж� Token ����
    if (isalpha(current)) {
        return readIdentifier();  // ��ȡ��ʶ����ؼ���
    }
    else if (isdigit(current)) {
        return readNumber();      // ��ȡ����
    }
    else if (current == ':') {
        pos++;
        if (pos < input.size() && input[pos] == '=') {
            pos++;
            return { TOKEN_ASSIGN, ":=" };  // ��ȡ��ֵ���� ":="
        }
        THROW_ERROR("Unexpected character after ':'");
    }
    else if (current == '+' || current == '-' || current == '*' || current == '/') {
        return readOperator();  // ��ȡ�����
    }
    else if (current == '=' || current == '<' || current == '>') {
        return readRelationalOperator();  // ��ȡ��ϵ�����
    }
    else if (current == '(' || current == ')' || current == ';' || current == '.' || current == ',') {
        return readPunctuation();  // ��ȡ������
    }
    else {
        THROW_ERROR("Unknown character: " + string(1, current));
    }
}

// ��ȡ��ʶ����ؼ���
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
// ��ȡ����
Token Lexer::readNumber() {
    size_t start = pos;
    while (pos < input.size() && isdigit(input[pos])) pos++;  // ��ȡ����������
    string value = input.substr(start, pos - start);
    return { TOKEN_NUMBER, value };
}

// ��ȡ�����
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

// ��ȡ��ϵ�����
Token Lexer::readRelationalOperator() {
    char op = input[pos++];
    if (op == '=') return { TOKEN_EQUAL, "=" };
    if (op == '<') {
        if (pos < input.size() && input[pos] == '>') {
            pos++;
            return { TOKEN_EQUAL, "<>" };  // ������
        }
        else if (pos < input.size() && input[pos] == '=') {
            pos++;
            return { TOKEN_EQUAL, "<=" };  // С�ڵ���
        }
        else {
            return { TOKEN_LESS, "<" };    // С��
        }
    }
    else if (op == '>') {
        if (pos < input.size() && input[pos] == '=') {
            pos++;
            return { TOKEN_EQUAL, ">=" };  // ���ڵ���
        }
        else {
            return { TOKEN_GREATER, ">" };  // ����
        }
    }
    THROW_ERROR("Unknown relational operator: " + string(1, op));
}

// ��ȡ������
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