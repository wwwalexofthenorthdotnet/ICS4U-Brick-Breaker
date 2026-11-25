using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS4U_Brick_Breaker
{
    internal class Paddle
    {
        private Texture2D _paddleTexture;
        private Rectangle _paddleRect;
        private Rectangle _window;

        public Paddle(Texture2D paddleTexture, Rectangle window)
        {
            _paddleTexture = paddleTexture;

            _paddleRect = new Rectangle(window.Width / 2 - 50, 550, 100, 30);

            _window = window;
        }

        public Point PaddleCenter { get { return _paddleRect.Center; } }



        public void Update(KeyboardState keyboardState)
        { 

            if (keyboardState.IsKeyDown(Keys.D))
            {
                _paddleRect.X += 2;
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                _paddleRect.X -= 2;

            }


        }

        public bool Intersects(Rectangle rectangle)
        {
            return _paddleRect.Intersects(rectangle);
        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_paddleTexture, _paddleRect, Color.White);
        }
    }
}
