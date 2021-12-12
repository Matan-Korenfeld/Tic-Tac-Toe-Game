using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public struct Move
    {
        private int m_Row;
        private int m_Col;

        public Move(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;
        }

        public int Row
        {
            get
            {
                return m_Row;
            }

            set
            {
                m_Row = value;
            }
        }

        public int Col
        {
            get
            {
                return m_Col;
            }

            set
            {
                m_Col = value;
            }
        }

        public bool InsertMove(Game i_CurrentGame)
        {
            Row--;
            Col--;
            bool isInserted = false;
            if (isValidMove(i_CurrentGame))
            {
                i_CurrentGame.GameBoard[Row, Col] = i_CurrentGame.Players[i_CurrentGame.CurrentPlayerTurn].Symbol;
                isInserted = true;
            }

            return isInserted;
        }

        private bool isValidMove(Game i_CurrentGame)
        {
            bool isValid = false;

            if (Row >= 0 && Row < i_CurrentGame.BoardSize && Col >= 0 && Col < i_CurrentGame.BoardSize)
            {
                if (string.IsNullOrEmpty(i_CurrentGame.GameBoard[Row, Col]))
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}