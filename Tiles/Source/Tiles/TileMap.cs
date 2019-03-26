using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using RPGGame.Source.Tiles;

namespace RPGGame.Tiles
{
    public class TileMap
    {
        public static SpriteBatch SpriteBatch;

        public static Dictionary<int, TileBase> TileDict = new Dictionary<int, TileBase>();
        public static Dictionary<string, int> TileNames = new Dictionary<string, int>();

        public static void SetSpriteBatch(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }

        public static void GenerateTileTypes()
        {
            GenerateTileNames();
            GenerateTileDictionary();
        }

        public static void GenerateTileNames()
        {
			TileNames["Water"] = 0;
			TileNames["Sand"] = 1;
			TileNames["Gravel"] = 2;
			TileNames["Grass"] = 3;
			TileNames["Stone"] = 4;
			TileNames["Snow"] = 5;
			TileNames["Ice"] = 6;
			TileNames["Dirt"] = 7;

        }

        public static void GenerateTileDictionary()
        {
			TileDict[0] = new TileWater(SpriteBatch);
			TileDict[1] = new TileSand(SpriteBatch);
			TileDict[2] = new TileGravel(SpriteBatch);
			TileDict[3] = new TileGrass(SpriteBatch);
			TileDict[4] = new TileStone(SpriteBatch);
			TileDict[5] = new TileSnow(SpriteBatch);
			TileDict[6] = new TileIce(SpriteBatch);
			TileDict[7] = new TileDirt(SpriteBatch);
        }
    }
}