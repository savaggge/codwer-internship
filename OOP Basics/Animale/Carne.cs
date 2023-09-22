using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animale
{
    public class Carne : Mancare
    {
        public Carne(decimal greutate)
        {
            Greutate = greutate;
            Energie = greutate * 0.02m; // Exemplu de calcul al energiei pentru carne
        }
    }
}
