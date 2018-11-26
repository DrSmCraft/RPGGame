using Microsoft.Xna.Framework.Graphics;

namespace RPGGame.Tiles
{
    public class TileGrass : TileBase
    {
        public TileGrass(SpriteBatch spriteBatch) : base(spriteBatch, TileMap.TileNames["Grass"],
            GameContent.grassTexture, Constants.TileDim / 32f) // 32f because texture is 32 pixels
        {
        }
    }
}