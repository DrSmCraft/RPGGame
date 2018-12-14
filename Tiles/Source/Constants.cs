using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace RPGGame
{
    public class Constants
    {
		// Object settings
		public static GraphicsDevice GraphicsDevice;
		public static SpriteBatch SpriteBatch;
		public static Camera2D Camera;
		public static RenderTarget2D MainRenderTarget;

		// World settings
		public static Vector2 WorldDim = new Vector2(50, 50); // World size, in chunks
        public static Vector2 ChunkDim = new Vector2(10, 10); // Chunk size, in tiles
        public static int TileDim = 25; // Tile size, in pixels, Default 25

		public static Vector2 WindowDim = new Vector2(800, 600); // Game Window Size
		public static float PreferredAspectRatio = WindowDim.X / WindowDim.Y;

		//public static Vector2 WindowDim = ChunkDim * TileDim; // Game Window Size, 1 Chunk Visible

		// Zoom settings
		public static float MaxZoom = 10f; // Default 5f
		public static float MinZoom = -0.5f; // Default 0f
		public static float ZoomAmount = 0.5f;

		// Time Settings
		public static int SpeedUpRate = 1; // For Debuging, speed up time, Default 1
		public static int TickToWorldTimeRatio = 20000 / SpeedUpRate; // Ratio of Ticks to WorldSeconds Default 10000
		public static int WorldSecondsToWorldMinute = 60; // How many WorldSeconds are in a WorldMinute;
		public static int WorldMinutesToWorldHours = 60; // How many WorldMinutes are in a WorldHour;
		public static int DawnLength = 4; // in WorldTime Hours
		public static int DayLength = 8; // in WorldTime Hours
		public static int DuskLength = 4; // in WorldTime Hours
		public static int NightLength = 8; // in WorldTime Hours
		public static int DayNightCycleLength = DawnLength + DayLength + DuskLength + NightLength;

		public static Color DayOverlayColor = new Color(1.0f, 1.0f, 1.0f, 0.8f);
		public static bool IgnoreDayNightEffects = true;

		// Player settings
		public static float PlayerMovementSpeed = 20f;

		

		// Debug Settings
		public static bool StreamLogToConsole = true;
		public static float PeriodicLogTime = 15;



		// Methods
		public static void SetGraphicsDevice(GraphicsDevice device)
		{
			GraphicsDevice = device;
		}

		public static void SetSpriteBatch(SpriteBatch batch)
		{
			SpriteBatch = batch;
		}

		public static void SetCamera(Camera2D camera)
		{
			Camera = camera;
		}

		public static void LoadObjects(GraphicsDevice device, SpriteBatch batch, Camera2D camera)
		{
			SetGraphicsDevice(device);
			SetSpriteBatch(batch);
			SetCamera(camera);
			SetRenderTarget();

		}

		public static void SetRenderTarget(RenderTarget2D target)
		{
			MainRenderTarget = target;
		}

		public static void SetRenderTarget(GraphicsDevice device)
		{
			MainRenderTarget = new RenderTarget2D(device, device.PresentationParameters.BackBufferWidth, device.PresentationParameters.BackBufferHeight);
		}

		public static void SetRenderTarget()
		{
			MainRenderTarget = new RenderTarget2D(GraphicsDevice, GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight);
			//MainRenderTarget = new RenderTarget2D(GraphicsDevice, GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight, false, SurfaceFormat.Color, DepthFormat.Depth24, 32, RenderTargetUsage.PreserveContents);
			//MainRenderTarget.RenderTargetUsage = RenderTargetUsage.PreserveContents;
		}

	}
}