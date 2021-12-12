using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TicTacToe;

namespace GameSettingsUI
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxForPlayer2.Checked)
            {
                textBoxPlayer2.Text = "Player 2";
                textBoxPlayer2.Enabled = true;
                comboBoxAIDifficulty.Enabled = false;
            }
            else
            {
                textBoxPlayer2.Text = "AI";
                comboBoxAIDifficulty.Enabled = true;
                textBoxPlayer2.Enabled = false;
            }
        }

        private void numericUpDownRow_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCols.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = numericUpDownCols.Value;
        }
   
        public string Player1Name
        {
            get
            {
                if (textBoxPlayer1.Text == string.Empty)
                {
                    textBoxPlayer1.Text = "Player 1";
                }

                return textBoxPlayer1.Text;
            }
        }

        public string Player2Name
        {
            get
            {
                return textBoxPlayer2.Text;
            }
        }

        public bool Player2AI
        {
            get { return checkBoxForPlayer2.Checked; }
        }

        public int BoardSize
        {
            get { return Convert.ToInt32(numericUpDownRows.Value); }
        }

        private void comboBoxAIDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            AI.Difficulty = (AI.eDifficulty) comboBoxAIDifficulty.SelectedIndex;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
