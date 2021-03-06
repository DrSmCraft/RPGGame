﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Util
{
	class GameMath
	{
		public static float Pow(float number, float exp)
		{
			return (float)Math.Pow((double)number, (double)exp);
		}

		public static float Root(float number, float n)
		{
			return Pow(number, Inv(n));
		}

		public static float Sqrt(float number)
		{
			return Root(number, 2.0f);
		}

		public static float Curt(float number)
		{
			return Root(number, 3.0f);
		}

		public static float Inv(float number)
		{
			return 1.0f / number;
		}

		public static float Abs(float number)
		{
			return (float)Math.Abs((double)number);
		}

		public static float Floor(float number)
		{
			return (float)Math.Floor((double)number);
		}

		public static float Ceiling(float number)
		{
			return (float)Math.Ceiling((double)number);
		}

		public static float Round(float number, int places)
		{
			return (float)Math.Round((double)number, places);
		}

		public static float Round(float number)
		{
			return Round(number, 0);
		}


		public static float Average(params float[] values)
		{
			float total = 0;
			foreach(float val in values)
			{
				total += val;
			}
			return total / values.Length;
		}

		public static object RandomChoice(params object[] options)
		{
			Random rand = new Random();
			int index = rand.Next(0, options.Length);
			return options[index];
		}
	}
}
