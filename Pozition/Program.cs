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
            DateTime time = DateTime.Now;

            int hour = time.Hour;
            Console.WriteLine("Текущее время: " +  hour);
        }
       
    }
}
