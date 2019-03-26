using Microsoft.Xna.Framework.Graphics;
using RPGGame.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Tiles
{
	class TileDirt :  TileBase
	{
		public TileDirt(SpriteBatch spriteBatch) : base(spriteBatch, TileMap.TileNames["Dirt"],
			GameContent.DirtTexture, Constants.TileDim / 32f) // 32f because texture is 32 pixels
		{
		}
	}
}
