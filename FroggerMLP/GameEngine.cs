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

        //Textures to render
        private Bitmap charTexture;

        /*Methods*/

        //Constructor
        public GameEngine(Graphics graphics)
        {
            drawHandler = graphics;
        }

        //Initializes a thread at the render() method
        public void initialize()
        {
            loadAssets();

            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

        private void loadAssets()
        {
            charTexture = FroggerMLP.Properties.Resources.charSprite;
        }

        //Kills the thread responsible for rendering
        public void stopRender()
        {
            renderThread.Abort();
        }

        //Render the images to the screen
        private void render()
        {
            int framesPerSecond = 0;
            long startTime = Environment.TickCount;
            Bitmap frame;
            graphicsEngine = new GraphicsEngine();

            while(true)
            {
                frame = graphicsEngine.refreshFrame();

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
