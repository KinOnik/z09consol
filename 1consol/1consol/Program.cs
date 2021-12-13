using System;
using System.Text;
using System.IO;


namespace _1consol
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				string curPatch = Environment.CurrentDirectory;
				Console.Write("\n\tДиапазон записываемых чисел (от): ");
				double a = double.Parse(Console.ReadLine());
				Console.Write("\n\tДиапазон записываемых чисел (до): ");
				double b = double.Parse(Console.ReadLine());
				if (a>b)
                {
					Console.Write("\n\n\t** Нарушен порядок ввода диапазона записываемых чисел, меняю местами **\n\n");
					double buf = a;
					a = b;
					b= buf;
                }
				Console.Write("\n\tШаг чисел в диапазоне: ");
				double h = double.Parse(Console.ReadLine());

				FileStream f = new FileStream($"{curPatch}/tmp.dat", FileMode.Create);
				BinaryWriter fOut = new BinaryWriter(f);
				for (double i = a; i <= b; i += h)
				{
					fOut.Write(i);
				}
				fOut.Close();

				f = new FileStream($"{curPatch}/tmp.dat", FileMode.Open);
				BinaryReader fIn = new BinaryReader(f);
				long m = f.Length;

				Console.Write("\n\tДиапазон игнорируемых чисел (от): ");
				double startIgnor = double.Parse(Console.ReadLine());
				Console.Write("\n\tДиапазон игнорируемых чисел (до): ");
				double stopIgnor = double.Parse(Console.ReadLine());

				if (startIgnor>stopIgnor)
				{
					Console.Write("\n\n\t** Нарушен порядок ввода диапазона игнорируемых чисел, меняю местами **\n\n");
					double buf = startIgnor;
					startIgnor = stopIgnor;
					stopIgnor = buf;
				}
				Console.Write("\n\n\t Вот числа с пропущенным диапазоном (пропущенные числа отмечены \'.\'):\n\t ");
				double tmpDigit = 0;

				for (long i = 0; i < m; i += 8)
				{
					f.Seek(i, SeekOrigin.Begin);
					tmpDigit = Math.Round(fIn.ReadDouble(), 2);
					if (tmpDigit >= startIgnor && tmpDigit <= stopIgnor)
					{
						Console.Write(".");
					}
					else
					{
						Console.Write($"{tmpDigit:f2} ");
					}
				}

				Console.Write("\n\n");
				fIn.Close();
				f.Close();
			}
			catch (Exception)
			{
				Console.Write("\n**** Вы ввели не число ****\n");
			}
		}
	}
}