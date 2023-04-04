using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr14_1_2
{
    class Program
    { 
        static void zad1()
        {
            try
            {
                Console.Write("n="); int n = int.Parse(Console.ReadLine());
                Stack<string> stack = new Stack<string>(n);
                for (int i = 1; i <= n; i++)
                {
                    stack.Push(Convert.ToString(i));
                }
                Console.WriteLine("Размерность стэка: " + stack.Count);
                Console.WriteLine("Верхний элемент стэка: " + n);
                Console.Write("Содержимое стэка: ");
                foreach (var vivod in stack)
                {
                    Console.Write(vivod + " ");
                }
                stack.Clear();
                Console.WriteLine("\nНовая размерность стэка: " + stack.Count);
            }
            catch { Console.WriteLine("Было введенно некорректное число!"); }
        }
        static void zad2a()
        {
            Console.WriteLine("Введите вашу формулу:");
            string formula = Console.ReadLine();
            File.WriteAllText("sa.txt", formula);
            string exp = File.ReadAllText("sa.txt");
            Stack<int> stack = new Stack<int>();
            bool scan = false;

            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];

                if (c == '"')
                {
                    scan = !scan;
                }
                else if (!scan)
                {
                    if (c == '(')
                    {
                        stack.Push(i);
                    }
                    else if (c == ')')
                    {
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("Возможно лишняя ) скобка в позиции: {0}", i + 1);
                            return;
                        }
                    }
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("Скобки сбалансированы");
            }
            else
            {
                Console.WriteLine("Возможно лишняя ( скобка в позиции: {0}", stack.Pop() + 1);
                Console.ReadKey();
            }

            Console.ReadKey();


        }



        static void zad2b()
        {
            Console.WriteLine("Введите вашу формулу:");
            string formula = Console.ReadLine();
            File.WriteAllText("sa.txt", formula);
            string exp = File.ReadAllText("sa.txt");
            Stack<int> stack2 = new Stack<int>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    stack2.Push(i);
                }
                else if (exp[i] == ')')
                {
                    if (stack2.Count > 0)
                    {

                        stack2.Pop();
                    }
                    else
                    {
                        exp = exp.Remove(i, 1);
                        exp = exp.Insert(i, " ");
                    }
                }
            }
            while (stack2.Count > 0)
            {
                int index = stack2.Pop();
                exp = exp.Remove(index, 1);
                exp = exp.Insert(index, " ");
            }
            using (StreamWriter writer = new StreamWriter("sa2.txt"))
            {
                writer.Write(exp);
            }

            Console.WriteLine("Новое выражение успешно записано в файл sa2.txt.");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Выберите задание 1-1, 2А-2, 2Б-3: "); int zad = int.Parse(Console.ReadLine());
                switch (zad)
                {
                    case 1:
                        zad1();
                        break;
                    case 2:
                        zad2a();
                        break;
                    case 3:
                        zad2b();
                        break;
                    default:
                        Console.WriteLine("Нет такого задания!");
                        break;
                }
            }
            catch { Console.WriteLine("Некорректный ввод данных");}
            Console.ReadLine();

        }
       
    }
}
