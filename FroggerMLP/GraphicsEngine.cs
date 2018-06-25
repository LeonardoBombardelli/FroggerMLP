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

        //Textures to render
        private Bitmap charTexture;


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
        }

        private void FillsBackground()
        {
            canvas.FillRectangle(new SolidBrush(Color.Beige), 0, 0, Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
        }

        private void DrawsChar(MainChar player)
        {
            canvas.DrawImage(charTexture, (float)player.posXGet(),(float)player.posYGet());
        }

        public Bitmap RefreshFrame(GameState gameState)
        {
            FillsBackground();
            DrawsChar(gameState.mainChar);
            return frame;
        }
    }
}
