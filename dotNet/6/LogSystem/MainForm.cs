using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogSystem;

namespace LogSystem
{
    public partial class MainForm : Form
    {
        private LoggerSubject _loggerSubject;
        private ILoggerFactory _loggerFactory;

        public MainForm()
        {
            InitializeComponent();
            _loggerSubject = new LoggerSubject();
            _loggerFactory = new ConsoleLoggerFactory(); // 默认为控制台日志
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            var message = messageTextBox.Text;
            _loggerSubject.Notify(message); // 使用 Notify 方法发送日志消息
            messageTextBox.Clear(); // 清空输入
        }

        private void showLogsButton_Click(object sender, EventArgs e)
        {
            logsTextBox.Text = LoggerSubject.GetAllLogs(); // 显示所有日志
        }

        private void saveLogsButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Log Files|*.log";
                saveFileDialog.Title = "Save Log File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoggerSubject.WriteLogsToFile(saveFileDialog.FileName); // 将日志写入文件
                    MessageBox.Show("Logs saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void addTimestampCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _loggerSubject.DetachAll(); // 移除所有现有的观察者

            ILogger logger = _loggerFactory.CreateLogger();
            if (addTimestampCheckBox.Checked)
            {
                logger = new TimestampLoggerDecorator(logger); // 添加时间戳装饰器
            }
            var observer = new LoggerObserver(logger);
            _loggerSubject.Attach(observer); // 添加观察者
        }
    }
}
