using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace RPGGame
{
    public class GameContent
    {
        public static Texture2D grassTexture, gravelTexture, sandTexture, waterTexture, tallGrassTexture;
		public static BitmapFont defaultFont;


        

        public static void LoadContent(ContentManager manager)
        {
            grassTexture = manager.Load<Texture2D>(@"Textures/Tiles/Grass");
            gravelTexture = manager.Load<Texture2D>(@"Textures/Tiles/Gravel");
            sandTexture = manager.Load<Texture2D>(@"Textures/Tiles/Sand");
            waterTexture = manager.Load<Texture2D>(@"Textures/Tiles/Water");
            tallGrassTexture = manager.Load<Texture2D>(@"Textures/Tiles/TallGrass");

			defaultFont = manager.Load<BitmapFont>(@"Fonts/DefaultFont");

		}
	}
}