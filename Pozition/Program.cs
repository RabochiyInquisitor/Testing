using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace TestsAndTasks
{
    public class Program
    {
        static string path1 = "map.txt";
        static string path2 = "ships.txt";
        static string[] answer1 = new string[] { "Да", "Приступаем", "Так точно" };

        async Task Main(string[] args)
        {
            while (true)
            {
                await Task.Delay(1000);

                Console.WriteLine("МОРСКОЙ БОЙ");
                string wait = Console.ReadLine();
                Console.Clear();


                while (wait != "Стоп")
                {
                    Console.Clear();

                    Console.WriteLine("Добро пожаловать на борт! Ваша эскадра готова к бою. Все ждут вашего приказа к атаке. (Начать атаку?)");

                    string command = Console.ReadLine();
                    char[,] map = ReadMap(path1);
                    char[,] ships = ReadMap(path2);

                    if (command == "Начать атаку")
                    {
                        Console.WriteLine("\t");
                        Console.Clear();

                        DrawShips(ships);

                        Console.WriteLine("В дальнейшем вы всегда сможете вернуться к этому списку, прописав команду /ships");
                        Console.WriteLine("\t");
                    }
                    Console.WriteLine("Приступаем?");

                    string answer = Console.ReadLine();

                    if (answer == answer1[0] || answer == answer1[1] || answer == answer1[2])
                    {
                        Console.Clear();
                        DrawMap(map);

                    }
                    wait = Console.ReadLine();

                }
            }
        }
        static void DrawShips(char[,] shipsinfo)
        {



            for (int y = 0; y < shipsinfo.GetLength(1); y++)
            {
                for (int x = 0; x < shipsinfo.GetLength(0); x++)
                {
                    Console.Write(shipsinfo[x, y]);





                }
                Console.Write("\n");
            }

        }
        static void DrawMap(char[,] map)
        {
            Random random = new Random();

            int c = random.Next(5, 34);
            int v = random.Next(5, 12);


            while (map[c, v] != ' ')
            {
                c = random.Next(5, 34);
                v = random.Next(5, 12);

            }
            map[c, v] = '.';

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.Write("\n");
            }
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
        private void StartInputField(char[,] ships)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == '/')
                    {
                        string command = Console.ReadKey(true).KeyChar.ToString();
                        if (command == "shipsinfo")
                        {
                            DisplayShipsInfo(ships);
                        }
                    }

                }
            });
        }
        private async Task DisplayShipsInfo(char[,] ships)
        {
            Console.Clear();
            DrawShips(ships);
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
            }


        }


    }
}