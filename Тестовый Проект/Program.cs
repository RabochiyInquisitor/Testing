using System;
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
           // if (map = ships)
            {



                Random random = new Random();

                int MaxValue = 11;
                int MinValue = 11;

                int c = random.Next(5, 11);
                int v = random.Next(5, 11);


              //map[c, v] = '.';
              
              while (map[c, v] != ' ')
              {
                  c = random.Next(5, 11);
                  v = random.Next(5, 11); 
              
              }

                //if (map[c, v] == Convert.ToChar("]"))
                //{
                //    map[c - 1, v] = Convert.ToChar('.');
                //
                //    
                //}
                //
                //else if (map[c, v] == Convert.ToChar("["))
                //{
                //    map[c + 1, v] = Convert.ToChar('.');
                //    
                //
                //}
                //else if (v <= 2)
                //{
                //    map[c, v + 1] = Convert.ToChar('.');
                //    
                //}


                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        Console.Write(map[x, y]);





                    }
                    Console.Write("\n");
                }
            }
            
            
            
            
            




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
            

            Random random = new Random();

            int MaxValue = 11;
            int MinValue = 11;

            int x = random.Next(5, 11);
            int y = random.Next(5, 11);




                if (map[x, y] == Convert.ToChar("]"))
                {
                    map[x - 1, y] = Convert.ToChar('.');

                    x--;
                }
              
                else if (map[x, y] == Convert.ToChar("["))
                {
                    map[x + 1, y] = Convert.ToChar('.');
                    x++;
                
                }
                //else if( x <= 2 )
                //{
                //    map[x + 2, y] = Convert.ToChar('.');
                //    x = x + 2;
                //}
                else if (y <= 2)
                {
                    map[x, y + 1] = Convert.ToChar('.');
                    y++;
                }

                if (map[cordinatex + 4, cordinatey + 2] == '.')
                {
                    Console.WriteLine("Вы попали!");

                }
                if (cordinatex < 0 || cordinatex >= MaxValue || cordinatey < 0 || cordinatey >= MaxValue)
                {
                    Console.WriteLine("Ваша эскадра ушла за координаты, и была признана дезертирующей. Вас отстранили от должности и предали военному трибуналу.");
                }

                else
                {

                    Console.WriteLine("Вы не попали!");
                    
                }

            
            
        }


        
    }
}


