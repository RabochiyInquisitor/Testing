﻿using System;
using System.IO;
using System.Runtime.InteropServices;



namespace Тестовый_Проект
{
    class Program
    {
       

       static string path1 = "map.txt";
       static string path2 = "ships.txt";
       static string[] answer1 = new string[] { "Да", "Приступаем", "Так точно" };
      
      
      
       static void Main()
       {

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

                    Console.WriteLine("В дальнейшем вы всегда сможете вернуться к этому списку ,прописав команду /ships");
                    Console.WriteLine("\t");
                }
                Console.WriteLine("Приступаем?");

                string answer = Console.ReadLine();



                if (answer == answer1[0] || answer == answer1[1] || answer == answer1[2])
                {
                    Console.Clear();
                    DrawMap(map);
                    Console.WriteLine("Назовите первую координату: ");
                    int cordinatey = int.Parse(Console.ReadLine());

                    Console.WriteLine("Назовите вторую координату: ");
                    int cordinatex = int.Parse(Console.ReadLine());
                    Try(cordinatey, cordinatex, map);
                }
                wait = Console.ReadLine();
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
                Console.WriteLine(c);
                Console.WriteLine(v);
            
            
            
            
            
            




        }
        static void DrawShips(char[,] map)
        {
           


            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);





                }
                Console.Write("\n");
            }

        }

        private static void Try(int cordinatex, int cordinatey, char[,] map)
        {
            

             

                 int MaxValue = 30;
                 


                if (map[cordinatex + 5, cordinatey + 1] == '.')
                {
                    Console.WriteLine("Вы попали!");

                }
                else
                {
               
                    Console.WriteLine("Вы не попали!");
               
                }
                if (cordinatex < 0 || cordinatex >= MaxValue || cordinatey < 0 || cordinatey >= MaxValue)
                {
                    Console.WriteLine("Ваша эскадра ушла за координаты, и была признана дезертирующей. Вас отстранили от должности и предали военному трибуналу.");
                }

               

            
            
        }


        
    }
}


