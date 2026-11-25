using ICS4U_Monogame_5._5;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ICS4U_Brick_Breaker
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ResolutionManager _resolutionManager;

        Texture2D brickTexture;
        Texture2D ballTexture;
        Texture2D paddleTexture;

        List<Brick> bricks;

        Rectangle window;

        MouseState mouseState;
        MouseState prevMouseState;
        KeyboardState keyboardState;
        KeyboardState prevKeyboardState;

        Ball ball;

        Paddle paddle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _resolutionManager = new ResolutionManager(1280, 720);

            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            //_graphics.PreferredBackBufferWidth = 112;
            //_graphics.PreferredBackBufferHeight = 216;

            _graphics.IsFullScreen = false;

            _graphics.ApplyChanges();

            window = new Rectangle(0, 0, _resolutionManager.VirtualWidth, _resolutionManager.VirtualHeight);

            bricks = new List<Brick>();

            base.Initialize();

            for (int i = 0; i < 11; i++)
            {
                for (int x = 0; x < 4; x++)
                    bricks.Add(new Brick(new Rectangle(105 * i + 60, 100 * x + 50, 100, 40), brickTexture));
            }

            ball = new Ball(ballTexture, window);

            paddle = new Paddle(paddleTexture, window);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            brickTexture = Content.Load<Texture2D>("images/rectangle");

            ballTexture = Content.Load<Texture2D>("images/circle");

            paddleTexture = Content.Load<Texture2D>("images/paddle");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            Vector2 physicalMousePosition = new Vector2(mouseState.X, mouseState.Y);
            Matrix resolutionMatrix = _resolutionManager.GetTransformationMatrix(GraphicsDevice);
            Matrix inverseMatrix = Matrix.Invert(resolutionMatrix);
            Vector2 virtualMousePosition = Vector2.Transform(physicalMousePosition, inverseMatrix);

            paddle.Update(keyboardState);
            ball.Update(bricks, paddle);
            //ball.Bounce();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Matrix resolutionMatrix = _resolutionManager.GetTransformationMatrix(GraphicsDevice);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(transformMatrix: resolutionMatrix, samplerState: SamplerState.PointClamp);

            _spriteBatch.Draw(brickTexture, window, Color.Teal);

            foreach (Brick brick in bricks)
            {
                brick.Draw(_spriteBatch, Color.White);
            }

            paddle.Draw(_spriteBatch);

            ball.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
