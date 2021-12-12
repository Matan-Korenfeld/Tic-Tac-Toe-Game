using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe;

namespace GameSettingsUI
{
    public partial class FormTicTacToeMisere : Form
    {
        private const int k_GapFromBorder = 2;
        private const int k_GapBetweenButtons = 2;
        protected Game m_GameBoard;
        private List<ButtonTicTacToe> m_ButtonsSlots;
        
        public FormTicTacToeMisere()
        {
            FormGameSettings formSettings = new FormGameSettings();
            DialogResult = formSettings.ShowDialog();
            if(DialogResult == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }

            Player player1 = new Player("X", formSettings.Player1Name);
            Player player2 = new Player("O", formSettings.Player2Name, !formSettings.Player2AI);

            m_GameBoard = new Game(player1, player2, formSettings.BoardSize);

            m_ButtonsSlots = new List<ButtonTicTacToe>();
            initializeComponents();
        }

        public void EndOfTurn()
        {
            Game.eGameOver result = m_GameBoard.CheckGameOver();

            if (result == Game.eGameOver.nextTurn)
            {
                m_GameBoard.TurnManager();

                if (m_GameBoard.Players[m_GameBoard.CurrentPlayerTurn].AI) // AI's turn
                {
                    initiateComputerMove();
                }
            }
            else
            {
                showEndOfRoundStatus(result);
            }
        }

        private void initializeComponents()
        {
            this.labelPlayerName1 = new System.Windows.Forms.Label();
            this.labelPlayerName2 = new System.Windows.Forms.Label();
            this.labelScore1 = new System.Windows.Forms.Label();
            this.labelScore2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            ////
            // FormTicTacToeMisere
            ////
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            int clientSizeWidth = m_GameBoard.BoardSize * ButtonTicTacToe.k_ButtonSize;
            int clientSizeHeight = m_GameBoard.BoardSize * ButtonTicTacToe.k_ButtonSize;
            this.ClientSize = new System.Drawing.Size(clientSizeWidth, clientSizeHeight);
            this.Controls.Add(this.labelScore2);
            this.Controls.Add(this.labelScore1);
            this.Controls.Add(this.labelPlayerName2);
            this.Controls.Add(this.labelPlayerName1);
            this.Name = "FormTicTacToeMisere";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTicTacToeMisere";
            ////
            // labelScore1
            //// 
            this.labelScore1.Top = Height;
            this.labelScore1.Name = "labelScore1";
            this.labelScore1.TabIndex = 2;
            this.labelScore1.Text = m_GameBoard.Players[m_GameBoard.CurrentPlayerTurn].WinCount.ToString();
            this.labelScore1.AutoSize = true;
            this.labelScore1.Left = ((Width - labelScore1.Right) / 2) - 10;
            //// 
            // labelPlayerName1
            //// 
            this.labelPlayerName1.Top = Height;
            this.labelPlayerName1.Name = "labelPlayerName1";
            this.labelPlayerName1.TabIndex = 0;
            this.labelPlayerName1.Text = m_GameBoard.Players[m_GameBoard.CurrentPlayerTurn].Name + ":";
            this.labelPlayerName1.AutoSize = true;
            this.labelPlayerName1.Left = labelScore1.Left - labelPlayerName1.Width;
            //// 
            // labelPlayerName2
            //// 
            this.labelPlayerName2.Top = Height;
            this.labelPlayerName2.Name = "labelPlayerName2";
            this.labelPlayerName2.TabIndex = 1;
            this.labelPlayerName2.Text = m_GameBoard.Players[m_GameBoard.NextPlayerTurn].Name + ":";
            this.labelPlayerName2.AutoSize = true;
            this.labelPlayerName2.Left = (Width / 2) + 10;
            //// 
            // labelScore2
            //// 
            this.labelScore2.Name = "labelScore2";
            this.labelScore2.TabIndex = 3;
            this.labelScore2.Text = m_GameBoard.Players[m_GameBoard.NextPlayerTurn].WinCount.ToString();
            this.labelScore2.AutoSize = true;
            labelScore2.Top = Height;
            labelScore2.Left = labelPlayerName2.Right + 3;

            int locationY = k_GapFromBorder;
            for (int i = 0; i < m_GameBoard.BoardSize; i++)
            {
                int locationX = k_GapFromBorder;

                for (int j = 0; j < m_GameBoard.BoardSize; j++)
                {
                    ButtonTicTacToe currentTicTacToeButton = new ButtonTicTacToe(i, j);
                    currentTicTacToeButton.Location = new Point(locationX, locationY);
                    Controls.Add(currentTicTacToeButton);
                    m_ButtonsSlots.Add(currentTicTacToeButton); // add to the button's list
                    locationX += k_GapBetweenButtons + ButtonTicTacToe.k_ButtonSize;
                    currentTicTacToeButton.Click += new EventHandler(legalButtonSlot_Click);
                }

                locationY += k_GapBetweenButtons + ButtonTicTacToe.k_ButtonSize;
            }
            
            this.AutoSize = true;
            this.Text = "TicTacToeMisere";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void legalButtonSlot_Click(object sender, EventArgs e)
        {
            ButtonTicTacToe selectedButtonSlot = sender as ButtonTicTacToe;
            Move move = new Move(selectedButtonSlot.Point.X, selectedButtonSlot.Point.Y);
            move.InsertMove(m_GameBoard);
            selectedButtonSlot.Text = m_GameBoard.Players[m_GameBoard.CurrentPlayerTurn].Symbol;
            selectedButtonSlot.Enabled = false;
            EndOfTurn();
        }

        private void initiateComputerMove()
        {
            Move move = AI.ComputeMove(m_GameBoard);
            m_ButtonsSlots[(move.Row * m_GameBoard.BoardSize) + move.Col].Text = m_GameBoard.Players[m_GameBoard.CurrentPlayerTurn].Symbol;
            m_ButtonsSlots[(move.Row * m_GameBoard.BoardSize) + move.Col].Enabled = false;
            EndOfTurn();
        }

        private void showEndOfRoundStatus(Game.eGameOver m_Result)
        {
            StringBuilder winnerMessage = new StringBuilder();
            StringBuilder headLineMessage = new StringBuilder();

            // check who won
            if (m_Result == Game.eGameOver.win)
            {
                winnerMessage.AppendFormat("The Winner is {0}", m_GameBoard.Players[m_GameBoard.NextPlayerTurn].Name.ToString());
                headLineMessage.AppendFormat("A Win!");
            }
            else
            {
                winnerMessage.Append("Tie!");
                headLineMessage.AppendFormat("A Tie!");
            }

            winnerMessage.AppendFormat(
                "{0}Would you like to play another round?",
                Environment.NewLine);
            //// show YES/NO message box to the user
            DialogResult anotherRound = MessageBox.Show(winnerMessage.ToString(), headLineMessage.ToString(), MessageBoxButtons.YesNo);
            if (anotherRound == DialogResult.Yes)
            {
                initializeGame();
            }
            else
            {
                this.Close();
            }
        }

        private void initializeGame()
        {
            m_GameBoard.NewGameSetUp();
            labelScore1.Text = m_GameBoard.Players[m_GameBoard.CurrentPlayerTurn].WinCount.ToString();
            labelScore2.Text = m_GameBoard.Players[m_GameBoard.NextPlayerTurn].WinCount.ToString();
            resetButtons();
        }

        private void resetButtons()
        {
            foreach (ButtonTicTacToe button in m_ButtonsSlots)
            {
                button.ResetText();
                button.Enabled = true;
            }
        }
    }
}
