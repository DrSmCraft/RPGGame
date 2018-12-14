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
		public RenderTarget2D LightsTarget;
		SpriteBatch SpriteBatch;
		GraphicsDevice Device;
		RenderTarget2D MainTarget;
		Camera2D Camera;
		Color BackgroundColor;
		Color ForegroundColor;
		float Scale = 3f; // Must be bigger than 1

		public Lighting(Effect effect, Texture2D texture, GraphicsDevice device, SpriteBatch spriteBatch, Color backgroundColor, Color foregroundColor)
		{
			Effect = effect;
			Texture = texture;
			SpriteBatch = Constants.SpriteBatch;
			Device = Constants.GraphicsDevice;
			Camera = Constants.Camera;
			BackgroundColor = backgroundColor;
			ForegroundColor = foregroundColor;

			var pp = Device.PresentationParameters;

			LightsTarget = new RenderTarget2D(Device, pp.BackBufferWidth, pp.BackBufferHeight);
			MainTarget = Constants.MainRenderTarget;
		}

		public Lighting(Effect effect, Texture2D texture, GraphicsDevice device, SpriteBatch spriteBatch)
		{
			Effect = effect;
			Texture = texture;
			SpriteBatch = Constants.SpriteBatch;
			Device = Constants.GraphicsDevice;
			Camera = Constants.Camera;
			BackgroundColor = Color.Black;
			ForegroundColor = Color.White;
			

			var pp = Device.PresentationParameters;

			LightsTarget = new RenderTarget2D(Device, pp.BackBufferWidth, pp.BackBufferHeight);
			MainTarget = Constants.MainRenderTarget;
		}

		

		public void Draw(GameTime gameTime, Vector2 position, float zoom = 1.0f)
		{
			float size = GameMath.Pow(Scale, zoom);
			Device.SetRenderTarget(LightsTarget);

			Device.Clear(BackgroundColor);
			//SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
			//var origin = new Vector2((float)Texture.Width / 2, (float)Texture.Height / 2);
			////draw light mask where there should be torches etc...
			//	SpriteBatch.Draw(Texture, position, null, ForegroundColor, 0.0f, origin, size,
			//		SpriteEffects.None, 0f);
			
			
			//SpriteBatch.End();
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

		public void SetBackgroundColor(Color color)
		{
			BackgroundColor = color;
		}
		

		
	}
}
