using System;
using System.IO;
using System.Text.RegularExpressions;


namespace _2consol
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				string curPatch = Environment.CurrentDirectory;
				Console.Write("k1= ");
				int k1 = int.Parse(Console.ReadLine());
				Console.Write("k2= ");
				int k2 = int.Parse(Console.ReadLine());
				if (k1 > k2)
				{
					Console.Write("\n\n\t** нарушены границы индексов элементов(k2>k1), меняю местами**\n\n");
					int buffer = k1;
					k1 = k2;
					k2 = buffer;
				}
				string[] buf = System.IO.File.ReadAllLines($"{curPatch}/text.txt");
				for (int i = 0; i < buf.Length; i++)
				{
					if (buf[i].Length >= k2)
					{
						Console.Write($"Символы строки №{i+1}: ");
						for (int j = k1 - 1; j < k2; j++)
						{
							Console.Write($"{buf[i][j]}");
						}
						Console.Write($"\n");
					}
					else if (buf[i].Length >= k1 && buf[i].Length < k2)
					{
						Console.Write($"В строке №{i + 1} меньше символов, чем вы ввели : ");
						for (int j = k1 - 1; j < buf[i].Length; j++)
						{
							Console.Write($"{buf[i][j]}");
						}
						Console.Write($"\n");
					}
					else
					{
						Console.Write($"В строке №{i + 1} нет символов с такими индексами в строке\n");
					}					
				}
			}
			catch (Exception)
			{
				Console.Write($"\n**** Вы ввели не число ****\n");
			}

		}
	}
}
