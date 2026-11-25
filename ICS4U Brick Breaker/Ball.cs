using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ICS4U_Brick_Breaker
{ 
    internal class Ball
    {
        private Texture2D _ballTexture;
        private Rectangle _ballRect;
        private Vector2 _speed;

        private Rectangle _window;

        private List<Brick> _bricks;

        private Random _generator;


        public Ball(Texture2D ballTexture, Rectangle window)
        {
            _ballTexture = ballTexture;

            _generator = new Random();
            

            _ballRect = new Rectangle(window.Width / 2 - 25, 500, 50, 50);

            _window = window;

            _speed = new Vector2(0, -1);
        }

        public void Update(List<Brick> bricks, Paddle paddle)
        {
            // Horizontal bounce
            bool bounce = false;
            bool paddleBounce = false;
            _ballRect.X += (int)_speed.X;
            for (int i = 0; i < bricks.Count; i++)
            {
                if (bricks[i].Intersects(_ballRect))
                {
                    bricks.RemoveAt(i);
                    i--;
                    bounce = true;
                }

            }


            if (paddle.Intersects(_ballRect))
            {
                paddleBounce = true;
            }

            if (bounce)
            {
                _speed.X *= -1;
                bounce = false;

            }

            if (paddleBounce)
            {
                int difference =  _ballRect.Center.X - paddle.PaddleCenter.X;

                int baseSpeed = 0;

                //_speed.X = -difference / 15;

                if (difference >= 25)
                {
                    _speed.X = 0;
                }
                else if (difference <= -25)
                {
                    _speed.X = 0;
                }
                else
                    _speed.Y = 100;

                paddleBounce = false;
            }


            //Vertical bounce

            _ballRect.Y += (int)_speed.Y;
            for (int i = 0; i < bricks.Count; i++)
            {
                if (bricks[i].Intersects(_ballRect))
                {
                    bricks.RemoveAt(i);
                    i--;
                    bounce = true;
                }

            }

            if (paddle.Intersects(_ballRect) && _speed.Y > 0)
            {
                bounce = true;
            }

            if (bounce)
            {
                _speed.Y *= -1;
                bounce = false;

            }

            if (_ballRect.Top <= _window.Top || _ballRect.Bottom >= _window.Bottom)
                _speed.Y *= -1;

            if (_ballRect.X <= _window.Left || _ballRect.Right >= _window.Right)
                _speed.X *= -1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_ballTexture, _ballRect, Color.White);
        }

    }

    
}
