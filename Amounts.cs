using System;

namespace Project_CoffeeMachine
{
    internal class Amounts
    {
        public Int32[] FillAmounts { get; private set; }

        public Amounts() 
        {
            FillAmounts = new Int32[] { 16, 32, 48, 300, 600, 900 };
        }
    }
}
