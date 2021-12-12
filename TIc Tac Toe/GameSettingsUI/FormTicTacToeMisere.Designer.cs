namespace GameSettingsUI
{
    public partial class FormTicTacToeMisere
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
            this.labelPlayerName1 = new System.Windows.Forms.Label();
            this.labelPlayerName2 = new System.Windows.Forms.Label();
            this.labelScore1 = new System.Windows.Forms.Label();
            this.labelScore2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPlayerName1
            // 
            this.labelPlayerName1.AutoSize = true;
            this.labelPlayerName1.Location = new System.Drawing.Point(59, 248);
            this.labelPlayerName1.Name = "labelPlayerName1";
            this.labelPlayerName1.Size = new System.Drawing.Size(0, 17);
            this.labelPlayerName1.TabIndex = 0;
            // 
            // labelPlayerName2
            // 
            this.labelPlayerName2.AutoSize = true;
            this.labelPlayerName2.Location = new System.Drawing.Point(217, 248);
            this.labelPlayerName2.Name = "labelPlayerName2";
            this.labelPlayerName2.Size = new System.Drawing.Size(0, 17);
            this.labelPlayerName2.TabIndex = 1;
            // 
            // labelScore1
            // 
            this.labelScore1.AutoSize = true;
            this.labelScore1.Location = new System.Drawing.Point(111, 248);
            this.labelScore1.Name = "labelScore1";
            this.labelScore1.Size = new System.Drawing.Size(0, 17);
            this.labelScore1.TabIndex = 2;
            // 
            // labelScore2
            // 
            this.labelScore2.AutoSize = true;
            this.labelScore2.Location = new System.Drawing.Point(269, 248);
            this.labelScore2.Name = "labelScore2";
            this.labelScore2.Size = new System.Drawing.Size(0, 17);
            this.labelScore2.TabIndex = 3;
            // 
            // FormTicTacToeMisere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 294);
            this.Controls.Add(this.labelScore2);
            this.Controls.Add(this.labelScore1);
            this.Controls.Add(this.labelPlayerName2);
            this.Controls.Add(this.labelPlayerName1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTicTacToeMisere";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTicTacToeMisere";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayerName1;
        private System.Windows.Forms.Label labelPlayerName2;
        private System.Windows.Forms.Label labelScore1;
        private System.Windows.Forms.Label labelScore2;
    }
}