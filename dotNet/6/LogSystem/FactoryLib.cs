using System;

namespace LogSystem
{
    // 日志工厂接口
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    // 控制台日志工厂
    public class ConsoleLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new ConsoleLogger();
        }
    }

    // 文件日志工厂
    public class FileLoggerFactory : ILoggerFactory
    {
        private readonly string _filePath;

        public FileLoggerFactory(string filePath)
        {
            _filePath = filePath;
        }

        public ILogger CreateLogger()
        {
            return new FileLogger(_filePath);
        }
    }

    // 数据库日志工厂
    public class DatabaseLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new DatabaseLogger();
        }
    }
}