using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Ajax.Utilities;

namespace HelloWorld
{
    public interface IHalving
    {
        void HalfIt(double original, List<double> halves);
        long SquareIt(long toBeSquared);
    }

    public interface IDoSomethingElse
    {
        string CallMe();
    }

    public class Halving : IHalving
    {
        private readonly IDoSomethingElse DoSomethingElse;

        public Halving(IDoSomethingElse doSomethingElse)
        {
            this.DoSomethingElse = doSomethingElse;
        }

        public void HalfIt(double original,  List<double> halves)
        {            
            CheckForNonNullHalves(halves);

            var called = this.DoSomethingElse.CallMe();

            var thisHalf = original / 2.000;

            if (thisHalf > 0.001)
            {                
                halves.Add(thisHalf);
                HalfIt(thisHalf, halves);
            }
        }

        public long SquareIt(long toBeSquared)
        {
            var called = this.DoSomethingElse.CallMe();

            return toBeSquared * toBeSquared;
        }

        private void CheckForNonNullHalves(List<double> halves)
        {
            if (halves == null)
            {
                throw new ArgumentNullException("halves", "halves must be assigned before use of this method");
            }
        }
    }

    public class DoSomethingElse : IDoSomethingElse
    {
        public string CallMe()
        {
            return "I have been called";
        }
    }
}
