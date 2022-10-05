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
            //5.-6. feladat
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
            //5.-6. feladat
            Console.WriteLine("5. feladat");
            Console.Write("\tKérem a versenyző nevét: ");
            
            Összpontszám(Console.ReadLine());
            //7. feladat
            Console.WriteLine("7. feladat");
            List<string> orszag = new List<string>();
            for (int i = 0; i < adatpont.rovidprogram.GetLength(1); i++)
            {
                bool vane = false;
                for (int j = 0; j < orszag.Count; j++)
                {
                    if (adatpont.rovidprogram[1, i] == orszag[j])
                    {
                        vane = true;
                    }
                }
                if (vane == false)
                {
                    orszag.Add(adatpont.rovidprogram[1,i]);
                }
            }

            int[] orszag2 = new int[orszag.Count];
            for (int i = 0; i < adatpont.donto.GetLength(1); i++)
            {
                for (int j = 0; j < orszag.Count; j++)
                {
                    if (adatpont.donto[1,i] == orszag[j])
                    {
                        orszag2[j]++;
                    }
                }
            }
            for (int i = 1; i < orszag2.Length; i++)
            {
                if (orszag2[i] > 0)
                {
                    Console.WriteLine($"\t{orszag[i]} : {orszag2[i]} versenyzo");
                }
            }
            //8. feladat
       /*     Console.WriteLine("8. feladat: Kiiratás.");
            
            string[,] kiirat = new string[3, adatpont.donto.Length];
            for (int i = 0; i < adatpont.donto.GetLength(1); i++)
            {
                kiirat[0, i] = adatpont.donto[0, i];
                kiirat[1, i] = adatpont.donto[1, i];
                kiirat[2, i] = Convert.ToString(double.Parse(adatpont.donto[2, i], CultureInfo.InvariantCulture) + double.Parse(adatpont.donto[3, i], CultureInfo.InvariantCulture) - double.Parse(adatpont.donto[4, i], CultureInfo.InvariantCulture));

            }
            StreamWriter kiiratas = new StreamWriter("vegeredmeny.csv");
            for (int i = 0; i < kiirat.GetLength(1); i++)
            {
                for (int j = 0; j < kiirat.GetLength(0); j++)
                {
                    kiiratas.Write(kiirat[j,i]);
                }
                kiiratas.WriteLine();
            }*/
            Console.ReadKey();          
        }

    }
}
