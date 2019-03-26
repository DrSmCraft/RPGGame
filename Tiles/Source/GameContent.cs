using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;
using RPGGame.Source.Util;

namespace RPGGame
{
    public class GameContent
    {
		public static Texture2D GrassTexture, GravelTexture, SandTexture, WaterTexture, SnowTexture, DirtTexture, IceTexture, StoneTexture;

		public static BitmapFont DefaultFont;

		public static Effect LightMask;
		public static Texture2D LightMaskTexture;


        public static void LoadContent(ContentManager manager)
        {
            GrassTexture = manager.Load<Texture2D>(@"Textures/Tiles/Grass");
            GravelTexture = manager.Load<Texture2D>(@"Textures/Tiles/Gravel");
            SandTexture = manager.Load<Texture2D>(@"Textures/Tiles/Sand");
            WaterTexture = manager.Load<Texture2D>(@"Textures/Tiles/Water");
            SnowTexture = manager.Load<Texture2D>(@"Textures/Tiles/Snow");
			DirtTexture = manager.Load<Texture2D>(@"Textures/Tiles/Dirt");
			IceTexture = manager.Load<Texture2D>(@"Textures/Tiles/Ice");
			StoneTexture = manager.Load<Texture2D>(@"Textures/Tiles/Stone");


            DefaultFont = manager.Load<BitmapFont>(@"Fonts/DefaultFont");

			LightMask = manager.Load<Effect>(@"Effects/LightEffect");
			LightMaskTexture = Miscellaneous.AddOpacityToTexture(manager.Load<Texture2D>(@"Effects/Textures/LightMask"), 0.8f);

		}
    }
}