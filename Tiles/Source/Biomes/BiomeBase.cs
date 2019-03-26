using Microsoft.Xna.Framework;
using RPGGame.Source.Util;
using RPGGame.Tiles;
using SharpNoise.Modules;

namespace RPGGame.Source.Biomes
{
	public abstract class BiomeBase
	{
		float Tempurature;
		float Humidity;
		protected TileBase[] TopTiles;


		public BiomeBase(float tempurature, float humidity)
		{
			Humidity = humidity;
			Tempurature = tempurature;
		}

		public BiomeBase(Vector2 tempuratureAndHumidity)
		{
			Tempurature = tempuratureAndHumidity.X;
			Humidity = tempuratureAndHumidity.Y;
		}

		public BiomeBase(Vector2 tempuratureAndHumidity, TileBase[] tiles)
		{
			Tempurature = tempuratureAndHumidity.X;
			Humidity = tempuratureAndHumidity.Y;
			SetTopTiles(tiles);
		}

		public BiomeBase(TileBase[] tiles)
		{
			SetTopTiles(tiles);
		}

		public void SetTopTiles(params TileBase[] tiles)
		{
			TopTiles = tiles;
		}



		//public virtual TileBase GetTileAtValue(float value)
		//{
		//	float id = value * TopTiles.Length - 1;
		//	if (id < 0)
		//	{
		//		id = 0;
		//	}

		//	return TopTiles[(int)id];
		//}


		public virtual TileBase GetTileAtValue(float value)
		{
			float id = value * TopTiles.Length - 1;
			if (id < 0)
			{
				id = 0;
			}

			return TopTiles[(int)id];
		}


		public virtual TileBase GetTileAtValue(float x, float y)
		{
			return TopTiles[0];
		}



	}
}
