using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace StudentManager
{
    public partial class Form2 : Form
    {

        private SchoolContext _context;
        private BindingList<School> _schools;
        private BindingList<Class> _classes;
        private BindingList<Student> _students;
        public Form2()
        {
            InitializeComponent();
            _context = new SchoolContext();
            _schools = new BindingList<School>();
            _classes = new BindingList<Class>();
            _students = new BindingList<Student>();

            // 设置数据源
            dataGridViewSchools.DataSource = _schools;
            dataGridViewClasses.DataSource = _classes;
            dataGridViewStudents.DataSource = _students;

            // 加载数据
            LoadSchools();
            LoadClasses();
            LoadStudents();
        }
        private void LoadSchools()
        {
            _schools = new BindingList<School>(_context.Schools.ToList());
        }

        private void LoadClasses()
        {
            _classes = new BindingList<Class>(_context.Classes.Include(c => c.School).ToList());
        }

        private void LoadStudents()
        {
            _students = new BindingList<Student>(_context.Students.Include(s => s.Class).ToList());
        }



        private void btnUpdateSchool_Click(object sender, EventArgs e)
        {
            var selectedSchool = (School)dataGridViewSchools.SelectedRows[0].DataBoundItem;
            selectedSchool.SchoolName = txtSchoolName.Text;
            SchoolContext.EfRepository.UpdateSchool(selectedSchool);
            LoadSchools();
        }

        private void btnUpdateClass_Click(object sender, EventArgs e)
        {
            var selectedClass = (Class)dataGridViewClasses.SelectedRows[0].DataBoundItem;
            selectedClass.ClassName = txtClassName.Text;
            SchoolContext.EfRepository.UpdateClass(selectedClass);
            LoadClasses();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            var selectedStudent = (Student)dataGridViewStudents.SelectedRows[0].DataBoundItem;
            selectedStudent.StudentName = txtStudentName.Text;
            SchoolContext.EfRepository.UpdateStudent(selectedStudent);
            LoadStudents();
        }


        private int GetSelectedSchoolId()
        {
            if (dataGridViewSchools.SelectedRows.Count > 0)
            {
                return (int)dataGridViewSchools.SelectedRows[0].Cells["SchoolId"].Value;
            }
            return -1; // 返回一个无效的ID
        }

        private int GetSelectedClassId()
        {
            if (dataGridViewClasses.SelectedRows.Count > 0)
            {
                return (int)dataGridViewClasses.SelectedRows[0].Cells["ClassId"].Value;
            }
            return -1; // 返回一个无效的ID
        }

        

        private void btnShowlog_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                var logs = context.Logs.ToList();
                dataGridViewLogs.DataSource = logs;
            }
        }
    }
}
