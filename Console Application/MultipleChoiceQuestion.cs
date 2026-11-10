using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Application
{
    internal class MultipleChoiceQuestion : Question
    {
        private List<string> multipleChoice=new List<string>();
        private List<int> twoanswer = new List<int>();

        
        public MultipleChoiceQuestion(Level level, string header, int marks,List<string> multipleChoice, List<int> twoanswer) : base(level, header,marks)
        {
            this.multipleChoice = multipleChoice;
            this.twoanswer = twoanswer;
        }
        public void Display()
        {
              Console.WriteLine($"1-{multipleChoice[0]}");
              Console.WriteLine($"2-{multipleChoice[1]}");
              Console.WriteLine($"3-{multipleChoice[2]}");
              Console.WriteLine($"4-{multipleChoice[3]}");
        }
        public override bool CheckAnswer(object studentanswer)
        {
            return studentanswer.Equals(multipleChoice);
        }
    }
}
