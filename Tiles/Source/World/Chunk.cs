using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using RPGGame.Tiles;

namespace RPGGame.World
{
    public class Chunk
    {
        public SpriteBatch SpriteBatch;
        public Vector2 Position;
        private int[,] Tiles;

        public Chunk(SpriteBatch spriteBatch, Vector2 position)
        {
            SpriteBatch = spriteBatch;
            Position = position;
            Tiles = new int[(int) Constants.ChunkDim.Y, (int) Constants.ChunkDim.X];
            GenerateTiles();
        }

        public void GenerateTiles()
        {
            Random random = new Random();
            for (int y = 0; y < Constants.ChunkDim.Y; y++)
            {
                for (int x = 0; x < Constants.ChunkDim.X; x++)
                {
                    Tiles[y, x] = random.Next(0, 4);
                }
            }
        }

        public int GetTileId(Vector2 pos) // get tile at pos
        {
            if (pos.X < 0)
            {
                Console.Out.WriteLine("WARNING: Trying to access tile in chunk where x < 0\nDefaulting to 0.");
                return GetTileId(new Vector2(0, pos.Y));
            }

            if (pos.X > Constants.ChunkDim.X)
            {
                Console.Out.WriteLine("WARNING: Trying to access tile in chunk where x < " + Constants.ChunkDim.X + "\nDefaulting to " + Constants.ChunkDim.X + ".");
                return GetTileId(new Vector2(Constants.ChunkDim.X, pos.Y));
            }
            
            if (pos.Y < 0)
            {
                Console.Out.WriteLine("WARNING: Trying to access tile in chunk where y < 0\nDefaulting to 0.");
                return GetTileId(new Vector2(pos.X, 0));
            }

            if (pos.Y > Constants.ChunkDim.Y)
            {
                Console.Out.WriteLine("WARNING: Trying to access tile in chunk where y < " + Constants.ChunkDim.Y + "\nDefaulting to " + Constants.ChunkDim.Y + ".");
                return GetTileId(new Vector2(pos.X, Constants.ChunkDim.Y));
            }

            return Tiles[(int) pos.Y, (int) pos.X];
        }

        public int GetTileId(int posX, int posY)
        {
            return GetTileId(new Vector2(posX, posY));
        }

        public void Draw(GameTime gameTime, Camera2D camera)
        {
            for (int y = 0; y < Constants.ChunkDim.Y; y++)
            {
                for (int x = 0; x < Constants.ChunkDim.X; x++)
                {
                    Vector2 position = new Vector2(Position.X * Constants.ChunkDim.X + x, Position.Y * Constants.ChunkDim.Y + y);
                    TileMap.TileDict[Tiles[y, x]].Draw(gameTime, position * Constants.TileDim, camera);
                }
            }
        }
    }
}