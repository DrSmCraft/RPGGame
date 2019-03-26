using Microsoft.Xna.Framework;
using RPGGame.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Biomes
{
	class BiomeMountain : BiomeBase
	{
		public BiomeMountain() : base(new Vector2(.25f, 0.5f))
		{
			SetTopTiles(new TileBase[] { TileMap.TileDict[TileMap.TileNames["Gravel"]], TileMap.TileDict[TileMap.TileNames["Stone"]] });
		}
	}
}
