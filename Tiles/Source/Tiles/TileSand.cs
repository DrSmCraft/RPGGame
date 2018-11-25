using Microsoft.Xna.Framework.Graphics;

namespace RPGGame.Tiles
{
    public class TileSand : TileBase
    {
        public TileSand(SpriteBatch spriteBatch) : base(spriteBatch, TileMap.TileNames["Sand"], GameContent.sandTexture, scale: Constants.TileDim / 32f) // 32f because texture is 32 pixels)
        {
            
        }
    }
}