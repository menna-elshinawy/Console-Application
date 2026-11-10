using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Application
{
    internal class ChooseOneQuestion : Question
    {
        private List<string> chooseOne = new List<string>();
        private int correctanswer;
        public ChooseOneQuestion(Level level, string header, int marks,List<string> chooseOne, int correctanswer) : base(level,header,marks)
        {
            this.chooseOne = chooseOne;
            this.correctanswer = correctanswer;
        }
        public void Display()
        {
            Console.WriteLine($"1-{chooseOne[0]}");
            Console.WriteLine($"2-{chooseOne[1]}");
            Console.WriteLine($"3-{ chooseOne[2]}");
            Console.WriteLine($"4-{ chooseOne[3]}");
        }
        public override bool CheckAnswer(object studentanswer)
        {
            return studentanswer.Equals(correctanswer);
        }
    }
}
