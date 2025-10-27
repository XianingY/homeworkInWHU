using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            dbHelper.ClearDatabase();
            dbHelper.ResetSchoolId(); // 清零现有的 SchoolId
            dbHelper.ResetSchoolIdIdentity(); // 如果是自增的话，重置自增计数
        }


        #region School
        private void btnAddSchool_Click(object sender, EventArgs e)
        {
            
            var school = new School { SchoolName = txtSchoolName.Text };
            dbHelper.AddSchool(school);
            LoadSchools();
        }

        private void dataGridViewSchools_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var school = new School
                {
                    SchoolId = Convert.ToInt32(dataGridViewSchools.Rows[e.RowIndex].Cells["SchoolId"].Value),
                    SchoolName = dataGridViewSchools.Rows[e.RowIndex].Cells["SchoolName"].Value.ToString()
                };
                dbHelper.UpdateSchool(school);
                LoadSchools();
            }
        }

        private int GetSelectedSchoolId()
        {
            if (dataGridViewSchools.SelectedRows.Count > 0)
            {
                // 假设SchoolId列在DataGridView的第一列
                int schoolId = Convert.ToInt32(dataGridViewSchools.SelectedRows[0].Cells["SchoolId"].Value);
                return schoolId;
            }
            return -1; 
        }

        private void btnDeleteSchool_Click(object sender, EventArgs e)
        {
            if (dataGridViewSchools.SelectedRows.Count > 0)
            {
                int schoolId = Convert.ToInt32(dataGridViewSchools.SelectedRows[0].Cells["SchoolId"].Value);
                dbHelper.DeleteSchool(schoolId);
                LoadSchools();
            }
        }

        // 加载学校列表
        private void LoadSchools()
        {
            var schools = dbHelper.GetAllSchools();
            dataGridViewSchools.DataSource = schools;
        }
        #endregion

        #region Class
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            var @class = new Class { ClassName = txtClassName.Text, SchoolId = GetSelectedSchoolId() };
            dbHelper.AddClass(@class);
            LoadClasses();
        }

        private void dataGridViewClasses_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var @class = new Class
                {
                    ClassId = Convert.ToInt32(dataGridViewClasses.Rows[e.RowIndex].Cells["ClassId"].Value),
                    ClassName = dataGridViewClasses.Rows[e.RowIndex].Cells["ClassName"].Value.ToString(),
                    SchoolId = Convert.ToInt32(dataGridViewClasses.Rows[e.RowIndex].Cells["SchoolId"].Value)
                };
                dbHelper.UpdateClass(@class);
                LoadClasses();
            }
        }

        private int GetSelectedClassId()
        {
            if (dataGridViewClasses.SelectedRows.Count > 0)
            {
                // 假设ClassId列在DataGridView的第一列
                int classId = Convert.ToInt32(dataGridViewClasses.SelectedRows[0].Cells["ClassId"].Value);
                return classId;
            }
            return -1; 
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            if (dataGridViewClasses.SelectedRows.Count > 0)
            {
                int classId = Convert.ToInt32(dataGridViewClasses.SelectedRows[0].Cells["ClassId"].Value);
                dbHelper.DeleteClass(classId);
                LoadClasses();
            }
        }

        private void LoadClasses()
        {
            var classes = dbHelper.GetAllClasses();
            dataGridViewClasses.DataSource = classes;
        }
        #endregion

        #region Student
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var student = new Student { StudentName = txtStudentName.Text, ClassId = GetSelectedClassId() };
            dbHelper.AddStudent(student);
            LoadStudents();
        }

        private void dataGridViewStudents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var student = new Student
                {
                    StudentId = Convert.ToInt32(dataGridViewStudents.Rows[e.RowIndex].Cells["StudentId"].Value),
                    StudentName = dataGridViewStudents.Rows[e.RowIndex].Cells["StudentName"].Value.ToString(),
                    ClassId = Convert.ToInt32(dataGridViewStudents.Rows[e.RowIndex].Cells["ClassId"].Value)
                };
                dbHelper.UpdateStudent(student);
                LoadStudents();
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                int studentId = Convert.ToInt32(dataGridViewStudents.SelectedRows[0].Cells["StudentId"].Value);
                dbHelper.DeleteStudent(studentId);
                LoadStudents();
            }
        }

        private void LoadStudents()
        {
            var students = dbHelper.GetAllStudents();
            dataGridViewStudents.DataSource = students;
        }
        #endregion

        #region Log
        private void btnShowlog_Click(object sender, EventArgs e)
        {

            var logData = dbHelper.GetLogData(); // 从数据库获取数据
            dataGridViewLogs.DataSource = logData; // 将数据绑定到 DataGridView
        }
        #endregion
    }
}
