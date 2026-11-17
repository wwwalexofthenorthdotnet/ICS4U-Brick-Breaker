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

        List<Brick> bricks;

        Rectangle window;

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
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            brickTexture = Content.Load<Texture2D>("images/rectangle");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Matrix resolutionMatrix = _resolutionManager.GetTransformationMatrix(GraphicsDevice);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(transformMatrix: resolutionMatrix, samplerState: SamplerState.PointClamp);

            _spriteBatch.Draw(brickTexture, window, Color.Green);

            foreach (Brick brick in bricks)
            {
                brick.Draw(_spriteBatch, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
