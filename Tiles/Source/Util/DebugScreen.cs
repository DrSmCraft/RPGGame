using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;
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

		public DebugScreen(SpriteBatch spriteBatch)
		{
			SpriteBatch = spriteBatch;
			FPSRate = new RateCounter();
			UPSRate = new RateCounter();
		}

		public void UpdateUPS(GameTime gameTime)
		{
			UPSRate.Update(gameTime);
		}

		public void UpdateFPS(GameTime gameTime)
		{
			FPSRate.Update(gameTime);
		}

		public void Draw(GameTime gameTime)
		{
			string fpsString = "FPS: " + (int)FPSRate.GetAverageRate();
			string upsString = "UPS: " + (int)UPSRate.GetAverageRate();

			SpriteBatch.Begin();
			SpriteBatch.DrawString(GameContent.defaultFont, fpsString, new Vector2(0, 1), Color.Red);
			SpriteBatch.DrawString(GameContent.defaultFont, upsString, new Vector2(0, 25), Color.Red);
			SpriteBatch.End();
		}
	}
}
