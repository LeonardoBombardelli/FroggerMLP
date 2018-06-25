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

        private Directions lastPlayerDirection = Directions.Up;

        //Textures to render
        private Bitmap charTextureFront;
        private Bitmap charTextureBack;
        private Bitmap charTextureLeft;
        private Bitmap charTextureRight;
        private Bitmap carTextureBlue;
        private Bitmap streetSprite;
        private Bitmap safeStreetSprite;

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
            charTextureFront = FroggerMLP.Properties.Resources.duckyFront;
            charTextureBack = FroggerMLP.Properties.Resources.duckyBack;
            charTextureLeft = FroggerMLP.Properties.Resources.duckyLeft;
            charTextureRight = FroggerMLP.Properties.Resources.duckyRight;
            carTextureBlue = FroggerMLP.Properties.Resources.SimpleBlueCarTopView;
            streetSprite = FroggerMLP.Properties.Resources.Street;
            safeStreetSprite = FroggerMLP.Properties.Resources.safeStreet;
        }

        private void FillsBackground()
        {
            canvas.FillRectangle(new SolidBrush(Color.Beige), 0, 0, Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
        }

        private void DrawsChar(Directions dir, MainChar player)
        {
            if (dir == Directions.None)
                dir = lastPlayerDirection;
            if(dir == Directions.Left)
            {
                canvas.DrawImage(charTextureLeft, (float)player.posXGet(), (float)player.posYGet());
                lastPlayerDirection = Directions.Left;
            }
            else if (dir == Directions.Right)
            {
                canvas.DrawImage(charTextureRight, (float)player.posXGet(), (float)player.posYGet());
                lastPlayerDirection = Directions.Right;
            }
            else if (dir == Directions.Up)
            {
                canvas.DrawImage(charTextureBack, (float)player.posXGet(), (float)player.posYGet());
                lastPlayerDirection = Directions.Up;
            }
            else if (dir == Directions.Down)
            {
                canvas.DrawImage(charTextureFront, (float)player.posXGet(), (float)player.posYGet());
                lastPlayerDirection = Directions.Down;
            }

        }

        private void DrawsStreets(List<Street> streets)
        {
            foreach(Street street in streets)
            {
                try
                {
                    if(street.IsSafe())
                        canvas.DrawImage(safeStreetSprite, INITIAL_STREET_X, (float)street.yPos);
                    else
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
            DrawsChar(gameState.ReturnPlayerDirection(), gameState.mainChar);
            return frame;
        }
    }
}
