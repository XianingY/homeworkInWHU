using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace StudentManager
{
    public class DBInit
    {
        private string dbPath = "school.db"; // 数据库文件名

        public void CreateDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                CreateTables();
            }
        }

        private void CreateTables()
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();

                // 创建 Schools 表
                string createSchoolsTable = @"
            CREATE TABLE IF NOT EXISTS Schools (
                SchoolId INTEGER PRIMARY KEY AUTOINCREMENT,
                SchoolName TEXT NOT NULL
            );";

                // 创建 Classes 表
                string createClassesTable = @"
            CREATE TABLE IF NOT EXISTS Classes (
                ClassId INTEGER PRIMARY KEY AUTOINCREMENT,
                ClassName TEXT NOT NULL,
                SchoolId INTEGER,
                FOREIGN KEY (SchoolId) REFERENCES Schools(SchoolId)
            );";

                // 创建 Students 表
                string createStudentsTable = @"
            CREATE TABLE IF NOT EXISTS Students (
                StudentId INTEGER PRIMARY KEY AUTOINCREMENT,
                StudentName TEXT NOT NULL,
                ClassId INTEGER,
                FOREIGN KEY (ClassId) REFERENCES Classes(ClassId)
            );";

                // 创建 Logs 表
                string createLogsTable = @"
            CREATE TABLE IF NOT EXISTS Logs (
                LogId INTEGER PRIMARY KEY AUTOINCREMENT,
                Action TEXT NOT NULL,
                Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP
            );";

                // 执行创建表的命令
                using (var command = new SQLiteCommand(createSchoolsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createClassesTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createStudentsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createLogsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RecreateDatabase()
        {
            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }
            CreateDatabase();
        }
    }
}
