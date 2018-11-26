using Microsoft.Xna.Framework;

namespace RPGGame
{
    public class Constants
    {
        public static Vector2 WorldDim = new Vector2(10, 10); // World size, in chunks
        public static Vector2 ChunkDim = new Vector2(20, 20); // Chunk size, in tiles
        public static int TileDim = 25; // Tile size, in pixels, Default 25

		public static Vector2 WindowDim = new Vector2(800, 600); // Game Window Size

		//public static Vector2 WindowDim = ChunkDim * TileDim; // Game Window Size, 1 Chunk Visible

		public static float MaxZoom = 5f;
		public static float MinZoom = 0f;
		public static float ZoomAmount = 0.5f;
    }
}