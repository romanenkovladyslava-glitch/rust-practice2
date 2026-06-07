using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть перше число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть друге число: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть операцію (+, -, *, /): ");
        string op = Console.ReadLine();

        double result = 0;

        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;

            case "-":
                result = num1 - num2;
                break;

            case "*":
                result = num1 * num2;
                break;

            case "/":
                result = num1 / num2;
                break;

            default:
                Console.WriteLine("Невірна операція");
                return;
        }

        Console.WriteLine($"Результат: {result}");
    }
}