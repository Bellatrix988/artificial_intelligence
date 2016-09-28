using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_Yurova
{
    class Program
    {
        const string writeStr = "Введите начальное число: ";
        const string writeStr2 = "Введите второе число: ";
        const string strResult = "Результат: ";


        static int plus3(int x) => x + 3;
        static int mult2(int x) => x * 2;
        static int minus2(int x) => x - 2;
        static int minus3(int x) => x - 3;
        static int div2(int x) => x % 2 == 0 ? x / 2 : int.MinValue;

        static void helloStr()
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания: ");
            var answer = Console.ReadLine();
            var main = new FoundSolution();

            int firstNum, lastNum;
            Console.Write(writeStr);
            firstNum = Convert.ToInt32(Console.ReadLine());
            Console.Write(writeStr2);
            lastNum = Convert.ToInt32(Console.ReadLine());


            string s;
            switch (Convert.ToInt32(answer))
            {
                case 1:
                    s = main.StartFound(firstNum, lastNum, plus3, mult2);
                    break;
                case 2:
                    s = main.StartFound(firstNum, lastNum, plus3, mult2, minus2);
                    break;
                case 3:
                    s = main.StartFound(lastNum, firstNum, minus3,div2);
                    break;
                default:
                    s = "Error";
                    break;

            }

            Console.WriteLine(strResult + main.countOper + '\n' + s);
        }
}
}
