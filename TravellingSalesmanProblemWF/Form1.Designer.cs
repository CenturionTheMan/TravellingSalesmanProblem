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
            this.algorithmSettingsButton = new System.Windows.Forms.Button();
            this.BranchAndBoundradioButton = new System.Windows.Forms.RadioButton();
            this.DynamicProgrammingRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.generateRandomMatrixButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maxDistanceNumeric = new System.Windows.Forms.NumericUpDown();
            this.vertexAmountNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.minDistanceNumeric = new System.Windows.Forms.NumericUpDown();
            this.showMatrixButton = new System.Windows.Forms.Button();
            this.SelectFileFromDiscButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.messageLogTextBox = new System.Windows.Forms.RichTextBox();
            this.SolvaButton = new System.Windows.Forms.Button();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.stopButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDistanceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertexAmountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDistanceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
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
            this.groupBox1.Controls.Add(this.algorithmSettingsButton);
            this.groupBox1.Controls.Add(this.BranchAndBoundradioButton);
            this.groupBox1.Controls.Add(this.DynamicProgrammingRadioButton);
            this.groupBox1.Controls.Add(this.BruteForceRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(7, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 225);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Algorithm";
            // 
            // algorithmSettingsButton
            // 
            this.algorithmSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(153)))), ((int)(((byte)(126)))));
            this.algorithmSettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.algorithmSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.algorithmSettingsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.algorithmSettingsButton.Location = new System.Drawing.Point(274, 160);
            this.algorithmSettingsButton.Name = "algorithmSettingsButton";
            this.algorithmSettingsButton.Size = new System.Drawing.Size(135, 59);
            this.algorithmSettingsButton.TabIndex = 9;
            this.algorithmSettingsButton.Text = "Algorithm Settings";
            this.algorithmSettingsButton.UseVisualStyleBackColor = false;
            this.algorithmSettingsButton.Click += new System.EventHandler(this.algorithmSettingsButton_Click);
            // 
            // BranchAndBoundradioButton
            // 
            this.BranchAndBoundradioButton.AutoSize = true;
            this.BranchAndBoundradioButton.Location = new System.Drawing.Point(5, 72);
            this.BranchAndBoundradioButton.Name = "BranchAndBoundradioButton";
            this.BranchAndBoundradioButton.Size = new System.Drawing.Size(125, 19);
            this.BranchAndBoundradioButton.TabIndex = 2;
            this.BranchAndBoundradioButton.TabStop = true;
            this.BranchAndBoundradioButton.Text = "Branch And Bound";
            this.BranchAndBoundradioButton.UseVisualStyleBackColor = true;
            this.BranchAndBoundradioButton.CheckedChanged += new System.EventHandler(this.BranchAndBoundradioButton_CheckedChanged);
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(230)))));
            this.fileNameTextBox.Location = new System.Drawing.Point(131, 47);
            this.fileNameTextBox.Multiline = true;
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(284, 30);
            this.fileNameTextBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.showMatrixButton);
            this.groupBox2.Controls.Add(this.SelectFileFromDiscButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.loadFileButton);
            this.groupBox2.Controls.Add(this.fileNameTextBox);
            this.groupBox2.Location = new System.Drawing.Point(7, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 239);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Matrix";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.generateRandomMatrixButton);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.maxDistanceNumeric);
            this.groupBox3.Controls.Add(this.vertexAmountNumeric);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.minDistanceNumeric);
            this.groupBox3.Location = new System.Drawing.Point(4, 82);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(257, 152);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Random Matrix";
            // 
            // generateRandomMatrixButton
            // 
            this.generateRandomMatrixButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(153)))), ((int)(((byte)(126)))));
            this.generateRandomMatrixButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.generateRandomMatrixButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateRandomMatrixButton.Location = new System.Drawing.Point(138, 68);
            this.generateRandomMatrixButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generateRandomMatrixButton.Name = "generateRandomMatrixButton";
            this.generateRandomMatrixButton.Size = new System.Drawing.Size(116, 82);
            this.generateRandomMatrixButton.TabIndex = 10;
            this.generateRandomMatrixButton.Text = "Generate Random Matrix";
            this.generateRandomMatrixButton.UseVisualStyleBackColor = false;
            this.generateRandomMatrixButton.Click += new System.EventHandler(this.generateRandomMatrixButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Min Distance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Max Distance";
            // 
            // maxDistanceNumeric
            // 
            this.maxDistanceNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(230)))));
            this.maxDistanceNumeric.Location = new System.Drawing.Point(0, 127);
            this.maxDistanceNumeric.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxDistanceNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maxDistanceNumeric.Name = "maxDistanceNumeric";
            this.maxDistanceNumeric.Size = new System.Drawing.Size(131, 23);
            this.maxDistanceNumeric.TabIndex = 14;
            this.maxDistanceNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // vertexAmountNumeric
            // 
            this.vertexAmountNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(230)))));
            this.vertexAmountNumeric.Location = new System.Drawing.Point(1, 45);
            this.vertexAmountNumeric.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vertexAmountNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.vertexAmountNumeric.Name = "vertexAmountNumeric";
            this.vertexAmountNumeric.Size = new System.Drawing.Size(131, 23);
            this.vertexAmountNumeric.TabIndex = 13;
            this.vertexAmountNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Vertex Amount";
            // 
            // minDistanceNumeric
            // 
            this.minDistanceNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(230)))));
            this.minDistanceNumeric.Location = new System.Drawing.Point(0, 87);
            this.minDistanceNumeric.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minDistanceNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.minDistanceNumeric.Name = "minDistanceNumeric";
            this.minDistanceNumeric.Size = new System.Drawing.Size(131, 23);
            this.minDistanceNumeric.TabIndex = 11;
            this.minDistanceNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // showMatrixButton
            // 
            this.showMatrixButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(153)))), ((int)(((byte)(126)))));
            this.showMatrixButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.showMatrixButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showMatrixButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.showMatrixButton.Location = new System.Drawing.Point(280, 130);
            this.showMatrixButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showMatrixButton.Name = "showMatrixButton";
            this.showMatrixButton.Size = new System.Drawing.Size(135, 104);
            this.showMatrixButton.TabIndex = 9;
            this.showMatrixButton.Text = "Show Matrix";
            this.showMatrixButton.UseVisualStyleBackColor = false;
            this.showMatrixButton.Click += new System.EventHandler(this.showMatrixButton_Click);
            // 
            // SelectFileFromDiscButton
            // 
            this.SelectFileFromDiscButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(153)))), ((int)(((byte)(126)))));
            this.SelectFileFromDiscButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SelectFileFromDiscButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectFileFromDiscButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectFileFromDiscButton.Location = new System.Drawing.Point(0, 22);
            this.SelectFileFromDiscButton.Name = "SelectFileFromDiscButton";
            this.SelectFileFromDiscButton.Size = new System.Drawing.Size(88, 55);
            this.SelectFileFromDiscButton.TabIndex = 8;
            this.SelectFileFromDiscButton.Text = "Select file from disc";
            this.SelectFileFromDiscButton.UseVisualStyleBackColor = false;
            this.SelectFileFromDiscButton.Click += new System.EventHandler(this.SelectFileFromDiscButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(94, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "OR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Insert file path:";
            // 
            // loadFileButton
            // 
            this.loadFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(153)))), ((int)(((byte)(126)))));
            this.loadFileButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.loadFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadFileButton.Location = new System.Drawing.Point(280, 82);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(135, 31);
            this.loadFileButton.TabIndex = 5;
            this.loadFileButton.Text = "Load File From Path";
            this.loadFileButton.UseVisualStyleBackColor = false;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // messageLogTextBox
            // 
            this.messageLogTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(230)))));
            this.messageLogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageLogTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messageLogTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.messageLogTextBox.HideSelection = false;
            this.messageLogTextBox.Location = new System.Drawing.Point(434, 12);
            this.messageLogTextBox.Name = "messageLogTextBox";
            this.messageLogTextBox.ReadOnly = true;
            this.messageLogTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.messageLogTextBox.ShortcutsEnabled = false;
            this.messageLogTextBox.Size = new System.Drawing.Size(504, 415);
            this.messageLogTextBox.TabIndex = 6;
            this.messageLogTextBox.Text = "";
            this.messageLogTextBox.VisibleChanged += new System.EventHandler(this.messageLogTextBox_VisibleChanged);
            // 
            // SolvaButton
            // 
            this.SolvaButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(141)))));
            this.SolvaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SolvaButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SolvaButton.Location = new System.Drawing.Point(562, 433);
            this.SolvaButton.Name = "SolvaButton";
            this.SolvaButton.Size = new System.Drawing.Size(376, 49);
            this.SolvaButton.TabIndex = 7;
            this.SolvaButton.Text = "SOLVE EXAMPLE";
            this.SolvaButton.UseVisualStyleBackColor = false;
            this.SolvaButton.Click += new System.EventHandler(this.SolvaButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.stopButton.Enabled = false;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.stopButton.Location = new System.Drawing.Point(434, 434);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(122, 48);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(949, 493);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.SolvaButton);
            this.Controls.Add(this.messageLogTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSP SOLVER";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDistanceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vertexAmountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDistanceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RadioButton BruteForceRadioButton;
        private GroupBox groupBox1;
        private RadioButton DynamicProgrammingRadioButton;
        private RadioButton BranchAndBoundradioButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
        private Button showMatrixButton;
        private Button generateRandomMatrixButton;
        private GroupBox groupBox3;
        private Label label6;
        private Label label5;
        private NumericUpDown maxDistanceNumeric;
        private NumericUpDown vertexAmountNumeric;
        private Label label4;
        private NumericUpDown minDistanceNumeric;
        private BindingSource bindingSource2;
        private Button stopButton;
        private Button algorithmSettingsButton;
    }
}