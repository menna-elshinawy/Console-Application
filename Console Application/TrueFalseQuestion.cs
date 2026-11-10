using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Application
{
    internal  class TrueFalseQuestion : Question
    {
        private bool trueFalse;

        public TrueFalseQuestion(Level level, string header, int marks, bool trueFalse) : base(level, header, marks)
        {
            this.trueFalse = trueFalse;
        }

        public override bool CheckAnswer(object studentanswer)
        {
            return studentanswer.Equals(trueFalse);
        }
    }
}
