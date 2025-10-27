using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GrammarClassifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void classifyButton_Click(object sender, EventArgs e)
        {
            string grammarInput = grammarTextBox.Text.Trim();
            string vnInput = vnTextBox.Text.Trim();
            string productionInput = productionsTextBox.Text.Trim();

            // 解析
            var VN = vnInput.Split(',').Select(s => s.Trim()).ToList();
            var productions = productionInput.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(s => s.Trim()).ToList();
            string formalGrammar = $"G[{grammarInput}] = ({{ {string.Join(", ", VN)} }}, P, {VN.First()})";

           
            string grammarType = ClassifyGrammar(productions);

            
            outputTextBox.Text = $"{formalGrammar}\n该文法是Chomsky {grammarType} 型文法。";
        }

        private string ClassifyGrammar(List<string> productions)
        {
            bool isContextFree = true;
            bool isRegular = true;
            bool isContextSensitive = true;

            foreach (var production in productions)
            {
                var parts = production.Split(new string[] { "::=" }, StringSplitOptions.None);
                if (parts.Length != 2) return "无效的产生式格式";

                string left = parts[0].Trim();
                string right = parts[1].Trim();


                // 检查右部的有效性
                if (string.IsNullOrEmpty(right))
                {
                    return "非文法：右部不能为空";
                }

               
                if (left.Length != 1 || !char.IsUpper(left[0]))
                    isContextFree = false;

                
                if (right.Length > 2 && right.Any(c => char.IsUpper(c) && !char.IsLower(c)))
                {
                    isRegular = false; // Non-regular grammar
                }

                
                if (left.Length > right.Length)
                {
                    isContextSensitive = false; // Context-sensitive condition violated
                }
            }

            // 确保有准确的优先级
            if (isRegular) return "3"; // Regular grammar
            if (isContextFree) return "2"; // Context-Free Grammar
            if (isContextSensitive) return "1"; // Context-Sensitive Grammar

            return "0"; // Type 0 
        }

    }
}
