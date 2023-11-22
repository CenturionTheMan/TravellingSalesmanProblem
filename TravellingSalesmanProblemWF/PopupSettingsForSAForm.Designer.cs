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
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(165, 165, 141);
            closeButton.FlatAppearance.BorderColor = Color.Black;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            closeButton.Location = new Point(341, 275);
            closeButton.Margin = new Padding(2);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(134, 30);
            closeButton.TabIndex = 0;
            closeButton.Text = "Save and Close";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // PopupSettingsForSAForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(237, 220, 210);
            ClientSize = new Size(486, 316);
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
            ResumeLayout(false);
        }

        #endregion

        private Button closeButton;
    }
}