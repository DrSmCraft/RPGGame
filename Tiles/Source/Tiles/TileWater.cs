using Microsoft.Xna.Framework.Graphics;

namespace RPGGame.Tiles
{
    public class TileWater : TileBase
    {
        public TileWater(SpriteBatch spriteBatch) : base(spriteBatch, TileMap.TileNames["Water"],
            GameContent.WaterTexture, Constants.TileDim / 32f) // 32f because texture is 32 pixels
        {
        }
    }
}