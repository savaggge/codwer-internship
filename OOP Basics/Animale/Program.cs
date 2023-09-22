using Animale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

enum TipAnimal { Lup, Urs, Oaie, Veverita, Pisica, Vaca }

class Program
{
    static void Main(string[] args)
    {
        // a. Instantierea animalelor
        Carnivor lup = new Carnivor("Lup", 80, new Animal.Dimensiune { Lungime = 1.5m, Latime = 0.7m, Inaltime = 0.8m }, 20);
        Erbivor oaie = new Erbivor("Oaie", 50, new Animal.Dimensiune { Lungime = 1.2m, Latime = 0.6m, Inaltime = 0.9m }, 15);
        Omnivor urs = new Omnivor("Urs", 150, new Animal.Dimensiune { Lungime = 1.8m, Latime = 1m, Inaltime = 1.2m }, 10);

        // b. Instantierea mancarii
        Planta salata = new Planta(0.2m);
        Carne sunca = new Carne(0.3m);

        // c. Hranirea animalelor
        lup.Mananca(sunca);
        lup.Mananca(sunca);
        oaie.Mananca(salata);
        oaie.Mananca(salata);
        oaie.Mananca(salata);
        urs.Mananca(sunca);
        urs.Mananca(salata);
        urs.Mananca(salata);
        urs.Mananca(salata);

        // d. Animalele alearga
        lup.Alearga(200);
        oaie.Alearga(200);
        urs.Alearga(200);

        // e. Afișarea numărului de animale instantiate
        Console.WriteLine($"Numarul total de animale instantiate: {Animal.Numar}");

        // f. Adaugarea a 10 animale aleatorii in lista si hranirea lor
        List<Animal> animale = new List<Animal>();
        Random random = new Random();
        for (int i = 0; i < 10; i++)
        {
            TipAnimal tipAleatoriu = (TipAnimal)random.Next(Enum.GetNames(typeof(TipAnimal)).Length);
            Animal animalAleatoriu = CreeazaAnimal(tipAleatoriu, $"Animal {i}", (decimal)random.NextDouble() * 100, new Animal.Dimensiune { Lungime = (decimal)random.NextDouble() * 2, Latime = (decimal)random.NextDouble(), Inaltime = (decimal)random.NextDouble() * 2 }, (decimal)random.NextDouble() * 20);
            animale.Add(animalAleatoriu);
        }

        // h. Hranirea animalelor aleatorii
        foreach (var animal in animale)
        {
            if (animal is Carnivor)
            {
                animal.Mananca(new Carne((decimal)random.NextDouble()));
            }
            else if (animal is Erbivor)
            {
                animal.Mananca(new Planta((decimal)random.NextDouble()));
            }
            else if (animal is Omnivor)
            {
                if (random.Next(2) == 0)
                {
                    animal.Mananca(new Carne((decimal)random.NextDouble()));
                }
                else
                {
                    animal.Mananca(new Planta((decimal)random.NextDouble()));
                }
            }
        }

        // j. Afișarea statisticilor
        int numarAnimaleMancare = animale.Count(a => a.VerificaMancare(salata));
        int numarAnimaleCarne = animale.Count(a => a.VerificaMancare(sunca));
        int numarAnimalePlante = animale.Count(a => a.VerificaMancare(salata));

        Console.WriteLine($"{numarAnimaleMancare} animale mananca mancare.");
        Console.WriteLine($"{numarAnimaleCarne} animale mananca carne.");
        Console.WriteLine($"{numarAnimalePlante} animale mananca plante.");

        Console.ReadLine();
    }

    // h. Metoda pentru crearea unui animal aleator
    static Animal CreeazaAnimal(TipAnimal tip, string nume, decimal greutate, Animal.Dimensiune dimensiuni, decimal viteza)
    {
        switch (tip)
        {
            case TipAnimal.Lup:
                return new Carnivor(nume, greutate, dimensiuni, viteza);
            case TipAnimal.Urs:
                return new Omnivor(nume, greutate, dimensiuni, viteza);
            case TipAnimal.Oaie:
                return new Erbivor(nume, greutate, dimensiuni, viteza);
            default:
                throw new ArgumentException("Tipul animalului nu este valid.");
        }
    }
}