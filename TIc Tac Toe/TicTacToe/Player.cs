using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public enum ePlayerType
        {
            player = 1,
            opponent = 2,
        }

        private static int m_PlayerInstances = 0;
        private bool m_AI; // True: Player is AI
        private int m_PlayerNumber;
        private int m_WinCount = 0;
        private string m_Name = string.Empty;
        private string m_Symbol = string.Empty;
        private ePlayerType m_PlayerType;

        public Player(string i_Symbol)
        {
            m_PlayerInstances++;
            PlayerNumber = m_PlayerInstances;
            Symbol = i_Symbol;

            if (m_PlayerInstances > 2)
            {
                throw new Exception("Only 2 Players for now");
            }

            if (PlayerNumber == 1)
            {
                PlayerType = ePlayerType.player;
                Name = GameUI.InitiatePlayerName();
            }
            else
            {
                GameUI.InitiateNextPlayer(this);
                PlayerType = ePlayerType.opponent;
                Name = AI ? "AI" : GameUI.InitiatePlayerName();
            }
        }

        public ePlayerType PlayerType
        {
            get
            {
                return m_PlayerType;
            }

            set
            {
                m_PlayerType = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public string Symbol
        {
            get
            {
                return m_Symbol;
            }

            set
            {
                m_Symbol = value;
            }
        }

        public int WinCount
        {
            get
            {
                return m_WinCount;
            }

            set
            {
                m_WinCount = value;
            }
        }

        public int PlayerNumber
        {
            get
            {
                return m_PlayerNumber;
            }

            set
            {
                m_PlayerNumber = value;
            }
        }

        public bool AI
        {
            get
            {
                return m_AI;
            }

            set
            {
                m_AI = value;
            }
        }
    }
}