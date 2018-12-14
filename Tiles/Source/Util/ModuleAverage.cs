using SharpNoise.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Util
{
	public class ModuleAverage : Module
	{


		
			
			public Module Source0
			{
				get { return SourceModules[0]; }
				set { SourceModules[0] = value; }
			}

			
			public Module Source1
			{
				get { return SourceModules[1]; }
				set { SourceModules[1] = value; }
			}

			
			public ModuleAverage()
				: base(2)
			{

			}

			
			public override double GetValue(double x, double y, double z)
			{
				return GameMath.Average((float)SourceModules[0].GetValue(x, y, z), (float)SourceModules[1].GetValue(x, y, z));
			}
		}
	}



