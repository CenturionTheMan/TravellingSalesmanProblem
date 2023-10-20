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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maxDistanceNumeric = new System.Windows.Forms.NumericUpDown();
            this.vertexAmountNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.minDistanceNumeric = new System.Windows.Forms.NumericUpDown();
            this.generateRandomMatrixButton = new System.Windows.Forms.Button();
            this.showMatrixButton = new System.Windows.Forms.Button();
            this.SelectFileFromDiscButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.messageLogTextBox = new System.Windows.Forms.RichTextBox();
            this.SolvaButton = new System.Windows.Forms.Button();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.BruteForcepanel.SuspendLayout();
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
            this.BruteForceRadioButton.Location = new System.Drawing.Point(7, 29);
            this.BruteForceRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BruteForceRadioButton.Name = "BruteForceRadioButton";
            this.BruteForceRadioButton.Size = new System.Drawing.Size(105, 24);
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
            this.groupBox1.Location = new System.Drawing.Point(8, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(222, 317);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Algorithm";
            // 
            // BranchAndBoundradioButton
            // 
            this.BranchAndBoundradioButton.AutoSize = true;
            this.BranchAndBoundradioButton.Enabled = false;
            this.BranchAndBoundradioButton.Location = new System.Drawing.Point(6, 96);
            this.BranchAndBoundradioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BranchAndBoundradioButton.Name = "BranchAndBoundradioButton";
            this.BranchAndBoundradioButton.Size = new System.Drawing.Size(153, 24);
            this.BranchAndBoundradioButton.TabIndex = 2;
            this.BranchAndBoundradioButton.TabStop = true;
            this.BranchAndBoundradioButton.Text = "Branch And Bound";
            this.BranchAndBoundradioButton.UseVisualStyleBackColor = true;
            // 
            // DynamicProgrammingRadioButton
            // 
            this.DynamicProgrammingRadioButton.AutoSize = true;
            this.DynamicProgrammingRadioButton.Location = new System.Drawing.Point(7, 63);
            this.DynamicProgrammingRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DynamicProgrammingRadioButton.Name = "DynamicProgrammingRadioButton";
            this.DynamicProgrammingRadioButton.Size = new System.Drawing.Size(183, 24);
            this.DynamicProgrammingRadioButton.TabIndex = 1;
            this.DynamicProgrammingRadioButton.TabStop = true;
            this.DynamicProgrammingRadioButton.Text = "Dynamic Programming";
            this.DynamicProgrammingRadioButton.UseVisualStyleBackColor = true;
            this.DynamicProgrammingRadioButton.CheckedChanged += new System.EventHandler(this.DynamicProgrammingRadioButton_CheckedChanged);
            // 
            // BruteForcepanel
            // 
            this.BruteForcepanel.Controls.Add(this.label1);
            this.BruteForcepanel.Location = new System.Drawing.Point(8, 336);
            this.BruteForcepanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BruteForcepanel.Name = "BruteForcepanel";
            this.BruteForcepanel.Size = new System.Drawing.Size(710, 429);
            this.BruteForcepanel.TabIndex = 2;
            this.BruteForcepanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "No settings to change";
            // 
            // DynamicProgrammingPanel
            // 
            this.DynamicProgrammingPanel.Location = new System.Drawing.Point(8, 336);
            this.DynamicProgrammingPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DynamicProgrammingPanel.Name = "DynamicProgrammingPanel";
            this.DynamicProgrammingPanel.Size = new System.Drawing.Size(710, 425);
            this.DynamicProgrammingPanel.TabIndex = 3;
            this.DynamicProgrammingPanel.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(150, 63);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileNameTextBox.Multiline = true;
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(324, 39);
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
            this.groupBox2.Location = new System.Drawing.Point(237, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(481, 319);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Matrix";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.maxDistanceNumeric);
            this.groupBox3.Controls.Add(this.vertexAmountNumeric);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.minDistanceNumeric);
            this.groupBox3.Controls.Add(this.generateRandomMatrixButton);
            this.groupBox3.Location = new System.Drawing.Point(5, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 203);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Random Matrix";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Min Distance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Max Distance";
            // 
            // maxDistanceNumeric
            // 
            this.maxDistanceNumeric.Location = new System.Drawing.Point(1, 170);
            this.maxDistanceNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maxDistanceNumeric.Name = "maxDistanceNumeric";
            this.maxDistanceNumeric.Size = new System.Drawing.Size(150, 27);
            this.maxDistanceNumeric.TabIndex = 14;
            this.maxDistanceNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // vertexAmountNumeric
            // 
            this.vertexAmountNumeric.Location = new System.Drawing.Point(0, 64);
            this.vertexAmountNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.vertexAmountNumeric.Name = "vertexAmountNumeric";
            this.vertexAmountNumeric.Size = new System.Drawing.Size(150, 27);
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
            this.label4.Location = new System.Drawing.Point(0, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Vertex Amount";
            // 
            // minDistanceNumeric
            // 
            this.minDistanceNumeric.Location = new System.Drawing.Point(0, 117);
            this.minDistanceNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.minDistanceNumeric.Name = "minDistanceNumeric";
            this.minDistanceNumeric.Size = new System.Drawing.Size(150, 27);
            this.minDistanceNumeric.TabIndex = 11;
            this.minDistanceNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // generateRandomMatrixButton
            // 
            this.generateRandomMatrixButton.Location = new System.Drawing.Point(176, 94);
            this.generateRandomMatrixButton.Name = "generateRandomMatrixButton";
            this.generateRandomMatrixButton.Size = new System.Drawing.Size(94, 109);
            this.generateRandomMatrixButton.TabIndex = 10;
            this.generateRandomMatrixButton.Text = "Generate Random Matrix";
            this.generateRandomMatrixButton.UseVisualStyleBackColor = true;
            this.generateRandomMatrixButton.Click += new System.EventHandler(this.generateRandomMatrixButton_Click);
            // 
            // showMatrixButton
            // 
            this.showMatrixButton.Location = new System.Drawing.Point(320, 176);
            this.showMatrixButton.Name = "showMatrixButton";
            this.showMatrixButton.Size = new System.Drawing.Size(154, 136);
            this.showMatrixButton.TabIndex = 9;
            this.showMatrixButton.Text = "Show Matrix";
            this.showMatrixButton.UseVisualStyleBackColor = true;
            this.showMatrixButton.Click += new System.EventHandler(this.showMatrixButton_Click);
            // 
            // SelectFileFromDiscButton
            // 
            this.SelectFileFromDiscButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectFileFromDiscButton.Location = new System.Drawing.Point(-1, 29);
            this.SelectFileFromDiscButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SelectFileFromDiscButton.Name = "SelectFileFromDiscButton";
            this.SelectFileFromDiscButton.Size = new System.Drawing.Size(100, 73);
            this.SelectFileFromDiscButton.TabIndex = 8;
            this.SelectFileFromDiscButton.Text = "Select file from disc";
            this.SelectFileFromDiscButton.UseVisualStyleBackColor = true;
            this.SelectFileFromDiscButton.Click += new System.EventHandler(this.SelectFileFromDiscButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(105, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "OR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Insert file path:";
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(320, 109);
            this.loadFileButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(154, 28);
            this.loadFileButton.TabIndex = 5;
            this.loadFileButton.Text = "Load File From Path";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // messageLogTextBox
            // 
            this.messageLogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageLogTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messageLogTextBox.HideSelection = false;
            this.messageLogTextBox.Location = new System.Drawing.Point(725, 16);
            this.messageLogTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.messageLogTextBox.Name = "messageLogTextBox";
            this.messageLogTextBox.ReadOnly = true;
            this.messageLogTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.messageLogTextBox.ShortcutsEnabled = false;
            this.messageLogTextBox.Size = new System.Drawing.Size(575, 675);
            this.messageLogTextBox.TabIndex = 6;
            this.messageLogTextBox.Text = "";
            this.messageLogTextBox.VisibleChanged += new System.EventHandler(this.messageLogTextBox_VisibleChanged);
            // 
            // SolvaButton
            // 
            this.SolvaButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SolvaButton.Location = new System.Drawing.Point(725, 700);
            this.SolvaButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SolvaButton.Name = "SolvaButton";
            this.SolvaButton.Size = new System.Drawing.Size(576, 65);
            this.SolvaButton.TabIndex = 7;
            this.SolvaButton.Text = "SOLVE EXAMPLE";
            this.SolvaButton.UseVisualStyleBackColor = true;
            this.SolvaButton.Click += new System.EventHandler(this.SolvaButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1312, 781);
            this.Controls.Add(this.SolvaButton);
            this.Controls.Add(this.messageLogTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DynamicProgrammingPanel);
            this.Controls.Add(this.BruteForcepanel);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
    }
}