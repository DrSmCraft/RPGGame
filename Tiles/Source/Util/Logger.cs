using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Source.Util
{
	public enum LogType
	{
		INFO, WARNING, ERROR
	}

	public class Logger
	{
		private static List<string> array = new List<string>();

		public static void Log(LogType type, string msg)
		{
			string st = "[" + DateTime.Now + "] " + "[" + type + "] " + msg;
			st = st.Replace("\n", "\n\t\t");
			array.Add(st);
		}

		public static string ToString()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("-------------LOG-------------");
			stringBuilder.AppendLine("Num:\t" + "Time:\t" + "Message...........");

			for (var i = 0; i < array.Count; i++)
				stringBuilder.AppendLine(array[i]);

			return stringBuilder.ToString();
		}

		public static void Print()
		{
			Console.Out.Write(ToString());
		}

		public static void WriteToFile(string filename)
		{
			if (!File.Exists(filename))
				using (var fs = File.Create(filename))
				{
					fs.Flush();
				}

			using (var writer = new StreamWriter(filename))
			{
				writer.Flush();
				writer.Write(ToString());
			}
		}
	}
}

