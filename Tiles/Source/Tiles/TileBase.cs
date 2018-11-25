using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace RPGGame.Tiles
{
    public abstract class TileBase
    {
        public Texture2D Texture;
        public readonly int Id;
        private readonly float Scale;
        public SpriteBatch SpriteBatch;

        public TileBase(SpriteBatch spriteBatch, int id, Texture2D texture, float scale = 1.0f)
        {
            this.SpriteBatch = spriteBatch;
            this.Id = id;
            this.Texture = texture;
            this.Scale = scale;
        }
        

        public virtual void Draw(GameTime gameTime, Vector2 position, Camera2D camera)
        {
            var origin = new Vector2((float) Texture.Width / 2, (float) Texture.Height / 2);
            SpriteBatch.Begin(transformMatrix: camera.GetViewMatrix());
            SpriteBatch.Draw(Texture, position, null, Color.White, 0.0f, origin, Scale,
                SpriteEffects.None, 0f);
            SpriteBatch.End();
        }

        public virtual void Draw(GameTime gameTime, Vector2 position)
        {
            var origin = new Vector2((float) Texture.Width / 2, (float) Texture.Height / 2);
            SpriteBatch.Begin();
            SpriteBatch.Draw(Texture, position, null, Color.White, 0.0f, origin, Scale,
                SpriteEffects.None, 0f);
            SpriteBatch.End();
        }

        public virtual void Draw(GameTime gameTime, Camera2D camera)
        {
            Draw(gameTime, Vector2.Zero, camera);
        }

        public virtual void Draw(GameTime gameTime)
        {
            Draw(gameTime, Vector2.Zero);
        }

        
    }
}