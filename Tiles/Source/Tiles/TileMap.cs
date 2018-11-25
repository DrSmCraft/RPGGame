using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

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
            TileNames["Grass"] = 0;
            TileNames["Gravel"] = 1;
            TileNames["Sand"] = 2;
            TileNames["Water"] = 3;
            TileNames["TallGrass"] = 4;
        }

        public static void GenerateTileDictionary()
        {
            TileDict[0] = new TileGrass(SpriteBatch);
            TileDict[1] = new TileGravel(SpriteBatch);
            TileDict[2] = new TileSand(SpriteBatch);
            TileDict[3] = new TileWater(SpriteBatch);
            TileDict[4] = new TileTallGrass(SpriteBatch);  
        }

    }
}