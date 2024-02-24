namespace FGJsonCheckTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            jsonTextBox = new TextBox();
            button1 = new Button();
            outputTextBox = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            button2 = new Button();
            fileNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // jsonTextBox
            // 
            jsonTextBox.AcceptsReturn = true;
            jsonTextBox.AllowDrop = true;
            jsonTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            jsonTextBox.Font = new Font("ＭＳ ゴシック", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            jsonTextBox.ImeMode = ImeMode.Disable;
            jsonTextBox.Location = new Point(12, 76);
            jsonTextBox.Multiline = true;
            jsonTextBox.Name = "jsonTextBox";
            jsonTextBox.ScrollBars = ScrollBars.Vertical;
            jsonTextBox.Size = new Size(776, 130);
            jsonTextBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(604, 12);
            button1.Name = "button1";
            button1.Size = new Size(184, 40);
            button1.TabIndex = 1;
            button1.Text = "解析する";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // outputTextBox
            // 
            outputTextBox.AcceptsReturn = true;
            outputTextBox.AllowDrop = true;
            outputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            outputTextBox.Font = new Font("ＭＳ ゴシック", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            outputTextBox.ImeMode = ImeMode.Disable;
            outputTextBox.Location = new Point(12, 227);
            outputTextBox.Multiline = true;
            outputTextBox.Name = "outputTextBox";
            outputTextBox.ReadOnly = true;
            outputTextBox.ScrollBars = ScrollBars.Vertical;
            outputTextBox.Size = new Size(776, 287);
            outputTextBox.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(486, 21);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "参照...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.Location = new Point(74, 21);
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.Size = new Size(406, 23);
            fileNameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 4;
            label1.Text = "DBファイル";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 58);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 5;
            label2.Text = "JSONをここ↓にペースト";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 209);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 6;
            label3.Text = "解析結果";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 526);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fileNameTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(outputTextBox);
            Controls.Add(jsonTextBox);
            Name = "Form1";
            Text = "FGJsonCheckTool";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox jsonTextBox;
        private Button button1;
        private TextBox outputTextBox;
        private OpenFileDialog openFileDialog1;
        private Button button2;
        private TextBox fileNameTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
