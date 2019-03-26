using Microsoft.Xna.Framework.Graphics;
using RPGGame.Tiles;


namespace RPGGame.Source.Tiles
{
	class TileStone : TileBase
	{
		public TileStone(SpriteBatch spriteBatch) : base(spriteBatch, TileMap.TileNames["Stone"],
			GameContent.StoneTexture, Constants.TileDim / 32f) // 32f because texture is 32 pixels
		{
		}
	}
}
