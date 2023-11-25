using System;

// Создаем свой тип исключения
public class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main()
    {
        // Массив из пяти различных видов исключений
        Exception[] exceptions = new Exception[]
        {
            new DivideByZeroException(),
            new InvalidOperationException(),
            new NullReferenceException(),
            new CustomException("Свое собственное исключение"),
            new ArgumentException("Некорректный аргумент")
        };

        // Используем конструкцию try-catch-finally
        foreach (var ex in exceptions)
        {
            try
            {
                // Вызываем метод, который может сгенерировать исключение
                ThrowException(ex);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Поймано исключение DivideByZeroException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Поймано исключение InvalidOperationException");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Поймано исключение NullReferenceException");
            }
            catch (CustomException customEx)
            {
                Console.WriteLine($"Поймано свое собственное исключение: {customEx.Message}");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine($"Поймано исключение ArgumentException: {argEx.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен");
            }
        }
    }

    // Метод, который генерирует исключение
    static void ThrowException(Exception exception)
    {
        if (exception != null)
        {
            throw exception;
        }
    }
}
