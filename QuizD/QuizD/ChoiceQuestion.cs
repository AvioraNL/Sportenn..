using System;
using System.Collections.Generic;
using System.Text;

namespace QuizD
{
    class ChoiceQuestion : Question
    {

        private List<string> Choices;

        public ChoiceQuestion()
        {
            Choices = new List<string>();
        }


        public void AddChoice(String choice, bool correct)
        {
            Choices.Add(choice);

            if (correct)
            {
                String choiceString = "" + Choices.Count;
                Answer = choiceString;
            }
        }


        public override void Display()
        {
            base.Display();
            for (int i = 0; i < Choices.Count; i++)
            {
                int choiceNumber = 1 + i;
                Console.WriteLine(choiceNumber + ": " + Choices[i]);
            }
        }


    }
}
