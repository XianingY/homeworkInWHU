using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem
{
    // 日志装饰器基类
    public abstract class LoggerDecorator : ILogger
    {
        protected ILogger _logger;

        public LoggerDecorator(ILogger logger)
        {
            _logger = logger;
        }

        public abstract void Log(string message);
    }

    // 示例装饰器：添加时间戳
    public class TimestampLoggerDecorator : LoggerDecorator
    {
        public TimestampLoggerDecorator(ILogger logger) : base(logger)
        {
        }

        public override void Log(string message)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _logger.Log(timestamp + " - " + message);
        }
    }
}
