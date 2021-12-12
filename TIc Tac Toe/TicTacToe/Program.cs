using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Program
    {
        public static void Main()
        {
            GameUI.PrintWelcome();
            Game currentGame = new Game();
            GameUI.GameMenu(currentGame);
        }
    }
}