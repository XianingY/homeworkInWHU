using System;
using System.IO;
using System.Windows.Forms;

namespace e3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ����ļ�1ѡ��ť
            Button btnBrowseFile1 = new Button();
            btnBrowseFile1.Text = "ѡ���ļ�1";
            btnBrowseFile1.Location = new System.Drawing.Point(20, 20);
            btnBrowseFile1.Click += BtnBrowseFile1_Click;
            Controls.Add(btnBrowseFile1);

            // ����ļ�1·����ʾ�ı���
            TextBox txtFile1 = new TextBox();
            txtFile1.Name = "txtFile1"; // ��ӿؼ�����
            txtFile1.Location = new System.Drawing.Point(140, 20);
            txtFile1.Width = 300;
            Controls.Add(txtFile1);

            // ����ļ�2ѡ��ť
            Button btnBrowseFile2 = new Button();
            btnBrowseFile2.Text = "ѡ���ļ�2";
            btnBrowseFile2.Location = new System.Drawing.Point(20, 60);
            btnBrowseFile2.Click += BtnBrowseFile2_Click;
            Controls.Add(btnBrowseFile2);

            // ����ļ�2·����ʾ�ı���
            TextBox txtFile2 = new TextBox();
            txtFile2.Name = "txtFile2"; // ��ӿؼ�����
            txtFile2.Location = new System.Drawing.Point(140, 60);
            txtFile2.Width = 300;
            Controls.Add(txtFile2);

            // ��Ӻϲ���ť
            Button btnMerge = new Button();
            btnMerge.Text = "�ϲ��ļ�";
            btnMerge.Location = new System.Drawing.Point(140, 100);
            btnMerge.Click += BtnMerge_Click;
            Controls.Add(btnMerge);


            btnBrowseFile1.Size = new System.Drawing.Size(100, 30);
            btnBrowseFile2.Size = new System.Drawing.Size(100, 30);
            btnMerge.Size = new System.Drawing.Size(100,30);
        }



        private void BtnBrowseFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ��ʾѡ����ļ�·�����ļ�1���ı���
                TextBox txtFile1 = Controls.Find("txtFile1", true)[0] as TextBox;
                txtFile1.Text = openFileDialog.FileName;
            }
        }

        private void BtnBrowseFile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ��ʾѡ����ļ�·�����ļ�2���ı���
                TextBox txtFile2 = Controls.Find("txtFile2", true)[0] as TextBox;
                txtFile2.Text = openFileDialog.FileName;
            }
        }

        private void BtnMerge_Click(object sender, EventArgs e)
        {
            try
            {
                // ��ȡ�ļ�1���ļ�2��·��
                TextBox txtFile1 = Controls.Find("txtFile1", true)[0] as TextBox;
                TextBox txtFile2 = Controls.Find("txtFile2", true)[0] as TextBox;

                string file1Path = txtFile1.Text;
                string file2Path = txtFile2.Text;

                // ����ļ��Ƿ����
                if (!File.Exists(file1Path) || !File.Exists(file2Path))
                {
                    MessageBox.Show("��ѡ���������ڵ��ļ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ��ȡ�ļ�����
                string file1Content = File.ReadAllText(file1Path);
                string file2Content = File.ReadAllText(file2Path);

                // �������ļ�·��
                string newFilePath = Path.Combine(Application.StartupPath, "Data", "merged_file.txt");

                // �ϲ��ļ�����
                string mergedContent = file1Content + Environment.NewLine + file2Content;

                // д�����ļ�
                File.WriteAllText(newFilePath, mergedContent);

                MessageBox.Show("�ļ��ϲ���ɣ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������{ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
