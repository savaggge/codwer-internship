using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // a) Citește de la tastatură 3 nume de persoane
        Console.WriteLine("Introduceti 3 nume de persoane separate prin spatiu:");
        string input = Console.ReadLine();
        string[] nume = input.Split(' ');

        if (nume.Length != 3)
        {
            Console.WriteLine("Trebuie a introdu exact 3 nume.");
            return;
        }

        // b) Afișează caracterul și numărul de apariții în fiecare nume
        Dictionary<char, int> caractereSiAparitii = new Dictionary<char, int>();

        foreach (string num in nume)
        {
            foreach (char caracter in num)
            {
                char caracterLowerCase = Char.ToLower(caracter); // Convertim caracterul la litere mici pentru a-l număra corect
                if (caractereSiAparitii.ContainsKey(caracterLowerCase))
                {
                    caractereSiAparitii[caracterLowerCase]++;
                }
                else
                {
                    caractereSiAparitii[caracterLowerCase] = 1;
                }
            }
        }

        Console.WriteLine("Caracterele si numarul de aparitii in fiecare nume sunt:");

        foreach (var kvp in caractereSiAparitii)
        {
            Console.WriteLine($"Caracterul '{kvp.Key}' apare de {kvp.Value} ori.");
        }
    }
}