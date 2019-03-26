using Microsoft.Xna.Framework;
using RPGGame.Tiles;

namespace RPGGame.Source.Biomes
{
	class BiomeDesert : BiomeBase
	{
		public BiomeDesert() : base(new Vector2(1f, 0.0f))
		{
			SetTopTiles(new TileBase[] { TileMap.TileDict[TileMap.TileNames["Sand"]] });
		}
	}
}
