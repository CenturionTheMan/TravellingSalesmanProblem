namespace TravellingSalesmanProblemWF
{
    partial class PopupSettingsForGAForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            closeButton = new Button();
            label1 = new Label();
            popu = new Label();
            label3 = new Label();
            label5 = new Label();
            CrossChanceUpDown = new NumericUpDown();
            PopulationNumericUpDown = new NumericUpDown();
            CostRepAmountNumericUpDown = new NumericUpDown();
            MutationChanceUpDown = new NumericUpDown();
            label4 = new Label();
            CrossoverComboBox = new ComboBox();
            label6 = new Label();
            MutationTypeComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)CrossChanceUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PopulationNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CostRepAmountNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MutationChanceUpDown).BeginInit();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(165, 165, 141);
            closeButton.FlatAppearance.BorderColor = Color.Black;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            closeButton.Location = new Point(232, 258);
            closeButton.Margin = new Padding(2);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(168, 38);
            closeButton.TabIndex = 0;
            closeButton.Text = "Save and Close";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 86);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 1;
            label1.Text = "Cross chance:";
            // 
            // popu
            // 
            popu.AutoSize = true;
            popu.Location = new Point(18, 16);
            popu.Margin = new Padding(2, 0, 2, 0);
            popu.Name = "popu";
            popu.Size = new Size(112, 20);
            popu.TabIndex = 2;
            popu.Text = "Population size:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 120);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 3;
            label3.Text = "Mutation type:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 188);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(215, 20);
            label5.TabIndex = 5;
            label5.Text = "Cost repeats amount until stop:";
            // 
            // CrossChanceUpDown
            // 
            CrossChanceUpDown.DecimalPlaces = 2;
            CrossChanceUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            CrossChanceUpDown.Location = new Point(256, 84);
            CrossChanceUpDown.Margin = new Padding(2);
            CrossChanceUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            CrossChanceUpDown.Name = "CrossChanceUpDown";
            CrossChanceUpDown.Size = new Size(144, 27);
            CrossChanceUpDown.TabIndex = 6;
            CrossChanceUpDown.Value = new decimal(new int[] { 8, 0, 0, 65536 });
            CrossChanceUpDown.ValueChanged += CrossChanceUpDown_ValueChanged;
            // 
            // PopulationNumericUpDown
            // 
            PopulationNumericUpDown.Location = new Point(256, 14);
            PopulationNumericUpDown.Margin = new Padding(2);
            PopulationNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            PopulationNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PopulationNumericUpDown.Name = "PopulationNumericUpDown";
            PopulationNumericUpDown.Size = new Size(144, 27);
            PopulationNumericUpDown.TabIndex = 7;
            PopulationNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            PopulationNumericUpDown.ValueChanged += PopulationNumericUpDown_ValueChanged;
            // 
            // CostRepAmountNumericUpDown
            // 
            CostRepAmountNumericUpDown.Location = new Point(256, 185);
            CostRepAmountNumericUpDown.Margin = new Padding(2);
            CostRepAmountNumericUpDown.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            CostRepAmountNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            CostRepAmountNumericUpDown.Name = "CostRepAmountNumericUpDown";
            CostRepAmountNumericUpDown.Size = new Size(144, 27);
            CostRepAmountNumericUpDown.TabIndex = 9;
            CostRepAmountNumericUpDown.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            CostRepAmountNumericUpDown.ValueChanged += CostRepAmountNumericUpDown_ValueChanged_1;
            // 
            // MutationChanceUpDown
            // 
            MutationChanceUpDown.DecimalPlaces = 3;
            MutationChanceUpDown.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            MutationChanceUpDown.Location = new Point(256, 151);
            MutationChanceUpDown.Margin = new Padding(2);
            MutationChanceUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            MutationChanceUpDown.Name = "MutationChanceUpDown";
            MutationChanceUpDown.Size = new Size(144, 27);
            MutationChanceUpDown.TabIndex = 11;
            MutationChanceUpDown.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            MutationChanceUpDown.ValueChanged += MutationChanceUpDown_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 154);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 10;
            label4.Text = "Mutation chance:";
            // 
            // CrossoverComboBox
            // 
            CrossoverComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CrossoverComboBox.FormattingEnabled = true;
            CrossoverComboBox.Location = new Point(256, 49);
            CrossoverComboBox.Margin = new Padding(4);
            CrossoverComboBox.Name = "CrossoverComboBox";
            CrossoverComboBox.Size = new Size(143, 28);
            CrossoverComboBox.TabIndex = 12;
            CrossoverComboBox.SelectedIndexChanged += CrossoverComboBox_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 52);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 13;
            label6.Text = "Crossover type:";
            // 
            // MutationTypeComboBox
            // 
            MutationTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MutationTypeComboBox.FormattingEnabled = true;
            MutationTypeComboBox.Location = new Point(256, 117);
            MutationTypeComboBox.Margin = new Padding(4);
            MutationTypeComboBox.Name = "MutationTypeComboBox";
            MutationTypeComboBox.Size = new Size(143, 28);
            MutationTypeComboBox.TabIndex = 14;
            MutationTypeComboBox.SelectedIndexChanged += MutationTypeComboBox_SelectedIndexChanged_1;
            // 
            // PopupSettingsForGAForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(237, 220, 210);
            ClientSize = new Size(434, 309);
            Controls.Add(MutationTypeComboBox);
            Controls.Add(label6);
            Controls.Add(CrossoverComboBox);
            Controls.Add(MutationChanceUpDown);
            Controls.Add(label4);
            Controls.Add(CostRepAmountNumericUpDown);
            Controls.Add(PopulationNumericUpDown);
            Controls.Add(CrossChanceUpDown);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(popu);
            Controls.Add(label1);
            Controls.Add(closeButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PopupSettingsForGAForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings for Simulated Annealing";
            TopMost = true;
            FormClosing += PopupSettingsForSAForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)CrossChanceUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)PopulationNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CostRepAmountNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)MutationChanceUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeButton;
        private Label label1;
        private Label popu;
        private Label label3;
        private Label label5;
        private NumericUpDown CrossChanceUpDown;
        private NumericUpDown PopulationNumericUpDown;
        private NumericUpDown CostRepAmountNumericUpDown;
        private NumericUpDown MutationChanceUpDown;
        private Label label4;
        private ComboBox CrossoverComboBox;
        private Label label6;
        private ComboBox MutationTypeComboBox;
    }
}