namespace WorkTimer.UI
{
    partial class OptionsForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.workTimerIntervalLabel = new System.Windows.Forms.Label();
            this.restTimerIntervalLabel = new System.Windows.Forms.Label();
            this.workTimerIntervalTextBox = new System.Windows.Forms.TextBox();
            this.restTimerIntervalTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(103, 128);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(184, 128);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // workTimerIntervalLabel
            // 
            this.workTimerIntervalLabel.AutoSize = true;
            this.workTimerIntervalLabel.Location = new System.Drawing.Point(12, 35);
            this.workTimerIntervalLabel.Name = "workTimerIntervalLabel";
            this.workTimerIntervalLabel.Size = new System.Drawing.Size(74, 13);
            this.workTimerIntervalLabel.TabIndex = 2;
            this.workTimerIntervalLabel.Text = "Work Interval:";
            // 
            // restTimerIntervalLabel
            // 
            this.restTimerIntervalLabel.AutoSize = true;
            this.restTimerIntervalLabel.Location = new System.Drawing.Point(12, 72);
            this.restTimerIntervalLabel.Name = "restTimerIntervalLabel";
            this.restTimerIntervalLabel.Size = new System.Drawing.Size(70, 13);
            this.restTimerIntervalLabel.TabIndex = 3;
            this.restTimerIntervalLabel.Text = "Rest Interval:";
            // 
            // workTimerIntervalTextBox
            // 
            this.workTimerIntervalTextBox.Location = new System.Drawing.Point(161, 32);
            this.workTimerIntervalTextBox.Name = "workTimerIntervalTextBox";
            this.workTimerIntervalTextBox.Size = new System.Drawing.Size(98, 20);
            this.workTimerIntervalTextBox.TabIndex = 4;
            // 
            // restTimerIntervalTextBox
            // 
            this.restTimerIntervalTextBox.Location = new System.Drawing.Point(161, 69);
            this.restTimerIntervalTextBox.Name = "restTimerIntervalTextBox";
            this.restTimerIntervalTextBox.Size = new System.Drawing.Size(98, 20);
            this.restTimerIntervalTextBox.TabIndex = 5;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(271, 163);
            this.Controls.Add(this.restTimerIntervalTextBox);
            this.Controls.Add(this.workTimerIntervalTextBox);
            this.Controls.Add(this.restTimerIntervalLabel);
            this.Controls.Add(this.workTimerIntervalLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label workTimerIntervalLabel;
        private System.Windows.Forms.Label restTimerIntervalLabel;
        private System.Windows.Forms.TextBox workTimerIntervalTextBox;
        private System.Windows.Forms.TextBox restTimerIntervalTextBox;
    }
}