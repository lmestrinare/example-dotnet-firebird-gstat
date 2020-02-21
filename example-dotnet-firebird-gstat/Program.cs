using System;
using System.IO;

namespace example_dotnet_firebird_gstat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Analisador DataPages\r\n\r\nEntre com arquivo:");
            
            string file = Console.ReadLine();
            Console.WriteLine("\r\nArquivo selecionado:");
            Console.WriteLine(file);

            string[] lines = System.IO.File.ReadAllLines(file);

            System.IO.File.Delete("results.txt");
            StreamWriter writer = new StreamWriter("results.txt");
            for (int line = 0; line <= lines.Length - 1; line++)
            {
                string results = "";

                string[] split1 = lines[line].Split(" ");
                results += split1[0];

                line += 2;

                string[] split2 = lines[line].Split(",");
                string[] split3 = split2[0].Split(":");
                int pages = Convert.ToInt32(split3[1].Trim());
                results += ";" + pages * 4096;

                line += 7;

                Console.WriteLine(results);
                writer.WriteLine(results);
            }
            writer.Close();

            string final = Console.ReadLine();
        }
    }
}
