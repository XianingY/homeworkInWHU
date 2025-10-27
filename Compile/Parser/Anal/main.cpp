#include <iostream>
#include <fstream>
#include "lexer.h"
#include "parser.h"

using namespace std;

int main() {
    // ��ȡ�����ļ�
    fstream file;
    string input = "";
    file.open("input.txt");
    string line;
    while (getline(file, line)) {
        input += line;       // ����ǰ��׷�ӵ� input ��
        input += "\n";       // ��ѡ����ӻ��з�������ԭʼ�ļ��ĸ�ʽ
    }

    // �����ʷ����������﷨������
    Lexer lexer(input);
    Parser parser(lexer);
    parser.parse();  // ��ʼ�﷨����
    return 0;
}