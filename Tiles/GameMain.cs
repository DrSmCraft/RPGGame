using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using RPGGame.Source.Util;
using RPGGame.Tiles;
using RPGGame.World;
using System;

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
		private KeyboardState PreviousKeybourdState;
		private float Zoom = 0;
		Lighting LightOverlay;
		WorldTime WorldTime;
		bool PauseWorldTime = false;

		public GameMain()
		{
			Graphics = new GraphicsDeviceManager(this);
			Graphics.PreferredBackBufferWidth = (int)Constants.WindowDim.X;
			Graphics.PreferredBackBufferHeight = (int)Constants.WindowDim.Y;
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			IsFixedTimeStep = true;
			Window.AllowUserResizing = true;

		}

		protected override void Initialize()
		{

			SpriteBatch = new SpriteBatch(GraphicsDevice);
			var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Graphics.PreferredBackBufferWidth,
			   Graphics.PreferredBackBufferHeight);
			GraphicsDevice.PresentationParameters.RenderTargetUsage = RenderTargetUsage.PreserveContents;
			Camera = new Camera2D(viewportAdapter);

			Constants.LoadObjects(GraphicsDevice, SpriteBatch, Camera);



			LoadContent();


			WorldTime = new WorldTime();


			WorldSystem = new WorldSystem(SpriteBatch);

			DebugScreen = new DebugScreen(SpriteBatch, WorldSystem, WorldTime, Camera);

			LightOverlay = new Lighting(GameContent.LightMask, GameContent.LightMaskTexture, GraphicsDevice, SpriteBatch, new Color(Color.Black, 0.8f), Color.White);


			LogStartupInformation();

			PreviousKeybourdState = Keyboard.GetState();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			TileMap.SetSpriteBatch(SpriteBatch);
			TileMap.GenerateTileTypes();

			GameContent.LoadContent(Content); // Load all textures
		}

		protected override void Update(GameTime gameTime)
		{
			CheckAspectRatio();
			if (!PauseWorldTime)
			{
				WorldTime.Update(gameTime);
			}

			HandleKeyboard();
			HandleMouse();
			DebugScreen.UpdateUPS(gameTime);


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);
			LightOverlay.Draw(gameTime, new Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth / 2.0f, GraphicsDevice.PresentationParameters.BackBufferHeight / 2.0f), zoom: Zoom);

			foreach (Chunk c in Miscellaneous.GetChunksInFrame(WorldSystem, Camera))
			{
				c.Draw(gameTime, Camera);
			}

			LightOverlay.SetBackgroundColor(Miscellaneous.GetColorOfDayNightCycle(WorldTime));
			if (!Constants.IgnoreDayNightEffects)
			{
				LightOverlay.Splice(gameTime);
			}

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
			KeyboardState currentKeyboardState = Keyboard.GetState();
			//if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			//    Keyboard.GetState().IsKeyDown(Keys.Escape))
			//    Exit();
			if (currentKeyboardState.IsKeyDown(Keys.Escape) && !PreviousKeybourdState.IsKeyDown(Keys.Escape))
				Exit();

			if (currentKeyboardState.IsKeyDown(Keys.A) && !PreviousKeybourdState.IsKeyDown(Keys.A)) Camera.Move(-Constants.PlayerMovementSpeed * Vector2.UnitX);
			if (currentKeyboardState.IsKeyDown(Keys.D) && !PreviousKeybourdState.IsKeyDown(Keys.D)) Camera.Move(Constants.PlayerMovementSpeed * Vector2.UnitX);
			if (currentKeyboardState.IsKeyDown(Keys.S) && !PreviousKeybourdState.IsKeyDown(Keys.S)) Camera.Move(Constants.PlayerMovementSpeed * Vector2.UnitY);
			if (currentKeyboardState.IsKeyDown(Keys.W) && !PreviousKeybourdState.IsKeyDown(Keys.W)) Camera.Move(-Constants.PlayerMovementSpeed * Vector2.UnitY);
			if (currentKeyboardState.IsKeyDown(Keys.Tab) && !PreviousKeybourdState.IsKeyDown(Keys.Tab))
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
			if (currentKeyboardState.IsKeyDown(Keys.P) && !PreviousKeybourdState.IsKeyDown(Keys.P))
			{
				PauseWorldTime = !PauseWorldTime;
				if (ShowDebugInfo)
				{
					Logger.Manager.Log(LogType.DEBUG, "World Time is PAUSED");
				}
				else
				{
					Logger.Manager.Log(LogType.DEBUG, "World Time is UNPAUSED");
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






		private void LogStartupInformation()
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

		public Rectangle CheckAspectRatio()
		{
			float aspectRatio = (float)GraphicsDevice.PresentationParameters.BackBufferWidth / (float)GraphicsDevice.PresentationParameters.BackBufferHeight;
			//Logger.Manager.Log(LogType.DEBUG, aspectRatio);

			Rectangle dst;
			if (aspectRatio <= Constants.PreferredAspectRatio)
			{
				// output is taller than it is wider, bars on top/bottom
				int presentHeight = (int)((Window.ClientBounds.Width / Constants.PreferredAspectRatio) + 0.5f);
				int barHeight = (Window.ClientBounds.Height - presentHeight) / 2;
				dst = new Rectangle(0, barHeight, Window.ClientBounds.Width, presentHeight);
			}
			else
			{
				// output is wider than it is tall, bars left/right
				int presentWidth = (int)((Window.ClientBounds.Height * Constants.PreferredAspectRatio) + 0.5f);
				int barWidth = (Window.ClientBounds.Width - presentWidth) / 2;
				dst = new Rectangle(barWidth, 0, presentWidth, Window.ClientBounds.Height);
			}
			return dst;
		}


	}
}