using System;
using MyCommandsLib;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            // ТипВозвращаемогоЗначения ИмяМетода(аргументы ввиде: типАргумента1 имяАргумента1,  типАргумента2 имяАргумента2)
            // void Console.WriteLine(string value)
            // string Console.ReadLine()
            // double double.Parse(string s)

            /* string str = "Hello";
             Console.WriteLine(str);
             Console.ReadLine();
             double num =  double.Parse("234");*/

            string s = "Какой-то заголовок";

            MyCommands.WriteTitle(s);

            /*Console.WriteLine("***********");
            Console.WriteLine(title);
            Console.WriteLine("***********");*/

            double number_1 = MyCommands.ReadDouble("введите число 1");
            double number_2 = MyCommands.ReadDouble("введите число 2");
            double number_3 = MyCommands.ReadDouble("введите число 3");
           
            // вычисаления
            double subtraction = number_1 * 2 - number_2 * 3 - number_3 * 2;
            double result_1 = (number_1 + number_2 + number_3) / 3;

            // вывод результата
            Console.WriteLine("Ответ");
            Console.WriteLine("Разность " + subtraction.ToString());
            Console.WriteLine("Среднее " + result_1.ToString());


            Console.ReadKey();
        }
    }

   

}
