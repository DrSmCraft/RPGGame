using Microsoft.Xna.Framework.Graphics;

namespace RPGGame.Tiles
{
    public class TileGravel : TileBase
    {
        public TileGravel(SpriteBatch spriteBatch) : base(spriteBatch, TileMap.TileNames["Gravel"],
            GameContent.GravelTexture, Constants.TileDim / 32f) // 32f because texture is 32 pixels
        {
        }
    }
}