using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;


// http://www.xnahub.com/simple-2d-lighting-system-in-c-and-monogame/
namespace RPGGame.Source.Util
{
	class Lighting
	{
		public static Texture2D Texture;
		public static Effect Effect;
		RenderTarget2D LightsTarget;
		SpriteBatch SpriteBatch;
		GraphicsDevice Device;
		RenderTarget2D MainTarget;
		Camera2D Camera;
		float Scale = 2f;

		public Lighting(Effect effect, Texture2D texture, GraphicsDevice device, SpriteBatch spriteBatch)
		{
			Effect = effect;
			Texture = texture;
			SpriteBatch = Constants.SpriteBatch;
			Device = Constants.GraphicsDevice;
			Camera = Constants.Camera;

			var pp = Device.PresentationParameters;

			LightsTarget = new RenderTarget2D(Device, pp.BackBufferWidth, pp.BackBufferHeight);
			MainTarget = Constants.MainRenderTarget;
		}

		public void Draw(GameTime gameTime)
		{
			Device.SetRenderTarget(LightsTarget);
			Device.Clear(Color.Black);
			SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
			var origin = new Vector2((float)Texture.Width / 2, (float)Texture.Height / 2);
			//draw light mask where there should be torches etc...
			Vector2 pos = new Vector2(Device.PresentationParameters.BackBufferWidth / 2.0f, Device.PresentationParameters.BackBufferHeight / 2.0f);
			SpriteBatch.Draw(Texture, pos, null, Color.White, 0.0f, origin, Scale,
				SpriteEffects.None, 0f);

			SpriteBatch.End();

			//Cleanup(gameTime);


		}

		public void Splice(GameTime gameTime)
		{
			SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
			Effect.Parameters["lightMask"].SetValue(LightsTarget);
			Effect.CurrentTechnique.Passes[0].Apply();
			SpriteBatch.Draw(MainTarget, Vector2.Zero, Color.White);
			SpriteBatch.End();
		}

		public void Cleanup(GameTime gameTime)
		{
			Device.SetRenderTarget(null);
		}

		
	}
}
