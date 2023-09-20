using System;

class Program
{
    static void Main()
    {
        // a) Citește lista de numere de la tastatură și salvează-le într-un array
        Console.WriteLine("Introduceti o lista de numere separate prin spatiu:");
        string input = Console.ReadLine();
        string[] numereString = input.Split(' ');
        double[] numere = new double[numereString.Length];

        for (int i = 0; i < numereString.Length; i++)
        {
            if (double.TryParse(numereString[i], out double numar))
            {
                numere[i] = numar;
            }
            else
            {
                Console.WriteLine($"Elementul {numereString[i]} nu este un numar valid si va fi ignorat.");
            }
        }

        // b) Parcurge array-ul și afișează numerele care nu sunt întregi
        Console.WriteLine("Numerele care nu sunt intregi sunt:");
        foreach (double numar in numere)
        {
            if (!EsteIntreg(numar))
            {
                Console.WriteLine(numar);
            }
        }

        // c) Găsește și afișează cel mai mic număr fără a folosi Math.Min
        double minim = GasesteMinim(numere);
        Console.WriteLine($"Cel mai mic numar este: {minim}");
    }

    // Verifică dacă un număr este întreg
    static bool EsteIntreg(double numar)
    {
        return numar == Math.Floor(numar);
    }

    // Găsește cel mai mic număr într-un array de numere
    static double GasesteMinim(double[] numere)
    {
        if (numere.Length == 0)
        {
            throw new ArgumentException("Array-ul de numere este gol.");
        }

        double minim = numere[0];
        for (int i = 1; i < numere.Length; i++)
        {
            if (numere[i] < minim)
            {
                minim = numere[i];
            }
        }

        return minim;
    }
}