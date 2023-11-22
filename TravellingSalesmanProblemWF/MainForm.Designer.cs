namespace TravellingSalesmanProblemWF
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            BruteForceRadioButton = new RadioButton();
            groupBox1 = new GroupBox();
            algorithmSettingsButton = new Button();
            BranchAndBoundradioButton = new RadioButton();
            DynamicProgrammingRadioButton = new RadioButton();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            bindingSource1 = new BindingSource(components);
            openFileDialog1 = new OpenFileDialog();
            fileNameTextBox = new TextBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            generateRandomMatrixButton = new Button();
            label6 = new Label();
            label5 = new Label();
            maxDistanceNumeric = new NumericUpDown();
            vertexAmountNumeric = new NumericUpDown();
            label4 = new Label();
            minDistanceNumeric = new NumericUpDown();
            showMatrixButton = new Button();
            SelectFileFromDiscButton = new Button();
            label3 = new Label();
            label2 = new Label();
            loadFileButton = new Button();
            messageLogTextBox = new RichTextBox();
            SolvaButton = new Button();
            bindingSource2 = new BindingSource(components);
            stopButton = new Button();
            SimulatedAnnealingRadioButton = new RadioButton();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)maxDistanceNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vertexAmountNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minDistanceNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            SuspendLayout();
            // 
            // BruteForceRadioButton
            // 
            BruteForceRadioButton.AutoSize = true;
            BruteForceRadioButton.Location = new Point(6, 22);
            BruteForceRadioButton.Name = "BruteForceRadioButton";
            BruteForceRadioButton.Size = new Size(85, 19);
            BruteForceRadioButton.TabIndex = 0;
            BruteForceRadioButton.TabStop = true;
            BruteForceRadioButton.Text = "Brute Force";
            BruteForceRadioButton.UseVisualStyleBackColor = true;
            BruteForceRadioButton.CheckedChanged += BruteForceRadioButton_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(SimulatedAnnealingRadioButton);
            groupBox1.Controls.Add(algorithmSettingsButton);
            groupBox1.Controls.Add(BranchAndBoundradioButton);
            groupBox1.Controls.Add(DynamicProgrammingRadioButton);
            groupBox1.Controls.Add(BruteForceRadioButton);
            groupBox1.Location = new Point(7, 257);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(415, 225);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Algorithm";
            // 
            // algorithmSettingsButton
            // 
            algorithmSettingsButton.BackColor = Color.FromArgb(203, 153, 126);
            algorithmSettingsButton.FlatAppearance.BorderColor = Color.White;
            algorithmSettingsButton.FlatStyle = FlatStyle.Flat;
            algorithmSettingsButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            algorithmSettingsButton.Location = new Point(274, 160);
            algorithmSettingsButton.Name = "algorithmSettingsButton";
            algorithmSettingsButton.Size = new Size(135, 59);
            algorithmSettingsButton.TabIndex = 9;
            algorithmSettingsButton.Text = "Algorithm Settings";
            algorithmSettingsButton.UseVisualStyleBackColor = false;
            algorithmSettingsButton.Click += algorithmSettingsButton_Click;
            // 
            // BranchAndBoundradioButton
            // 
            BranchAndBoundradioButton.AutoSize = true;
            BranchAndBoundradioButton.Location = new Point(5, 72);
            BranchAndBoundradioButton.Name = "BranchAndBoundradioButton";
            BranchAndBoundradioButton.Size = new Size(125, 19);
            BranchAndBoundradioButton.TabIndex = 2;
            BranchAndBoundradioButton.TabStop = true;
            BranchAndBoundradioButton.Text = "Branch And Bound";
            BranchAndBoundradioButton.UseVisualStyleBackColor = true;
            BranchAndBoundradioButton.CheckedChanged += BranchAndBoundradioButton_CheckedChanged;
            // 
            // DynamicProgrammingRadioButton
            // 
            DynamicProgrammingRadioButton.AutoSize = true;
            DynamicProgrammingRadioButton.Location = new Point(6, 47);
            DynamicProgrammingRadioButton.Name = "DynamicProgrammingRadioButton";
            DynamicProgrammingRadioButton.Size = new Size(149, 19);
            DynamicProgrammingRadioButton.TabIndex = 1;
            DynamicProgrammingRadioButton.TabStop = true;
            DynamicProgrammingRadioButton.Text = "Dynamic Programming";
            DynamicProgrammingRadioButton.UseVisualStyleBackColor = true;
            DynamicProgrammingRadioButton.CheckedChanged += DynamicProgrammingRadioButton_CheckedChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.BackColor = Color.FromArgb(255, 241, 230);
            fileNameTextBox.Location = new Point(131, 47);
            fileNameTextBox.Multiline = true;
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.Size = new Size(284, 30);
            fileNameTextBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(showMatrixButton);
            groupBox2.Controls.Add(SelectFileFromDiscButton);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(loadFileButton);
            groupBox2.Controls.Add(fileNameTextBox);
            groupBox2.Location = new Point(7, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(421, 239);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Matrix";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(generateRandomMatrixButton);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(maxDistanceNumeric);
            groupBox3.Controls.Add(vertexAmountNumeric);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(minDistanceNumeric);
            groupBox3.Location = new Point(4, 82);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(257, 152);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Random Matrix";
            // 
            // generateRandomMatrixButton
            // 
            generateRandomMatrixButton.BackColor = Color.FromArgb(203, 153, 126);
            generateRandomMatrixButton.FlatAppearance.BorderColor = Color.White;
            generateRandomMatrixButton.FlatStyle = FlatStyle.Flat;
            generateRandomMatrixButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            generateRandomMatrixButton.Location = new Point(138, 68);
            generateRandomMatrixButton.Margin = new Padding(3, 2, 3, 2);
            generateRandomMatrixButton.Name = "generateRandomMatrixButton";
            generateRandomMatrixButton.Size = new Size(116, 82);
            generateRandomMatrixButton.TabIndex = 10;
            generateRandomMatrixButton.Text = "Generate Random Matrix";
            generateRandomMatrixButton.UseVisualStyleBackColor = false;
            generateRandomMatrixButton.Click += generateRandomMatrixButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 70);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 16;
            label6.Text = "Min Distance";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(0, 110);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 15;
            label5.Text = "Max Distance";
            // 
            // maxDistanceNumeric
            // 
            maxDistanceNumeric.BackColor = Color.FromArgb(255, 241, 230);
            maxDistanceNumeric.Location = new Point(0, 127);
            maxDistanceNumeric.Margin = new Padding(3, 2, 3, 2);
            maxDistanceNumeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            maxDistanceNumeric.Name = "maxDistanceNumeric";
            maxDistanceNumeric.Size = new Size(131, 23);
            maxDistanceNumeric.TabIndex = 14;
            maxDistanceNumeric.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // vertexAmountNumeric
            // 
            vertexAmountNumeric.BackColor = Color.FromArgb(255, 241, 230);
            vertexAmountNumeric.Location = new Point(1, 45);
            vertexAmountNumeric.Margin = new Padding(3, 2, 3, 2);
            vertexAmountNumeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            vertexAmountNumeric.Name = "vertexAmountNumeric";
            vertexAmountNumeric.Size = new Size(131, 23);
            vertexAmountNumeric.TabIndex = 13;
            vertexAmountNumeric.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1, 28);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 12;
            label4.Text = "Vertex Amount";
            // 
            // minDistanceNumeric
            // 
            minDistanceNumeric.BackColor = Color.FromArgb(255, 241, 230);
            minDistanceNumeric.Location = new Point(0, 87);
            minDistanceNumeric.Margin = new Padding(3, 2, 3, 2);
            minDistanceNumeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            minDistanceNumeric.Name = "minDistanceNumeric";
            minDistanceNumeric.Size = new Size(131, 23);
            minDistanceNumeric.TabIndex = 11;
            minDistanceNumeric.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // showMatrixButton
            // 
            showMatrixButton.BackColor = Color.FromArgb(203, 153, 126);
            showMatrixButton.FlatAppearance.BorderColor = Color.White;
            showMatrixButton.FlatStyle = FlatStyle.Flat;
            showMatrixButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            showMatrixButton.Location = new Point(280, 130);
            showMatrixButton.Margin = new Padding(3, 2, 3, 2);
            showMatrixButton.Name = "showMatrixButton";
            showMatrixButton.Size = new Size(135, 104);
            showMatrixButton.TabIndex = 9;
            showMatrixButton.Text = "Show Matrix";
            showMatrixButton.UseVisualStyleBackColor = false;
            showMatrixButton.Click += showMatrixButton_Click;
            // 
            // SelectFileFromDiscButton
            // 
            SelectFileFromDiscButton.BackColor = Color.FromArgb(203, 153, 126);
            SelectFileFromDiscButton.FlatAppearance.BorderColor = Color.White;
            SelectFileFromDiscButton.FlatStyle = FlatStyle.Flat;
            SelectFileFromDiscButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            SelectFileFromDiscButton.Location = new Point(0, 22);
            SelectFileFromDiscButton.Name = "SelectFileFromDiscButton";
            SelectFileFromDiscButton.Size = new Size(88, 55);
            SelectFileFromDiscButton.TabIndex = 8;
            SelectFileFromDiscButton.Text = "Select file from disc";
            SelectFileFromDiscButton.UseVisualStyleBackColor = false;
            SelectFileFromDiscButton.Click += SelectFileFromDiscButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(94, 56);
            label3.Name = "label3";
            label3.Size = new Size(32, 21);
            label3.TabIndex = 7;
            label3.Text = "OR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 29);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 6;
            label2.Text = "Insert file path:";
            // 
            // loadFileButton
            // 
            loadFileButton.BackColor = Color.FromArgb(203, 153, 126);
            loadFileButton.FlatAppearance.BorderColor = Color.White;
            loadFileButton.FlatStyle = FlatStyle.Flat;
            loadFileButton.Location = new Point(280, 82);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(135, 31);
            loadFileButton.TabIndex = 5;
            loadFileButton.Text = "Load File From Path";
            loadFileButton.UseVisualStyleBackColor = false;
            loadFileButton.Click += loadFileButton_Click;
            // 
            // messageLogTextBox
            // 
            messageLogTextBox.BackColor = Color.FromArgb(255, 241, 230);
            messageLogTextBox.BorderStyle = BorderStyle.FixedSingle;
            messageLogTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            messageLogTextBox.ForeColor = SystemColors.WindowText;
            messageLogTextBox.HideSelection = false;
            messageLogTextBox.Location = new Point(434, 12);
            messageLogTextBox.Name = "messageLogTextBox";
            messageLogTextBox.ReadOnly = true;
            messageLogTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            messageLogTextBox.ShortcutsEnabled = false;
            messageLogTextBox.Size = new Size(504, 415);
            messageLogTextBox.TabIndex = 6;
            messageLogTextBox.Text = "";
            messageLogTextBox.VisibleChanged += messageLogTextBox_VisibleChanged;
            // 
            // SolvaButton
            // 
            SolvaButton.BackColor = Color.FromArgb(165, 165, 141);
            SolvaButton.FlatStyle = FlatStyle.Flat;
            SolvaButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            SolvaButton.Location = new Point(562, 433);
            SolvaButton.Name = "SolvaButton";
            SolvaButton.Size = new Size(376, 49);
            SolvaButton.TabIndex = 7;
            SolvaButton.Text = "SOLVE EXAMPLE";
            SolvaButton.UseVisualStyleBackColor = false;
            SolvaButton.Click += SolvaButton_Click;
            // 
            // stopButton
            // 
            stopButton.BackColor = Color.FromArgb(183, 183, 164);
            stopButton.Enabled = false;
            stopButton.FlatStyle = FlatStyle.Flat;
            stopButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            stopButton.Location = new Point(434, 434);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(122, 48);
            stopButton.TabIndex = 8;
            stopButton.Text = "STOP";
            stopButton.UseVisualStyleBackColor = false;
            stopButton.Click += stopButton_Click;
            // 
            // SimulatedAnnealingRadioButton
            // 
            SimulatedAnnealingRadioButton.AutoSize = true;
            SimulatedAnnealingRadioButton.Location = new Point(4, 97);
            SimulatedAnnealingRadioButton.Name = "SimulatedAnnealingRadioButton";
            SimulatedAnnealingRadioButton.Size = new Size(135, 19);
            SimulatedAnnealingRadioButton.TabIndex = 10;
            SimulatedAnnealingRadioButton.TabStop = true;
            SimulatedAnnealingRadioButton.Text = "Simulated Annealing";
            SimulatedAnnealingRadioButton.UseVisualStyleBackColor = true;
            SimulatedAnnealingRadioButton.CheckedChanged += SimulatedAnnealingRadioButton_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(237, 220, 210);
            ClientSize = new Size(949, 493);
            Controls.Add(stopButton);
            Controls.Add(SolvaButton);
            Controls.Add(messageLogTextBox);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TSP SOLVER";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)maxDistanceNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)vertexAmountNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)minDistanceNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ResumeLayout(false);
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
        private RadioButton SimulatedAnnealingRadioButton;
    }
}