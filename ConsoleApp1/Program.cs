using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        // Metod som tar in ett Random-objekt och returnerar en tärningssiffra mellan 1 och 6
        static int RullaTärning(Random slumpObjekt)
        {
            // Slumpar fram ett tal mellan 1 och 6 (6 är exkluderat i .Next, därför skriver vi 7)
            int tal = slumpObjekt.Next(1, 7);
            return tal;
        }

        static void Main()
        {
            Random slump = new Random(); // Skapar slumpgenerator
            List<int> tärningar = new List<int>(); // Lista som sparar alla rullade tärningar

            Console.WriteLine("\n\tVälkommen till tärningsgeneratorn!");

            bool kör = true;
            while (kör)
            {
                // Menyval
                Console.WriteLine("\n\t[1] Rulla tärning\n" +
                    "\t[2] Kolla vad du rullade\n" +
                    "\t[3] Avsluta");
                Console.Write("\tVälj: ");
                int.TryParse(Console.ReadLine(), out int val);

                switch (val)
                {
                    case 1:
                        // Användaren väljer hur många tärningar att rulla
                        Console.Write("\n\tHur många tärningar vill du rulla: ");
                        bool inmatning = int.TryParse(Console.ReadLine(), out int antal);

                        if (inmatning)
                        {
                            for (int i = 0; i < antal; i++)
                            {
                                // Vi rullar tärningen och sparar resultatet i listan
                                tärningar.Add(RullaTärning(slump));
                            }
                        }
                        break;

                    case 2:
                        // Visar alla tidigare kast och räknar medelvärdet
                        if (tärningar.Count <= 0)
                        {
                            Console.WriteLine("\n\tDet finns inga sparade tärningsrull! ");
                        }
                        else
                        {
                            Console.WriteLine("\n\tRullade tärningar: ");
                            int sum = 0;

                            foreach (int tärning in tärningar)
                            {
                                Console.WriteLine("\t" + tärning);
                                sum += tärning; // Adderar alla värden
                            }

                            int medelvärde = sum / tärningar.Count; // Räknar ut medel
                            Console.WriteLine("\n\tMedelvärdet på alla tärningsrull: " + medelvärde);
                        }
                        break;

                    case 3:
                        // Avslutar programmet
                        Console.WriteLine("\n\tTack för att du rullade tärning!");
                        Thread.Sleep(1000);
                        kör = false;
                        break;

                    default:
                        Console.WriteLine("\n\tVälj 1-3 från menyn.");
                        break;
                }
            }
        }
    }
}
