using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animale
{
    public abstract class Animal
    {
        public static int Numar { get; private set; } = 0; // Contor pentru numarul de animale instantiate

        public string Nume { get; set; }
        public decimal Greutate { get; private set; }
        public struct Dimensiune
        {
            public decimal Lungime;
            public decimal Latime;
            public decimal Inaltime;
        }
        public Dimensiune Dimensiuni { get; private set; }
        public decimal Viteza { get; private set; }
        protected List<Mancare> stomach = new List<Mancare>(); // Modificăm nivelul de acces la protected

        public Animal(string nume, decimal greutate, Dimensiune dimensiuni, decimal viteza)
        {
            Nume = nume;
            Greutate = greutate;
            Dimensiuni = dimensiuni;
            Viteza = viteza;
            Numar++; // Incrementăm contorul la fiecare nou animal creat
        }

        public void Mananca(Mancare m)
        {
            if (VerificaMancare(m))
            {
                stomach.Add(m);
                Console.WriteLine($"{Nume} mananca.");
            }
            else
            {
                Console.WriteLine($"{Nume} nu mananca aceasta mancare.");
            }
        }

        // Metodă abstractă pentru verificarea dacă mancarea este potrivită pentru animal
        protected abstract bool VerificaMancare(Mancare m);

    public abstract double Energie();

        public void Alearga(decimal distanta)
        {
            double timp = (double)(distanta / (Viteza / (decimal)Energie()));
            Console.WriteLine($"{Nume} parcurge {distanta} metri in aproximativ {timp} secunde.");
        }

        public override string ToString()
        {
            return $"Tip animal: {this.GetType().Name}\n" +
                   $"Nume: {Nume}\n" +
                   $"Greutate: {Greutate} kg\n" +
                   $"Dimensiuni: {Dimensiuni.Lungime} x {Dimensiuni.Latime} x {Dimensiuni.Inaltime}\n" +
                   $"Viteza: {Viteza} m/s";
        }

        internal bool VerificaMancare(Planta salata)
        {
            throw new NotImplementedException();
        }

        internal bool VerificaMancare(Carne sunca)
        {
            throw new NotImplementedException();
        }
    }

}

