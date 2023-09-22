using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animale
{
    public class Carnivor : Animal
    {
        public Carnivor(string nume, decimal greutate, Dimensiune dimensiuni, decimal viteza)
            : base(nume, greutate, dimensiuni, viteza)
        {
        }

        protected override bool VerificaMancare(Mancare m)
        {
            return m is Carne;
        }

        public override double Energie()
        {
            decimal sumaEnergieMancare = 0;
            decimal mediaGreutateMancare = 0;

            foreach (var mancare in stomach)
            {
                sumaEnergieMancare += mancare.Energie;
                mediaGreutateMancare += mancare.Greutate;
            }

            mediaGreutateMancare /= stomach.Count;

            return (double)(0.2m - 1 / 5m * mediaGreutateMancare + sumaEnergieMancare);
        }
    }

}
