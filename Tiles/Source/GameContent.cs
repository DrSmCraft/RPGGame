using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace RPGGame
{
    public class GameContent
    {
        public static Texture2D GrassTexture, GravelTexture, SandTexture, WaterTexture, TallGrassTexture;
        public static BitmapFont DefaultFont;

		public static Effect LightMask;
		public static Texture2D LightMaskTexture;


        public static void LoadContent(ContentManager manager)
        {
            GrassTexture = manager.Load<Texture2D>(@"Textures/Tiles/Grass");
            GravelTexture = manager.Load<Texture2D>(@"Textures/Tiles/Gravel");
            SandTexture = manager.Load<Texture2D>(@"Textures/Tiles/Sand");
            WaterTexture = manager.Load<Texture2D>(@"Textures/Tiles/Water");
            TallGrassTexture = manager.Load<Texture2D>(@"Textures/Tiles/TallGrass");

            DefaultFont = manager.Load<BitmapFont>(@"Fonts/DefaultFont");

			LightMask = manager.Load<Effect>(@"Effects/LightEffect");
			LightMaskTexture = manager.Load<Texture2D>(@"Effects/Textures/LightMask");

		}
    }
}