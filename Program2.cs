using System;
using System.Collections.Generic;

// Создаем свой тип исключения для некорректного ввода
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message)
    {
    }
}

class Program2
{
    // Событие для сортировки
    public static event Action<List<string>, bool> SortList;

    static void Main()
    {
        // Исходный список фамилий
        List<string> surnames = new List<string> { "Smith", "Johnson", "Williams", "Jones", "Brown" };

        // Подписываем метод на событие
        SortList += SortSurnames;

        try
        {
            Console.WriteLine("Введите число 1 для сортировки А-Я или 2 для сортировки Я-А:");
            string input = Console.ReadLine();

            // Проверка введенных данных
            ValidateInput(input);

            // Запуск события сортировки
            bool ascendingOrder = input == "1";
            SortList?.Invoke(surnames, ascendingOrder);

            // Вывод отсортированного списка
            Console.WriteLine("Отсортированный список фамилий:");
            foreach (var surname in surnames)
            {
                Console.WriteLine(surname);
            }
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        finally
        {
            Console.ReadLine();
        }
    }

    // Метод для проверки введенных данных
    static void ValidateInput(string input)
    {
        if (input != "1" && input != "2")
        {
            throw new InvalidInputException("Некорректный ввод. Введите 1 или 2.");
        }
    }

    // Метод для сортировки фамилий
    static void SortSurnames(List<string> surnames, bool ascendingOrder)
    {
        if (ascendingOrder)
        {
            surnames.Sort();
        }
        else
        {
            surnames.Sort((x, y) => y.CompareTo(x));
        }
    }
}
