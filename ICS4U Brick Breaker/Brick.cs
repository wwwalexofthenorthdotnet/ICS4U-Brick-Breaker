using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS4U_Brick_Breaker
{
    internal class Brick
    {

        private Rectangle _brickRect;
        private Texture2D _brickTexture;
        private Color _color;


        public Brick(Rectangle brickRect, Texture2D brickTexture)
        {
            _brickRect = brickRect;
            _brickTexture = brickTexture;
        }

        public bool Intersects(Rectangle rectangle)
        {
            return _brickRect.Intersects(rectangle);
        }

        public Rectangle Rectangle { get { return _brickRect; } }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(_brickTexture, _brickRect, color);
        }
    }
}
