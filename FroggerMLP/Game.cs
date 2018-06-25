using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FroggerMLP
{
    class Game
    {
        /* Constants */
        public const int CANVAS_WIDTH = 1200;
        public const int CANVAS_HEIGHT = 700;

        /* Members */
        private GameEngine gameEngine;

        /* Methods */
        
        public void StartGraphics(Graphics graphics)
        {
            gameEngine = new GameEngine(graphics);
            gameEngine.Initialize();
        }

        //Called when the Form is closed, used to stop all threads from the game
        public void StopGame()
        {
            gameEngine.StopRender();
        }

        //Method to call when clock ticks
        public void ClockTick()
        {
            gameEngine.ClockTick();
        }

        public void PressS()
        {
            gameEngine.PressS();
        }

        public void PressW()
        {
            gameEngine.PressW();
        }

        public void PressA()
        {
            gameEngine.PressA();
        }

        public void PressD()
        {
            gameEngine.PressD();
        }
    }
}
