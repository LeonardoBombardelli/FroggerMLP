using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FroggerMLP
{
    public partial class GameWindow : Form
    {
        //Members
        private Game game = new Game();

        //Methods
        public GameWindow()
        {
            InitializeComponent();
        }

        //Canvas painting function - Launches paint functionality
        private void gameCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = gameCanvas.CreateGraphics();
            game.startGraphics(graphics);
        }

        //Called when the Form is closed, makes all game threads close
        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.stopGame();
        }

        //When window is loaded, we open the debug console
        private void GameWindow_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        //--------------------------------------------//
        //Permits debuginng with console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
