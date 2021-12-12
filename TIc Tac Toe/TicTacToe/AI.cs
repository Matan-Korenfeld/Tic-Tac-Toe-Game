using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class AI
    {
        public class EmergencyMove // While AI is optimized with random moves, this makes sure it catches important moves that would otherwise end the game.
        {
            public enum eWinTypes
            {
                horizontal,
                vertical,
                leftDiagonal,
                rightDiagonal
            }

            private static bool m_InitializeEmergency = false;
            private static eWinTypes m_WinType;
            private static int m_Location;

            public static bool InitializeEmergency
            {
                get
                {
                    return m_InitializeEmergency;
                }

                set
                {
                    m_InitializeEmergency = value;
                }
            }

            public static eWinTypes WinType
            {
                get
                {
                    return m_WinType;
                }

                set
                {
                    m_WinType = value;
                }
            }

            public static int Location
            {
                get
                {
                    return m_Location;
                }

                set
                {
                    m_Location = value;
                }
            }

            public static Move FindEmergencySlot(Game i_CurrentGame)
            {
                Move move = new Move(-1, -1);

                if (m_WinType == eWinTypes.horizontal)
                {
                    for (int i = 0; i < i_CurrentGame.BoardSize; i++)
                    {
                        if (string.IsNullOrEmpty(i_CurrentGame.GameBoard[m_Location, i]))
                        {
                            move.Row = m_Location;
                            move.Col = i;
                            break;
                        }
                    }
                }
                else if (m_WinType == eWinTypes.vertical)
                {
                    for (int i = 0; i < i_CurrentGame.BoardSize; i++)
                    {
                        if (string.IsNullOrEmpty(i_CurrentGame.GameBoard[i, m_Location]))
                        {
                            move.Row = i;
                            move.Col = m_Location;
                            break;
                        }
                    }
                }
                else if (m_WinType == eWinTypes.leftDiagonal)
                {
                    for (int i = 0; i < i_CurrentGame.BoardSize; i++)
                    {
                        if (string.IsNullOrEmpty(i_CurrentGame.GameBoard[i, i]))
                        {
                            move.Row = i;
                            move.Col = i;
                            break;
                        }
                    }
                }
                else    // WinType = rightDiagonal
                {
                    for (int i = 0; i < i_CurrentGame.BoardSize; i++)
                    {
                        if (string.IsNullOrEmpty(i_CurrentGame.GameBoard[i_CurrentGame.BoardSize - i - 1, i]))
                        {
                            move.Row = i_CurrentGame.BoardSize - i - 1;
                            move.Col = i;
                            break;
                        }
                    }
                }

                move.Row++;
                move.Col++;

                return move;
            }

            public static bool InsertEmergencySlot(Game i_CurrentGame, Move i_move)
            {
                bool isSuccess = i_move.InsertMove(i_CurrentGame);

                if (Difficulty == eDifficulty.hard && i_CurrentGame.TurnCount != (i_CurrentGame.BoardSize * i_CurrentGame.BoardSize) - 1)
                {
                    isSuccess = computeRandomMove(i_CurrentGame);
                    i_CurrentGame.GameBoard[i_move.Row, i_move.Col] = string.Empty;
                }

                return isSuccess;
            }
        }

        public enum eDifficulty
        {
            easy = 1,   // AI: Tries to lose
            medium,     // Random Moves
            hard        // AI: Tries to win
        }

        private static eDifficulty m_Difficulty;
        private static Player.ePlayerType m_TestWinner;

        public static eDifficulty Difficulty
        {
            get
            {
                return m_Difficulty;
            }

            set
            {
                m_Difficulty = value;
            }
        }

        public static Player.ePlayerType TestWinner
        {
            get
            {
                return m_TestWinner;
            }

            set
            {
                m_TestWinner = value;
            }
        }

        public static bool ComputeMove(Game i_CurrentGame)
        {
            bool isValidMove = false;
            bool isOptimizeRequired = (i_CurrentGame.BoardSize > 3) && ((i_CurrentGame.BoardSize * i_CurrentGame.BoardSize) - i_CurrentGame.TurnCount > 11);
            /// isOptimizedRequired - the AI is determinstic, boards sized 4x4 and higher take very long to calculate the next move. 
            /// This helps by only determening the move when necessary.

            if (EmergencyMove.InitializeEmergency && isOptimizeRequired)
            {
                Move move = new Move(-1, -1);
                move = EmergencyMove.FindEmergencySlot(i_CurrentGame);
                isValidMove = EmergencyMove.InsertEmergencySlot(i_CurrentGame, move);
            }
            else if (Difficulty == eDifficulty.medium || isOptimizeRequired)
            {
                isValidMove = computeRandomMove(i_CurrentGame);
            }
            else // Difficulty = Easy / Hard
            {
                isValidMove = computeSmartMove(i_CurrentGame);
            }

            EmergencyMove.InitializeEmergency = false;
            return isValidMove;
        }

        private static bool computeRandomMove(Game i_CurrentGame)
        {
            Move move = new Move();
            bool isValidMove = false;
            Random randomMove = new Random();

            while (!isValidMove)
            {
                move.Row = randomMove.Next(1, i_CurrentGame.BoardSize + 1);
                move.Col = randomMove.Next(1, i_CurrentGame.BoardSize + 1);
                isValidMove = move.InsertMove(i_CurrentGame);
            }

            return isValidMove;
        }

        private static bool computeSmartMove(Game i_CurrentGame)
        {
            Move move = new Move();
            move = findBestMove(i_CurrentGame);

            bool isValidMove = move.InsertMove(i_CurrentGame);

            return isValidMove;
        }

        private static int alphaBetaPruning(Game i_CurrentGame, bool i_AImove, int i_Depth, int i_Alpha, int i_Beta)
        {
            int maxScore;

            if (i_CurrentGame.IsWinner())
            {
                Player.ePlayerType me = i_AImove ?
                    i_CurrentGame.Players[i_CurrentGame.CurrentPlayerTurn].PlayerType :
                    i_CurrentGame.Players[i_CurrentGame.NextPlayerTurn].PlayerType;

                if (Difficulty == eDifficulty.easy)     // Tries to get a strike (to lose)
                {
                    maxScore = me == TestWinner ? 15 - i_Depth : i_Depth - 15;
                }
                else                                    // Hard: Tries to not get a strike (to win)
                {
                    maxScore = me == TestWinner ? i_Depth - 15 : 15 - i_Depth;
                }

                goto Escape;
            }

            if (i_CurrentGame.IsDraw())
            {
                maxScore = 0;
                goto Escape;
            }

            maxScore = i_Alpha;
            string curentTurnSymbol = i_AImove == true ?
                i_CurrentGame.Players[i_CurrentGame.CurrentPlayerTurn].Symbol :
                i_CurrentGame.Players[i_CurrentGame.NextPlayerTurn].Symbol;

            for (int i = 0; i < i_CurrentGame.BoardSize; i++)
            {
                for (int j = 0; j < i_CurrentGame.BoardSize; j++)
                {
                    if (string.IsNullOrEmpty(i_CurrentGame.GameBoard[i, j]))
                    {
                        i_CurrentGame.GameBoard[i, j] = curentTurnSymbol;
                        int score = -alphaBetaPruning(i_CurrentGame, !i_AImove, i_Depth + 1, -i_Beta, -maxScore);
                        i_CurrentGame.GameBoard[i, j] = string.Empty;

                        if (maxScore < score)
                        {
                            maxScore = score;

                            if (maxScore >= i_Beta)
                            {
                                goto Escape;
                            }
                        }
                    }
                }
            }

        Escape:
            return maxScore;
        }

        private static int miniMax(Game i_CurrentGame, bool i_AImove, int i_Depth)
        {
            const int alpha = -10_000;
            const int beta = 10_000;
            const int maxScore = alpha;

            return alphaBetaPruning(i_CurrentGame, i_AImove, i_Depth, -beta, -maxScore);
        }

        private static Move findBestMove(Game i_CurrentGame)
        {
            int bestScore = int.MinValue;
            Move move = new Move(-1, -1);

            for (int i = 0; i < i_CurrentGame.BoardSize; i++)    // Look for all empty spots.
            {
                for (int j = 0; j < i_CurrentGame.BoardSize; j++)
                {
                    if (string.IsNullOrEmpty(i_CurrentGame.GameBoard[i, j]))
                    {
                        i_CurrentGame.GameBoard[i, j] = i_CurrentGame.Players[i_CurrentGame.CurrentPlayerTurn].Symbol;
                        int score = -miniMax(i_CurrentGame, false, 0);
                        i_CurrentGame.GameBoard[i, j] = string.Empty;

                        if (score > bestScore)
                        {
                            move.Row = i;
                            move.Col = j;
                            bestScore = score;
                        }
                    }
                }
            }

            move.Row++;
            move.Col++;

            return move;
        }
    }
}