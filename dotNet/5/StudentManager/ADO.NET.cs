using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Windows.Forms;


namespace StudentManager
{
	public class DatabaseHelper
	{
		private string connectionString = "Data Source=school.db;Version=3;";

		public void ExecuteNonQuery(string query)
		{
			using (var connection = new SQLiteConnection(connectionString))
			{
				connection.Open();
				using (var command = new SQLiteCommand(query, connection))
				{
					command.ExecuteNonQuery();
				}
			}
		}

		public SQLiteDataReader ExecuteReader(string query)
		{
			var connection = new SQLiteConnection(connectionString);
			connection.Open();
			var command = new SQLiteCommand(query, connection);
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}


        #region School
        public void AddSchool(School school)
		{
			string query = $"INSERT INTO Schools (SchoolName) VALUES ('{school.SchoolName}')";
			ExecuteNonQuery(query);
			LogAction($"Added school: {school.SchoolName}");
		}

		public List<School> GetAllSchools()
		{
			var schools = new List<School>();
			string query = "SELECT * FROM Schools";
			using (var reader = ExecuteReader(query))
			{
				while (reader.Read())
				{
					schools.Add(new School
					{
						SchoolId = reader.GetInt32(0),
						SchoolName = reader.GetString(1)
					});
				}
			}
			return schools;
		}

        public void UpdateSchool(School school)
        {
            string query = $"UPDATE Schools SET SchoolName = '{school.SchoolName}' WHERE SchoolId = {school.SchoolId}";
            ExecuteNonQuery(query);
            LogAction($"Updated school: {school.SchoolName}");
        }

        public void DeleteSchool(int schoolId)
        {
            string query = $"DELETE FROM Schools WHERE SchoolId = {schoolId}";
            ExecuteNonQuery(query);
            LogAction($"Deleted school with ID: {schoolId}");
        }
        #endregion

        #region Class
        public void AddClass(Class @class)
        {
            string query = $"INSERT INTO Classes (ClassName, SchoolId) VALUES ('{@class.ClassName}', {@class.SchoolId})";
            ExecuteNonQuery(query);
            LogAction($"Added class: {@class.ClassName}");
        }

        public List<Class> GetAllClasses()
        {
            var classes = new List<Class>();
            string query = "SELECT * FROM Classes";
            using (var reader = ExecuteReader(query))
            {
                while (reader.Read())
                {
                    classes.Add(new Class
                    {
                        ClassId = reader.GetInt32(0),
                        ClassName = reader.GetString(1),
                        SchoolId = reader.GetInt32(2)
                    });
                }
            }
            return classes;
        }

        public void UpdateClass(Class @class)
        {
            string query = $"UPDATE Classes SET ClassName = '{@class.ClassName}', SchoolId = {@class.SchoolId} WHERE ClassId = {@class.ClassId}";
            ExecuteNonQuery(query);
            LogAction($"Updated class: {@class.ClassName}");
        }

        public void DeleteClass(int classId)
        {
            string query = $"DELETE FROM Classes WHERE ClassId = {classId}";
            ExecuteNonQuery(query);
            LogAction($"Deleted class with ID: {classId}");
        }
        #endregion

        #region Student
        public void AddStudent(Student student)
        {
            string query = $"INSERT INTO Students (StudentName, ClassId) VALUES ('{student.StudentName}', {student.ClassId})";
            ExecuteNonQuery(query);
            LogAction($"Added student: {student.StudentName}");
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            string query = "SELECT * FROM Students";
            using (var reader = ExecuteReader(query))
            {
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        StudentId = reader.GetInt32(0),
                        StudentName = reader.GetString(1),
                        ClassId = reader.GetInt32(2)
                    });
                }
            }
            return students;
        }

        public void UpdateStudent(Student student)
        {
            string query = $"UPDATE Students SET StudentName = '{student.StudentName}', ClassId = {student.ClassId} WHERE StudentId = {student.StudentId}";
            ExecuteNonQuery(query);
            LogAction($"Updated student: {student.StudentName}");
        }

        public void DeleteStudent(int studentId)
        {
            string query = $"DELETE FROM Students WHERE StudentId = {studentId}";
            ExecuteNonQuery(query);
            LogAction($"Deleted student with ID: {studentId}");
        }
        #endregion

        #region Log
        public DataTable GetLogData()
		{
			var dataTable = new DataTable();
			string connectionString = "Data Source=school.db;Version=3;"; 

			try
			{
				using (var connection = new SQLiteConnection(connectionString))
				{
					connection.Open();

					// 使用参数化查询，避免SQL注入
					var command = new SQLiteCommand("SELECT * FROM Logs", connection);

					using (var reader = command.ExecuteReader())
					{
						// 加载数据到DataTable
						dataTable.Load(reader);
					}
				}
			}
			catch (SQLiteException ex)
			{
				// 记录异常信息
				Console.WriteLine("SQLite error: " + ex.Message);
			}
			catch (Exception ex)
			{
				// 记录其他异常信息
				Console.WriteLine("Error getting log data: " + ex.Message);
			}

			return dataTable;
		}

		public void LogAction(string action)
		{
			string query = $"INSERT INTO Logs (Action) VALUES ('{action}')";
			ExecuteNonQuery(query);
		}
        #endregion

        #region Clear and Reset
        public void ClearDatabase()
		{
			var connection = new SQLiteConnection(connectionString);
			connection.Open();
			var command = new SQLiteCommand("DELETE FROM Schools", connection);
			command.ExecuteNonQuery();
			
		}

		public void ResetSchoolId()
		{
			using (var connection = new SQLiteConnection(connectionString)) { 

				connection.Open();
				var command = new SQLiteCommand("UPDATE Schools SET SchoolId = 0", connection);
				command.ExecuteNonQuery();
			}
		}

		public void ResetSchoolIdIdentity()
		{
			using (var connection = new SQLiteConnection(connectionString))
			{

				connection.Open();

				// 首先删除所有记录
				var deleteCommand = new SQLiteCommand("DELETE FROM Schools", connection);
				deleteCommand.ExecuteNonQuery();

				// 然后重置自增计数
				var resetCommand = new SQLiteCommand("DELETE FROM sqlite_sequence WHERE name='Schools'", connection);
				resetCommand.ExecuteNonQuery();
			}
			
		}
#endregion
    }
}
