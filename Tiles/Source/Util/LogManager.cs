using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RPGGame.Source.Util
{




	public enum LogType
	{
		INFO, WARNING, ERROR, DEBUG
	}



	public class LogManager
	{
		private static List<string> Array = new List<string>();
		private static bool StreamToConsole = Constants.StreamLogToConsole;

		public LogManager()
		{
			if (StreamToConsole)
			{
				Print();
			}
		}

		

		public void Log(LogType type, string msg)
		{
			string st = "[" + Array.Count + "] [" + DateTime.Now + "] [" + type + "] " + msg;
			st = st.Replace("\n", "\n\t\t");
			Array.Add(st);

			if (StreamToConsole)
			{
				Print(st);
			}
		}

		public void Log(LogType type, Object obj)
		{
			Log(type, obj.ToString());
		}

		public string ToString()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("-------------LOG-------------");
			stringBuilder.AppendLine("Num:\t" + "Time:\t" + "Message...........");

			for (var i = 0; i < Array.Count; i++)
				stringBuilder.AppendLine(Array[i]);

			return stringBuilder.ToString();
		}

		public void Print() // Print the all info
		{
			Console.Out.Write(ToString());
		}

		void Print(string stringToPrint) // Print a specific string
		{
			Console.Out.WriteLine(stringToPrint);
		}

		void Print(int index) // Print one Log entry given by index
		{
			Console.Out.WriteLine(Array[index]);
		}




		void WriteToFile(string filename)
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

		public bool GetStreamingToConsole()
		{
			return StreamToConsole;
		}

		public void SetStreamingToConsole(bool arg)
		{
			StreamToConsole = arg;
		}
	}
}



