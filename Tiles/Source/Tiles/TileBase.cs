using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using RPGGame.Source.Util;

namespace RPGGame.Tiles
{
    public abstract class TileBase: GameObject
    {
        public readonly int Id;
        private readonly float Scale;
        public SpriteBatch SpriteBatch;
        public Texture2D Texture;

        public TileBase(SpriteBatch spriteBatch, int id, Texture2D texture, float scale = 1.0f)
        {
            SpriteBatch = spriteBatch;
            Id = id;
            Texture = texture;
            Scale = scale;
        }


        public override void Draw(GameTime gameTime, Vector2 position, Camera2D camera)
        {
			Constants.GraphicsDevice.SetRenderTarget(Constants.MainRenderTarget);
			var origin = new Vector2((float) Texture.Width / 2, (float) Texture.Height / 2);

			SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.GetViewMatrix());
			//SpriteBatch.Begin(transformMatrix: camera.GetViewMatrix());
			SpriteBatch.Draw(Texture, position, null, Color.White, 0.0f, origin, Scale,
                SpriteEffects.None, 0f);
            SpriteBatch.End();			


		}

		public void Cleanup(GameTime gameTime)
		{
			Constants.GraphicsDevice.SetRenderTarget(null);

		}

		public override void Draw(GameTime gameTime, Vector2 position)
        {
            var origin = new Vector2((float) Texture.Width / 2, (float) Texture.Height / 2);
            SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
            SpriteBatch.Draw(Texture, position, null, Color.White, 0.0f, origin, Scale,
                SpriteEffects.None, 0f);
            SpriteBatch.End();
        }

		public override void Draw(GameTime gameTime, Camera2D camera)
        {
            Draw(gameTime, Vector2.Zero, camera);
        }

		public override void Draw(GameTime gameTime)
        {
            Draw(gameTime, Vector2.Zero);
        }

		//public override void DrawRaw(GameTime gameTime)
		//{
		//	SpriteBatch.Draw(Texture, position, null, Color.White, 0.0f, origin, Scale,
		//		SpriteEffects.None, 0f);
		//}
	}
}