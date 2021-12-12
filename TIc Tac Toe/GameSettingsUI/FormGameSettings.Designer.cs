namespace GameSettingsUI
{
    public partial class FormGameSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxForPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxAIDifficulty = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 1:";
            // 
            // checkBoxForPlayer2
            // 
            this.checkBoxForPlayer2.AutoSize = true;
            this.checkBoxForPlayer2.Location = new System.Drawing.Point(38, 87);
            this.checkBoxForPlayer2.Name = "checkBoxForPlayer2";
            this.checkBoxForPlayer2.Size = new System.Drawing.Size(86, 21);
            this.checkBoxForPlayer2.TabIndex = 3;
            this.checkBoxForPlayer2.Text = "Player 2:";
            this.checkBoxForPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxForPlayer2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(137, 51);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(128, 22);
            this.textBoxPlayer1.TabIndex = 2;
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(137, 86);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(128, 22);
            this.textBoxPlayer2.TabIndex = 4;
            this.textBoxPlayer2.Text = "AI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Board Size:";
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(115, 199);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(44, 22);
            this.numericUpDownRows.TabIndex = 9;
            this.numericUpDownRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRows.ValueChanged += new System.EventHandler(this.numericUpDownRow_ValueChanged);
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.Location = new System.Drawing.Point(221, 199);
            this.numericUpDownCols.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(44, 22);
            this.numericUpDownCols.TabIndex = 11;
            this.numericUpDownCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownCols.ValueChanged += new System.EventHandler(this.numericUpDownCols_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cols:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 248);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(250, 28);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "AI Difficulty:";
            // 
            // comboBoxAIDifficulty
            // 
            this.comboBoxAIDifficulty.FormattingEnabled = true;
            this.comboBoxAIDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.comboBoxAIDifficulty.Location = new System.Drawing.Point(137, 125);
            this.comboBoxAIDifficulty.Name = "comboBoxAIDifficulty";
            this.comboBoxAIDifficulty.Size = new System.Drawing.Size(128, 24);
            this.comboBoxAIDifficulty.TabIndex = 6;
            this.comboBoxAIDifficulty.Text = "Easy";
            this.comboBoxAIDifficulty.SelectedIndexChanged += new System.EventHandler(this.comboBoxAIDifficulty_SelectedIndexChanged);
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 312);
            this.Controls.Add(this.comboBoxAIDifficulty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.checkBoxForPlayer2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxForPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxAIDifficulty;
    }
}