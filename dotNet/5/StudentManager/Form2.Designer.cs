namespace StudentManager
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnUpdateStudent;
            System.Windows.Forms.Button btnUpdateClass;
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.dataGridViewClasses = new System.Windows.Forms.DataGridView();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.dataGridViewLogs = new System.Windows.Forms.DataGridView();
            this.btnShowlog = new System.Windows.Forms.Button();
            this.dataGridViewSchools = new System.Windows.Forms.DataGridView();
            this.txtSchoolName = new System.Windows.Forms.TextBox();
            this.btnUpdateSchool = new System.Windows.Forms.Button();
            btnUpdateStudent = new System.Windows.Forms.Button();
            btnUpdateClass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchools)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateStudent
            // 
            btnUpdateStudent.Location = new System.Drawing.Point(632, 207);
            btnUpdateStudent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            btnUpdateStudent.Name = "btnUpdateStudent";
            btnUpdateStudent.Size = new System.Drawing.Size(72, 18);
            btnUpdateStudent.TabIndex = 24;
            btnUpdateStudent.Text = "更新学生";
            btnUpdateStudent.UseVisualStyleBackColor = true;
            btnUpdateStudent.Click += new System.EventHandler(this.btnUpdateStudent_Click);
            // 
            // btnUpdateClass
            // 
            btnUpdateClass.Location = new System.Drawing.Point(356, 207);
            btnUpdateClass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            btnUpdateClass.Name = "btnUpdateClass";
            btnUpdateClass.Size = new System.Drawing.Size(96, 18);
            btnUpdateClass.TabIndex = 20;
            btnUpdateClass.Text = "更新班级";
            btnUpdateClass.UseVisualStyleBackColor = true;
            btnUpdateClass.Click += new System.EventHandler(this.btnUpdateClass_Click);
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Location = new System.Drawing.Point(632, 62);
            this.dataGridViewStudents.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.RowHeadersWidth = 51;
            this.dataGridViewStudents.RowTemplate.Height = 27;
            this.dataGridViewStudents.Size = new System.Drawing.Size(206, 120);
            this.dataGridViewStudents.TabIndex = 26;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(632, 10);
            this.txtStudentName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(73, 21);
            this.txtStudentName.TabIndex = 25;
            // 
            // dataGridViewClasses
            // 
            this.dataGridViewClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClasses.Location = new System.Drawing.Point(356, 62);
            this.dataGridViewClasses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewClasses.Name = "dataGridViewClasses";
            this.dataGridViewClasses.RowHeadersWidth = 51;
            this.dataGridViewClasses.RowTemplate.Height = 27;
            this.dataGridViewClasses.Size = new System.Drawing.Size(233, 120);
            this.dataGridViewClasses.TabIndex = 22;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(356, 10);
            this.txtClassName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(76, 21);
            this.txtClassName.TabIndex = 21;
            // 
            // dataGridViewLogs
            // 
            this.dataGridViewLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLogs.Location = new System.Drawing.Point(20, 267);
            this.dataGridViewLogs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewLogs.Name = "dataGridViewLogs";
            this.dataGridViewLogs.RowHeadersWidth = 51;
            this.dataGridViewLogs.RowTemplate.Height = 27;
            this.dataGridViewLogs.Size = new System.Drawing.Size(760, 126);
            this.dataGridViewLogs.TabIndex = 18;
            // 
            // btnShowlog
            // 
            this.btnShowlog.Location = new System.Drawing.Point(802, 358);
            this.btnShowlog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShowlog.Name = "btnShowlog";
            this.btnShowlog.Size = new System.Drawing.Size(56, 18);
            this.btnShowlog.TabIndex = 17;
            this.btnShowlog.Text = "日志";
            this.btnShowlog.UseVisualStyleBackColor = true;
            this.btnShowlog.Click += new System.EventHandler(this.btnShowlog_Click);
            // 
            // dataGridViewSchools
            // 
            this.dataGridViewSchools.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSchools.Location = new System.Drawing.Point(22, 62);
            this.dataGridViewSchools.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewSchools.Name = "dataGridViewSchools";
            this.dataGridViewSchools.RowHeadersWidth = 51;
            this.dataGridViewSchools.RowTemplate.Height = 27;
            this.dataGridViewSchools.Size = new System.Drawing.Size(242, 120);
            this.dataGridViewSchools.TabIndex = 16;
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.Location = new System.Drawing.Point(22, 10);
            this.txtSchoolName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(76, 21);
            this.txtSchoolName.TabIndex = 15;
            // 
            // btnUpdateSchool
            // 
            this.btnUpdateSchool.Location = new System.Drawing.Point(22, 207);
            this.btnUpdateSchool.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdateSchool.Name = "btnUpdateSchool";
            this.btnUpdateSchool.Size = new System.Drawing.Size(96, 18);
            this.btnUpdateSchool.TabIndex = 14;
            this.btnUpdateSchool.Text = "更新学校";
            this.btnUpdateSchool.UseVisualStyleBackColor = true;
            this.btnUpdateSchool.Click += new System.EventHandler(this.btnUpdateSchool_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 468);
            this.Controls.Add(this.dataGridViewStudents);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(btnUpdateStudent);
            this.Controls.Add(this.dataGridViewClasses);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(btnUpdateClass);
            this.Controls.Add(this.dataGridViewLogs);
            this.Controls.Add(this.btnShowlog);
            this.Controls.Add(this.dataGridViewSchools);
            this.Controls.Add(this.txtSchoolName);
            this.Controls.Add(this.btnUpdateSchool);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchools)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.DataGridView dataGridViewClasses;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.DataGridView dataGridViewLogs;
        private System.Windows.Forms.Button btnShowlog;
        private System.Windows.Forms.DataGridView dataGridViewSchools;
        private System.Windows.Forms.TextBox txtSchoolName;
        private System.Windows.Forms.Button btnUpdateSchool;
    }
}