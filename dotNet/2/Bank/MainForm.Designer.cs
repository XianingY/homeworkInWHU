namespace Bank
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCheckBalance;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtUsername; 
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblUsername;
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCheckBalance = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(263, 44);
            this.btnWithdraw.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(100, 27);
            this.btnWithdraw.TabIndex = 0;
            this.btnWithdraw.Text = "取款";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(263, 77);
            this.btnDeposit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(100, 27);
            this.btnDeposit.TabIndex = 1;
            this.btnDeposit.Text = "存款";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(19, 77);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 27);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(153, 77);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 27);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCheckBalance
            // 
            this.btnCheckBalance.Location = new System.Drawing.Point(261, 176);
            this.btnCheckBalance.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCheckBalance.Name = "btnCheckBalance";
            this.btnCheckBalance.Size = new System.Drawing.Size(100, 27);
            this.btnCheckBalance.TabIndex = 4;
            this.btnCheckBalance.Text = "检查余额";
            this.btnCheckBalance.UseVisualStyleBackColor = true;
            this.btnCheckBalance.Click += new System.EventHandler(this.btnCheckBalance_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(16, 46);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(237, 25);
            this.txtAmount.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(16, 176);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(237, 25);
            this.txtUsername.TabIndex = 6;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(16, 10);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(79, 15);
            this.lblBalance.TabIndex = 7;
            this.lblBalance.Text = "当前余额为: ";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(16, 145);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(71, 15);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "希望查看余额的用户名";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 225);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnCheckBalance);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnWithdraw);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "ATM模拟器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}

