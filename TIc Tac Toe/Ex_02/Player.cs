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

        private static int s_PlayerInstances = 0;
        private readonly string r_Symbol = string.Empty;
        private readonly int r_PlayerNumber;
        private readonly ePlayerType r_PlayerType;
        private bool m_AI; // True: Player is AI
        private int m_WinCount = 0;
        private string m_Name = string.Empty;
        
        public Player(string i_Symbol, string i_Name, bool i_IsAI = false)
        {
            s_PlayerInstances++;
            r_PlayerNumber = s_PlayerInstances;
            Name = i_Name;
            r_Symbol = i_Symbol;

            if (s_PlayerInstances > 2)
            {
                throw new ArgumentException("Only 2 Players for now");
            }

            if (PlayerNumber == 1)
            {
                r_PlayerType = ePlayerType.player;
            }
            else
            {
                AI = i_IsAI;
                r_PlayerType = ePlayerType.opponent;
            }
        }

        public ePlayerType PlayerType
        {
            get
            {
                return r_PlayerType;
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
                return r_Symbol;
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
                return r_PlayerNumber;
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