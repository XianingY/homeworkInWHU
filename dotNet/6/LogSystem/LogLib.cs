using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogSystem
{
    // 日志接口
    public interface ILogger
    {
        void Log(string message);
    }

    // 控制台日志记录器
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Console: " + message);
        }
    }

    // 文件日志记录器
    public class FileLogger : ILogger
    {
        private string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }


    // 数据库日志记录器
    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            
            Console.WriteLine("Database: " + message);
        }
    }
}
