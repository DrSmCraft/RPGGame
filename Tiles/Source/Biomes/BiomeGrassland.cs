using Microsoft.Xna.Framework;
using RPGGame.Tiles;

namespace RPGGame.Source.Biomes
{
	class BiomeGrassland : BiomeBase
	{
		public BiomeGrassland() : base(new Vector2(0.75f, 0.5f))
		{
			SetTopTiles(new TileBase[] { TileMap.TileDict[TileMap.TileNames["Grass"]] });
		}
	}
}
