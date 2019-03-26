using Microsoft.Xna.Framework;
using RPGGame.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Biomes
{
	class BiomeFrozenDesert : BiomeBase
	{
		public BiomeFrozenDesert() : base(new Vector2(0.0f, 0.0f))
		{
			SetTopTiles(new TileBase[] {TileMap.TileDict[TileMap.TileNames["Snow"]] });
		}
	}
}
