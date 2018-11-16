using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizD
{
    public class Program
    {
        private static List<Question> VragenLijst = new List<Question>();

        private static void Main(string[] args)
        {
            ChoiceQuestion vraag1 = new ChoiceQuestion()
            {
                Text = "Wie heeft C# bedacht?",
                Difficult = 2,
                Category = "Techniek & Wetenschap",
            };

            vraag1.AddChoice("Microsoft", true);
            vraag1.AddChoice("Oracle", false);
            vraag1.AddChoice("De Haagse Hogeschool", false);
            vraag1.AddChoice("Bakfiets", false);

            ChoiceQuestion vraag2 = new ChoiceQuestion()
            {
                Text = "Door welk bedrijf is de Playstation ontwikkeld?",
                Difficult = 3,
                Category = "Techniek & Wetenschap",
            };

            vraag2.AddChoice("Microsoft", false);
            vraag2.AddChoice("Oracle", false);
            vraag2.AddChoice("IBM", false);
            vraag2.AddChoice("Sony", true);

            FreeResponseQuestion vraag3 = new FreeResponseQuestion()
            {
                Text = "Hoeveel hoekpunten heeft een piramide?",
                Answer = "5",
                Difficult = 1,
                Category = "Techniek & Wetenschaps",
            };

            VragenLijst.Add(vraag1);
            VragenLijst.Add(vraag2);
            VragenLijst.Add(vraag3);

            bool spelKlaar = false;

            PrintWelkom();
            int vragenGoed = 0;

            while (!spelKlaar)
            {
                Console.Write("Command: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        foreach (Question d in VragenLijst)
                        {
                            d.Display();
                            Console.WriteLine("Jouw antwoord is: ");
                            string answer = Console.ReadLine();
                            bool gewonnen = d.CheckAnswer(answer) ? true : false;
                            if (gewonnen)
                            {
                                if (VragenLijst.Last() == d)
                                {
                                    Console.WriteLine("Dat was de laatste vraag, je hebt {0} van de {1} goed", vragenGoed + 1, VragenLijst.Count);
                                    break;
                                }
                                Console.WriteLine("Je doet het goed, ga door!");
                                vragenGoed++;
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Beter je college doen :)");
                                continue;
                            }
                        }
                        break;

                    case "2":
                        VragenLijst.Sort((a, b) => (a.Difficult.CompareTo(b.Difficult)));
                        foreach (Question d in VragenLijst)
                        {
                            d.Display();
                            Console.WriteLine("Jouw antwoord is: ");
                            string answer = Console.ReadLine();
                            bool gewonnen = d.CheckAnswer(answer) ? true : false;
                            if (!gewonnen)
                            {
                                Console.WriteLine("Typ 1 om opnieuw te beginnen");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Je doet het goed, ga door!");
                                continue;
                            }
                        }

                        break;

                    case "3":
                        VragenLijst.Sort((a, b) => (b.Difficult.CompareTo(a.Difficult)));
                        foreach (Question d in VragenLijst)
                        {
                            d.Display();
                            Console.WriteLine("Jouw antwoord is: ");
                            string answer = Console.ReadLine();
                            bool gewonnen = d.CheckAnswer(answer) ? true : false;
                            if (!gewonnen)
                            {
                                Console.WriteLine("Typ 1 om opnieuw te beginnen");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Je doet het goed, ga door!");
                                continue;
                            }
                        }
                        break;

                    case "4":
                        PrintCategories(VragenLijst);
                        break;

                    case "clear":
                        Console.Clear();
                        PrintWelkom();

                        break;

                    case "9":
                        spelKlaar = true;
                        break;
                }
            }
        }

        public static void PrintWelkom()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Title = "Super coole Quiz";
            Console.WriteLine("+------------------------------Welkom bij Super coole Quiz vragen-----------------------+");
            Console.WriteLine("- Wil je uitdaging of hou je het van lekker makkelijk volg hieronder de keuze menu!    -+");
            Console.WriteLine("- Wil je beginnen met de vragen? Tik dan 1                                             -+");
            Console.WriteLine("- Wil je beginnen met de makkelijke vragen? Tik dan 2                                  -+");
            Console.WriteLine("- Wil je beginnen met de moeilijke vragen? Tik dan 3                                   -+");
            Console.WriteLine("- Wil je overzicht bekijken welke categorieën mogelijk zijn? Tik dan 4                 -+");
            Console.WriteLine("- Wil je beginnen met de vragen? Tik dan 1                                             -+");
            Console.WriteLine("- Wil je beginnen met de vragen? Tik dan 1                                             -+");
            Console.WriteLine("- Wil je de quiz verlaten Tik dan 9                                                    -+");
            Console.WriteLine("+---------------------------------------------------------=-----------------------------+");
        }

        public static void PrintCategories(List<Question> vragenLijst)
        {
            var categories = vragenLijst.Select(e => e.Category).Distinct().ToList();
            Console.WriteLine("Categorieën die je kan kiezen zijn: \n");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + categories[i]);
            }
            Console.WriteLine("Welke bij welke categorie wil je de vragen beantwoorden?");
            string inputCategorie = Console.ReadLine();
            Console.WriteLine("Je hebt gekozen voor : " + categories[int.Parse(inputCategorie) - 1]);

            var questions = vragenLijst.Where(e => e.Category == categories[int.Parse(inputCategorie) - 1]);

            foreach (Question question in questions)
            {
                question.Display();

                Console.WriteLine("Jouw antwoord is: ");
                string answer = Console.ReadLine();
                bool gewonnen = question.CheckAnswer(answer) ? true : false;
                if (!gewonnen)
                {
                    Console.WriteLine("Typ 1 om opnieuw te beginnen");
                    PrintWelkom();
                    Console.Clear();
                    break;
                }
                else
                {
                    if (VragenLijst.Last() == question)
                    {
                        Console.WriteLine("Dat was de laatste vraag, je hebt goed");
                        break;
                    }
                    Console.WriteLine("Je doet het goed, ga door!");
                    continue;
                }
            }
        }
    }
}