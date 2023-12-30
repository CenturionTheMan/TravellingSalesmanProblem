namespace TravellingSalesmanProblemWF
{
    partial class PopupSettingsForBabForm
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
            searchTypeComboBox = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(165, 165, 141);
            closeButton.FlatAppearance.BorderColor = Color.Black;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            closeButton.Location = new Point(101, 88);
            closeButton.Margin = new Padding(2);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(168, 38);
            closeButton.TabIndex = 0;
            closeButton.Text = "Save and Close";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // searchTypeComboBox
            // 
            searchTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            searchTypeComboBox.FormattingEnabled = true;
            searchTypeComboBox.ItemHeight = 20;
            searchTypeComboBox.Location = new Point(12, 40);
            searchTypeComboBox.Margin = new Padding(2);
            searchTypeComboBox.Name = "searchTypeComboBox";
            searchTypeComboBox.Size = new Size(256, 28);
            searchTypeComboBox.TabIndex = 1;
            searchTypeComboBox.DropDownClosed += searchTypeComboBox_DropDownClosed;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 14);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(231, 23);
            label1.TabIndex = 2;
            label1.Text = "Select search type for BandB:";
            // 
            // PopupSettingsForBabForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(237, 220, 210);
            ClientSize = new Size(281, 138);
            Controls.Add(label1);
            Controls.Add(searchTypeComboBox);
            Controls.Add(closeButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PopupSettingsForBabForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings for Branch And Bound";
            TopMost = true;
            FormClosing += PopupSettingsForBabForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeButton;
        private ComboBox searchTypeComboBox;
        private Label label1;
    }
}