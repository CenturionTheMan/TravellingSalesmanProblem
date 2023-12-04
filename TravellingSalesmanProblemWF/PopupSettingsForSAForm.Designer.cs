namespace TravellingSalesmanProblemWF
{
    partial class PopupSettingsForSAForm
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
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            AlphaNumericUpDown = new NumericUpDown();
            TemperatureNumericUpDown = new NumericUpDown();
            RepAmountPerTempNumericUpDown = new NumericUpDown();
            CostRepAmountNumericUpDown = new NumericUpDown();
            RepInNeighbourhoodNumericUpDown = new NumericUpDown();
            label4 = new Label();
            CoolingTypeComboBox = new ComboBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)AlphaNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TemperatureNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RepAmountPerTempNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CostRepAmountNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RepInNeighbourhoodNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(165, 165, 141);
            closeButton.FlatAppearance.BorderColor = Color.Black;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            closeButton.Location = new Point(186, 206);
            closeButton.Margin = new Padding(2);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(134, 30);
            closeButton.TabIndex = 0;
            closeButton.Text = "Save and Close";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 69);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 1;
            label1.Text = "Alpha factor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 13);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 2;
            label2.Text = "Initial temperature:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 96);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 3;
            label3.Text = "Reps per epoch:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 150);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(173, 15);
            label5.TabIndex = 5;
            label5.Text = "Cost repeats amount until stop:";
            // 
            // AlphaNumericUpDown
            // 
            AlphaNumericUpDown.DecimalPlaces = 4;
            AlphaNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            AlphaNumericUpDown.Location = new Point(205, 67);
            AlphaNumericUpDown.Margin = new Padding(2);
            AlphaNumericUpDown.Maximum = new decimal(new int[] { 9999, 0, 0, 262144 });
            AlphaNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            AlphaNumericUpDown.Name = "AlphaNumericUpDown";
            AlphaNumericUpDown.Size = new Size(115, 23);
            AlphaNumericUpDown.TabIndex = 6;
            AlphaNumericUpDown.Value = new decimal(new int[] { 99, 0, 0, 131072 });
            AlphaNumericUpDown.ValueChanged += AlphaNumericUpDown_ValueChanged;
            // 
            // TemperatureNumericUpDown
            // 
            TemperatureNumericUpDown.Location = new Point(205, 11);
            TemperatureNumericUpDown.Margin = new Padding(2);
            TemperatureNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            TemperatureNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            TemperatureNumericUpDown.Name = "TemperatureNumericUpDown";
            TemperatureNumericUpDown.Size = new Size(115, 23);
            TemperatureNumericUpDown.TabIndex = 7;
            TemperatureNumericUpDown.Value = new decimal(new int[] { 500, 0, 0, 0 });
            TemperatureNumericUpDown.ValueChanged += TemperatureNumericUpDown_ValueChanged;
            // 
            // RepAmountPerTempNumericUpDown
            // 
            RepAmountPerTempNumericUpDown.Location = new Point(205, 94);
            RepAmountPerTempNumericUpDown.Margin = new Padding(2);
            RepAmountPerTempNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            RepAmountPerTempNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RepAmountPerTempNumericUpDown.Name = "RepAmountPerTempNumericUpDown";
            RepAmountPerTempNumericUpDown.Size = new Size(115, 23);
            RepAmountPerTempNumericUpDown.TabIndex = 8;
            RepAmountPerTempNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            RepAmountPerTempNumericUpDown.ValueChanged += RepAmountPerTempNumericUpDown_ValueChanged;
            // 
            // CostRepAmountNumericUpDown
            // 
            CostRepAmountNumericUpDown.Location = new Point(205, 148);
            CostRepAmountNumericUpDown.Margin = new Padding(2);
            CostRepAmountNumericUpDown.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            CostRepAmountNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            CostRepAmountNumericUpDown.Name = "CostRepAmountNumericUpDown";
            CostRepAmountNumericUpDown.Size = new Size(115, 23);
            CostRepAmountNumericUpDown.TabIndex = 9;
            CostRepAmountNumericUpDown.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            CostRepAmountNumericUpDown.ValueChanged += CostRepAmountNumericUpDown_ValueChanged;
            // 
            // RepInNeighbourhoodNumericUpDown
            // 
            RepInNeighbourhoodNumericUpDown.Location = new Point(205, 121);
            RepInNeighbourhoodNumericUpDown.Margin = new Padding(2);
            RepInNeighbourhoodNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            RepInNeighbourhoodNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RepInNeighbourhoodNumericUpDown.Name = "RepInNeighbourhoodNumericUpDown";
            RepInNeighbourhoodNumericUpDown.Size = new Size(115, 23);
            RepInNeighbourhoodNumericUpDown.TabIndex = 11;
            RepInNeighbourhoodNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            RepInNeighbourhoodNumericUpDown.ValueChanged += RepInNeighbourhoodNumericUpDown_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 123);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(178, 15);
            label4.TabIndex = 10;
            label4.Text = "Number of compared neighbors";
            // 
            // CoolingTypeComboBox
            // 
            CoolingTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CoolingTypeComboBox.FormattingEnabled = true;
            CoolingTypeComboBox.Location = new Point(205, 39);
            CoolingTypeComboBox.Name = "CoolingTypeComboBox";
            CoolingTypeComboBox.Size = new Size(115, 23);
            CoolingTypeComboBox.TabIndex = 12;
            CoolingTypeComboBox.SelectedIndexChanged += CoolingTypeComboBox_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 42);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 13;
            label6.Text = "Cooling function:";
            // 
            // PopupSettingsForSAForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(237, 220, 210);
            ClientSize = new Size(347, 247);
            Controls.Add(label6);
            Controls.Add(CoolingTypeComboBox);
            Controls.Add(RepInNeighbourhoodNumericUpDown);
            Controls.Add(label4);
            Controls.Add(CostRepAmountNumericUpDown);
            Controls.Add(RepAmountPerTempNumericUpDown);
            Controls.Add(TemperatureNumericUpDown);
            Controls.Add(AlphaNumericUpDown);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(closeButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PopupSettingsForSAForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "PopupSettingsForSAForm";
            TopMost = true;
            FormClosing += PopupSettingsForSAForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)AlphaNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)TemperatureNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RepAmountPerTempNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CostRepAmountNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RepInNeighbourhoodNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private NumericUpDown AlphaNumericUpDown;
        private NumericUpDown TemperatureNumericUpDown;
        private NumericUpDown RepAmountPerTempNumericUpDown;
        private NumericUpDown CostRepAmountNumericUpDown;
        private NumericUpDown RepInNeighbourhoodNumericUpDown;
        private Label label4;
        private ComboBox CoolingTypeComboBox;
        private Label label6;
    }
}