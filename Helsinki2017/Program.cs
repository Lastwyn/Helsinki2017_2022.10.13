using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helsinki2017
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] soroknyers = File.ReadAllLines(@"donto.csv");
            string[] sorok2nyers = File.ReadAllLines(@"rovidprogram.csv");
            string[,] adatok = new string[5 , soroknyers.Length];
            for (int i = 0; i < soroknyers.Length; i++)
            {                 
                    string[] s = soroknyers[i].Split(';');
                    for (int k = 0; k < s.Length; k++)
                    {
                        adatok[k, i] = s[k];
                        Console.WriteLine(adatok[k, i]);
                    }                             
            }
            
            Console.ReadKey();
        }

    }
}
