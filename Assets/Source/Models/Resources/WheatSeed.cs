using Assets.Source.Models.Enums;
using System;

namespace Assets.Source.Models.Resources
{
    public class WheatSeed : Resource
    {
        public WheatSeed() : base(Constants.ResourceIdWheatSeed)
        {
            TimeToGrow = 3000;
            Yield = 10;
            BuyCost = 0.01;
            SellCost = 0.005;
        }

        public int TimeToGrow { get; } = 0;
        public int Yield { get; } = 0;
    }
}
