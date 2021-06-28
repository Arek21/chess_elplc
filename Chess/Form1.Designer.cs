
namespace Chess
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddSessionLabel = new System.Windows.Forms.Label();
            this.AddSessionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(392, 240);
            this.dataGridView1.TabIndex = 0;
            // 
            // AddSessionLabel
            // 
            this.AddSessionLabel.AutoSize = true;
            this.AddSessionLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddSessionLabel.Location = new System.Drawing.Point(24, 16);
            this.AddSessionLabel.Name = "AddSessionLabel";
            this.AddSessionLabel.Size = new System.Drawing.Size(220, 37);
            this.AddSessionLabel.TabIndex = 1;
            this.AddSessionLabel.Text = "Available Session";
            // 
            // AddSessionButton
            // 
            this.AddSessionButton.Location = new System.Drawing.Point(236, 314);
            this.AddSessionButton.Name = "AddSessionButton";
            this.AddSessionButton.Size = new System.Drawing.Size(180, 33);
            this.AddSessionButton.TabIndex = 2;
            this.AddSessionButton.Text = "Add Session";
            this.AddSessionButton.UseVisualStyleBackColor = true;
            this.AddSessionButton.Click += new System.EventHandler(this.AddSessionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 374);
            this.Controls.Add(this.AddSessionButton);
            this.Controls.Add(this.AddSessionLabel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Chess";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label AddSessionLabel;
        private System.Windows.Forms.Button AddSessionButton;
    }
}

