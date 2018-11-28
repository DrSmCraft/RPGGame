using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using RPGGame.Source.Util;
using RPGGame.Tiles;
using RPGGame.World;
using System;
using System.Collections.Generic;

namespace RPGGame
{
	public class GameMain : Game
    {
        private Camera2D Camera;
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        private WorldSystem WorldSystem;
		private DebugScreen DebugScreen;
		private bool ShowDebugInfo = false;
		private int PreviousMouseWheelValue = 0;
		private float Zoom = 0;
		Lighting Lighting;
		WorldTime WorldTime;

		public GameMain()
        {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferWidth = (int) Constants.WindowDim.X;
            Graphics.PreferredBackBufferHeight = (int) Constants.WindowDim.Y;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
			IsFixedTimeStep = true;
			Window.AllowUserResizing = true;
			
        }

        protected override void Initialize()
        {
            LoadContent();
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Graphics.PreferredBackBufferWidth,
                Graphics.PreferredBackBufferHeight);
			GraphicsDevice.PresentationParameters.RenderTargetUsage = RenderTargetUsage.PreserveContents;
            Camera = new Camera2D(viewportAdapter);

			WorldTime = new WorldTime();


			Constants.LoadObjects(GraphicsDevice, SpriteBatch, Camera);
            WorldSystem = new WorldSystem(SpriteBatch);

			DebugScreen = new DebugScreen(SpriteBatch, WorldSystem, WorldTime);

			Lighting = new Lighting(GameContent.LightMask, GameContent.LightMaskTexture, GraphicsDevice, SpriteBatch);


			LogStartupInformation();

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
			WorldTime.Update(gameTime);
			
			HandleKeyboard();
			HandleMouse();
			DebugScreen.UpdateUPS(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
			GraphicsDevice.Clear(Color.Black);
			Lighting.Draw(gameTime);

			foreach (Chunk c in Miscellaneous.GetChunksInFrame(WorldSystem, Camera))
			{
				c.Draw(gameTime, Camera);
			}

			Lighting.Splice(gameTime);
			Constants.GraphicsDevice.SetRenderTarget(null);

			SpriteBatch.Begin();
			SpriteBatch.Draw(Constants.MainRenderTarget, Vector2.Zero, Color.White);
			SpriteBatch.End();









			DebugScreen.UpdateFPS(gameTime);
			if (ShowDebugInfo)
			{
				DebugScreen.Draw(gameTime, Camera);
			}

			base.Draw(gameTime);
		}

        private void HandleKeyboard() 
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.A)) Camera.Move(-Constants.PlayerMovementSpeed * Vector2.UnitX);
            if (Keyboard.GetState().IsKeyDown(Keys.D)) Camera.Move(Constants.PlayerMovementSpeed * Vector2.UnitX);
            if (Keyboard.GetState().IsKeyDown(Keys.S)) Camera.Move(Constants.PlayerMovementSpeed * Vector2.UnitY);
            if (Keyboard.GetState().IsKeyDown(Keys.W)) Camera.Move(-Constants.PlayerMovementSpeed * Vector2.UnitY);
			if (Keyboard.GetState().IsKeyDown(Keys.Tab))
			{
				ShowDebugInfo = !ShowDebugInfo;
				if (ShowDebugInfo)
				{
					Logger.Manager.Log(LogType.DEBUG, "Debug Info Mode tuned ON");
				}
				else
				{
					Logger.Manager.Log(LogType.DEBUG, "Debug Info Mode tuned OFF");
				}
			}
        }

		private void HandleMouse()
		{
			int delta = Mouse.GetState().ScrollWheelValue - PreviousMouseWheelValue;
			bool zoomInAllowed = true;
			bool zoomOutAllowed = true;
			if (Zoom >= Constants.MaxZoom)
			{
				Zoom = Constants.MaxZoom;
				zoomInAllowed = false;
				zoomOutAllowed = true;
			}
			else if (Zoom <= Constants.MinZoom)
			{
				Zoom = Constants.MinZoom;
				zoomOutAllowed = false;
				zoomInAllowed = true;
			}

			if (delta > 0 && zoomInAllowed)
			{
				Camera.ZoomIn(Constants.ZoomAmount);
				Zoom += Constants.ZoomAmount;
			}

			if (delta < 0 && zoomOutAllowed)
			{

				Camera.ZoomOut(Constants.ZoomAmount);
				Zoom -= Constants.ZoomAmount;
			}

			PreviousMouseWheelValue = Mouse.GetState().ScrollWheelValue;
		}

		


		

		public void LogStartupInformation()
		{
			Logger.Manager.Log(LogType.INFO, "Initializing Systems");
			Logger.Manager.Log(LogType.INFO, "Chunk Dimension setting is " + Constants.ChunkDim);
			Logger.Manager.Log(LogType.INFO, "World initiated with dimensions of " + Constants.WorldDim + " Chunks");

		}

		protected override void OnExiting(object sender, EventArgs args)
		{
			Logger.Manager.Log(LogType.INFO, "Exiting");
			base.OnExiting(sender, args);
		}
	}
}