using System;
using System.Collections.Generic;

namespace Labs_DM.Lab1
{
    public static class DisplayExtension
    {
        public static void Display(this List<Edge> array)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            array.ForEach(x => Console.WriteLine($"{x.Name} - {x.Weight}"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        public static void Display(this List<List<Edge>> array)
        {
            array.Display(new char[0]);
        }

        public static void Display(this List<List<Edge>> array, char[] headers)
        {
            if (headers.Length != 0 && headers.Length != array.Count)
            {
                throw new Exception("Not valid length of headers");
            }

            if (headers.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\t");

                for (int j = 0; j < headers.Length; j++)
                {
                    Console.Write($"{headers[j]}\t");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }

            for (int i = 0; i < array.Count; i++)
            {
                if (headers.Length > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{headers[i]}\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                for (int j = 0; j < array[i].Count; j++)
                {
                    if (array[i][j].Selected)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write($"{array[i][j].Weight}\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }
        }
    }
}
