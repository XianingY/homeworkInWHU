namespace LogSystem
{
    partial class MainForm
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
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.logButton = new System.Windows.Forms.Button();
            this.addTimestampCheckBox = new System.Windows.Forms.CheckBox();
            this.logsTextBox = new System.Windows.Forms.TextBox();
            this.showLogsButton = new System.Windows.Forms.Button();
            this.saveLogsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(66, 55);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(218, 120);
            this.messageTextBox.TabIndex = 0;
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(66, 206);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(75, 23);
            this.logButton.TabIndex = 1;
            this.logButton.Text = "记录日志";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // addTimestampCheckBox
            // 
            this.addTimestampCheckBox.AutoSize = true;
            this.addTimestampCheckBox.Location = new System.Drawing.Point(175, 210);
            this.addTimestampCheckBox.Name = "addTimestampCheckBox";
            this.addTimestampCheckBox.Size = new System.Drawing.Size(60, 16);
            this.addTimestampCheckBox.TabIndex = 2;
            this.addTimestampCheckBox.Text = "时间戳";
            this.addTimestampCheckBox.UseVisualStyleBackColor = true;
            this.addTimestampCheckBox.CheckedChanged += new System.EventHandler(this.addTimestampCheckBox_CheckedChanged);
            // 
            // logsTextBox
            // 
            this.logsTextBox.Location = new System.Drawing.Point(319, 55);
            this.logsTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.logsTextBox.Multiline = true;
            this.logsTextBox.Name = "logsTextBox";
            this.logsTextBox.Size = new System.Drawing.Size(218, 120);
            this.logsTextBox.TabIndex = 3;
            // 
            // showLogsButton
            // 
            this.showLogsButton.Location = new System.Drawing.Point(319, 205);
            this.showLogsButton.Name = "showLogsButton";
            this.showLogsButton.Size = new System.Drawing.Size(75, 23);
            this.showLogsButton.TabIndex = 4;
            this.showLogsButton.Text = "显示日志";
            this.showLogsButton.UseVisualStyleBackColor = true;
            this.showLogsButton.Click += new System.EventHandler(this.showLogsButton_Click);
            // 
            // saveLogsButton
            // 
            this.saveLogsButton.Location = new System.Drawing.Point(319, 271);
            this.saveLogsButton.Name = "saveLogsButton";
            this.saveLogsButton.Size = new System.Drawing.Size(75, 23);
            this.saveLogsButton.TabIndex = 5;
            this.saveLogsButton.Text = "保存日志";
            this.saveLogsButton.UseVisualStyleBackColor = true;
            this.saveLogsButton.Click += new System.EventHandler(this.saveLogsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.saveLogsButton);
            this.Controls.Add(this.showLogsButton);
            this.Controls.Add(this.logsTextBox);
            this.Controls.Add(this.addTimestampCheckBox);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.messageTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.CheckBox addTimestampCheckBox;
        private System.Windows.Forms.TextBox logsTextBox;
        private System.Windows.Forms.Button showLogsButton;
        private System.Windows.Forms.Button saveLogsButton;
    }
}

