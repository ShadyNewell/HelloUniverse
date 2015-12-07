using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public static class Halving
    {
        public static void HalfIt(double original, ref List<double> halves)
        {            
            CheckForNonNullHalves(halves);

            double thisHalf;

            thisHalf = original / 2.0;

            if (thisHalf > 0.001)
            {                
                halves.Add(thisHalf);
                HalfIt(thisHalf, ref halves);
            }
        }

        private static void CheckForNonNullHalves(List<double> halves)
        {
            if (halves == null)
            {
                throw new ArgumentNullException("halves", "halves must be assigned before use of this method");
            }
        }
    }
}
