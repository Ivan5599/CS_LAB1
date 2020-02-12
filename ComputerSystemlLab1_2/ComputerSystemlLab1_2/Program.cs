using System;
using System.IO;

namespace ComputerSystemlLab1_2
{
    class Program
    {
        static readonly string textFile = @"C:\Users\wanya\OneDrive\Робочий стіл\СS_LAB1\text_3.txt";
        static void Main(string[] args)
        {
			var text = "";
			if (File.Exists(textFile))
			{
				text = File.ReadAllText(textFile);
			}
			var str = "";
			str = text;
			Console.WriteLine("Текст, що міститься в файлі: ");
			Console.WriteLine(str);
			Console.WriteLine();
			Console.WriteLine("Довжина тексту: ");
			Console.WriteLine(str.Length);
			byte[] data = System.Text.Encoding.Default.GetBytes(str);
			char[] value = Base64(data);
			Console.WriteLine("\nЗакодований текст: ");
			Console.WriteLine(value);
			Console.WriteLine("\nДовжина закодованого тексту: ");
			Console.WriteLine(value.Length);
		}
		public static char[] Base64(byte[] data)
		{
			int leng, leng2;
			int bCount;
			int padCount;

			leng = data.Length;

			if ((leng % 3) == 0)
			{
				padCount = 0;
				bCount = leng / 3;
			}
			else
			{
				padCount = 3 - (leng % 3);
				bCount = (leng + padCount) / 3;
			}

			leng2 = leng + padCount;

			byte[] source2;
			source2 = new byte[leng2];

			for (int x = 0; x < leng2; x++)
			{
				if (x < leng)
				{
					source2[x] = data[x];
				}
				else
				{
					source2[x] = 0;
				}
			}

			byte b1, b2, b3;
			byte temp, temp1, temp2, temp3, temp4;
			byte[] buffer = new byte[bCount * 4];
			char[] result = new char[bCount * 4];

			for (int x = 0; x < bCount; x++)
			{
				b1 = source2[x * 3];
				b2 = source2[x * 3 + 1];
				b3 = source2[x * 3 + 2];

				temp1 = (byte)((b1 & 252) >> 2);

				temp = (byte)((b1 & 3) << 4);
				temp2 = (byte)((b2 & 240) >> 4);
				temp2 += temp;

				temp = (byte)((b2 & 15) << 2);
				temp3 = (byte)((b3 & 192) >> 6);
				temp3 += temp;

				temp4 = (byte)(b3 & 63);

				buffer[x * 4] = temp1;
				buffer[x * 4 + 1] = temp2;
				buffer[x * 4 + 2] = temp3;
				buffer[x * 4 + 3] = temp4;

			}

			for (int x = 0; x < bCount * 4; x++)
			{
				result[x] = BitToChar(buffer[x]);
			}

			switch (padCount)
			{
				case 0:
					break;
				case 1:
					result[bCount * 4 - 1] = '=';
					break;
				case 2:
					result[bCount * 4 - 1] = '=';
					result[bCount * 4 - 2] = '=';
					break;
				default:
					break;
			}

			return result;
		}

		private static char BitToChar(byte b)
		{
			char[] lookupTable = new char[64] {
		'A','B','C','D','E','F','G','H','I','J','K','L','M',
		'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
		'a','b','c','d','e','f','g','h','i','j','k','l','m',
		'n','o','p','q','r','s','t','u','v','w','x','y','z',
		'0','1','2','3','4','5','6','7','8','9','+','/'
	};

			if ((b >= 0) && (b <= 63))
			{
				return lookupTable[(int)b];
			}
			else
			{
				return ' ';
			}
		}
	
}
}
