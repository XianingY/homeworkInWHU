using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class RegisterForm : Form
    {
        private UserManager userManager;

        public RegisterForm(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            decimal initialBalance;

            if (!decimal.TryParse(txtInitialBalance.Text, out initialBalance))
            {
                MessageBox.Show("请输入正确的初始余额格式。");
                return;
            }

            if (userManager.Register(username, password, initialBalance))
            {
                MessageBox.Show("注册成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名已存在，请选择其他用户名。");
            }
        }
    }
}
