using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManager
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }

        public List<Class> Classes { get; set; } // 导航属性
    }

    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int SchoolId { get; set; } // 外键
        public School School { get; set; } // 导航属性
        public List<Student> Students { get; set; } // 导航属性
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; } // Foreign Key

        public Class Class { get; set; } // 导航属性
    }

    public class Log
    {
        public int LogId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
