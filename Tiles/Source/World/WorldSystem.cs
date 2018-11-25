using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;

namespace RPGGame.World
{
    public class WorldSystem : EntityProcessingSystem
    {
        public SpriteBatch SpriteBatch;
        public Chunk[,] Chunks;
        
        public WorldSystem(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
            Chunks = new Chunk[(int) Constants.WorldDim.Y, (int) Constants.WorldDim.X];
            GenerateWorld();
        }

        public void GenerateWorld()
        {
            for (int y = 0; y < Constants.WorldDim.Y; y++)
            {
                for (int x = 0; x < Constants.WorldDim.X; x++)
                {
                    Chunks[y, x] = new Chunk(SpriteBatch, new Vector2(x, y));
                    Chunks[y, x].GenerateTiles();
                }
            }
        }

        public int GetTileId(Vector2 pos)
        {
            if (pos.X < 0)
            {
                Console.Out.WriteLine("WARNING: Trying to access tile in world where x < 0\nDefaulting to 0.");
                return GetTileId(new Vector2(0, pos.Y));
            }
            if (pos.X > Constants.WorldDim.X)
            {
                Console.Out.WriteLine("WARNING: Trying to access tile in world where x < " + Constants.WorldDim.X + "\nDefaulting to " + Constants.WorldDim.X + ".");
                return GetTileId(new Vector2(Constants.WorldDim.X, pos.Y));
            }
            
            if (pos.Y < 0)
            {
                Console.Out.WriteLine("WARNING: Trying to access tile in world where y < 0\nDefaulting to 0.");
                return GetTileId(new Vector2(pos.X, 0));
            }

            if (pos.Y > Constants.WorldDim.Y)
            {
                Console.Out.WriteLine("WARNING: Trying to access tile in world where y < " + Constants.WorldDim.Y + "\nDefaulting to " + Constants.WorldDim.Y + ".");
                return GetTileId(new Vector2(pos.X, Constants.WorldDim.Y));
            }
            
            return Chunks[(int) (pos.Y % Constants.WorldDim.Y), (int) (pos.X % Constants.WorldDim.X)]
                .GetTileId((int) (pos.X % Constants.ChunkDim.X), (int) (pos.Y % Constants.ChunkDim.Y));
        }

        public void Draw(GameTime gameTime, Camera2D camera)
        {
            for (int y = 0; y < Constants.WorldDim.Y; y++)
            {
                for (int x = 0; x < Constants.WorldDim.X; x++)
                {
                    Chunks[y, x].Draw(gameTime, camera);
                }
            }
        }
    }
}