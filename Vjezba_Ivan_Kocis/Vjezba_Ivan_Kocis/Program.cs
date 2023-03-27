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
                        case "D7": Osoba(); break;
                                 default:
                            break;
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
                StartProgram();
                List<int> lista = new List<int>();

                Random rand = new Random();

                do
                {
                    int randomBroj = rand.Next(1, 46);

                    if (!lista.Contains(randomBroj))
                    {
                        lista.Add(randomBroj);
                    }
                } while (lista.Count < 7);

                foreach (int broj in lista)
                {
                    Console.Write($"{broj} ");
                }
                Console.WriteLine();
                EndProgram();
            }

            void Listic()
            {
                StartProgram();
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
                Console.WriteLine($"ispisano u fajl: {filePath}");

                EndProgram();
            }

            void Osoba()
            {
                StartProgram();
                Console.WriteLine("statiska osoba ...");
                Osoba osoba = new Osoba();

                List<Osoba> osobe = new List<Osoba>()
                {
                    new Osoba() {Ime = "Pero",Prezime="Perić",DOB= new DateTime(2001,1,1),IsMale=true},
                    new Osoba() {Ime = "Darko",Prezime="Draguljče",DOB= new DateTime(1988,1,1),IsMale=true},
                    new Osoba() {Ime = "Marica",Prezime="Krvarica",DOB= new DateTime(1977,1,1),IsMale=false},
                    new Osoba() {Ime = "Pepeljuga",Prezime="Pepeljkovičević",DOB= new DateTime(1966,1,1),IsMale=false},
                    new Osoba() {Ime = "Snjeguljica",Prezime="Izgubljenka",DOB= new DateTime(1957,1,1),IsMale=false},
                };

                int brojMuskaraca = osobe.Where(s => s.IsMale == true).Count();
                Console.WriteLine($"broj muškaraca u listi: {brojMuskaraca}");

                int brojZena = osobe.Where(s => s.IsMale == false).Count();
                Console.WriteLine($"broj žena u listi: {brojZena}");

                foreach (var o in osobe)
                {
                    o.Age = DateTime.Now.Year - o.DOB.Year;
                }

                Osoba oldest = osobe.OrderBy(t => t.DOB).FirstOrDefault();
                Console.WriteLine($"najstarija osoba: {oldest.Ime}, {oldest.Prezime}, {oldest.DOB.ToShortDateString()}");

                Osoba youngest = osobe.OrderByDescending(t => t.DOB).FirstOrDefault();
                Console.WriteLine($"najmlađa osoba: {youngest.Ime}, {youngest.Prezime}, {youngest.DOB.ToShortDateString()}");

                IEnumerable<Osoba> prije2000 = osobe.Where(t => t.DOB.Year < 2000);
                foreach (var o in prije2000)
                {
                    Console.WriteLine($"prije 2000.g.: {o.Ime}, {o.Prezime}, {o.DOB.ToShortDateString()}");

                }
                EndProgram();
            }

            MainMenu();
        }
    }
}
