using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba_Ivan_Kocis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void MainMenu()
            {
                Console.Clear();
                ConsoleKeyInfo keyPress;

                do
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine("===========================");
                    Console.WriteLine("           VJEŽBA          ");
                    Console.WriteLine("===========================");
                    Console.WriteLine();
                    Console.WriteLine("<1> Parnost");
                    Console.WriteLine("<2> Kvadratna");
                    Console.WriteLine("<3> Prosjek");
                    Console.WriteLine("<4> Znamenke");
                    Console.WriteLine("<5> Loto");
                    Console.WriteLine("<6> Listić");
                    Console.WriteLine("<7> Osoba");
                    Console.WriteLine("<8> Pdf");


                    Console.WriteLine();
                    Console.WriteLine("Type number of choice you wish to make");
                    Console.Write("(<Esc> to exit):");
                    Console.ResetColor();

                    keyPress = Console.ReadKey();

                    switch (keyPress.Key.ToString())
                    {
                        case "D1": Parnost(); break;
                        case "D2": Kvadratna(); break;
                        case "D3": Prosjek(); break;
                        case "D4": Znamenke(); break;
                        case "D5": Loto(); break;
                        case "D6": Listic(); break;
                            /*     case "D7": new UpisiOsobe().MainMenu(); break;
                                 default:
                                     break;*/
                    }
                } while (keyPress.Key != ConsoleKey.Escape);
            }

            void StartProgram()
            {
                Console.Clear();
            }

            void EndProgram()
            {
                Console.WriteLine();
                Console.Write("...press anykey to return to MainMenu...");
                Console.ReadKey();
                StartProgram();
            }

            bool CheckIfDouble(string input)
            {
                double num;
                return double.TryParse(input, out num) ? true : false;
            }

            bool CheckIfInt(string input)
            {
                int num;
                return int.TryParse(input, out num) ? true : false;
            }

            double ReturnDouble(string input)
            {
                double num;
                if (!double.TryParse(input, out num))
                {
                    return 0;
                }
                return double.Parse(input);
            }

            void Parnost()
            {
                StartProgram();
                Console.WriteLine("Da vidimo jel paran ili neparan: ");
                string input;

                do
                {
                    Console.Write("Upiši broj: ");
                    input = Console.ReadLine();

                } while (!CheckIfDouble(input));


                if (double.Parse(input) % 2 == 0)
                {
                    Console.WriteLine("paran je");
                }
                else
                {
                    Console.WriteLine("nije paran");
                }
                EndProgram();
            }

            void Kvadratna()
            {
                StartProgram();
                Console.WriteLine("Rješavanje kvadratne jednadžbe");
                Console.WriteLine("Unesi tri broja (a,b,c)");

                string inputA;
                string inputB;
                string inputC;

                do
                {
                    Console.WriteLine("Upiši prvi broj(a): ");
                    inputA = Console.ReadLine();
                } while (!CheckIfDouble(inputA));

                do
                {
                    Console.WriteLine("Upiši prvi broj(b): ");
                    inputB = Console.ReadLine();
                } while (!CheckIfDouble(inputB));

                do
                {
                    Console.WriteLine("Upiši prvi broj(c): ");
                    inputC = Console.ReadLine();
                } while (!CheckIfDouble(inputC));

                double a = double.Parse(inputA);
                double b = double.Parse(inputB);
                double c = double.Parse(inputC);

                double resultOne;
                double resultTwo;

                resultOne = ((-1 * b) + Math.Sqrt(b * b - 4 * a * c)) / 2 * a;
                resultTwo = ((-1 * b) - Math.Sqrt(b * b - 4 * a * c)) / 2 * a;

                double podKorjenom = b * b - 4 * a * c;

                if (podKorjenom < 0)
                {
                    //Console.WriteLine("rezultat: {0}", podKorjenom);
                    Console.WriteLine("Rezultat je kompleksan broj.");
                }
                else
                {
                    Console.WriteLine($"Rezultat prvi = {resultOne}");
                    Console.WriteLine($"Rezultat drugi = {resultTwo}");
                }

                EndProgram();
            }
            void Prosjek()
            {
                StartProgram();
                Console.WriteLine("Računanje prosjeka ocjena ");
                string input;
                List<double> numbers = new List<double>();

                do
                {
                    Console.Write("Upiši ocjenu 1-5 (decimalni ,): ");
                    input = Console.ReadLine();
                    if (CheckIfDouble(input))
                    {
                        double inputNum = double.Parse(input);
                        if (inputNum >= 1 && inputNum <= 5)
                        {
                            numbers.Add(inputNum);
                        }
                        else if (inputNum != 0)
                        {
                            Console.WriteLine("nije dobar broj");
                        }
                    }

                } while (input != "0");

                double prosjek = numbers.Average();

                Console.WriteLine($"Prosječna ocjena liste je: {prosjek}");

                if (prosjek >= 5)
                {
                    Console.WriteLine("odličan");
                }
                else if (prosjek >= 4)
                {
                    Console.WriteLine("vrlo dobar");
                }
                else if (prosjek >= 3)
                {
                    Console.WriteLine("dobar");
                }
                else if (prosjek >= 2)
                {
                    Console.WriteLine("dovoljan");
                }
                else
                {
                    Console.WriteLine("nedovoljan");
                }

                EndProgram();
            }

            void Znamenke()
            {
                StartProgram();

                Console.WriteLine("zbroj zadnjih znamenaka");
                // koliko brojeva
                string brojUnosaInput;
                List<string> brojeviStr = new List<string>();
                int zbroj = 0;

                do
                {
                    Console.Write("unesi broj brojeva: ");
                    brojUnosaInput = Console.ReadLine();
                } while (!CheckIfInt(brojUnosaInput));

                int brojUnosa = int.Parse(brojUnosaInput);

                for (int i = 0; i < brojUnosa; i++)
                {
                    string input;
                    do
                    {
                        Console.Write("unesi broj (dec ,): ");
                        input = Console.ReadLine();
                    } while (!CheckIfDouble(input));

                    brojeviStr.Add(input);
                    //brojevi.Add(double.Parse(input));
                }

                foreach (var broj in brojeviStr)
                {
                    Console.WriteLine($"{broj} -> {broj.Last()}");
                    Console.WriteLine(int.Parse(broj.Last().ToString()));
                    zbroj += int.Parse(broj.Last().ToString());
                }

                Console.WriteLine($"zbroj zadnjih znamenaka: {zbroj}");

                EndProgram();
            }

            void Loto()
            {
                List<int> lista = new List<int>();

                for (int i = 0; i < 7; i++)
                {
                    int randomBroj = new Random().Next(1, 46);
                    if (!lista.Contains(randomBroj))
                    {
                        lista.Add(randomBroj);
                    }
                }

                // iza ove linije lista ima samo jedan element, kako to ?

                foreach (int broj in lista)
                {
                    Console.WriteLine("broj:{0}", broj);
                }
                Console.WriteLine("broj elemenata: {0}", lista.Count());
            }

            void Listic()
            {
                int broj = 1;
                string filePath = @"C:\Users\turpija\Documents\_source\CSharp_ConsoleApp_vjezba\listic.txt";

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("Listić za loto 6/49");

                    for (int i = 1; i <= 7; i++)
                    {
                        for (int j = 1; j <= 7; j++)
                        {
                            if (broj < 10)
                            {
                                sw.Write($" {broj} ");
                            }
                            else
                            {
                                sw.Write($"{broj} ");
                            }
                            broj++;
                        }

                        sw.WriteLine();
                    }
                }
            }


            //Loto();
            //MainMenu();
        }
    }
}
