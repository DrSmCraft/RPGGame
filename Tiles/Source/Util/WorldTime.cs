using Microsoft.Xna.Framework;
using System;

namespace RPGGame.Source.Util
{
	public enum TimeOfDayNightCycle
	{
		Dawn = 0,
		Day = 4,
		Dusk = 4 + 8,
		Night = 4 + 8 + 4
	}

	public class WorldTime
	{
		GameTime GameTime;
		public int TotalTicks;
		public int Ticks;
		public int TotalSeconds;
		public int Seconds;
		public int TotalMinutes;
		public int Minutes;
		public int TotalHours;
		public int Hours;
		public int DayNightCycles;




		public WorldTime()
		{
			GameTime = new GameTime();
			Update();
		}

		public void Update(GameTime gameTime)
		{
			GameTime = gameTime;
			Update();
		}

		public void Update()
		{
			TotalTicks = (int) GameTime.TotalGameTime.Ticks;
			TotalSeconds = TotalTicks / Constants.TickToWorldTimeRatio;
			TotalMinutes = TotalSeconds / Constants.WorldSecondsToWorldMinute;
			TotalHours = TotalMinutes / Constants.WorldMinutesToWorldHours;
			DayNightCycles = TotalHours / Constants.DayNightCycleLength;

			Seconds = TotalSeconds % Constants.WorldSecondsToWorldMinute;
			Minutes = TotalMinutes % Constants.WorldMinutesToWorldHours;
			Hours = TotalHours % Constants.DayNightCycleLength;

		}


		public TimeOfDayNightCycle GetTimeOfDayNightCycle()
		{
			if(Hours < Constants.DawnLength)
			{
				return TimeOfDayNightCycle.Dawn;
			}
			if(Hours >= Constants.DawnLength && Hours <= Constants.DawnLength + Constants.DayLength)
			{
				return TimeOfDayNightCycle.Day;
			}
			if(Hours >= Constants.DawnLength + Constants.DayLength && Hours <= Constants.DawnLength + Constants.DayLength + Constants.DuskLength){
				return TimeOfDayNightCycle.Dusk;
			}
			return TimeOfDayNightCycle.Night;
		}



	}
}
