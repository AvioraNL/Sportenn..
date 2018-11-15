using System;

namespace QuizD
{
    class Program
    {
        static void Main(string[] args)

        {

            ChoiceQuestion d = new ChoiceQuestion()
            {
            Text = "Welke wereld leven wij?",
            };

            d.AddChoice("Weetje wel idee", true);
            d.AddChoice("Geen idee", false);
            d.AddChoice("Geen idee", false);
            d.AddChoice("Geen idee", false);



            PrintQuestion(d);
        }

        public static void PrintQuestion(Question f)
        {
            f.Display();
            Console.WriteLine("Jouw antwoord is: ");
            string answer = Console.ReadLine();
            
            Console.WriteLine(f.CheckAnswer(answer));
            Console.ReadLine();
        }
    }
}
