using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using RPGGame.Source.Biomes;

namespace RPGGame.Tiles
{
	public class BiomeMap
	{
		public static SpriteBatch SpriteBatch;

		public static Dictionary<int, BiomeBase> BiomeDict = new Dictionary<int, BiomeBase>();
		public static Dictionary<string, int> BiomeNames = new Dictionary<string, int>();

		

		public static void GenerateBiomeTypes()
		{
			GenerateBiomeNames();
			GenerateBiomeDictionary();
		}

		public static void GenerateBiomeNames()
		{
			BiomeNames["Grassland"] = 0;
			BiomeNames["Desert"] = 1;
			BiomeNames["Mountain"] = 2;
			BiomeNames["Ocean"] = 3;
			BiomeNames["FrozenDesert"] = 4;
			BiomeNames["FrozenOcean"] = 5;
			BiomeNames["Forest"] = 6;
			BiomeNames["Jungle"] = 7;
			BiomeNames["Swamp"] = 8;

		}

		public static void GenerateBiomeDictionary()
		{
			BiomeDict[0] = new BiomeGrassland();
			BiomeDict[1] = new BiomeDesert();
			BiomeDict[2] = new BiomeMountain();
			BiomeDict[3] = new BiomeOcean();
			BiomeDict[4] = new BiomeFrozenDesert();
			BiomeDict[5] = new BiomeFrozenOcean();
			BiomeDict[6] = new BiomeForest(); 
			BiomeDict[7] = new BiomeGrassland(); // Change to Jungle
			BiomeDict[8] = new BiomeSwamp(); // Change to Swamp
		}

		public static int GetBiomeId(float temp, float humidity)
		{
			if (temp > 0.0f && temp <= 0.25f)
			{
				if (humidity > 0.0f && humidity <= 0.25f)
				{
					return BiomeNames["FrozenDesert"];
				}
				else if(humidity >= 0.25f && humidity < 0.5f)
				{
					return BiomeNames["FrozenDesert"];
				}
				else if (humidity >= 0.5f && humidity < 0.75f)
				{
					return BiomeNames["FrozenOcean"];
				}
				else if (humidity >= 0.75f && humidity < 1f)
				{
					return BiomeNames["Ocean"];
				}

			}

			else if(temp >= 0.25f && temp < 0.5f)
			{
				if (humidity > 0.0f && humidity <= 0.25f)
				{
					return BiomeNames["Grassland"];
				}
				else if (humidity >= 0.25f && humidity < 0.5f)
				{
					return BiomeNames["Grassland"];
				}
				else if (humidity >= 0.5f && humidity < 0.75f)
				{
					return BiomeNames["Forest"];
				}
				else if (humidity >= 0.75f && humidity < 1f)
				{
					return BiomeNames["Forest"];
				}
			}

			else if (temp >= 0.5f && temp < 0.75f)
			{
				if (humidity > 0.0f && humidity <= 0.25f)
				{
					return BiomeNames["Grassland"];
				}
				else if (humidity >= 0.25f && humidity < 0.5f)
				{
					return BiomeNames["Grassland"];
				}
				else if (humidity >= 0.5f && humidity < 0.75f)
				{
					return BiomeNames["Forest"];
				}
				else if (humidity >= 0.75f && humidity < 1f)
				{
					return BiomeNames["Forest"];
				}
			}
			else if (temp >= 0.75f && temp < 1f)
			{
				if (humidity > 0.0f && humidity <= 0.25f)
				{
					return BiomeNames["Desert"];
				}
				else if (humidity >= 0.25f && humidity < 0.5f)
				{
					return BiomeNames["Grassland"];
				}
				else if (humidity >= 0.5f && humidity < 0.75f)
				{
					return BiomeNames["Swamp"];
				}
				else if (humidity >= 0.75f && humidity < 1f)
				{
					return BiomeNames["Jungle"];
				}
			}
			return BiomeNames["Ocean"];

		}

		public static BiomeBase GetBiome(float temp, float humidity)
		{
			return BiomeDict[GetBiomeId(temp, humidity)];
		}
	}
}