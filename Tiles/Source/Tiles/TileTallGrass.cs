using Microsoft.Xna.Framework.Graphics;

namespace RPGGame.Tiles
{
    public class TileTallGrass : TileBase
    {
        public TileTallGrass(SpriteBatch spriteBatch) : base(spriteBatch, TileMap.TileNames["TallGrass"],
            GameContent.tallGrassTexture, Constants.TileDim / 32f) // 32f because texture is 32 pixels)
        {
        }
    }
}