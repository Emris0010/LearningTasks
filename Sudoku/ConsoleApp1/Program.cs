using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double number_1 = ReadDouble("введите число 1");
            double number_2 = ReadDouble("введите число 2");
            double number_3 = ReadDouble("введите число 3");

            double subtraction = number_1 * 2 - number_2 * 3 - number_3 * 2;
            double result_1 = (number_1 + number_2 + number_3) / 3;

            // вывод результата
            Console.WriteLine("Ответ");
            Console.WriteLine("Разность " + subtraction.ToString());
            Console.WriteLine("Среднее " + result_1.ToString());

            Console.ReadKey();
        }

        static double ReadDouble(string requestText)
        {
            Console.WriteLine(requestText);
            double number;
            string str;
            str = Console.ReadLine();
            number = double.Parse(str);

            return number;
        }
    }
}
