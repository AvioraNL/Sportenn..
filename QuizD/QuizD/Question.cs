using System;
using System.Collections.Generic;
using System.Text;

namespace QuizD
{
    public abstract class Question
    {
    
        public string Text  { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public int Difficult { get; set; }



        public Boolean CheckAnswer(string response) => response == Answer;

        public virtual void Display() => Console.WriteLine(Text);

    }


}
