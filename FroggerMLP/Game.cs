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
        
        public void startGraphics(Graphics graphics)
        {
            gameEngine = new GameEngine(graphics);
            gameEngine.initialize();
        }

        //Called when the Form is closed, used to stop all threads from the game
        public void stopGame()
        {
            gameEngine.stopRender();
        }
    }
}
