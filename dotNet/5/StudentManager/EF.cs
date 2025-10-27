using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManager
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=school.db");
        }

        public static class EfRepository
        {
            private static SchoolContext context = new SchoolContext();

            #region School
            public static void AddSchool(School school)
            {
                context.Schools.Add(school);
                context.SaveChanges();
                LogAction($"Added school: {school.SchoolName}");
            }

            public static List<School> GetAllSchools()
            {
                return context.Schools.ToList();
            }

            public static void UpdateSchool(School school)
            {
                context.Schools.Update(school);
                context.SaveChanges();
                LogAction($"Updated school: {school.SchoolName}");
            }
            public static void DeleteSchool(int schoolId)
            {
                var school = context.Schools.Find(schoolId);
                if (school != null)
                {
                    context.Schools.Remove(school);
                    context.SaveChanges();
                    LogAction($"Deleted school with ID: {schoolId}");
                }
            }
            #endregion

            #region Class
            public static void AddClass(Class @class)
            {
                context.Classes.Add(@class);
                context.SaveChanges();
                LogAction($"Added class: {@class.ClassName}");
            }

            public static List<Class> GetAllClasses()
            {
                return context.Classes.Include(c => c.School).ToList();
            }

            public static void UpdateClass(Class @class)
            {
                context.Classes.Update(@class);
                context.SaveChanges();
                LogAction($"Updated class: {@class.ClassName}");
            }

            public static void DeleteClass(int classId)
            {
                var @class = context.Classes.Find(classId);
                if (@class != null)
                {
                    context.Classes.Remove(@class);
                    context.SaveChanges();
                    LogAction($"Deleted class with ID: {classId}");
                }
            }
            #endregion

            #region Student
            public static void AddStudent(Student student)
            {
                context.Students.Add(student);
                context.SaveChanges();
                LogAction($"Added student: {student.StudentName}");
            }

            public static List<Student> GetAllStudents()
            {
                return context.Students.Include(s => s.Class).ToList();
            }

            public static void UpdateStudent(Student student)
            {
                context.Students.Update(student);
                context.SaveChanges();
                LogAction($"Updated student: {student.StudentName}");
            }

            public static void DeleteStudent(int studentId)
            {
                var student = context.Students.Find(studentId);
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                    LogAction($"Deleted student with ID: {studentId}");
                }
            }
            #endregion

            private static void LogAction(string action)
            {
                context.Logs.Add(new Log { Action = action, Timestamp = DateTime.Now });
                context.SaveChanges();
            }
        }
    }
}