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
        private Entity doll;


        /*Methods*/

        //Constructor
        public GameEngine(Graphics graphics)
        {
            drawHandler = graphics;
        }

        //Initializes a thread at the render() method
        public void Initialize()
        {
            renderThread = new Thread(new ThreadStart(Render));
            renderThread.Start();
            doll = new Entity(TypeOfEntity.MainChar, 100, 100);
            
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
                frame = graphicsEngine.RefreshFrame(doll);

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
    }
}
