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
            analyzeButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            dbFileBrowseButton = new Button();
            fileNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            clearButton = new Button();
            resultListView = new ListView();
            label4 = new Label();
            label5 = new Label();
            hostTextBox = new TextBox();
            didTextBox = new TextBox();
            generateUriButton = new Button();
            label6 = new Label();
            uriTextBox = new TextBox();
            openBrowserButton = new Button();
            protocolTextBox = new TextBox();
            label7 = new Label();
            label8 = new Label();
            shortNameTextBox = new TextBox();
            label9 = new Label();
            cursorTextBox = new TextBox();
            generateUriWithCursorButton = new Button();
            SuspendLayout();
            // 
            // jsonTextBox
            // 
            jsonTextBox.AcceptsReturn = true;
            jsonTextBox.AllowDrop = true;
            jsonTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            jsonTextBox.Font = new Font("ＭＳ ゴシック", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            jsonTextBox.ImeMode = ImeMode.Disable;
            jsonTextBox.Location = new Point(12, 181);
            jsonTextBox.Multiline = true;
            jsonTextBox.Name = "jsonTextBox";
            jsonTextBox.ScrollBars = ScrollBars.Vertical;
            jsonTextBox.Size = new Size(874, 130);
            jsonTextBox.TabIndex = 0;
            // 
            // analyzeButton
            // 
            analyzeButton.Location = new Point(257, 154);
            analyzeButton.Name = "analyzeButton";
            analyzeButton.Size = new Size(116, 24);
            analyzeButton.TabIndex = 1;
            analyzeButton.Text = "解析する";
            analyzeButton.UseVisualStyleBackColor = true;
            analyzeButton.Click += analyzeButton_Click;
            // 
            // dbFileBrowseButton
            // 
            dbFileBrowseButton.Location = new Point(449, 3);
            dbFileBrowseButton.Name = "dbFileBrowseButton";
            dbFileBrowseButton.Size = new Size(57, 23);
            dbFileBrowseButton.TabIndex = 2;
            dbFileBrowseButton.Text = "参照...";
            dbFileBrowseButton.UseVisualStyleBackColor = true;
            dbFileBrowseButton.Click += dbFileBrowseButton_Click;
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.Location = new Point(74, 3);
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.Size = new Size(369, 23);
            fileNameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 7);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 4;
            label1.Text = "DBファイル";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 158);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 5;
            label2.Text = "JSONをここ↓にペースト";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 325);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 6;
            label3.Text = "解析結果";
            // 
            // clearButton
            // 
            clearButton.Location = new Point(134, 154);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(75, 23);
            clearButton.TabIndex = 7;
            clearButton.Text = "クリア";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // resultListView
            // 
            resultListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultListView.FullRowSelect = true;
            resultListView.GridLines = true;
            resultListView.LabelWrap = false;
            resultListView.Location = new Point(13, 354);
            resultListView.MultiSelect = false;
            resultListView.Name = "resultListView";
            resultListView.Size = new Size(873, 252);
            resultListView.TabIndex = 8;
            resultListView.UseCompatibleStateImageBehavior = false;
            resultListView.View = View.Details;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 35);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 9;
            label4.Text = "プロトコル";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 63);
            label5.Name = "label5";
            label5.Size = new Size(26, 15);
            label5.TabIndex = 10;
            label5.Text = "DID";
            // 
            // hostTextBox
            // 
            hostTextBox.Location = new Point(205, 32);
            hostTextBox.Name = "hostTextBox";
            hostTextBox.Size = new Size(373, 23);
            hostTextBox.TabIndex = 11;
            // 
            // didTextBox
            // 
            didTextBox.Location = new Point(75, 60);
            didTextBox.Name = "didTextBox";
            didTextBox.Size = new Size(298, 23);
            didTextBox.TabIndex = 12;
            // 
            // generateUriButton
            // 
            generateUriButton.Location = new Point(584, 44);
            generateUriButton.Name = "generateUriButton";
            generateUriButton.Size = new Size(91, 23);
            generateUriButton.TabIndex = 13;
            generateUriButton.Text = "URI生成";
            generateUriButton.UseVisualStyleBackColor = true;
            generateUriButton.Click += generateUriButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 94);
            label6.Name = "label6";
            label6.Size = new Size(25, 15);
            label6.TabIndex = 14;
            label6.Text = "URI";
            // 
            // uriTextBox
            // 
            uriTextBox.Location = new Point(75, 91);
            uriTextBox.Multiline = true;
            uriTextBox.Name = "uriTextBox";
            uriTextBox.Size = new Size(715, 57);
            uriTextBox.TabIndex = 15;
            // 
            // openBrowserButton
            // 
            openBrowserButton.Location = new Point(795, 105);
            openBrowserButton.Name = "openBrowserButton";
            openBrowserButton.Size = new Size(91, 23);
            openBrowserButton.TabIndex = 16;
            openBrowserButton.Text = "ブラウザで開く";
            openBrowserButton.UseVisualStyleBackColor = true;
            openBrowserButton.Click += openBrowserButton_Click;
            // 
            // protocolTextBox
            // 
            protocolTextBox.Location = new Point(75, 32);
            protocolTextBox.Name = "protocolTextBox";
            protocolTextBox.Size = new Size(74, 23);
            protocolTextBox.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(165, 35);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 18;
            label7.Text = "ホスト";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(379, 63);
            label8.Name = "label8";
            label8.Size = new Size(66, 15);
            label8.TabIndex = 19;
            label8.Text = "short name";
            // 
            // shortNameTextBox
            // 
            shortNameTextBox.Location = new Point(450, 60);
            shortNameTextBox.Name = "shortNameTextBox";
            shortNameTextBox.Size = new Size(128, 23);
            shortNameTextBox.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(88, 325);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 21;
            label9.Text = "cursor";
            // 
            // cursorTextBox
            // 
            cursorTextBox.Location = new Point(134, 322);
            cursorTextBox.Name = "cursorTextBox";
            cursorTextBox.ReadOnly = true;
            cursorTextBox.Size = new Size(508, 23);
            cursorTextBox.TabIndex = 22;
            // 
            // generateUriWithCursorButton
            // 
            generateUriWithCursorButton.Location = new Point(648, 322);
            generateUriWithCursorButton.Name = "generateUriWithCursorButton";
            generateUriWithCursorButton.Size = new Size(176, 23);
            generateUriWithCursorButton.TabIndex = 23;
            generateUriWithCursorButton.Text = "cursorを付けてURI生成";
            generateUriWithCursorButton.UseVisualStyleBackColor = true;
            generateUriWithCursorButton.Click += generateUriWithCursorButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 618);
            Controls.Add(generateUriWithCursorButton);
            Controls.Add(cursorTextBox);
            Controls.Add(label9);
            Controls.Add(shortNameTextBox);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(protocolTextBox);
            Controls.Add(openBrowserButton);
            Controls.Add(uriTextBox);
            Controls.Add(label6);
            Controls.Add(generateUriButton);
            Controls.Add(didTextBox);
            Controls.Add(hostTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(resultListView);
            Controls.Add(clearButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fileNameTextBox);
            Controls.Add(dbFileBrowseButton);
            Controls.Add(analyzeButton);
            Controls.Add(jsonTextBox);
            Name = "Form1";
            Text = "FGJsonCheckTool";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox jsonTextBox;
        private Button analyzeButton;
        private OpenFileDialog openFileDialog1;
        private Button dbFileBrowseButton;
        private TextBox fileNameTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button clearButton;
        private ListView resultListView;
        private Label label4;
        private Label label5;
        private TextBox hostTextBox;
        private TextBox didTextBox;
        private Button generateUriButton;
        private Label label6;
        private TextBox uriTextBox;
        private Button openBrowserButton;
        private TextBox protocolTextBox;
        private Label label7;
        private Label label8;
        private TextBox shortNameTextBox;
        private Label label9;
        private TextBox cursorTextBox;
        private Button generateUriWithCursorButton;
    }
}
