using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogSystem
{
    // 日志观察者接口
    public interface ILogObserver
    {
        void Update(string message);
    }

    public class LoggerSubject
    {
        private List<ILogObserver> _observers = new List<ILogObserver>();
        private static List<string> _logMessages = new List<string>(); // 存储日志消息

        public void Attach(ILogObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Detach(ILogObserver observer)
        {
            _observers.Remove(observer);
        }

        public void DetachAll()
        {
            _observers.Clear();
        }

        public void Notify(string message)
        {
            string timestampedMessage = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {message}";
            _logMessages.Add(timestampedMessage); // 将消息添加到日志存储
            foreach (var observer in _observers)
            {
                observer.Update(timestampedMessage);
            }
        }

        public static string GetAllLogs()
        {
            return string.Join("\n", _logMessages); // 返回所有日志消息，每个消息之间用换行分隔
        }

        public static void WriteLogsToFile(string filePath)
        {
            File.WriteAllText(filePath, GetAllLogs()); // 将所有日志写入文件
        }
    }

    // 具体的日志观察者
    public class LoggerObserver : ILogObserver
    {
        private readonly ILogger _logger;

        public LoggerObserver(ILogger logger)
        {
            _logger = logger;
        }

        public void Update(string message)
        {
            _logger.Log(message);
        }
    }
}