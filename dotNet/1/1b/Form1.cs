using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1b
{
    public partial class Form1 : Form
    {

        private Random random = new Random();
        private int currentScore = 0;
        private int totalQuestions = 0;
        private int counts = 10;
        private int timeLimit = 20; 
        private Timer timer = new Timer();
        private Label questionLabel = new Label();
        private TextBox answerTextBox = new TextBox();
        private Button submitButton = new Button();
        private Label feedbackLabel = new Label();
       
        

        public Form1()
        {
            InitializeComponent();
            SetupForm();
            StartTimer();
        }
        private void SetupForm()
        {
            this.Text = "智商检测";
            this.Size = new Size(400, 200);

            questionLabel = new Label()
            {
                Location = new Point(10, 10),
                Size = new Size(300, 20),
                Text = "这里会出现题目，请准备"
            };
            this.Controls.Add(questionLabel);

            answerTextBox = new TextBox()
            {
                Location = new Point(10, 40),
                Size = new Size(100, 20)
            };
            this.Controls.Add(answerTextBox);

            submitButton = new Button()
            {
                Location = new Point(120, 40),
                Size = new Size(75, 23),
                Text = "提交",
                Font = new Font("Arial", 8)
            };
            submitButton.Click += SubmitButton_Click;
            this.Controls.Add(submitButton);

            feedbackLabel = new Label()
            {
                Location = new Point(10, 70),
                Size = new Size(300, 20),
                Text = "题目每三秒出现一道题，请思考再三后提交",
                ForeColor = Color.Red
            };
            this.Controls.Add(feedbackLabel);


        }

        private void StartTimer()
        {
            timer.Interval = 3000; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        int answer;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLimit-- <= 0)
            {
                timer.Stop();
                MessageBox.Show($"时间用完了，最终得分是: {currentScore}/{counts}");
                this.Close();
            }
            else
            {
                int num1 = random.Next(1, 11);
                int num2 = random.Next(1, 11);
                char operation = random.Next(0, 2) == 0 ? '+' : '-';
                string question = $"{num1} {operation} {num2}";
                answer = operation == '+' ? num1 + num2 : num1 - num2;
               
                questionLabel.Text = question;
                
            }
        }

        private void SubmitAnswer()
        {
            if (int.TryParse(answerTextBox.Text, out int userAnswer))
            {
                if (userAnswer == answer)
                {
                    currentScore++;
                    feedbackLabel.Text = "答对了";
                    feedbackLabel.BackColor = Color.Green;
                    
                }
                else
                {
                    feedbackLabel.Text = "不太对";
                    feedbackLabel.BackColor = Color.Red;
                    
                    
                }
            }
            else
            {
                feedbackLabel.Text = "请输入合适的答案";
                feedbackLabel.BackColor = Color.Orange;
            }
            answerTextBox.Clear();
            totalQuestions++;
            if (totalQuestions >= counts)
            {
                timer.Stop();
                MessageBox.Show($"所有的题目都被答完了，你的得分是: {currentScore}/{counts}");
                this.Close();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SubmitAnswer();
        }

        
    }
}
