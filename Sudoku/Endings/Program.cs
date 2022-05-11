using System;

namespace Endings
{
    /* Задача: Окончания слов.
        Пользователь вводит денежную сумму в виде дробного число. Программа преобразует эту сумму в строку типа "xx рублей, yy копеек". Важно использовать правильные окончания слов.
        Пример: 
            Ввод: 2,41. 
            Вывод: "2 рубля, 41 копейка." 
    */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            var inputResult = Console.ReadLine();
            var enteredValue = decimal.Parse(inputResult);

            var rub = (int)enteredValue;
            var kop = (int)((enteredValue - rub) * 100);

            var resultString = CreateMoneyString(rub, kop);
            Console.WriteLine(resultString);
            Console.ReadKey();
        }

        private static string CreateMoneyString(int rub, int kop)
        {
            var rubStr = $"{rub} рубл{SelectEnding(rub, "ь", "я", "ей")}";
            var kopStr = $"{kop} копе{SelectEnding(kop, "йка", "йки", "ек")}";

            return $"{rubStr}, {kopStr}";
        }

        private static object SelectEnding(int number, string endingForOne, string endingForSeveral, string endingForMany)
        {
            var lastDigit = number % 10;
            var lastTwoDigits = number % 100;
            bool isSecondTen = lastTwoDigits > 10 && lastTwoDigits < 20;

            if (lastDigit == 0 || lastDigit > 4 || isSecondTen)
                return endingForMany;
            
            if (lastDigit > 1 && lastDigit < 5)
                return endingForSeveral;

            return endingForOne;
        }
    }
}
