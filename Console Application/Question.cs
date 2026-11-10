using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Application
{
    internal abstract class Question
    {
        protected Question(Level level, string header, int marks)
        {
            this.level = level;
            this.header = header;
            this.marks = marks;
        }

        public enum Level
        {
            Easy, Medium, Hard
        }
        public Level level {  get; set; }
        public string header { get; set; }
        public int marks { get; set; }
        public static void Display(List<Question> q , Level l)
        {
            int Q = 0;   
            for(int i = 0; i < q.Count; i++)
            {
                if(q[i].level == l)
                {
                    Q++;
                }
            }
            Q = Q / 2;
            for(int i = 0; i < q.Count; i++)
            {
                if (q[i].level == l && Q > 0)
                {
                    Console.WriteLine(q[i].header);
                    Q--;
                }
            }
        }
        public abstract bool CheckAnswer(object studentanswer);
    }
}
