using System;

namespace Assets.Source.Models
{
    public static class Constants
    {
        // Game speed
        public const int SlowdownFactor = 1;

        // resource IDs
        public static Guid ResourceIdWheatSeed = Guid.Parse("a18229d7-2696-4048-abc6-c3e528bdf1e9");
        public static Guid ResourceIdWheatPlant = Guid.Parse("c66b29c6-c9bc-498b-9266-0e48b7c9d6fb");
        public static Guid ResourceIdCoin = Guid.Parse("5ee070b0-b10c-4cc1-9bcb-39ddbe650852");

        // Field
        public const int GrowthTime = 2000;
    }
}
