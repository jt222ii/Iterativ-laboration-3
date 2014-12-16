using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnvandningsfallRaknaPoang
{
    class count // Denna klass ska räkna ut medelpoängen.
    {
        public decimal average(int[] pointArray)
        {
            Array.Sort(pointArray); // sorterar arrayen i storleksordning
            int total = 0; //totalpoängen för arrayen
            for (int i = 1; i < pointArray.Length - 1; i++) // i = 1; för att minsta talet ska inte räknas med och "pointArray.Length-1;" för största talet ska inte räknas med.
            {
                total += pointArray[i]; //lägger till poängen på totalpoängen för utförandet
            }
            decimal average = ((decimal)total/(pointArray.Length-2)); //räknar ut medelpoängen
            return average; //returnerar medelpoängen
        }
    }
}
