using Microsoft.Xna.Framework;
using RPGGame.Source.Util;
using RPGGame.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Biomes
{
	class BiomeSwamp : BiomeBase
	{
		public BiomeSwamp() : base(new Vector2(1f, 0.0f))
		{
			SetTopTiles(new TileBase[] { TileMap.TileDict[TileMap.TileNames["Grass"]], TileMap.TileDict[TileMap.TileNames["Dirt"]], TileMap.TileDict[TileMap.TileNames["Water"]] });
		}

		public override TileBase GetTileAtValue(float value)
		{
			return (TileBase)GameMath.RandomChoice(TopTiles);
		}
	}
}
