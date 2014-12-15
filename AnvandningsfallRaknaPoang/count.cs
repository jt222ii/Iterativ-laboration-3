using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnvandningsfallRaknaPoang
{
    class count
    {
        public decimal average(int[] pointArray)
        {
            Array.Sort(pointArray);
            int total = 0;
            for (int i = 1; i < pointArray.Length-1; i++)
            {
                total += pointArray[i];
            }
            decimal average = ((decimal)total/(pointArray.Length-2));
            return average;
        }
    }
}
