using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using MonoGame.Extended.ViewportAdapters;
using RPGGame.Source.Util;
using RPGGame.Tiles;
using RPGGame.World;


namespace RPGGame
{
    public class GameMain : Game
    {
        GraphicsDeviceManager Graphics;
        SpriteBatch SpriteBatch;
        private Camera2D Camera;
        private WorldSystem WorldSystem;
		private RateCounter UPSCounter;
		private RateCounter FPSCounter;

        public GameMain()
        {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferWidth = (int) Constants.WindowDim.X;
            Graphics.PreferredBackBufferHeight = (int) Constants.WindowDim.Y;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            
        }

        protected override void Initialize()
        {
            LoadContent();
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight);
            Camera = new Camera2D(viewportAdapter);

			UPSCounter = new RateCounter();
			FPSCounter = new RateCounter();
            WorldSystem = new WorldSystem(SpriteBatch);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            TileMap.SetSpriteBatch(SpriteBatch);
            TileMap.GenerateTileTypes();
            
            GameContent.LoadContent(Content); // Load all textures
        }

        protected override void Update(GameTime gameTime)
        {
            HandleKeyboard();
			UPSCounter.Update(gameTime);
			//Console.Out.WriteLine(UPSCounter.GetAverageRate());
            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
			FPSCounter.Update(gameTime);
            GraphicsDevice.Clear(Color.White);
            WorldSystem.Draw(gameTime, Camera);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("FPS: ");
			stringBuilder.Append(FPSCounter.GetAverageRate());
			Console.Out.WriteLine(stringBuilder);
			SpriteBatch.Begin();
            SpriteBatch.DrawString(GameContent.defaultFont, stringBuilder, new Vector2(0, 1), Color.Red);
			SpriteBatch.End();
            base.Draw(gameTime);
        }

        private void HandleKeyboard()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Camera.Move(-20 * Vector2.UnitX);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Camera.Move(20 * Vector2.UnitX);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Camera.Move(20 * Vector2.UnitY);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Camera.Move(-20 * Vector2.UnitY);
            }
        }

        
    }
}