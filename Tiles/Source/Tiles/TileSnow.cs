using Microsoft.Xna.Framework.Graphics;
using RPGGame.Tiles;

namespace RPGGame.Source.Tiles
{
	class TileSnow : TileBase
	{
		public TileSnow(SpriteBatch spriteBatch) : base(spriteBatch, TileMap.TileNames["Snow"],
			GameContent.SnowTexture, Constants.TileDim / 32f) // 32f because texture is 32 pixels
		{
		}
	}
}
