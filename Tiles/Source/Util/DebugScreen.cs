using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using RPGGame.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Util
{
	class DebugScreen
	{
		SpriteBatch SpriteBatch;
		RateCounter FPSRate;
		RateCounter UPSRate;
		WorldSystem WorldSystem;
		WorldTime WorldTime;
		Camera2D Camera;

		public DebugScreen(SpriteBatch spriteBatch, WorldSystem worldSystem, WorldTime worldTime, Camera2D camera)
		{
			SpriteBatch = spriteBatch;
			FPSRate = new RateCounter();
			UPSRate = new RateCounter();
			WorldSystem = worldSystem;
			WorldTime = worldTime;
			Camera = camera;
		}

		public void UpdateUPS(GameTime gameTime)
		{
			UPSRate.Update(gameTime);
		}

		public void UpdateFPS(GameTime gameTime)
		{
			FPSRate.Update(gameTime);
		}

		public void Draw(GameTime gameTime, Camera2D camera)
		{

			string fpsString = "FPS: " + (int)FPSRate.GetAverageRate();
			string upsString = "UPS: " + (int)UPSRate.GetAverageRate();
			string timeString = "Day " + WorldTime.DayNightCycles + ", " + WorldTime.Hours + ":" + WorldTime.Minutes + ":" + WorldTime.Seconds + "      " + WorldTime.GetTimeOfDayNightCycle();
			string chunksRender = "Chunks Rendered: " + Miscellaneous.GetChunksInFrame(WorldSystem, Camera).Count;

			SpriteBatch.Begin();
			SpriteBatch.DrawString(GameContent.DefaultFont, fpsString, new Vector2(0, 1), Color.Red);
			SpriteBatch.DrawString(GameContent.DefaultFont, upsString, new Vector2(0, 25), Color.Red);
			SpriteBatch.DrawString(GameContent.DefaultFont, timeString, new Vector2(200, 1), Color.Red);
			SpriteBatch.DrawString(GameContent.DefaultFont, chunksRender, new Vector2(0, 49), Color.Red);
			SpriteBatch.End();

			SpriteBatch.Begin(transformMatrix: camera.GetViewMatrix());
			foreach(Chunk chunk in Miscellaneous.GetChunksInFrame(WorldSystem, camera))
			{
				Vector2 borderOrigin = (chunk.Position * Constants.ChunkDim * Constants.TileDim) - new Vector2(Constants.TileDim / 2.0f);
				Vector2 borderEnd = (borderOrigin + Constants.ChunkDim * Constants.TileDim) - new Vector2(Constants.TileDim / 2.0f);
				SpriteBatch.DrawLine(borderOrigin.X, borderOrigin.Y, borderOrigin.X, borderEnd.Y + 20, Color.Red, 2f);
				SpriteBatch.DrawLine(borderOrigin.X, borderOrigin.Y, borderEnd.X + 20, borderOrigin.Y, Color.Red, 2f);
			}
			SpriteBatch.End();
		}
	}
}
