using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FroggerMLP
{
    class GraphicsEngine
    {
        private const float INITIAL_STREET_X = 0;

        /* Members */
        private Graphics canvas;
        private Bitmap frame;

        //Textures to render
        private Bitmap charTexture;
        private Bitmap carTextureBlue;
        private Bitmap streetSprite;

        /* Methods */
        //Constructor
        public GraphicsEngine()
        {
            frame = new Bitmap(Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
            canvas = Graphics.FromImage(frame);

            LoadAssets();
        }
        
        private void LoadAssets()
        {
            charTexture = FroggerMLP.Properties.Resources.charSprite;
            carTextureBlue = FroggerMLP.Properties.Resources.SimpleBlueCarTopView;
            streetSprite = FroggerMLP.Properties.Resources.Street;
        }

        private void FillsBackground()
        {
            canvas.FillRectangle(new SolidBrush(Color.Beige), 0, 0, Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
        }

        private void DrawsChar(MainChar player)
        {
            canvas.DrawImage(charTexture, (float)player.posXGet(),(float)player.posYGet());
        }

        private void DrawsStreets(List<Street> streets)
        {
            foreach(Street street in streets)
            {
                try
                {
                    canvas.DrawImage(streetSprite, INITIAL_STREET_X, (float)street.yPos);

                    foreach (Car car in street.streetCarsGet())
                    {
                        canvas.DrawImage(carTextureBlue, (float)car.posXGet(), (float)car.posYGet());
                    }
                }
                catch (InvalidOperationException e) //TODO: Try to make a mutex kind of solution to this problem.
                {
                    Console.WriteLine("Exception Handled!");
                }
            }
        }

        public Bitmap RefreshFrame(GameState gameState)
        {
            FillsBackground();
            DrawsStreets(gameState.streets);
            DrawsChar(gameState.mainChar);
            return frame;
        }
    }
}
