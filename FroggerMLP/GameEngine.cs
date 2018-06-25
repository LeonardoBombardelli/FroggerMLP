using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace FroggerMLP
{
    class GameEngine
    {
        /*Constants*/

        /*Members*/
        private Graphics drawHandler;
        private Thread renderThread;
        private GraphicsEngine graphicsEngine;
        private GameState gameState;


        /*Methods*/

        //Constructor
        public GameEngine(Graphics graphics)
        {
            drawHandler = graphics;
            gameState = new GameState();
        }

        //Initializes a thread at the render() method
        public void Initialize()
        {
            renderThread = new Thread(new ThreadStart(Render));
            renderThread.Start();
            
        }

        //Kills the thread responsible for rendering
        public void StopRender()
        {
            renderThread.Abort();
        }

        //Render the images to the screen
        private void Render()
        {
            int framesPerSecond = 0;
            long startTime = Environment.TickCount;
            Bitmap frame;
            graphicsEngine = new GraphicsEngine();

            while(true)
            {
                frame = graphicsEngine.RefreshFrame(gameState);

                //Draws the frame on the canvas
                drawHandler.DrawImage(frame, 0, 0);

                //Checking FPS count
                framesPerSecond++;
                if (Environment.TickCount >= startTime + 1000)
                {
                    Console.WriteLine("GameEngine: " + framesPerSecond + " FPS.");
                    framesPerSecond = 0;
                    startTime = Environment.TickCount;
                }
            }
        }

        //Method to call when clock thicks
        public void ClockTick()
        {
            gameState.ClockTick();
        }

        public void PressKey(KeyboardKeys key)
        {
            if (key == KeyboardKeys.KeyS)
                gameState.GoDown();
            else if (key == KeyboardKeys.KeyW)
                gameState.GoUp();
            else if (key == KeyboardKeys.KeyA)
                gameState.GoLeft();
            else if (key == KeyboardKeys.KeyD)
                gameState.GoRight();
        }

        public void ReleaseKey(KeyboardKeys key)
        {
            if (key == KeyboardKeys.KeyS)
                gameState.StopGoDown();
            else if (key == KeyboardKeys.KeyA)
                gameState.StopGoLeft();
            else if (key == KeyboardKeys.KeyD)
                gameState.StopGoRight();
            else if (key == KeyboardKeys.KeyW)
                gameState.StopGoUp();
        }


    }
}
