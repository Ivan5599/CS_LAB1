using System;
using System.IO;
namespace ComputerSystemLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = 0;
            Console.WriteLine("Ця програма рахує відносну частоту появи символу в тексті.");
            Console.WriteLine("В тексті було знайдено:");
            Console.WriteLine("#################################################");
            System.IO.StreamReader sr = System.IO.File.OpenText(@"C:\Users\wanya\OneDrive\Робочий стіл\СS_LAB1\text_3_1.txt.bz2");
            string stringData = sr.ReadToEnd();
            sr.Close();
            Parsesthefile(stringData, b);
            Console.ReadKey();
        }
        public static void Parsesthefile(string line, int a)
        {
            bool q = true;
            double probabil = 0; //імовірність
            double summ = 0; // всі символи
            double entroph = 0;// ентропія
            double b = 0; 
            double HINT = 0;
            char[] line2 = line.ToCharArray();
            // string symvols = "АаБбВвГгҐґДдЕеЄєЖжЗзИиІіЇїЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЬьЮюЯя .,";
            string symvols = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm +., / 1234567890";

            char[] symvols2 = symvols.ToCharArray();
            using (var reader = new StreamReader(@"C:\Users\wanya\OneDrive\Робочий стіл\СS_LAB1\text_3_1.txt.bz2", detectEncodingFromByteOrderMarks: true))
            {
                while (reader.Read() > -1)
                {
                    summ++;
                }
            }
            
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < line.Length; j++)

                    if ((symvols2[2 * i] == line2[j]) || (symvols2[2 * i + 1] == line2[j]))
                    {
                        a = a + 1;
                    };
                probabil = a / summ;
                entroph = probabil * Math.Log2(1 / probabil);
                if (entroph > 0)
                    b = b + (probabil * Math.Log2(1.0 / probabil));
                if (a == 0)
                {
                    entroph = 0;
                }
                if (a != 0)

                    if (q) Console.WriteLine("");
                {
                    Console.WriteLine("Cимвол {0:d} зустрічається {1:d} раз з ймовірністю {2:f8}. Ентропія символа = {3:f8}", symvols2[2 * i], a, probabil, entroph);
                    q = false;
                }
                a = 0;
            }
            HINT = summ * b;
            Console.WriteLine("Загальна ентропія: {0:f8}", b);
            Console.WriteLine("HINT файлу: {0:f8}", HINT);
        }
    }
}
