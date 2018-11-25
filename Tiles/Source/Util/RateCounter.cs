using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Util
{
	class RateCounter
	{
		public int TotalFrames;
		public float TotalSeconds;
		public float AvgFrames;
		public float CurrentFrames;
		public const int Max_Frames = 100;
		private Queue<float> Buffer;

		public RateCounter()
		{
			TotalFrames = 0;
			TotalSeconds = 0;
			AvgFrames = 0;
			CurrentFrames = 0;
			Buffer = new Queue<float>();
		}

		public void Update(GameTime gameTime)
		{
			CurrentFrames = 1.0f / gameTime.ElapsedGameTime.Seconds;
			Buffer.Enqueue(CurrentFrames);
			if(Buffer.Count > Max_Frames)
			{
				Buffer.Dequeue();
				AvgFrames = Buffer.Average();
			}
			else
			{
				AvgFrames = CurrentFrames;
			}
			TotalFrames++;
			TotalSeconds += gameTime.ElapsedGameTime.Seconds;
		}

		public float GetAverageRate()
		{
			return AvgFrames;
		}
	}
}
