
namespace Chess
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.waitingLabel = new System.Windows.Forms.Label();
            this.leaveButton = new System.Windows.Forms.Button();
            this.periodTimeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.eventLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // waitingLabel
            // 
            this.waitingLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.waitingLabel.AutoSize = true;
            this.waitingLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.waitingLabel.Location = new System.Drawing.Point(40, 64);
            this.waitingLabel.Name = "waitingLabel";
            this.waitingLabel.Size = new System.Drawing.Size(148, 60);
            this.waitingLabel.TabIndex = 0;
            this.waitingLabel.Text = "Waiting for \r\nsecond player\r\n";
            this.waitingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.waitingLabel.UseMnemonic = false;
            // 
            // leaveButton
            // 
            this.leaveButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.leaveButton.Location = new System.Drawing.Point(186, 178);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(94, 29);
            this.leaveButton.TabIndex = 1;
            this.leaveButton.Text = "Leave";
            this.leaveButton.UseVisualStyleBackColor = false;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // periodTimeLabel
            // 
            this.periodTimeLabel.AutoSize = true;
            this.periodTimeLabel.Location = new System.Drawing.Point(13, 178);
            this.periodTimeLabel.Name = "periodTimeLabel";
            this.periodTimeLabel.Size = new System.Drawing.Size(0, 20);
            this.periodTimeLabel.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // eventLabel
            // 
            this.eventLabel.AutoSize = true;
            this.eventLabel.Location = new System.Drawing.Point(40, 178);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.Size = new System.Drawing.Size(0, 20);
            this.eventLabel.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(292, 219);
            this.Controls.Add(this.eventLabel);
            this.Controls.Add(this.periodTimeLabel);
            this.Controls.Add(this.leaveButton);
            this.Controls.Add(this.waitingLabel);
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label waitingLabel;
        private System.Windows.Forms.Button leaveButton;
        private System.Windows.Forms.Label periodTimeLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label eventLabel;
    }
}