using System;

using Int32 = System.Int32;

namespace Project_CoffeeMachine
{
    internal class CoffeeMachine
    {
        public const Int32 maximumWaterCapacity = 900;
        public const Int32 waterPerCup = 150;
        public const Int32 maximumCoffeeCapacity = 48;
        public const Int32 coffeePerCup = 8;
        public const Int32 maximumCupsBeforeCleaning = 12;

        public Int32 cupsBrewed = 0;
        public Int32 currentWaterAmount = 0;
        public Int32 currentCoffeeAmount = 0;
        public String status = String.Empty;
        public String message = String.Empty;
    }
}
