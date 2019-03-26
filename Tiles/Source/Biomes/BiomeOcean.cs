using Microsoft.Xna.Framework;
using RPGGame.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Biomes
{
	class BiomeOcean : BiomeBase
	{
		public BiomeOcean() : base(new Vector2(0.5f, 1f))
		{
			SetTopTiles(new TileBase[] { TileMap.TileDict[TileMap.TileNames["Water"]] });
		}
	}
}
