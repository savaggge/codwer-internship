using System;

class Program
{
    static void Main()
    {
        int num;
        bool isNumberValid = false;

        do
        {
            Console.Write("Introdu un numar cu cel putin 3 cifre: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out num) && input.Length >= 3)
            {
                isNumberValid = true;
            }
            else
            {
                Console.WriteLine("Numarul introdus nu are cel putin 3 cifre. Te rog sa introdu un alt numar.");
            }
        } while (!isNumberValid);

        int reversedNum = ReverseNumber(num);
        Console.WriteLine($"Valoarea in oglinda a numarului este: {reversedNum}");

        if (IsPerfectSquare(reversedNum))
        {
            Console.WriteLine($"{reversedNum} este un patrat perfect.");
        }
        else
        {
            Console.WriteLine($"{reversedNum} nu este un patrat perfect.");
        }
    }

    static int ReverseNumber(int num)
    {
        int reversedNum = 0;
        while (num > 0)
        {
            int digit = num % 10;
            reversedNum = reversedNum * 10 + digit;
            num /= 10;
        }
        return reversedNum;
    }

    static bool IsPerfectSquare(int num)
    {
        int sqrt = (int)Math.Sqrt(num);
        return sqrt * sqrt == num;
    }
}