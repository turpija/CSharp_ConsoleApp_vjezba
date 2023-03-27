using System;
using System.Collections.Generic;
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
                    Console.WriteLine("<4> SumArray");
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
                            /*  case "D4": SumArray(); break;
                              case "D5": BeautifyString(); break;
                              case "D6": Random(); break;
                              case "D7": new UpisiOsobe().MainMenu(); break;
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

            bool CheckIfNum(string input)
            {
                double num;
                return double.TryParse(input, out num) ? true : false;
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

                } while (!CheckIfNum(input));


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
                } while (!CheckIfNum(inputA));

                do
                {
                    Console.WriteLine("Upiši prvi broj(b): ");
                    inputB = Console.ReadLine();
                } while (!CheckIfNum(inputB));

                do
                {
                    Console.WriteLine("Upiši prvi broj(c): ");
                    inputC = Console.ReadLine();
                } while (!CheckIfNum(inputC));

                double A = double.Parse(inputA);
                double B = double.Parse(inputB);
                double C = double.Parse(inputC);

                double resultOne;
                double resultTwo;

                resultOne = ((-1 * B) + Math.Sqrt(B * B - 4 * A * C)) / 2 * A;
                resultTwo = ((-1 * B) - Math.Sqrt(B * B - 4 * A * C)) / 2 * A;

                Console.WriteLine($"Rezultat prvi = {resultOne}");
                Console.WriteLine($"Rezultat drugi = {resultTwo}");

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
                    if (CheckIfNum(input))
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


            MainMenu();
        }
    }
}
