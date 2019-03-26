using Microsoft.Xna.Framework;
using RPGGame.Tiles;


namespace RPGGame.Source.Biomes
{
	class BiomeFrozenOcean : BiomeBase
	{
		public BiomeFrozenOcean() : base(new Vector2(0.0f, 1f))
		{
			SetTopTiles(new TileBase[] { TileMap.TileDict[TileMap.TileNames["Ice"]] });
		}
	}
}
