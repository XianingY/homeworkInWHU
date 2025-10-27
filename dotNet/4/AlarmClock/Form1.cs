using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class Form1 : Form
    {

        private AlarmClock alarmClock;
        private System.Windows.Forms.Timer timer;
        private bool isRunning = false;
        public Form1()
        {
            InitializeComponent();
            InitializeAlarmClock();
        }

        private void InitializeAlarmClock()
        {
            alarmClock = new AlarmClock(DateTime.Now.AddSeconds(5)); //五秒后响铃
            alarmClock.Tick += AlarmClock_Tick;
            alarmClock.Alarm += AlarmClock_Alarm;
        }

        private void AlarmClock_Tick(object sender, EventArgs e)
        {
            // 更新UI线程上的当前时间
            this.Invoke(new Action(() =>
            {
                currentTimeLabel.Text = alarmClock.GetCurrentTime().ToString("HH:mm:ss");
            }));
        }

        private void AlarmClock_Alarm(object sender, EventArgs e)
        {
            // 更新UI线程上的提示信息
            this.Invoke(new Action(() =>
            {
                MessageBox.Show("闹钟响了！");
            }));
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000; // 1秒
                timer.Tick += Timer_Tick;
                timer.Start();
                isRunning = true;
                startButton.Text = "正在运行";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            alarmClock.TickClock();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                timer.Stop();
                isRunning = false;
                startButton.Text = "开始";
            }
        }

    }
}
