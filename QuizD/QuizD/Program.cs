using System;
using System.Collections.Generic;

namespace QuizD
{
    class Program
    {
        static void Main(string[] args)

        {

            List<Question> VragenLijst = new List<Question>();

            ChoiceQuestion vraag1 = new ChoiceQuestion()
            {
                Text = "Wie heeft C# bedacht?",
                Difficult = 1,
                Category = "Techniek & Wetenschap",

            };

            vraag1.AddChoice("Microsoft", true);
            vraag1.AddChoice("Oracle", false);
            vraag1.AddChoice("De Haagse Hogeschool", false);
            vraag1.AddChoice("Bakfiets", false);

            ChoiceQuestion vraag2 = new ChoiceQuestion()
            {
                Text = "Door welk bedrijf is de Playstation ontwikkeld?",
                Difficult = 1,
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
                Difficult = 5,
                Category = "Techniek & Wetenschap",
            };



            VragenLijst.Add(vraag1);
            VragenLijst.Add(vraag2);
            VragenLijst.Add(vraag3);


            PrintQuestions(VragenLijst);
        }

        public static void PrintQuestions(List<Question> vragen)
        {
            f.Display();
            Console.WriteLine("Jouw antwoord is: ");

            string answer = Console.ReadLine();
            bool gewonnen = f.CheckAnswer(answer) ? true : false;

        
            Console.WriteLine(f.CheckAnswer(answer));
        }
    }
}
