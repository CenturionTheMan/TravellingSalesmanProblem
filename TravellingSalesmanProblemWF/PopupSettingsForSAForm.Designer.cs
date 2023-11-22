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
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AlphaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TemperatureNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RepAmountPerTempNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CostRepAmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RepInNeighbourhoodNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepAmountPerTempNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostRepAmountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepInNeighbourhoodNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(141)))));
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeButton.Location = new System.Drawing.Point(232, 211);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(168, 38);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Save and Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alpha factor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initial temperature:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Repeats amount per temperature:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cost repeats amount until stop:";
            // 
            // AlphaNumericUpDown
            // 
            this.AlphaNumericUpDown.DecimalPlaces = 3;
            this.AlphaNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.AlphaNumericUpDown.Location = new System.Drawing.Point(256, 12);
            this.AlphaNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AlphaNumericUpDown.Name = "AlphaNumericUpDown";
            this.AlphaNumericUpDown.Size = new System.Drawing.Size(144, 27);
            this.AlphaNumericUpDown.TabIndex = 6;
            this.AlphaNumericUpDown.Value = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.AlphaNumericUpDown.ValueChanged += new System.EventHandler(this.AlphaNumericUpDown_ValueChanged);
            // 
            // TemperatureNumericUpDown
            // 
            this.TemperatureNumericUpDown.Location = new System.Drawing.Point(256, 45);
            this.TemperatureNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.TemperatureNumericUpDown.Name = "TemperatureNumericUpDown";
            this.TemperatureNumericUpDown.Size = new System.Drawing.Size(144, 27);
            this.TemperatureNumericUpDown.TabIndex = 7;
            this.TemperatureNumericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.TemperatureNumericUpDown.ValueChanged += new System.EventHandler(this.TemperatureNumericUpDown_ValueChanged);
            // 
            // RepAmountPerTempNumericUpDown
            // 
            this.RepAmountPerTempNumericUpDown.Location = new System.Drawing.Point(256, 78);
            this.RepAmountPerTempNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.RepAmountPerTempNumericUpDown.Name = "RepAmountPerTempNumericUpDown";
            this.RepAmountPerTempNumericUpDown.Size = new System.Drawing.Size(144, 27);
            this.RepAmountPerTempNumericUpDown.TabIndex = 8;
            this.RepAmountPerTempNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.RepAmountPerTempNumericUpDown.ValueChanged += new System.EventHandler(this.RepAmountPerTempNumericUpDown_ValueChanged);
            // 
            // CostRepAmountNumericUpDown
            // 
            this.CostRepAmountNumericUpDown.Location = new System.Drawing.Point(256, 161);
            this.CostRepAmountNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.CostRepAmountNumericUpDown.Name = "CostRepAmountNumericUpDown";
            this.CostRepAmountNumericUpDown.Size = new System.Drawing.Size(144, 27);
            this.CostRepAmountNumericUpDown.TabIndex = 9;
            this.CostRepAmountNumericUpDown.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.CostRepAmountNumericUpDown.ValueChanged += new System.EventHandler(this.CostRepAmountNumericUpDown_ValueChanged);
            // 
            // RepInNeighbourhoodNumericUpDown
            // 
            this.RepInNeighbourhoodNumericUpDown.Location = new System.Drawing.Point(256, 128);
            this.RepInNeighbourhoodNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.RepInNeighbourhoodNumericUpDown.Name = "RepInNeighbourhoodNumericUpDown";
            this.RepInNeighbourhoodNumericUpDown.Size = new System.Drawing.Size(144, 27);
            this.RepInNeighbourhoodNumericUpDown.TabIndex = 11;
            this.RepInNeighbourhoodNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RepInNeighbourhoodNumericUpDown.ValueChanged += new System.EventHandler(this.RepInNeighbourhoodNumericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 40);
            this.label4.TabIndex = 10;
            this.label4.Text = "Repeats amount \r\nwhile neighbourhood search:\r\n";
            // 
            // PopupSettingsForSAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(434, 269);
            this.Controls.Add(this.RepInNeighbourhoodNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CostRepAmountNumericUpDown);
            this.Controls.Add(this.RepAmountPerTempNumericUpDown);
            this.Controls.Add(this.TemperatureNumericUpDown);
            this.Controls.Add(this.AlphaNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupSettingsForSAForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PopupSettingsForSAForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopupSettingsForSAForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.AlphaNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepAmountPerTempNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostRepAmountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepInNeighbourhoodNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}