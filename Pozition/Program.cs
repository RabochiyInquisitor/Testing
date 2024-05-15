using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pozition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = ReadMap("map.txt");
            DrawMap(map);
        }
        public static int GetMaxLengthofLines(string[] lines)
        {
            int maxLength = 0;

            foreach (var line in lines)
            {
                if (line.Length > maxLength)
                    maxLength = line.Length;
            }

            return maxLength;
        }
        public static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);

            char[,] map = new char[GetMaxLengthofLines(file), file.Length];

            for (int y = 0; y < file.Length; y++)
            {
                for (int x = 0; x < file[y].Length; x++)
                {
                    map[x, y] = file[y][x];
                }
            }

            return map;
        }
        static void DrawMap(char[,] map)
        {

            int a = 5;
            int b = 5;

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            map[a, b] = '.';

            while (consoleKeyInfo.Key == ConsoleKey.Enter)
            { 
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        Console.Write(map[x, y]);





                    }
                    Console.Write("\n");
                }
                if (consoleKeyInfo.KeyChar == 'w')
                {
                    b++;
                    Console.Clear();

                }
            }

        }
    }
}
