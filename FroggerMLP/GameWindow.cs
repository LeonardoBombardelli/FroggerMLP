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
        private void GameCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = gameCanvas.CreateGraphics();
            game.StartGraphics(graphics);
        }

        //Called when the Form is closed, makes all game threads close
        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.StopGame();
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

        private void clockRefreshFrame_Tick(object sender, EventArgs e)
        {
            game.ClockTick();
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
                game.PressS();
            if (e.KeyCode == Keys.W)
                game.PressW();
            if (e.KeyCode == Keys.A)
                game.PressA();
            if (e.KeyCode == Keys.D)
                game.PressD();
        }

        private void GameWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
                game.ReleaseS();
            if (e.KeyCode == Keys.W)
                game.ReleaseW();
            if (e.KeyCode == Keys.A)
                game.ReleaseA();
            if (e.KeyCode == Keys.D)
                game.ReleaseD();
        }
    }
}
