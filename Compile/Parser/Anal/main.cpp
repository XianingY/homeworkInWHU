#include <iostream>
#include <fstream>
#include "lexer.h"
#include "parser.h"

using namespace std;

int main() {
    // 读取输入文件
    fstream file;
    string input = "";
    file.open("input.txt");
    string line;
    while (getline(file, line)) {
        input += line;       // 将当前行追加到 input 中
        input += "\n";       // 可选：添加换行符，保持原始文件的格式
    }

    // 创建词法分析器和语法分析器
    Lexer lexer(input);
    Parser parser(lexer);
    parser.parse();  // 开始语法分析
    return 0;
}