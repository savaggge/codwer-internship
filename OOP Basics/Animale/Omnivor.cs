using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animale
{
    public class Omnivor : Animal
    {
        public Omnivor(string nume, decimal greutate, Dimensiune dimensiuni, decimal viteza)
            : base(nume, greutate, dimensiuni, viteza)
        {
        }

        protected override bool VerificaMancare(Mancare m)
        {
            return m is Carne || m is Planta;
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

            decimal coeficientGreutate = stomach.Exists(m => m is Planta) ? 0.5m : -0.5m;

            return (double)(0.35m + coeficientGreutate * mediaGreutateMancare + sumaEnergieMancare);
        }
    }
}
