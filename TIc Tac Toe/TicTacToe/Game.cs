using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        public enum eGameOver
        {
            nextTurn = 0,
            win = 1,
            draw = 2
        }

        private int m_BoardSize;
        private int m_CurrentPlayerTurn = 0;
        private int m_NextPlayerTurn = 1;
        private int m_TurnCount = 0;
        private int m_DrawCount = 0;
        private string[,] m_GameBoard;
        private List<Player> m_Players;

        public Game()
        {
            GameUI.InitiateBoard(this);
            BoardSize = GameBoard.GetLength(0);
            m_Players = new List<Player>();
            m_Players.Add(new Player("X"));
            m_Players.Add(new Player("O"));
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }

            set
            {
                m_BoardSize = value;
            }
        }

        public int TurnCount
        {
            get
            {
                return m_TurnCount;
            }

            set
            {
                m_TurnCount = value;
            }
        }

        public int DrawCount
        {
            get
            {
                return m_DrawCount;
            }

            set
            {
                m_DrawCount = value;
            }
        }

        public int CurrentPlayerTurn
        {
            get
            {
                return m_CurrentPlayerTurn;
            }

            set
            {
                m_CurrentPlayerTurn = value;
            }
        }

        public int NextPlayerTurn
        {
            get
            {
                return m_NextPlayerTurn;
            }

            set
            {
                m_NextPlayerTurn = value;
            }
        }

        public string[,] GameBoard
        {
            get
            {
                return m_GameBoard;
            }

            set
            {
                m_GameBoard = value;
            }
        }

        public List<Player> Players
        {
            get
            {
                return m_Players;
            }

            set
            {
                m_Players = value;
            }
        }

        public void TurnManager()
        {
            TurnCount++;
            CurrentPlayerTurn++;
            CurrentPlayerTurn %= 2;
            NextPlayerTurn++;
            NextPlayerTurn %= 2;
        }

        public bool IsDraw()
        {
            bool isDrawFlag = true;
            foreach (string s in m_GameBoard)
            {
                if (string.IsNullOrEmpty(s))
                {
                    isDrawFlag = false;
                    break;
                }
            }

            return isDrawFlag;
        }

        public void CleanBoard()
        {
            Array.Clear(m_GameBoard, 0, m_GameBoard.Length);
        }

        public bool IsWinner()
        {
            bool isWinnerFlag = false;

            isWinnerFlag = this.checkDiagonallStrike();
            if (!isWinnerFlag)
            {
                isWinnerFlag = this.checkHorizontalAndVerticalStrike();
            }

            return isWinnerFlag;
        }

        public eGameOver CheckGameOver()
        {
            eGameOver result = (int)eGameOver.nextTurn;

            if (IsWinner())
            {
                this.Players[NextPlayerTurn].WinCount++;
                result = eGameOver.win;
            }
            else if (IsDraw())
            {
                this.DrawCount++;
                result = eGameOver.draw;
            }

            return result;
        }

        public void NewGameSetUp()
        {
            this.CleanBoard();
            this.CurrentPlayerTurn = 0;
            this.NextPlayerTurn = 1;
            this.TurnCount = 0;
        }

        private bool isDistinct(string i_Strike)
        {
            bool isDistinctFlag = true;
            char symbol = i_Strike[0];

            foreach (char c in i_Strike)
            {
                if (symbol != c)
                {
                    isDistinctFlag = false;
                    break;
                }
            }

            return isDistinctFlag;
        }

        private bool checkHorizontalAndVerticalStrike()
        {
            int i, j;
            bool isWinner = false;
            StringBuilder horizontalCount = new StringBuilder();
            StringBuilder verticalCount = new StringBuilder();

            for (i = 0; i < BoardSize; i++)
            {
                for (j = 0; j < BoardSize; j++)
                {
                    if (!string.IsNullOrEmpty(m_GameBoard[i, j]))
                    {
                        horizontalCount.Append(m_GameBoard[i, j]);
                    }

                    if (!string.IsNullOrEmpty(m_GameBoard[j, i]))
                    {
                        verticalCount.Append(m_GameBoard[j, i]);
                    }
                }

                if (checkStrike(horizontalCount.ToString(), verticalCount.ToString()))
                {
                    isWinner = true;
                    break;
                }

                checkPotentialStrike(horizontalCount.ToString(), verticalCount.ToString(), AI.EmergencyMove.eWinTypes.horizontal, AI.EmergencyMove.eWinTypes.vertical, i); // For AI.

                horizontalCount.Clear();
                verticalCount.Clear();
            }

            return isWinner;
        }

        private bool checkDiagonallStrike()
        {
            bool isWinner = false;
            StringBuilder rightDiagonalCount = new StringBuilder();
            StringBuilder leftDiagonalCount = new StringBuilder();

            for (int i = 0; i < BoardSize; i++)
            {
                if (!string.IsNullOrEmpty(m_GameBoard[i, i]))
                {
                    leftDiagonalCount.Append(m_GameBoard[i, i]);
                }

                if (!string.IsNullOrEmpty(m_GameBoard[i, BoardSize - i - 1]))
                {
                    rightDiagonalCount.Append(m_GameBoard[i, BoardSize - i - 1]);
                }
            }

            if (checkStrike(leftDiagonalCount.ToString(), rightDiagonalCount.ToString()))
            {
                isWinner = true;
            }
            else
            {
                checkPotentialStrike(leftDiagonalCount.ToString(), rightDiagonalCount.ToString(), AI.EmergencyMove.eWinTypes.leftDiagonal, AI.EmergencyMove.eWinTypes.rightDiagonal); // For AI.
            }

            return isWinner;
        }

        private bool checkStrike(string i_StrikeOne, string i_StrikeTwo)
        {
            bool isWinner = false;

            isWinner = checklStrikeWinner(i_StrikeOne.ToString(), BoardSize);

            if (!isWinner)
            {
                isWinner = checklStrikeWinner(i_StrikeTwo.ToString(), BoardSize);
            }

            return isWinner;
        }

        private bool checklStrikeWinner(string i_Strike, int i_LengthNeeded)
        {
            bool isGoodStrike = false;

            if (i_Strike.Length == i_LengthNeeded)
            {
                isGoodStrike = isDistinct(i_Strike);
            }

            if (isGoodStrike && i_LengthNeeded == BoardSize) // For minimax.
            {
                AI.TestWinner = i_Strike.Contains("X") ? Player.ePlayerType.player : Player.ePlayerType.opponent;
            }

            return isGoodStrike;
        }

        private void checkPotentialStrike(string i_StrikeOne, string i_StrikeTwo, AI.EmergencyMove.eWinTypes i_PotentialWinTypeOne, AI.EmergencyMove.eWinTypes i_PotentialWinTypeTwo, int i_PotentialLocation = -1)
        {
            int lengthNeeded = BoardSize - 1;

            checkStrikePotentialWinner(i_StrikeOne.ToString(), lengthNeeded, i_PotentialWinTypeOne, i_PotentialLocation);

            if (!AI.EmergencyMove.InitializeEmergency)
            {
                checkStrikePotentialWinner(i_StrikeTwo.ToString(), lengthNeeded, i_PotentialWinTypeTwo, i_PotentialLocation);
            }
        }

        private void checkStrikePotentialWinner(string i_Strike, int i_LengthNeeded, AI.EmergencyMove.eWinTypes i_PotentialWinType, int i_PotentialLocation = -1)
        {
            bool isGoodStrike = false;

            if (!Players[CurrentPlayerTurn].AI && BoardSize > 3 && i_LengthNeeded == i_Strike.Length)
            {
                isGoodStrike = checklStrikeWinner(i_Strike, i_LengthNeeded);
            }

            if (isGoodStrike)
            {
                Player.ePlayerType whoPotentialWin = i_Strike.Contains("X") ? Player.ePlayerType.player : Player.ePlayerType.opponent;

                if((AI.Difficulty == AI.eDifficulty.easy && whoPotentialWin == Player.ePlayerType.player) || (AI.Difficulty == AI.eDifficulty.hard && whoPotentialWin == Player.ePlayerType.opponent))
                {
                    AI.EmergencyMove.InitializeEmergency = true;
                    AI.EmergencyMove.WinType = i_PotentialWinType;
                    AI.EmergencyMove.Location = i_PotentialLocation;
                }
            }
        }
    }
}