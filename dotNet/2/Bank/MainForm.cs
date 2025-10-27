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
    public partial class MainForm : Form
    {
        private Bank bank;
        private ATM atm;
        private UserManager userManager;
        private User currentUser;

        public MainForm()
        {
            InitializeComponent();
            bank = new Bank("MyBank");
            atm = new ATM();
            userManager = new UserManager();
            atm.BigMoneyFetched += Atm_BigMoneyFetched;
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("请先登录。");
                return;
            }

            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("请输入正确的金额格式。");
                return;
            }

            try
            {
                atm.Withdraw(currentUser.Account, amount);
                lblBalance.Text = $"当前余额: {currentUser.Account.Balance}";
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (BadCashException ex)
            {
                MessageBox.Show(ex.Message);
            }

            // 模拟破损钞票
            Random random = new Random();
            if (random.NextDouble() < 0.3)
            {
                throw new BadCashException("检测到坏钞，此ATM崩溃!");
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("请先登录。");
                return;
            }

            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("请输入正确的金额格式。");
                return;
            }

            currentUser.Account.Deposit(amount);
            lblBalance.Text = $"当前余额: {currentUser.Account.Balance}";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(userManager);
            registerForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(userManager);
            loginForm.ShowDialog();

            if (loginForm.LoggedInUser != null)
            {
                currentUser = loginForm.LoggedInUser;
                lblBalance.Text = $"当前余额: {currentUser.Account.Balance}";
                MessageBox.Show($"欢迎, {currentUser.Username}!");
            }
        }

        private void btnCheckBalance_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            User user = userManager[username];

            if (user != null)
            {
                MessageBox.Show($"用户: {user.Username}, 当前余额: {user.Account.Balance}");
            }
            else
            {
                MessageBox.Show("用户不存在。");
            }
        }

        private void Atm_BigMoneyFetched(object sender, BigMoneyArgs e)
        {
            MessageBox.Show($"检测到大额取款\r当前帐号: {e.AccountNumber}\r 取款金额: {e.Amount}");
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
