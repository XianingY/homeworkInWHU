namespace GrammarClassifier
{
    partial class Form1
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
            this.grammarTextBox = new System.Windows.Forms.TextBox();
            this.vnTextBox = new System.Windows.Forms.TextBox();
            this.productionsTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.classifyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grammarTextBox
            // 
            this.grammarTextBox.Location = new System.Drawing.Point(31, 76);
            this.grammarTextBox.Name = "grammarTextBox";
            this.grammarTextBox.Size = new System.Drawing.Size(100, 25);
            this.grammarTextBox.TabIndex = 0;
            this.grammarTextBox.Text = "G[N]";
            // 
            // vnTextBox
            // 
            this.vnTextBox.Location = new System.Drawing.Point(31, 139);
            this.vnTextBox.Name = "vnTextBox";
            this.vnTextBox.Size = new System.Drawing.Size(100, 25);
            this.vnTextBox.TabIndex = 1;
            this.vnTextBox.Text = "S,A,B,C,D,E";
            // 
            // productionsTextBox
            // 
            this.productionsTextBox.Location = new System.Drawing.Point(31, 204);
            this.productionsTextBox.Multiline = true;
            this.productionsTextBox.Name = "productionsTextBox";
            this.productionsTextBox.Size = new System.Drawing.Size(746, 192);
            this.productionsTextBox.TabIndex = 2;
            this.productionsTextBox.Text = "S::=ACaB\r\nCa::=aaC\r\nCB::=DB\r\nCB::=E\r\naD::=Da\r\nAD::=AC\r\naE::=Ea\r\nAE::=ε";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(410, 75);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(367, 89);
            this.outputTextBox.TabIndex = 3;
            // 
            // classifyButton
            // 
            this.classifyButton.Location = new System.Drawing.Point(294, 75);
            this.classifyButton.Name = "classifyButton";
            this.classifyButton.Size = new System.Drawing.Size(75, 23);
            this.classifyButton.TabIndex = 4;
            this.classifyButton.Text = "启动分析";
            this.classifyButton.UseVisualStyleBackColor = true;
            this.classifyButton.Click += new System.EventHandler(this.classifyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "文法标识符（默认为G[N]）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "非终结符";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "产生式规则";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "输出";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.classifyButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.productionsTextBox);
            this.Controls.Add(this.vnTextBox);
            this.Controls.Add(this.grammarTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox grammarTextBox;
        private System.Windows.Forms.TextBox vnTextBox;
        private System.Windows.Forms.TextBox productionsTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button classifyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

