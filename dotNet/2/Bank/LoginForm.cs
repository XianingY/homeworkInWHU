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
    public partial class LoginForm : Form
    {
        private UserManager userManager;
        public User LoggedInUser { get; private set; }

        public LoginForm(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = userManager.Login(username, password);
            if (user != null)
            {
                MessageBox.Show("登录成功！");
                LoggedInUser = user;
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误。");
            }
        }
    }
}
