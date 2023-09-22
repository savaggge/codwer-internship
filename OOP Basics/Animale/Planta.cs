using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animale
{
    public class Planta : Mancare
    {
        public Planta(decimal greutate)
        {
            Greutate = greutate;
            Energie = greutate * 0.01m; // Exemplu de calcul al energiei pentru planta
        }
    }
}
