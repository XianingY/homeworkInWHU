using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    public class AlarmClock
    {
        // Tick事件，当闹钟的秒针移动时触发
        public event EventHandler Tick;

        // Alarm事件，当闹钟到达设定时间时触发
        public event EventHandler Alarm;

        // 闹钟的当前时间
        private DateTime currentTime = DateTime.Now;

        // 闹钟的设定时间
        private DateTime alarmTime;

        // 构造函数，设置闹钟的初始时间
        public AlarmClock(DateTime alarmTime)
        {
            this.alarmTime = alarmTime;
        }

        // 闹钟的走时方法
        public void TickClock()
        {
            currentTime = DateTime.Now;

            // 触发Tick事件
            OnTick();

            // 检查是否到达设定时间
            if (currentTime >= alarmTime)
            {
                // 触发Alarm事件
                OnAlarm();
            }
        }

        // Tick事件的保护虚方法，供派生类或外部调用
        protected virtual void OnTick()
        {
            Tick?.Invoke(this, EventArgs.Empty);
        }

        // Alarm事件的保护虚方法，供派生类或外部调用
        protected virtual void OnAlarm()
        {
            Alarm?.Invoke(this, EventArgs.Empty);
        }

        // 设置闹钟时间
        public void SetAlarmTime(DateTime time)
        {
            alarmTime = time;
        }

        // 获取当前时间
        public DateTime GetCurrentTime()
        {
            return currentTime;
        }
    }
}
