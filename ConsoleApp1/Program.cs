namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Skriv in ett nummer");
        string inputFirstString = Console.ReadLine() ?? "Error";

        Console.WriteLine("Skriv in ett nummer");
        string inputSecondString = Console.ReadLine() ?? "Error";

        float firstNumber = 0;
        float secondNumber = 0;
        try
        {
            firstNumber = float.Parse(inputFirstString);
            secondNumber = float.Parse(inputSecondString);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine(Addition(firstNumber, secondNumber));
        Console.WriteLine(Subtraction(firstNumber, secondNumber));
        Console.WriteLine(Multiplication(firstNumber, secondNumber));
        Console.WriteLine(Division(firstNumber, secondNumber));
    }

    static float Addition(float x, float y)
    {
        return x + y;
    }

    static float Subtraction(float x, float y)
    {
        return x - y;
    }

    static float Multiplication(float x, float y)
    {
        return x * y;
    }

    static float Division(float x, float y)
    {
        return (float)Math.Round(x / y, 2);
    }



}
