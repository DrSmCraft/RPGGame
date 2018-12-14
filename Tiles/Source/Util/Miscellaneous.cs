using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

		public static Texture2D AddOpacityToTexture(Texture2D texture, float alpha)
		{
			Color[] originalColorData = new Color[texture.Width * texture.Height];
			Color[] newColorData = new Color[texture.Width * texture.Height];
			
			for(int i = 0; i < originalColorData.Length; i++)
			{
				newColorData[i] = new Color(originalColorData[i], alpha);
			}
			Texture2D outTexture = new Texture2D(Constants.GraphicsDevice, texture.Width, texture.Height);
			outTexture.SetData<Color>(newColorData);
			return outTexture;
		}

		public static Color GetColorOfDayNightCycle(WorldTime time) // Needs more work to make it seem gradual and seamless
		{
			int hourSince;
			int currentHour = time.Hours;
			float halfDay = Constants.DayNightCycleLength / 2.0f;

			bool isTimeIncline = currentHour < halfDay; // Is it the begging of the day

			if (isTimeIncline)
			{
				hourSince = currentHour;
				Vector4 dayColorVector = Constants.DayOverlayColor.ToVector4();
				float multFactor = hourSince / halfDay;
				return new Color(dayColorVector.X * multFactor, dayColorVector.Y * multFactor, dayColorVector.Z * multFactor, dayColorVector.W);
			}
			else
			{
				hourSince = currentHour;
				Vector4 dayColorVector = Constants.DayOverlayColor.ToVector4();
				float multFactor = (hourSince - halfDay) / halfDay;
				return new Color(1 - (dayColorVector.X * multFactor), 1- (dayColorVector.Y * multFactor), 1 - (dayColorVector.Z * multFactor), dayColorVector.W);
			}

		}
	}
}
