using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace RPGGame.Source.Util
{
	public abstract class GameObject
	{
		public virtual void Draw(GameTime gameTime)
		{
			Logger.Manager.Log(LogType.WARNING, "Calling virtual method GameObject.Draw\nOverride this method!");
		}

		public virtual void Draw(GameTime gameTime, Camera2D camera)
		{
			Logger.Manager.Log(LogType.WARNING, "Calling virtual method GameObject.Draw\nOverride this method!");
		}

		public virtual void Draw(GameTime gameTime, Vector2 position)
		{
			Logger.Manager.Log(LogType.WARNING, "Calling virtual method GameObject.Draw\nOverride this method!");
		}

		public virtual void Draw(GameTime gameTime, Vector2 position, Camera2D camera)
		{
			Logger.Manager.Log(LogType.WARNING, "Calling virtual method GameObject.Draw\nOverride this method!");
		}

		public virtual void DrawRaw(GameTime gameTime)
		{
			Logger.Manager.Log(LogType.WARNING, "Calling virtual method GameObject.DrawRaw\nOverride this method!");
		}
	}
}
