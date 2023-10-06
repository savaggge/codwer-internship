using Animale;
using System;
using System.Collections.Generic;


namespace NumeleSpatiuluiDeNume
{
    enum TipAnimal { Lup, Urs, Oaie, Veverita, Pisica, Vaca }

    public class Program
    {
        public static void Main()
        {
            // a. Instantierea animalelor
            Carnivor lup = new Carnivor("Lup", 30, new Animal.Dimensiune { Lungime = 1.2m, Latime = 0.6m, Inaltime = 0.8m }, 15);
            Erbivor oaie = new Erbivor("Oaie", 25, new Animal.Dimensiune { Lungime = 1.0m, Latime = 0.5m, Inaltime = 0.7m }, 10);
            Omnivor urs = new Omnivor("Urs", 100, new Animal.Dimensiune { Lungime = 2.0m, Latime = 1.2m, Inaltime = 1.5m }, 12);

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
            int numarAnimalePlante = 0;
            int numarAnimaleMancare = 0;
            int numarAnimaleCarne = 0;
            int numarAnimaleOmnivor = 0;


            // j. Afișarea statisticilor
            foreach (var animal in animale)
            {
                if (animal is Erbivor)
                {
                    numarAnimalePlante++;
                    numarAnimaleMancare++;

                }

                else if (animal is Carnivor)
                {
                    numarAnimaleCarne++;
                    numarAnimaleMancare++;

                }

                else if (animal is Omnivor)
                {
                    numarAnimaleOmnivor++;
                    numarAnimaleMancare++;

                }
                else
                {
                    Console.WriteLine("Some error has occured");
                }

            }


            Console.WriteLine($"{numarAnimaleMancare} animale mananca mancare.");
            Console.WriteLine($"{numarAnimaleCarne} animale mananca carne.");
            Console.WriteLine($"{numarAnimalePlante} animale mananca plante.");
            Console.WriteLine($"{numarAnimaleOmnivor} animale omnivoare.");


            for (int i = 0; i < animale.Count; i++)
            {
                Console.Write($"{i} ");

                if (animale[i].Nume != null)
                {
                    Console.Write($"Nume: {animale[i].Nume} ");
                }

                Console.WriteLine($"cu greutate de: {animale[i].Greutate}");
            }

            Console.ReadLine();
        }


        enum TipAnimal { Lup, Urs, Oaie, Veverita, Pisica, Vaca }

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
                case TipAnimal.Veverita:
                    return new Erbivor(nume, greutate, dimensiuni, viteza);
                case TipAnimal.Pisica:
                    return new Omnivor(nume, greutate, dimensiuni, viteza);
                case TipAnimal.Vaca:
                    return new Erbivor(nume, greutate, dimensiuni, viteza);
                // Adăugați aici și celelalte tipuri de animale
                default:
                    throw new ArgumentException("Tipul animalului nu este valid.", nameof(tip));
            }
        }
    }
}