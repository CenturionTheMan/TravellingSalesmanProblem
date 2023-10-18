namespace TravellingSalesmanProblemWF
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
            this.components = new System.ComponentModel.Container();
            this.BruteForceRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BranchAndBoundradioButton = new System.Windows.Forms.RadioButton();
            this.DynamicProgrammingRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BruteForcepanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DynamicProgrammingPanel = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SelectFileFromDiscButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.messageLogTextBox = new System.Windows.Forms.RichTextBox();
            this.SolvaButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.BruteForcepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BruteForceRadioButton
            // 
            this.BruteForceRadioButton.AutoSize = true;
            this.BruteForceRadioButton.Location = new System.Drawing.Point(6, 22);
            this.BruteForceRadioButton.Name = "BruteForceRadioButton";
            this.BruteForceRadioButton.Size = new System.Drawing.Size(85, 19);
            this.BruteForceRadioButton.TabIndex = 0;
            this.BruteForceRadioButton.TabStop = true;
            this.BruteForceRadioButton.Text = "Brute Force";
            this.BruteForceRadioButton.UseVisualStyleBackColor = true;
            this.BruteForceRadioButton.CheckedChanged += new System.EventHandler(this.BruteForceRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BranchAndBoundradioButton);
            this.groupBox1.Controls.Add(this.DynamicProgrammingRadioButton);
            this.groupBox1.Controls.Add(this.BruteForceRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 238);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Algorithm";
            // 
            // BranchAndBoundradioButton
            // 
            this.BranchAndBoundradioButton.AutoSize = true;
            this.BranchAndBoundradioButton.Enabled = false;
            this.BranchAndBoundradioButton.Location = new System.Drawing.Point(5, 72);
            this.BranchAndBoundradioButton.Name = "BranchAndBoundradioButton";
            this.BranchAndBoundradioButton.Size = new System.Drawing.Size(125, 19);
            this.BranchAndBoundradioButton.TabIndex = 2;
            this.BranchAndBoundradioButton.TabStop = true;
            this.BranchAndBoundradioButton.Text = "Branch And Bound";
            this.BranchAndBoundradioButton.UseVisualStyleBackColor = true;
            // 
            // DynamicProgrammingRadioButton
            // 
            this.DynamicProgrammingRadioButton.AutoSize = true;
            this.DynamicProgrammingRadioButton.Location = new System.Drawing.Point(6, 47);
            this.DynamicProgrammingRadioButton.Name = "DynamicProgrammingRadioButton";
            this.DynamicProgrammingRadioButton.Size = new System.Drawing.Size(149, 19);
            this.DynamicProgrammingRadioButton.TabIndex = 1;
            this.DynamicProgrammingRadioButton.TabStop = true;
            this.DynamicProgrammingRadioButton.Text = "Dynamic Programming";
            this.DynamicProgrammingRadioButton.UseVisualStyleBackColor = true;
            this.DynamicProgrammingRadioButton.CheckedChanged += new System.EventHandler(this.DynamicProgrammingRadioButton_CheckedChanged);
            // 
            // BruteForcepanel
            // 
            this.BruteForcepanel.Controls.Add(this.label1);
            this.BruteForcepanel.Location = new System.Drawing.Point(7, 252);
            this.BruteForcepanel.Name = "BruteForcepanel";
            this.BruteForcepanel.Size = new System.Drawing.Size(621, 322);
            this.BruteForcepanel.TabIndex = 2;
            this.BruteForcepanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "No settings to change";
            // 
            // DynamicProgrammingPanel
            // 
            this.DynamicProgrammingPanel.Location = new System.Drawing.Point(7, 252);
            this.DynamicProgrammingPanel.Name = "DynamicProgrammingPanel";
            this.DynamicProgrammingPanel.Size = new System.Drawing.Size(621, 319);
            this.DynamicProgrammingPanel.TabIndex = 3;
            this.DynamicProgrammingPanel.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(6, 47);
            this.fileNameTextBox.Multiline = true;
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(409, 44);
            this.fileNameTextBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SelectFileFromDiscButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.loadFileButton);
            this.groupBox2.Controls.Add(this.fileNameTextBox);
            this.groupBox2.Location = new System.Drawing.Point(207, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 239);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Load Matrix";
            // 
            // SelectFileFromDiscButton
            // 
            this.SelectFileFromDiscButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectFileFromDiscButton.Location = new System.Drawing.Point(6, 189);
            this.SelectFileFromDiscButton.Name = "SelectFileFromDiscButton";
            this.SelectFileFromDiscButton.Size = new System.Drawing.Size(285, 44);
            this.SelectFileFromDiscButton.TabIndex = 8;
            this.SelectFileFromDiscButton.Text = "Select file from disc";
            this.SelectFileFromDiscButton.UseVisualStyleBackColor = true;
            this.SelectFileFromDiscButton.Click += new System.EventHandler(this.SelectFileFromDiscButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "OR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Insert file path:";
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(290, 97);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(125, 34);
            this.loadFileButton.TabIndex = 5;
            this.loadFileButton.Text = "Load File";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // messageLogTextBox
            // 
            this.messageLogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageLogTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messageLogTextBox.Location = new System.Drawing.Point(634, 12);
            this.messageLogTextBox.Name = "messageLogTextBox";
            this.messageLogTextBox.ReadOnly = true;
            this.messageLogTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.messageLogTextBox.Size = new System.Drawing.Size(504, 507);
            this.messageLogTextBox.TabIndex = 6;
            this.messageLogTextBox.Text = "";
            // 
            // SolvaButton
            // 
            this.SolvaButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SolvaButton.Location = new System.Drawing.Point(634, 525);
            this.SolvaButton.Name = "SolvaButton";
            this.SolvaButton.Size = new System.Drawing.Size(504, 49);
            this.SolvaButton.TabIndex = 7;
            this.SolvaButton.Text = "SOLVE EXAMPLE";
            this.SolvaButton.UseVisualStyleBackColor = true;
            this.SolvaButton.Click += new System.EventHandler(this.SolvaButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1148, 586);
            this.Controls.Add(this.SolvaButton);
            this.Controls.Add(this.messageLogTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DynamicProgrammingPanel);
            this.Controls.Add(this.BruteForcepanel);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.BruteForcepanel.ResumeLayout(false);
            this.BruteForcepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RadioButton BruteForceRadioButton;
        private GroupBox groupBox1;
        private RadioButton DynamicProgrammingRadioButton;
        private RadioButton BranchAndBoundradioButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel BruteForcepanel;
        private Label label1;
        private Panel DynamicProgrammingPanel;
        private BindingSource bindingSource1;
        private OpenFileDialog openFileDialog1;
        private TextBox fileNameTextBox;
        private GroupBox groupBox2;
        private Button SelectFileFromDiscButton;
        private Label label3;
        private Label label2;
        private Button loadFileButton;
        private RichTextBox messageLogTextBox;
        private Button SolvaButton;
    }
}