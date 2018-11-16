using System;
using System.Collections.Generic;

namespace QuizD
{
    public class Program
    {
        public static List<Question> VragenLijst = new List<Question>();

        public static void Main(string[] args)
        {
            ChoiceQuestion vraag1 = new ChoiceQuestion()
            {
                Text = "Wie heeft C# bedacht?",
                Difficult = 2,
                Category = "ICT",
            };

            vraag1.AddChoice("Microsoft", true);
            vraag1.AddChoice("Oracle", false);
            vraag1.AddChoice("De Haagse Hogeschool", false);
            vraag1.AddChoice("Bakfiets", false);

            ChoiceQuestion vraag2 = new ChoiceQuestion()
            {
                Text = "Door welk bedrijf is de Playstation ontwikkeld?",
                Difficult = 2,
                Category = "ICT",
            };

            vraag2.AddChoice("Microsoft", false);
            vraag2.AddChoice("Oracle", false);
            vraag2.AddChoice("IBM", false);
            vraag2.AddChoice("Sony", true);

            ChoiceQuestion vraag3 = new ChoiceQuestion()
            {
                Text = "Welke Italiaanse voetbalclub wordt vergeleken met een oude dame?",
                Difficult = 3,
                Category = "Sport",
            };

            vraag2.AddChoice("Juventus", true);
            vraag2.AddChoice("Barcelona", false);
            vraag2.AddChoice("AC Milan", false);
            vraag2.AddChoice("Inter Milan", false);

            ChoiceQuestion vraag4 = new ChoiceQuestion()
            {
                Text = "Welke sport betekend in het Japans “zachte weg”?",
                Difficult = 3,
                Category = "Sport",
            };

            vraag2.AddChoice("Judo", true);
            vraag2.AddChoice("Voetbal", false);
            vraag2.AddChoice("Tennis", false);
            vraag2.AddChoice("Kaarten", false);

            FreeResponseQuestion vraag5 = new FreeResponseQuestion()
            {
                Text = "Hoeveel hoekpunten heeft een piramide?",
                Answer = "5",
                Difficult = 1,
                Category = "Wetenschap",
            };

            FreeResponseQuestion vraag6 = new FreeResponseQuestion()
            {
                Text = "Wanneer eindigde de eerste wereldoorlog??",
                Answer = "1918",
                Difficult = 2,
                Category = "Geschiedenis",
            };

            FreeResponseQuestion vraag7 = new FreeResponseQuestion()
            {
                Text = "Hoe worden Romeinen genoemd die in amfitheaters vochten als leedvermaak?",
                Answer = "Gladiatoren",
                Difficult = 2,
                Category = "Geschiedenis",
            };

            FreeResponseQuestion vraag8 = new FreeResponseQuestion()
            {
                Text = "Waarvoor staat de P in de afkorting APK?",
                Answer = "Periodieke",
                Difficult = 2,
                Category = "Vervoer",
            };

            VragenLijst.Add(vraag1);
            VragenLijst.Add(vraag2);
            VragenLijst.Add(vraag3);
            VragenLijst.Add(vraag4);
            VragenLijst.Add(vraag5);
            VragenLijst.Add(vraag6);
            VragenLijst.Add(vraag7);
            VragenLijst.Add(vraag8);

            bool spelKlaar = false;

            Game.PrintWelkom();

            while (!spelKlaar)
            {
                Console.Write("Command: ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Game.PrintVragenNormaal();
                        break;

                    case "2":
                        Game.PrintMakkelijkeVragenEerst();
                        break;

                    case "3":
                        Game.PrintMoeilijkeVragenEerst();
                        break;

                    case "4":
                        Game.PrintCategories(VragenLijst);
                        break;

                    case "5":
                        Game.PrintMoeilijkHeidsGraad(VragenLijst);
                        break;

                    case "clear":
                        Console.Clear();
                        Game.PrintWelkom();
                        break;

                    case "9":
                        spelKlaar = true;
                        break;
                }
            }
        }
    }
}