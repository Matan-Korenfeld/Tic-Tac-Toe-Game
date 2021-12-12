using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSettingsUI
{
    public class ButtonTicTacToe : Button
    {
        public const int k_ButtonSize = 70;

        private Point m_Point;
        
        public ButtonTicTacToe(int i_X, int i_Y)
        {
            m_Point = new Point(i_X, i_Y);
            this.TabStop = false;
            initializeComponent();
        }

        private void initializeComponent()
        {
            this.Size = new Size(k_ButtonSize, k_ButtonSize);
            this.Enabled = true;
        }

        public Point Point
        {
            get { return m_Point; }
        }
    }
}
