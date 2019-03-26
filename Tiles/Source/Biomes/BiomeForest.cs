using Microsoft.Xna.Framework;
using RPGGame.Source.Util;
using RPGGame.Tiles;
using SharpNoise.Modules;


namespace RPGGame.Source.Biomes
{
	class BiomeForest : BiomeBase
	{
		public BiomeForest() : base(new Vector2(1f, 0.0f))
		{
			SetTopTiles(new TileBase[] { TileMap.TileDict[TileMap.TileNames["Dirt"]], TileMap.TileDict[TileMap.TileNames["Grass"]], TileMap.TileDict[TileMap.TileNames["Grass"]] });
		}

		//public override TileBase GetTileAtValue(float value)
		//{
		//	Checkerboard noise = new Checkerboard();
		//	Logger.Manager.Log("hhhhhhhhhhhh            " + noise.GetValue((int)GameMath.RandomChoice(0, 1, 2, 3, 4, 5, 6, 7, 8, 9), (int)GameMath.RandomChoice(0, 1, 2, 3, 4, 5, 6, 7, 8, 9), 0));
		//	return TopTiles[(int)(noise.GetValue(value, value, 0) * TopTiles.Length)];
		//	return (TileBase)GameMath.RandomChoice(TopTiles);
		//}

		public override TileBase GetTileAtValue(float x, float y)
		{
			Checkerboard noise = new Checkerboard();
			int value = (int)(noise.GetValue(x, y, 0) * (TopTiles.Length - 1));

			if (value < 0){
				value = 0;
			}
			return TopTiles[value];
		}
		
	}
}
