using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using RPGGame.Source.Util;

namespace RPGGame.World
{
    public class WorldSystem : GameObject
    {
        public Chunk[,] Chunks;
        public SpriteBatch SpriteBatch;

        public WorldSystem(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
            Chunks = new Chunk[(int) Constants.WorldDim.Y, (int) Constants.WorldDim.X];
            GenerateWorld();
        }

        public void GenerateWorld()
        {
            for (var y = 0; y < Constants.WorldDim.Y; y++)
            for (var x = 0; x < Constants.WorldDim.X; x++)
            {
                Chunks[y, x] = new Chunk(SpriteBatch, new Vector2(x, y));
            }
        }

        public int GetTileId(Vector2 pos)
        {
            if (pos.X < 0)
            {
				Logger.Manager.Log(LogType.WARNING, "Trying to access tile in world where x < 0\nDefaulting to 0.");
                return GetTileId(new Vector2(0, pos.Y));
            }

            if (pos.X > Constants.WorldDim.X * Constants.ChunkDim.X)
            {
				Logger.Manager.Log(LogType.WARNING, "Trying to access tile in world where x < " + Constants.WorldDim.X * Constants.ChunkDim.X +
                                      "\nDefaulting to " + Constants.WorldDim.X * Constants.ChunkDim.X + ".");
                return GetTileId(new Vector2(Constants.WorldDim.X, pos.Y));
            }

            if (pos.Y < 0)
            {
				Logger.Manager.Log(LogType.WARNING, "Trying to access tile in world where y < 0\nDefaulting to 0.");
                return GetTileId(new Vector2(pos.X, 0));
            }

            if (pos.Y > Constants.WorldDim.Y * Constants.ChunkDim.Y)
            {
                Logger.Manager.Log(LogType.WARNING, "Trying to access tile in world where y < " + Constants.WorldDim.Y * Constants.ChunkDim.Y +
                                      "\nDefaulting to " + Constants.WorldDim.Y * Constants.ChunkDim.Y + ".");
                return GetTileId(new Vector2(pos.X, Constants.WorldDim.Y));
            }

			return GetChunk(new Vector2(pos.Y % Constants.WorldDim.Y, pos.X % Constants.WorldDim.X))
                .GetTileId((int) (pos.X % Constants.ChunkDim.X), (int) (pos.Y % Constants.ChunkDim.Y));
        }

		public Chunk GetChunk(Vector2 pos)
		{
			if (pos.X < 0)
			{
				Logger.Manager.Log(LogType.WARNING, "Trying to access chunk in world where x < 0\nDefaulting to 0.");
				return GetChunk(new Vector2(0, pos.Y));
			}

			if (pos.X >= Constants.WorldDim.X)
			{
				Logger.Manager.Log(LogType.WARNING, "Trying to access chunk in world where x < " + Constants.WorldDim.X +
									  "\nDefaulting to " + Constants.WorldDim.X + ".");
				return GetChunk(new Vector2(Constants.WorldDim.X- 1, pos.Y));
			}

			if (pos.Y < 0)
			{
				Logger.Manager.Log(LogType.WARNING, "Trying to access chunk in world where y < 0\nDefaulting to 0.");
				return GetChunk(new Vector2(pos.X, 0));
			}

			if (pos.Y >= Constants.WorldDim.Y)
			{
				Logger.Manager.Log(LogType.WARNING, "Trying to access chunk in world where y < " + Constants.WorldDim.Y +
									  "\nDefaulting to " + Constants.WorldDim.Y + ".");
				return GetChunk(new Vector2(pos.X, Constants.WorldDim.Y - 1));
			}
			return Chunks[(int) pos.Y, (int) pos.X];
		}

		public Chunk GetChunk(int posX, int posY)
		{
			return GetChunk(new Vector2(posX, posY));
		}

        public void Draw(GameTime gameTime, Camera2D camera)
        {
            for (var y = 0; y < Constants.WorldDim.Y; y++)
            for (var x = 0; x < Constants.WorldDim.X; x++)
                Chunks[y, x].Draw(gameTime, camera);
        }

		
	}
}