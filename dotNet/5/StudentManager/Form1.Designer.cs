namespace StudentManager
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnAddClass;
            System.Windows.Forms.Button btnAddStudent;
            this.btnAddSchool = new System.Windows.Forms.Button();
            this.txtSchoolName = new System.Windows.Forms.TextBox();
            this.dataGridViewSchools = new System.Windows.Forms.DataGridView();
            this.btnShowlog = new System.Windows.Forms.Button();
            this.dataGridViewLogs = new System.Windows.Forms.DataGridView();
            this.btnDeleteSchool = new System.Windows.Forms.Button();
            this.btnDeleteClass = new System.Windows.Forms.Button();
            this.dataGridViewClasses = new System.Windows.Forms.DataGridView();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            btnAddClass = new System.Windows.Forms.Button();
            btnAddStudent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddSchool
            // 
            this.btnAddSchool.Location = new System.Drawing.Point(76, 276);
            this.btnAddSchool.Name = "btnAddSchool";
            this.btnAddSchool.Size = new System.Drawing.Size(128, 23);
            this.btnAddSchool.TabIndex = 0;
            this.btnAddSchool.Text = "添加学校";
            this.btnAddSchool.UseVisualStyleBackColor = true;
            this.btnAddSchool.Click += new System.EventHandler(this.btnAddSchool_Click);
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.Location = new System.Drawing.Point(76, 30);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(100, 25);
            this.txtSchoolName.TabIndex = 1;
            // 
            // dataGridViewSchools
            // 
            this.dataGridViewSchools.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSchools.Location = new System.Drawing.Point(76, 95);
            this.dataGridViewSchools.Name = "dataGridViewSchools";
            this.dataGridViewSchools.RowHeadersWidth = 51;
            this.dataGridViewSchools.RowTemplate.Height = 27;
            this.dataGridViewSchools.Size = new System.Drawing.Size(323, 150);
            this.dataGridViewSchools.TabIndex = 2;
            this.dataGridViewSchools.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSchools_CellEndEdit);
            // 
            // btnShowlog
            // 
            this.btnShowlog.Location = new System.Drawing.Point(1117, 465);
            this.btnShowlog.Name = "btnShowlog";
            this.btnShowlog.Size = new System.Drawing.Size(75, 23);
            this.btnShowlog.TabIndex = 3;
            this.btnShowlog.Text = "日志";
            this.btnShowlog.UseVisualStyleBackColor = true;
            this.btnShowlog.Click += new System.EventHandler(this.btnShowlog_Click);
            // 
            // dataGridViewLogs
            // 
            this.dataGridViewLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLogs.Location = new System.Drawing.Point(73, 351);
            this.dataGridViewLogs.Name = "dataGridViewLogs";
            this.dataGridViewLogs.RowHeadersWidth = 51;
            this.dataGridViewLogs.RowTemplate.Height = 27;
            this.dataGridViewLogs.Size = new System.Drawing.Size(1013, 158);
            this.dataGridViewLogs.TabIndex = 4;
            // 
            // btnDeleteSchool
            // 
            this.btnDeleteSchool.Location = new System.Drawing.Point(76, 315);
            this.btnDeleteSchool.Name = "btnDeleteSchool";
            this.btnDeleteSchool.Size = new System.Drawing.Size(128, 23);
            this.btnDeleteSchool.TabIndex = 5;
            this.btnDeleteSchool.Text = "删除学校";
            this.btnDeleteSchool.UseVisualStyleBackColor = true;
            this.btnDeleteSchool.Click += new System.EventHandler(this.btnDeleteSchool_Click);
            // 
            // btnDeleteClass
            // 
            this.btnDeleteClass.Location = new System.Drawing.Point(521, 315);
            this.btnDeleteClass.Name = "btnDeleteClass";
            this.btnDeleteClass.Size = new System.Drawing.Size(128, 23);
            this.btnDeleteClass.TabIndex = 9;
            this.btnDeleteClass.Text = "删除班级";
            this.btnDeleteClass.UseVisualStyleBackColor = true;
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);
            // 
            // dataGridViewClasses
            // 
            this.dataGridViewClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClasses.Location = new System.Drawing.Point(521, 95);
            this.dataGridViewClasses.Name = "dataGridViewClasses";
            this.dataGridViewClasses.RowHeadersWidth = 51;
            this.dataGridViewClasses.RowTemplate.Height = 27;
            this.dataGridViewClasses.Size = new System.Drawing.Size(311, 150);
            this.dataGridViewClasses.TabIndex = 8;
            this.dataGridViewClasses.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClasses_CellEndEdit);
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(521, 30);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(100, 25);
            this.txtClassName.TabIndex = 7;
            // 
            // btnAddClass
            // 
            btnAddClass.Location = new System.Drawing.Point(521, 276);
            btnAddClass.Name = "btnAddClass";
            btnAddClass.Size = new System.Drawing.Size(128, 23);
            btnAddClass.TabIndex = 6;
            btnAddClass.Text = "添加班级";
            btnAddClass.UseVisualStyleBackColor = true;
            btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Location = new System.Drawing.Point(889, 315);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(96, 23);
            this.btnDeleteStudent.TabIndex = 13;
            this.btnDeleteStudent.Text = "删除学生";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Location = new System.Drawing.Point(889, 95);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.RowHeadersWidth = 51;
            this.dataGridViewStudents.RowTemplate.Height = 27;
            this.dataGridViewStudents.Size = new System.Drawing.Size(275, 150);
            this.dataGridViewStudents.TabIndex = 12;
            this.dataGridViewStudents.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudents_CellEndEdit);
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(889, 30);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(96, 25);
            this.txtStudentName.TabIndex = 11;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new System.Drawing.Point(889, 276);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new System.Drawing.Size(96, 23);
            btnAddStudent.TabIndex = 10;
            btnAddStudent.Text = "添加学生";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 570);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.dataGridViewStudents);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(btnAddStudent);
            this.Controls.Add(this.btnDeleteClass);
            this.Controls.Add(this.dataGridViewClasses);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(btnAddClass);
            this.Controls.Add(this.btnDeleteSchool);
            this.Controls.Add(this.dataGridViewLogs);
            this.Controls.Add(this.btnShowlog);
            this.Controls.Add(this.dataGridViewSchools);
            this.Controls.Add(this.txtSchoolName);
            this.Controls.Add(this.btnAddSchool);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddSchool;
        private System.Windows.Forms.TextBox txtSchoolName;
        private System.Windows.Forms.DataGridView dataGridViewSchools;
        private System.Windows.Forms.Button btnShowlog;
        private System.Windows.Forms.DataGridView dataGridViewLogs;
        private System.Windows.Forms.Button btnDeleteSchool;
        private System.Windows.Forms.Button btnDeleteClass;
        private System.Windows.Forms.DataGridView dataGridViewClasses;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.TextBox txtStudentName;
    }
}

