using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizD
{
    public static class Game
    {
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
            Console.WriteLine("- Wil je de moeilijkheidsgraad kiezen? Tik dan 5                                       -+");
            Console.WriteLine("- Wil je de scherm leeg hebben Tik dan clear                                           -+");
            Console.WriteLine("- Wil je de quiz verlaten Tik dan 9                                                    -+");
            Console.WriteLine("+---------------------------------------------------------=-----------------------------+");
        }

        public static void PrintMoeilijkeVragenEerst()
        {
            var moeilijkeVragenEerst = Program.VragenLijst.OrderByDescending(e => e.Difficult).ToList();
            foreach (Question d in moeilijkeVragenEerst)
            {
                int vragenGoed = 0;

                d.Display();
                Console.WriteLine("Jouw antwoord is: ");
                string answer = Console.ReadLine();
                bool gewonnen = d.CheckAnswer(answer) ? true : false;
                if (moeilijkeVragenEerst.Last() == d)
                {
                    Console.WriteLine("Dat was de laatste vraag, je hebt {0} van de {1} goed", vragenGoed + 1, moeilijkeVragenEerst.Count);
                    break;
                }
                if (gewonnen)
                {
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
        }

        public static void PrintMakkelijkeVragenEerst()
        {
            var makkelijkeVragenEerst = Program.VragenLijst.OrderBy(e => e.Difficult).ToList();
            int vragenGoed = 0;
            foreach (Question d in makkelijkeVragenEerst)
            {
                d.Display();
                Console.WriteLine("Jouw antwoord is: ");
                string answer = Console.ReadLine();
                bool gewonnen = d.CheckAnswer(answer) ? true : false;

                if (makkelijkeVragenEerst.Last() == d)
                {
                    Console.WriteLine("Dat was de laatste vraag, je hebt {0} van de {1} goed", vragenGoed + 1, makkelijkeVragenEerst.Count);
                    break;
                }

                if (gewonnen)
                {
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
        }

        public static void PrintVragenNormaal()
        {
            int vragenGoed = 0;

            foreach (Question d in Program.VragenLijst)
            {
                d.Display();
                Console.WriteLine("Jouw antwoord is: ");
                string answer = Console.ReadLine();
                bool gewonnen = d.CheckAnswer(answer) ? true : false;

                if (Program.VragenLijst.Last() == d)
                {
                    Console.WriteLine("Dat was de laatste vraag, je hebt {0} van de {1} goed", vragenGoed + 1, Program.VragenLijst.Count);
                    break;
                }

                if (gewonnen)
                {
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
        }

        public static void PrintMoeilijkHeidsGraad(List<Question> vragenLijst)
        {
            Console.WriteLine("De mogelijke moeilijksgraden die je kan kiezen zijn \n1 Makkelijk  \n2 Normaal  \n3 Gevorderd\n" + "Welke wil je(Hoe Hoger hoe moeilijker)?");
            Console.Write("Ik wil ");
            string choice = Console.ReadLine();
            int nummerGraad = int.Parse(choice);
            int vragenGoed = 0;

            List<Question> vragenMetDieMoeilijkheidsGraad = vragenLijst.Where(e => e.Difficult == nummerGraad).ToList();

            foreach (Question question in vragenMetDieMoeilijkheidsGraad)
            {
                question.Display();

                Console.WriteLine("Jouw antwoord is: ");
                string answer = Console.ReadLine();
                bool gewonnen = question.CheckAnswer(answer) ? true : false;
                if (vragenMetDieMoeilijkheidsGraad.Last() == question)
                {
                    Console.WriteLine("Dat was de laatste vraag, je hebt {0} van de {1} goed", vragenGoed + 1, vragenMetDieMoeilijkheidsGraad.Count);
                    break;
                }

                if (gewonnen)
                {
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
        }

        public static void PrintCategories(List<Question> vragenLijst)
        {
            var categories = vragenLijst.OrderBy(e => e.Category)
                .Select(e => e.Category)
                .Distinct().
                ToList();

            int vragenGoed = 0;
            Console.WriteLine("Categorieën die je kan kiezen zijn: \n");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + categories[i]);
            }

            Console.WriteLine("Welke bij welke categorie wil je de vragen beantwoorden?");
            string inputCategorie = Console.ReadLine();
            Console.WriteLine("Je hebt gekozen voor : " + categories[int.Parse(inputCategorie) - 1]);

            List<Question> vragenMetDieCategorie = vragenLijst
                .Where(e => e.Category == categories[int.Parse(inputCategorie) - 1])
                .ToList();

            foreach (Question question in vragenMetDieCategorie)
            {
                question.Display();

                Console.WriteLine("Jouw antwoord is: ");
                string answer = Console.ReadLine();
                bool gewonnen = question.CheckAnswer(answer) ? true : false;
                if (vragenMetDieCategorie.Last() == question)
                {
                    Console.WriteLine("Dat was de laatste vraag, je hebt {0} van de {1} goed", vragenGoed + 1, vragenMetDieCategorie.Count);
                    break;
                }
                if (gewonnen)
                {
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
        }
    }
}