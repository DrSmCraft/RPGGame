using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using RPGGame.Source.Biomes;
using RPGGame.Source.Util;
using RPGGame.Tiles;
using SharpNoise.Modules;

namespace RPGGame.World
{
    public class Chunk : GameObject
    {
        public Vector2 Position;
        public SpriteBatch SpriteBatch;
        private readonly int[,] Tiles;

        public Chunk(SpriteBatch spriteBatch, Vector2 position)
        {
            SpriteBatch = spriteBatch;
            Position = position;
            Tiles = new int[(int) Constants.ChunkDim.Y, (int) Constants.ChunkDim.X];
            GenerateTiles();
        }

		public void GenerateTiles()
		{
			//Voronoi biomeNiose = new Voronoi();
			//biomeNiose.Seed = Constants.Seed;

			//RidgedMulti baseNoise = new RidgedMulti();
			//baseNoise.Seed = Constants.Seed;
			//baseNoise.OctaveCount = 1;

			//Perlin topNoise = new Perlin();
			//topNoise.Seed = Constants.Seed;
			//topNoise.OctaveCount = 10;
			//topNoise.Persistence = 0.3f;
			//topNoise.Frequency = 2;
			//topNoise.Lacunarity = 1;


			//Add noise = new Add();
			//noise.Source0 = baseNoise;
			//noise.Source1 = topNoise;

			Perlin tempNoise = new Perlin();
			tempNoise.Seed = Constants.Seed;

			Perlin humidityNoise = new Perlin();
			humidityNoise.Seed = Constants.Seed + 1;

			Normalizer norm = new Normalizer(0.0f, 1.0f);

			float scale = .01f; // 0.001f
			for (var y = 0; y < Constants.ChunkDim.Y; y++)
			{
				for (var x = 0; x < Constants.ChunkDim.X; x++)
				{
					//Vector3 simplexLoc = new Vector3((x + (Position.X * Constants.ChunkDim.X)) * scale, (y + (Position.Y * Constants.ChunkDim.Y)) * scale, 0);
					//double tileId = baseNoise.GetValue(simplexLoc.X, simplexLoc.Y, simplexLoc.Z);
					//double biomeId = biomeNiose.GetValue((x + (Position.X * Constants.ChunkDim.X)) * scale, (y + (Position.Y * Constants.ChunkDim.Y)) * scale, 0);
					//biomeId = ((biomeId + 1) / 2) * BiomeMap.BiomeDict.Count;
					//tileId = BiomeMap.BiomeDict[(int)biomeId].GetTileAtValue(norm.Normalize((float)(tileId + 1) / 2)).Id;
					float xValue = (x + (Position.X * Constants.ChunkDim.X)) * scale;
					float yValue = (y + (Position.Y * Constants.ChunkDim.Y)) * scale;

					float tempValue = norm.Normalize((float)(tempNoise.GetValue(xValue, yValue, 0) + 1) / 2);
					float humidityValue = norm.Normalize((float)(humidityNoise.GetValue(xValue, yValue, 0) + 1) / 2);
					//Logger.Manager.Log(tempValue + "       " + humidityValue);
					//BiomeBase biome = BiomeMap.BiomeDict[BiomeMap.BiomeNames["Swamp"]];
					BiomeBase biome = BiomeMap.GetBiome(tempValue, humidityValue);

					Tiles[y, x] = (int)biome.GetTileAtValue(x, y).Id;
				}
			}
		
        }

        public int GetTileId(Vector2 pos) // get tile at pos
        {
            if (pos.X < 0)
            {
                Logger.Manager.Log(LogType.WARNING, "Trying to access tile in chunk where x < 0\nDefaulting to 0.");
                return GetTileId(new Vector2(0, pos.Y));
            }

            if (pos.X > Constants.ChunkDim.X)
            {
				Logger.Manager.Log(LogType.WARNING, "Trying to access tile in chunk where x < " + Constants.ChunkDim.X +
                                      "\nDefaulting to " + Constants.ChunkDim.X + ".");
                return GetTileId(new Vector2(Constants.ChunkDim.X, pos.Y));
            }

            if (pos.Y < 0)
            {
				Logger.Manager.Log(LogType.WARNING, "Trying to access tile in chunk where y < 0\nDefaulting to 0.");
                return GetTileId(new Vector2(pos.X, 0));
            }

            if (pos.Y > Constants.ChunkDim.Y)
            {
				Logger.Manager.Log(LogType.WARNING, "Trying to access tile in chunk where y < " + Constants.ChunkDim.Y +
                                      "\nDefaulting to " + Constants.ChunkDim.Y + ".");
                return GetTileId(new Vector2(pos.X, Constants.ChunkDim.Y));
            }

            return Tiles[(int) pos.Y, (int) pos.X];
        }

        public int GetTileId(int posX, int posY)
        {
            return GetTileId(new Vector2(posX, posY));
        }

		public void SetTileId(Vector2 pos, int id)
		{
			Tiles[(int)pos.Y, (int)pos.X] = id;
		}

		public void SetTileId(int posX, int posY, int id)
		{
			SetTileId(new Vector2(posX, posY), id);
		}

		public override void Draw(GameTime gameTime, Camera2D camera)
        {
            for (var y = 0; y < Constants.ChunkDim.Y; y++)
            for (var x = 0; x < Constants.ChunkDim.X; x++)
            {
                var position = new Vector2(Position.X * Constants.ChunkDim.X + x,
                    Position.Y * Constants.ChunkDim.Y + y);

				
                TileMap.TileDict[Tiles[y, x]].Draw(gameTime, position * Constants.TileDim, camera);
            }
        }

		public override void Draw(GameTime gameTime)
		{
			for (var y = 0; y < Constants.ChunkDim.Y; y++)
				for (var x = 0; x < Constants.ChunkDim.X; x++)
				{
					var position = new Vector2(Position.X * Constants.ChunkDim.X + x,
						Position.Y * Constants.ChunkDim.Y + y);
					TileMap.TileDict[Tiles[y, x]].Draw(gameTime, position * Constants.TileDim);
				}
		}

		public override string ToString()
		{
			return "{Chunk at " + Position + " }";
		}
	}
}