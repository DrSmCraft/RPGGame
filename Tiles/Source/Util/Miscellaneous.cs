using Microsoft.Xna.Framework;
using MonoGame.Extended;
using RPGGame.World;
using System.Collections.Generic;


namespace RPGGame.Source.Util
{
	public static class Miscellaneous
	{
		public static List<Chunk> GetChunksInFrame(WorldSystem worldSystem, Camera2D camera) // Returns Chunks completely or partially in frame TODO Test this Method
		{
			Vector2 topLeftChunkPos = new Vector2(camera.BoundingRectangle.TopLeft.X, camera.BoundingRectangle.TopLeft.Y) / (Constants.ChunkDim.X * Constants.TileDim);
			Vector2 bottomRightChunkPos = new Vector2(camera.BoundingRectangle.BottomRight.X, camera.BoundingRectangle.BottomRight.Y) / (Constants.ChunkDim.X * Constants.TileDim);

			Chunk topLeftChunk = worldSystem.GetChunk(topLeftChunkPos);
			Chunk bottomRightChunk = worldSystem.GetChunk(bottomRightChunkPos);

			List<Chunk> chunksInFrame = new List<Chunk>();
			for (int y = (int)topLeftChunk.Position.Y; y <= (int)bottomRightChunk.Position.Y; y++)
			{
				for (int x = (int)topLeftChunk.Position.X; x <= (int)bottomRightChunk.Position.X; x++)
				{
					chunksInFrame.Add(worldSystem.GetChunk(x, y));
				}
			}
			return chunksInFrame;
		}
	}
}
