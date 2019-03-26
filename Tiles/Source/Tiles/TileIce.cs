using Microsoft.Xna.Framework.Graphics;
using RPGGame.Tiles;


namespace RPGGame.Source.Tiles
{
	class TileIce : TileBase
	{
		public TileIce(SpriteBatch spriteBatch) : base(spriteBatch, TileMap.TileNames["Ice"],
			GameContent.IceTexture, Constants.TileDim / 32f) // 32f because texture is 32 pixels
		{
		}
	}
}
