#include <iostream>
#include <string>
#include <vector>
#include <stdio.h>
#include <iomanip>
#include <fstream>
#include <sstream>
using namespace std;
const int NUM_KEYWORD = 50;
const string KeyWord[NUM_KEYWORD] ={
	"main",
	"return",
	"void",
	"using",
	"namespace",
	"cout",
	"cin",
	"if",
	"else",
	"for",
	"while",
	"do",
	"switch",
	"case",
	"default",
	"break",
	"continue",
	"goto",
	"true",
	"false",
	"vector",//--------------------------
	"int",
	"float",
	"string",
	"char",
	"bool",
	"idt",
	"null",//--------------------------
	"INT",
	"FLOAT",
	"STRING",
	"CHAR",
	"BOOL",
	"IDT",
	"NULL"
};

int tokenKind;  //单词种别码
string  currentToken;       //单词自身字符串
int sum;  //INT整型里的码内值
int i = 0; //整个程序的长度
int isStringClosed = 1;     //后面判断STRING字符 


void showAll();     //输入部分单词符号所对应的种别码（可自行扩展）
bool IsLetter(char ch);   //判断是否为字母
bool IsDigit(char ch);   //判断是否为数字
void scan(string s);     //扫描


int main() {
	showAll();
	string input = "";
	string line;
	ifstream inputFile("input.txt"); // 创建 ifstream 对象来读取文件
	if (!inputFile.is_open()) {
		cerr << "Error opening input file!" << endl;
		return 1; // 如果文件打开失败，输出错误并退出程序
	}
	cout << "\n正在从文件读取内容..." << endl;

	// 读取整个文件内容，包括多行
	while (getline(inputFile, line)) {
		input += line + "\n";
	}

	inputFile.close(); // 关闭文件

	// 确保输入以 '$' 结束
	if (input.back() != '$') {
		input += '$';
	}

	cout << "\nLine:行号（tokenKind，currentToken|sum）：" << endl;

	// 开始扫描

	scan(input);

	return 0;
}


void showAll() {
	cout << "---------- 符号表---------------------- " << endl;

	cout << left << setw(10) << "符号" << setw(10) << "种别码" << setw(10) << "符号" << setw(10) << "种别码" << endl;

	cout << setw(10) << '$' << setw(10) << "000" << setw(10) << "=" << setw(10) << "200" << endl;
	cout << setw(10) << "main" << setw(10) << "001" << setw(10) << "==" << setw(10) << "201" << endl;
	cout << setw(10) << "return" << setw(10) << "002" << setw(10) << "+" << setw(10) << "202" << endl;
	cout << setw(10) << "void" << setw(10) << "003" << setw(10) << "+=" << setw(10) << "203" << endl;
	cout << setw(10) << "using" << setw(10) << "004" << setw(10) << "-" << setw(10) << "204" << endl;
	cout << setw(10) << "namespace" << setw(10) << "005" << setw(10) << "-=" << setw(10) << "205" << endl;
	cout << setw(10) << "cout" << setw(10) << "006" << setw(10) << "*pointer" << setw(10) << "1206" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "*num" << setw(10) << "2206" << endl;
	cout << setw(10) << "cin" << setw(10) << "007" << setw(10) << "*=" << setw(10) << "207" << endl;
	cout << setw(10) << "if" << setw(10) << "008" << setw(10) << "/" << setw(10) << "208" << endl;
	cout << setw(10) << "else" << setw(10) << "009" << setw(10) << "/=" << setw(10) << "209" << endl;
	cout << setw(10) << "for" << setw(10) << "010" << setw(10) << "(" << setw(10) << "210" << endl;
	cout << setw(10) << "while" << setw(10) << "011" << setw(10) << ")" << setw(10) << "211" << endl;
	cout << setw(10) << "do" << setw(10) << "012" << setw(10) << "[" << setw(10) << "212" << endl;
	cout << setw(10) << "switch" << setw(10) << "013" << setw(10) << "]" << setw(10) << "213" << endl;
	cout << setw(10) << "case" << setw(10) << "014" << setw(10) << "{" << setw(10) << "214" << endl;
	cout << setw(10) << "default" << setw(10) << "015" << setw(10) << "}" << setw(10) << "215" << endl;
	cout << setw(10) << "break" << setw(10) << "016" << setw(10) << "," << setw(10) << "216" << endl;
	cout << setw(10) << "continue" << setw(10) << "017" << setw(10) << ":" << setw(10) << "217" << endl;
	cout << setw(10) << "goto" << setw(10) << "018" << setw(10) << ";" << setw(10) << "218" << endl;
	cout << setw(10) << "true" << setw(10) << "019" << setw(10) << "." << setw(10) << "219" << endl;
	cout << setw(10) << "false" << setw(10) << "020" << setw(10) << ">" << setw(10) << "220" << endl;
	cout << setw(10) << "vector" << setw(10) << "021" << setw(10) << ">=" << setw(10) << "221" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "<" << setw(10) << "222" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "<=" << setw(10) << "223" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "!=" << setw(10) << "224" << endl; 
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "<<" << setw(10) << "225" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "<<" << setw(10) << "226" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "\\" << setw(10) << "227" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "&" << setw(10) << "228" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "&&" << setw(10) << "229" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "|" << setw(10) << "230" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "||" << setw(10) << "231" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "^" << setw(10) << "232" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "!" << setw(10) << "233" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "::" << setw(10) << "234" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "#" << setw(10) << "235" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "++" << setw(10) << "236" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "--" << setw(10) << "237" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "?" << setw(10) << "238" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "%" << setw(10) << "239" << endl;
	cout << setw(10) << "" << setw(10) << "" << setw(10) << "%=" << setw(10) << "240" << endl;


	cout << setw(10) << "int" << setw(10) << "022" << setw(10) << "INT" << setw(10) << "300" << endl;
	cout << setw(10) << "float" << setw(10) << "023" << setw(10) << "FLOAT" << setw(10) << "301" << endl;
	cout << setw(10) << "string" << setw(10) << "024" << setw(10) << "STRING" << setw(10) << "302" << endl;
	cout << setw(10) << "char" << setw(10) << "025" << setw(10) << "CHAR" << setw(10) << "303" << endl;
	cout << setw(10) << "bool" << setw(10) << "026" << setw(10) << "BOOL" << setw(10) << "304" << endl;
	cout << setw(10) << "idt" << setw(10) << "027" << setw(10) << "IDT" << setw(10) << "305" << endl;
	cout << setw(10) << "null" << setw(10) << "028" << setw(10) << "NULL" << setw(10) << "306" << endl;

	cout << "---------------------------------------" << endl;
}

bool IsLetter(char ch)  //判断是否为字母
{
	if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
		return true;
	else
		return false;
}

bool IsDigit(char ch)  //判断是否为数字
{
	if (ch >= '0' && ch <= '9')
		return true;
	else
		return false;
}


void scan(string s)    //扫描
{
	i = 0; // 重置索引
	int lineNumber = 1; // 行号从1开始
	while (i < s.length()) {
		if (s[i] == '\n') {
			lineNumber++; // 换行符，行号增加
			i++;
		}
		else if (s[i] == ' ' || s[i] == '\r' || s[i] == '\t') {
			// 跳过空格、回车符和制表符
			i++;
		}
		else if (s[i] == '$') {
			// 结束符+
			tokenKind = 0;
			cout << "\n[End]" << endl;
			break;
		}
		else
		{
			currentToken = "";   //清空当前字符串

			//1. 判断为符号
			 if(!IsDigit(s[i]) && !IsLetter(s[i]) && s[i] != '_') {
				currentToken = ""; //清空当前字符串
				bool isOperatorDefined = false;
				switch (s[i]) {
				case'=':
					tokenKind = 200;
					i++;
					currentToken = "=";
					if (s[i] == '=') {
						tokenKind = 201;
						i++;
						currentToken = "==";
					}
					isOperatorDefined = true;
					break;

				case'+':
					tokenKind = 202;
					i++;
					currentToken = "+";
					if (s[i] == '=') {
						tokenKind = 203;
						i++;
						currentToken = "+=";
					}
					if (s[i] == '+') {
						tokenKind = 236;
						i++;
						currentToken = "++";
					}
					isOperatorDefined = true;
					break;

				case'-':
					tokenKind = 204;
					i++;
					currentToken = "-";
					if (s[i] == '=') {
						tokenKind = 205;
						i++;
						currentToken = "-=";
					}
					if (s[i] == '-') {
						tokenKind = 237;
						i++;
						currentToken = "--";
					}
					isOperatorDefined = true;
					break;

				case '*':
					if (s[i + 1] == '=') {
						tokenKind = 207;
						i += 2;
						currentToken = "*=";
					}
					else if (IsLetter(s[i + 1]) ) {
						tokenKind = 1206; // 指针解引用
						i++;
						currentToken = "*";
					}
					else {
						tokenKind = 2206;
						i++;
						currentToken = "*";
					}
					isOperatorDefined = true;
					break;

				case '/':
					if (s[i + 1] == '/') {
						// 单行注释
						tokenKind = -2; // 忽略注释
						i += 2;
						while (i < s.length() && s[i] != '\n') {
							i++;
						}
					}
					else if (s[i + 1] == '*') {
						// 多行注释
						tokenKind = -2; // 忽略注释
						i += 2;
						while (i < s.length() && (s[i] != '*' || s[i + 1] != '/')) {
							if (s[i] == '\n') {
								lineNumber++; // 换行符，行号增加
								currentToken += '\n';
							}
							i++;
						}
						if (i < s.length()) {
							i += 2;
						}
					}
					else {
						tokenKind = 208;
						i++;
						currentToken = "/";
						if (s[i] == '=') {
							tokenKind = 209;
							i++;
							currentToken = "/=";
						}
					}
					isOperatorDefined = true;
					break;

				case'(':
					tokenKind = 210;
					i++;
					currentToken = "(";
					isOperatorDefined = true;
					break;

				case')':
					tokenKind = 211;
					i++;
					currentToken = ")";
					isOperatorDefined = true;
					break;

				case'[':
					tokenKind = 212;
					i++;
					currentToken = "[";
					isOperatorDefined = true;
					break;

				case']':
					tokenKind = 213;
					i++;
					currentToken = "]";
					isOperatorDefined = true;
					break;

				case'{':
					tokenKind = 214;
					i++;
					currentToken = "{";
					isOperatorDefined = true;
					break;

				case'}':
					tokenKind = 215;
					i++;
					currentToken = "}";
					isOperatorDefined = true;
					break;

				case',':
					tokenKind = 216;
					i++;
					currentToken = ",";
					isOperatorDefined = true;
					break;

				case':':
					tokenKind = 217;
					i++;
					if (s[i] == ':')
					{
						tokenKind = 234;
						i++;
						currentToken = "::";
					}
					isOperatorDefined = true;
					break;

				case';':
					tokenKind = 218;
					i++;
					currentToken = ";";
					isOperatorDefined = true;
					break;

				case'.':
					tokenKind = 219;
					i++;
					currentToken = ".";
					isOperatorDefined = true;
					break;

				case'\\':
					tokenKind = 227;
					i++;
					currentToken = "\\";
					isOperatorDefined = true;
					break;

				case'>':
					tokenKind = 220;
					i++;
					currentToken = ">";
					if (s[i] == '=')
					{
						tokenKind = 221;
						i++;
						currentToken = ">=";
					}
					if (s[i] == '>')
					{
						tokenKind = 226;
						i++;
						currentToken = ">>";
					}
					isOperatorDefined = true;
					break;

				case'<':
					tokenKind = 222;
					i++;
					currentToken = "<";
					if (s[i] == '=')
					{
						tokenKind = 223;
						i++;
						currentToken = "<=";
					}
					if (s[i] == '<')
					{
						tokenKind = 225;
						i++;
						currentToken = "<<";
					}
					isOperatorDefined = true;
					break;


				case'&':
					tokenKind = 228;
					i++;
					if (s[i] == '&')
					{
						tokenKind = 229;
						i++;
						currentToken = "&&";
					}
					isOperatorDefined = true;
					break;

				case'|':
					tokenKind = 230;
					i++;
					if (s[i] == '|')
					{
						tokenKind = 231;
						i++;
						currentToken = "||";
					}
					isOperatorDefined = true;
					break;

				case'^':
					tokenKind = 232;
					i++;
					currentToken = "^";
					isOperatorDefined = true;
					break;

				case'!':
					tokenKind = 233;
					i++;
					if (s[i] == '=')
					{
						tokenKind = 224;
						i++;
						currentToken = "!=";
					}
					isOperatorDefined = true;
					break;

				case'#':
					tokenKind = 235;
					i++;
					currentToken = "#";
					isOperatorDefined = true;
					break;

				case'?':
					tokenKind = 238;
					i++;
					currentToken = "?";
					isOperatorDefined = true;
					break;

				case'%':
					tokenKind = 239;
					i++;
					currentToken = "%";
					if (s[i] == '=')
					{
						tokenKind = 240;
						i++;
						currentToken = "%=";
					}
					isOperatorDefined = true;
					break;

				case '"':
					tokenKind = 302; // STRING种别码为302
					currentToken += s[i];
					i++;
					while (s[i] != '"' && s[i] != '$') {
						//来确保在遇到字符串结束符或输入结束符 $ 时停止读取
						//这样可以防止读取超出输入字符串的范围。
						if (s[i] == '\\') { // 处理转义字符
							i++;
							switch (s[i]) {
							case 'n': currentToken += '\n'; break;
							case 't': currentToken += '\t'; break;
							case 'r': currentToken += '\r'; break;
							case '"': currentToken += '"'; break;
							case '\\': currentToken += '\\'; break;
							default: currentToken += s[i];
							}
						}
						else {
							currentToken += s[i];
						}
						i++;
					}
					if (s[i] == '"') {
						currentToken += s[i];
						i++;
					}
					else {
						tokenKind = -1; // 错误处理，字符串未正确闭合
						cout << "[Error] STRING not closed properly at line " << lineNumber << endl;
					}
					isOperatorDefined = true;
					break;


					// 处理 CHAR 类型
				case '\'':
					tokenKind = 303; // CHAR种别码为303
					currentToken += s[i];
					i++;
					if (s[i] == '\\') { // 处理转义字符
						i++;
						switch (s[i]) {
						case 'n': currentToken += '\n'; break;
						case 't': currentToken += '\t'; break;
						case 'r': currentToken += '\r'; break;
						default: currentToken += s[i];
						}
					}
					else {
						currentToken += s[i];
					}
					i++;
					if (s[i] == '\'') {
						currentToken += s[i];
						i++;

					}
					else {
						tokenKind = -1; // 错误处理，字符未正确闭合
						cout << "[Error] CHAR not closed properly at line " << lineNumber << endl;
					}
					isOperatorDefined = true;
					break;


				case '$': //结束
					tokenKind = 0;
					cout << "\n[End]" << endl;
					isOperatorDefined = true;
					break;

				default:
					if (s[i] == '\n') {
						lineNumber++;
						i++;
					}
					else {
						tokenKind = -1;
						cout << "[Error] Undefined operator '" << s[i] << "' at line " << lineNumber << endl;
						i++;
						isOperatorDefined = false;
					}
					break;
				}
			}

			// 2. 判断字符是否为INT 与 FLOAT
			else if (s[i] == '+' || s[i] == '-') { // 处理正负号
				currentToken += s[i];
				i++;
				if (IsDigit(s[i])) {
					bool isFloat = false;
					int dotCount = 0;
					while (IsDigit(s[i]) || s[i] == '.' || s[i] == 'e' || s[i] == 'E') {
						if (s[i] == '.') {
							if ( ++dotCount > 1) { // 如果有多个点，则报错
								tokenKind = -1;
								cout << "[Error] Invalid number format at line " << lineNumber << endl;
								return;
							}
							isFloat = true;
						}
						else if (s[i] == 'e' || s[i] == 'E') {
							if (!IsDigit(s[i + 1]) && s[i + 1] != '+' && s[i + 1] != '-') { // 指数部分必须有数字
								tokenKind = -1;
								cout << "[Error] Invalid number format at line " << lineNumber << endl;
								return;
							}
							isFloat = true;
						}
						currentToken += s[i];
						i++;
					}
					tokenKind = isFloat ? 301 : 300; // 根据是否有小数点判断是INT还是FLOAT
				}
				else {
					tokenKind = -1; // 如果正负号后不是数字，则报错
					cout << "[Error] Invalid number format at line " << lineNumber << endl;
					return;
				}
			}
			else if (IsDigit(s[i])) {
				bool isFloat = false;
				int dotCount = 0;
				currentToken += s[i];
				i++;
				while (IsDigit(s[i]) || s[i] == '.' || s[i] == 'e' || s[i] == 'E') {
					if (s[i] == '.') {
						if ( ++dotCount > 1) { // 如果有多个点，则报错
							tokenKind = -1;
							cout << "[Error] Invalid number format at line " << lineNumber << endl;
							return;
						}
						isFloat = true;
					}
					else if (s[i] == 'e' || s[i] == 'E') {
						if (!IsDigit(s[i + 1]) && s[i + 1] != '+' && s[i + 1] != '-') { // 指数部分必须有数字
							tokenKind = -1;
							cout << "[Error] Invalid number format at line " << lineNumber << endl;
							return;
						}
						isFloat = true;
					}
					currentToken += s[i];
					i++;
				}
				tokenKind = isFloat ? 301 : 300; // 根据是否有小数点判断是INT还是FLOAT

				// 检查是否跟随了非法字符（如字母或下划线）
				if (IsLetter(s[i]) || s[i] == '_') {
					tokenKind = -1;
					cout << "[Error] Invalid number format at line " << lineNumber << endl;
					return;
				}
			}

			// 3.字符为标识符，表现为字母开头衔接任意个数字或字母
			else if (IsLetter(s[i]) || s[i] == '_') {
				currentToken = ""; //清空当前字符串
				currentToken += s[i]; // 加入第一个字符
				i++;
				while (IsLetter(s[i]) || IsDigit(s[i]) || s[i] == '_') {
					currentToken += s[i];   //加入currentToken字符串
					i++;
				}
				tokenKind = 305;  // 如果是标识符idt，种别码为305

				// 如果是关键字，则用for循环将currentToken与keyword比较找对应的种别码
				for (int j = 0; j < NUM_KEYWORD; j++) {
					if (currentToken == KeyWord[j]) { //如果相等
						tokenKind = j + 1;   //种别码从1开始所以要加1
						break;
					}
				}
			}

			// 输出当前token的种别码和内容
			if (tokenKind != -1 && tokenKind != -2) {
				cout << "Line " << lineNumber << ": ( " << tokenKind << "," << currentToken << " )" << endl;
			}

			if (tokenKind == 0) {
				break;
			}
		}
	END: {}

	}
}