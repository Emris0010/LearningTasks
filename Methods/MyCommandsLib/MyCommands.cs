using System;

namespace MyCommandsLib
{
    public class MyCommands
    {
        public static void WriteTitle(string title)
        {
            Console.WriteLine("***********");
            Console.WriteLine(title);
            Console.WriteLine("***********");
        }

        public static double ReadDouble(string requestText)
        {
            Console.WriteLine(requestText);
            //создаем числовую пременнужю
            double num;
            //создаем строковую переменную
            string str;
            //присваеваем строковое переменной стр1 данные введенные пользователем
            str = Console.ReadLine();
            // Парсируем строчный тип данных в числовой для переменной намбер1
            num = double.Parse(str);

            return num;
        }
    }
}
