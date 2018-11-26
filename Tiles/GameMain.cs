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
		private int PreviousMouseWheelValue = 0;
		private float Zoom = 0;

        public GameMain()
        {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferWidth = (int) Constants.WindowDim.X;
            Graphics.PreferredBackBufferHeight = (int) Constants.WindowDim.Y;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
			IsFixedTimeStep = false;
			Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            LoadContent();
            Console.Out.WriteLine(typeof(GraphicsDevice));
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Graphics.PreferredBackBufferWidth,
                Graphics.PreferredBackBufferHeight);
            Camera = new Camera2D(viewportAdapter);

			DebugScreen = new DebugScreen(SpriteBatch);


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
			HandleMouse();
			DebugScreen.UpdateUPS(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
			foreach (Chunk c in GetChunksInFrame())
			{
				c.Draw(gameTime, Camera);
			}

			DebugScreen.UpdateFPS(gameTime);
			DebugScreen.Draw(gameTime);
            
            base.Draw(gameTime);
        }

        private void HandleKeyboard() 
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.A)) Camera.Move(-20 * Vector2.UnitX);
            if (Keyboard.GetState().IsKeyDown(Keys.D)) Camera.Move(20 * Vector2.UnitX);
            if (Keyboard.GetState().IsKeyDown(Keys.S)) Camera.Move(20 * Vector2.UnitY);
            if (Keyboard.GetState().IsKeyDown(Keys.W)) Camera.Move(-20 * Vector2.UnitY);
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

		


		private List<Chunk> GetChunksInFrame(Camera2D camera) // Returns Chunks completely or partially in frame TODO Test this Method
		{
			Vector2 topLeftChunkPos = new Vector2(camera.BoundingRectangle.TopLeft.X, camera.BoundingRectangle.TopLeft.Y) / (Constants.ChunkDim.X * Constants.TileDim);
			Vector2 bottomRightChunkPos = new Vector2(camera.BoundingRectangle.BottomRight.X, camera.BoundingRectangle.BottomRight.Y) / (Constants.ChunkDim.X * Constants.TileDim);

			Chunk topLeftChunk = WorldSystem.GetChunk(topLeftChunkPos);
			Chunk bottomRightChunk = WorldSystem.GetChunk(bottomRightChunkPos);

			List<Chunk> chunksInFrame = new List<Chunk>();
			for (int y = (int)topLeftChunk.Position.Y; y <= (int)bottomRightChunk.Position.Y; y++)
			{
				for(int x = (int)topLeftChunk.Position.X; x <= (int)bottomRightChunk.Position.X; x++)
				{
					chunksInFrame.Add(WorldSystem.GetChunk(x, y));
				}
			}

			return chunksInFrame;



			
		}
		private List<Chunk> GetChunksInFrame()
		{
			return GetChunksInFrame(Camera);
		}

		protected override void OnExiting(object sender, EventArgs args)
		{
			Logger.Print();
			base.OnExiting(sender, args);
		}
	}
}