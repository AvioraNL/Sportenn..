using System;

namespace QuizD
{
    public class Question
    {
        public string Text { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public int Difficult { get; set; }

        public Boolean CheckAnswer(string response) => response == Answer;

        public virtual void Display() => Console.WriteLine(Text + " Categorie " + Category + " Moeilijkheidsgraad " + Difficult);
    }
}