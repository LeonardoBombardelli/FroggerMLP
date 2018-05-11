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
        /* Members */
        private Graphics canvas;
        private Bitmap frame;
        int i = 1;

        //Textures to render
        private Bitmap charTexture;


        /* Methods */
        //Constructor
        public GraphicsEngine()
        {
            frame = new Bitmap(Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
            canvas = Graphics.FromImage(frame);

            loadAssets();
        }

        private void loadAssets()
        {
            charTexture = FroggerMLP.Properties.Resources.charSprite;
        }

        private void fillsBackground()
        {
            canvas.FillRectangle(new SolidBrush(Color.Beige), 0, 0, Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
        }

        private void drawsChar(int Width, int Height)
        {
            canvas.DrawImage(charTexture, Width, Height);
        }

        public Bitmap refreshFrame()
        {
            fillsBackground();
            drawsChar(100, 100);
            return frame;
        }
    }
}
