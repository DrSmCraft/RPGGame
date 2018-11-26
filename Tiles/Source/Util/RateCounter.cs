using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace RPGGame.Source.Util
{
    internal class RateCounter
    {
        public const int Max_Frames = 100;
        public float AvgFrames;
        private readonly Queue<float> Buffer;
        public float CurrentFrames;
        public int TotalFrames;
        public float TotalSeconds;

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
            if (Buffer.Count > Max_Frames)
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