using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Helsinki2017
{
    class Program
    {
        //4. feladat
        static void Összpontszám(string nev)
        {
            double sum = 0;
            for (int i = 0; i < adatpont.donto.GetLength(1); i++)
            {
                if (adatpont.donto[0,i] == nev)
                {
                    sum += double.Parse(adatpont.donto[2, i], CultureInfo.InvariantCulture) + double.Parse(adatpont.donto[3, i], CultureInfo.InvariantCulture) - double.Parse(adatpont.donto[4, i], CultureInfo.InvariantCulture);
                }
            }
            for (int i = 0; i < adatpont.rovidprogram.GetLength(1); i++)
            {
                if (adatpont.rovidprogram[0, i] == nev)
                {
                    sum += double.Parse(adatpont.rovidprogram[2, i], CultureInfo.InvariantCulture) + double.Parse(adatpont.rovidprogram[3, i], CultureInfo.InvariantCulture) - double.Parse(adatpont.rovidprogram[4, i], CultureInfo.InvariantCulture);
                }
            }
            //5-6. feladat
            Console.WriteLine("6. feladat");
            if (sum !=0 )
            {
                Console.WriteLine($"\tA versenyző összpontszáma:{sum}");
            }
            else
            {
                Console.WriteLine("\tNincs ilyen versenyző.");
            }
        }
        static class adatpont {
            public static string[,] rovidprogram;
            public static string[,] donto;
        }
        static void Main(string[] args)
        {
            //1. feladat
           
            string[] soroknyers = File.ReadAllLines(@"donto.csv");
            string[] sorok2nyers = File.ReadAllLines(@"rovidprogram.csv");
            string[,] adatok = new string[5 , soroknyers.Length];
            for (int i = 0; i < soroknyers.Length; i++)
            {                 
                    string[] s = soroknyers[i].Split(';');
                    for (int k = 0; k < s.Length; k++)
                    {
                        adatok[k, i] = s[k];
                       
                    }                             
            }
            string[,] adatok2 = new string[5, sorok2nyers.Length];
            for (int i = 0; i < sorok2nyers.Length; i++)
            {
                string[] s = sorok2nyers[i].Split(';');
                for (int k = 0; k < s.Length; k++)
                {
                    adatok2[k, i] = s[k];
                   
                }
            }
            adatpont.donto = adatok;
            adatpont.rovidprogram = adatok2;
            //2. fealadat
            Console.WriteLine("2. feladat");
            Console.WriteLine($"\tA rövidprogramban {sorok2nyers.Length - 1} induló volt.");
            //3. feladat
            Console.WriteLine("3. feladat");
            bool magyarvane = false;
            for (int i = 0; i < adatok.GetLength(1); i++)
            {
                if (adatok[1,i] == "HUN")
                {
                    magyarvane = true;
                }
            }
            if (magyarvane)
            {
                Console.WriteLine("\tA magyar versenyző bejutott a kűrbe.");
            }
            else {
                Console.WriteLine("\tA magyar versenyző nem jutott be a kűrbe.");
            }
            //5-6. feladat
            Console.WriteLine("5. feladat");
            Console.WriteLine("\tKérem a versenyző nevét:");
            
            Összpontszám(Console.ReadLine());
            //7. feladat
            List<string> orszag = new List<string>();
            for (int i = 0; i < ; i++)
            {

            }

            Console.ReadKey();          
        }

    }
}
