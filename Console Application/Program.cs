using System.ComponentModel;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Console_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> q = new List<Question>();
            List<string> choose = new List<string>();
            List<string> choose2 = new List<string>();
            int n;
            do
            {
                Console.WriteLine("main menu");
                Console.WriteLine("1- Doctor Mode");
                Console.WriteLine("2- Student Mode");
                Console.WriteLine("3- Exit");
                Console.Write("choose : ");
                n = Convert.ToInt32(Console.ReadLine());
                switch(n)
                {
                    case 1:
                        DoctorMode(q);
                        break;
                    case 2: 
                        StudentMode(q);
                        break;
                    case 3:
                        Console.WriteLine("finish");
                        break;
                    default:
                        Console.WriteLine("invaild value");
                    break;
                }
            }
            while (n != 3);
        }
        public static void DoctorMode(List<Question> q)
        {
            try
            {
                Console.WriteLine("How Many Question You Want To Add ? ");
                int n = Convert.ToInt32(Console.ReadLine());
                if (n <= 50 && n>0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"Adding Question{i + 1} : ");
                        Console.Write("Select Question Type : 1- TrueFalseQuestion / 2-ChooseOneQuestion / 3- MultipleChoiceQuestion ");
                        int Choose = Convert.ToInt32(Console.ReadLine());
                        switch (Choose)
                        {
                            case 1:
                                    Console.Write($"Enter Question Level ({Question.Level.Easy} / {Question.Level.Medium} / {Question.Level.Hard}) : ");
                                    Question.Level l = (Question.Level)Enum.Parse(typeof(Question.Level), Console.ReadLine(), ignoreCase: true);
                                    Console.Write("Enter Question Header : ");
                                    string header = Console.ReadLine();
                                    Console.Write("Enter Question Marks : ");
                                    int marks = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter Correct Answer true or false : ");
                                    bool answer = Convert.ToBoolean(Console.ReadLine());
                                    TrueFalseQuestion tf = new TrueFalseQuestion(l, header, marks, answer);
                                    q.Add(tf);
                                break;
                            case 2:
                                
                                    Console.Write($"Enter Question Level ({Question.Level.Easy} / {Question.Level.Medium} / {Question.Level.Hard}) : ");
                                     l = (Question.Level)Enum.Parse(typeof(Question.Level), Console.ReadLine(), ignoreCase: true);
                                    Console.Write("Enter Question Header : ");
                                     header = Console.ReadLine();
                                    Console.Write("Enter Question Marks : ");
                                    marks = Convert.ToInt32(Console.ReadLine());
                                    List<string> choose = new List<string>();
                                    for (int k = 0; k < 4; k++)
                                    {
                                        Console.Write($"Enter Choose {k + 1} : ");
                                        string ch = Console.ReadLine();
                                        choose.Add(ch);
                                    }
                                    Console.WriteLine("Enter Correct Choose Number From (1-4) : ");
                                    int correctanswer = Convert.ToInt32(Console.ReadLine());
                                    ChooseOneQuestion c = new ChooseOneQuestion(l, header, marks, choose, correctanswer);
                                    q.Add(c);
                                break;
                            case 3:
                                    Console.Write($"Enter Question Level ({Question.Level.Easy} / {Question.Level.Medium} / {Question.Level.Hard}) : ");
                                     l = (Question.Level)Enum.Parse(typeof(Question.Level), Console.ReadLine(), ignoreCase: true);
                                    Console.Write("Enter Question Header : ");
                                     header = Console.ReadLine();
                                    Console.Write("Enter Question Marks : ");
                                     marks = Convert.ToInt32(Console.ReadLine());
                                    List<string> choose2 = new List<string>();
                                    for (int f = 0; f < 4; f++)
                                    {
                                        Console.Write($"Enter Choose {f + 1} : ");
                                        string ch = Console.ReadLine();
                                        choose2.Add(ch);
                                    }
                                    Console.Write("Enter Correct Answers e.g. 1&3 :");
                                    List<int> twoanswer = new List<int>();
                                    for (int w = 0; w < 2; w++)
                                    {
                                        twoanswer.Add(Convert.ToInt32(Console.ReadLine()));
                                        Console.Write("&");
                                    }
                                    MultipleChoiceQuestion m = new MultipleChoiceQuestion(l, header, marks, choose2, twoanswer);
                                q.Add(m);
                                break;
                            default:
                                Console.WriteLine("invaild value");
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("please try again");
            }
        }
        public static void StudentMode(List<Question> q)
        {
            try
            {
                Console.WriteLine("Choose Exam Type : 1- Practical Exam 2- Final Exam");
                int type = Convert.ToInt32(Console.ReadLine());
                switch (type)
                {
                    case 1:
                        Console.WriteLine($"Enter Practical Level :  ({Question.Level.Easy} / {Question.Level.Medium} / {Question.Level.Hard})");
                        Question.Level l = (Question.Level)Enum.Parse(typeof(Question.Level), Console.ReadLine(), ignoreCase: true);
                        Console.WriteLine("__________Practical started__________");
                        int result = 0;
                        Question.Display(q, l);
                        for (int i = 0; i < q.Count; i++)
                        {
                            if (q[i].level == l)
                            {
                                if (q[i] is TrueFalseQuestion f)
                                {
                                    Console.Write("please enter true or false : ");
                                    object studentanswer = Convert.ToBoolean(Console.ReadLine());
                                    if (f.CheckAnswer(studentanswer) == true)
                                    {
                                        result += f.marks;
                                    }
                                }
                                else if (q[i] is ChooseOneQuestion c)
                                {
                                    c.Display();
                                    Console.Write("please choose one : ");
                                    object studentanswer = Convert.ToInt32(Console.ReadLine());
                                    if (c.CheckAnswer(studentanswer) == true)
                                    {
                                        result += c.marks;
                                    }
                                }
                                else if (q[i] is MultipleChoiceQuestion m)
                                {
                                    List<int> theanswer = new List<int>();
                                    m.Display();
                                    Console.Write("please enter two chooses : ");
                                    for (int y = 0; y < 2; y++)
                                    {
                                        theanswer.Add(Convert.ToInt32(Console.ReadLine()));
                                        Console.Write("&");
                                    }
                                    Console.WriteLine();
                                    if (m.CheckAnswer(theanswer) == true)
                                    {
                                        result += m.marks;
                                    }
                                }
                            }
                        }
                        Console.Write("Your Result : " + result);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine($"Enter Exam Level :  ({Question.Level.Easy} / {Question.Level.Medium} / {Question.Level.Hard})");
                        l = (Question.Level)Enum.Parse(typeof(Question.Level), Console.ReadLine(), ignoreCase: true);
                        Console.WriteLine("__________Exam started__________");
                        result = 0;
                        for (int i = 0; i < q.Count; i++)
                        {
                            if (q[i].level == l)
                            {

                                Console.WriteLine(q[i].header);
                                if (q[i] is TrueFalseQuestion f)
                                {
                                    Console.Write("please enter true or false : ");
                                    object studentanswer = Convert.ToBoolean(Console.ReadLine());
                                    if (f.CheckAnswer(studentanswer) == true)
                                    {
                                        result += f.marks;
                                    }
                                }
                                else if (q[i] is ChooseOneQuestion c)
                                {
                                    c.Display();
                                    Console.Write("please choose one : ");
                                    object studentanswer = Convert.ToInt32(Console.ReadLine());
                                    if (c.CheckAnswer(studentanswer) == true)
                                    {
                                        result += c.marks;
                                    }
                                }
                                else if (q[i] is MultipleChoiceQuestion m)
                                {
                                    m.Display();
                                    List<int> theanswer = new List<int>();
                                    Console.Write("please enter two chooses : ");
                                    for (int y = 0; y < 2; y++)
                                    {
                                        theanswer.Add(Convert.ToInt32(Console.ReadLine()));
                                        Console.Write("&");
                                    }
                                    Console.WriteLine();
                                    if (m.CheckAnswer(theanswer) == true)
                                    {
                                        result += m.marks;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Your Result : " + result);
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("invaild value");
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
