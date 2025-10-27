#pragma once
#ifndef ERROR_H
#define ERROR_H
using namespace std;

#include <stdexcept>

// 抛出运行时错误的宏
#define THROW_ERROR(msg) throw runtime_error(msg)

#endif