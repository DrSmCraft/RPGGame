using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Util
{
	class Normalizer
	{
		float lowerBound;
		float upperBound;

		public Normalizer(float lower=0.0f, float upper=1.0f)
		{
			lowerBound = lower;
			upperBound = upper;
		}

		public float Normalize(float value)
		{
			if(value > upperBound)
			{
				return upperBound;
			}
			else if(value < lowerBound)
			{
				return lowerBound;
			}
			return value;
		}
	}
}
