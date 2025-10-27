using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CountApp
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
         
        }

        

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "C# files (*.cs)|*.cs";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    AnalyzeFile(filePath);
                }
            }
        }

        private void AnalyzeFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            int originalLineCount = CountLines(fileContent);
            int originalWordCount = CountWords(fileContent);

            statsTextBox.Clear();
            statsTextBox.AppendText($"原始行数: {originalLineCount}\r\n");
            statsTextBox.AppendText($"原始单词数: {originalWordCount}\r\n");

            string cleanedContent = RemoveCommentsAndEmptyLines(fileContent);
            int cleanedLineCount = CountLines(cleanedContent);
            int cleanedWordCount = CountWords(cleanedContent);

            statsTextBox.AppendText($"清理后的行数: {cleanedLineCount}\r\n");
            statsTextBox.AppendText($"清理后的单词数: {cleanedWordCount}\r\n");

            wordCountListBox.Items.Clear();
            CountWordFrequency(cleanedContent, wordCountListBox);
        }

        private int CountLines(string text)
        {
            return text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Length;
        }

        private int CountWords(string text)
        {
            string[] words = Regex.Split(text, @"\W+");
            int wordCount = 0;
            foreach (var word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    wordCount++;
                }
            }
            return wordCount;
        }

        private string RemoveCommentsAndEmptyLines(string text)
        {
            text = Regex.Replace(text, @"^\s*//.*$", "", RegexOptions.Multiline);
            text = Regex.Replace(text, @"^\s*$[\r\n]+", "\r\n", RegexOptions.Multiline);
            return text;
        }

        private void CountWordFrequency(string text, ListBox listBox)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            string[] words = Regex.Split(text, @"\W+");
            foreach (var word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }
            }

            foreach (var pair in wordCounts)
            {
                listBox.Items.Add($"{pair.Key}: {pair.Value}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
