using System;

namespace Assets.Source.Models
{
    public static class Constants
    {
        // Game speed
        public const int SlowdownFactor = 1;

        // Person
        public const int TiredLimit = 1000;
        public const int HungryLimit = 1000;
        public const int Minimumfood = 5;

        // resource IDs
        public static Guid ResourceIdWheatSeed = Guid.Parse("a18229d7-2696-4048-abc6-c3e528bdf1e9");
        public static Guid ResourceIdWheatPlant = Guid.Parse("c66b29c6-c9bc-498b-9266-0e48b7c9d6fb");
        public static Guid ResourceIdCoin = Guid.Parse("5ee070b0-b10c-4cc1-9bcb-39ddbe650852");
        public static Guid ResourceIdFlour = Guid.Parse("fa964885-1f55-4553-a0ef-d047c1273fc5");
        public static Guid ResourceIdWater = Guid.Parse("4220e0c6-95e9-48e0-afdb-14e07b1a90cd");
        public static Guid ResourceIdBread = Guid.Parse("6d114b93-237e-4f21-bcf7-dc801062020d");

        // Field
        public const int GrowthTime = 2000;

        // Mill
        public const int MillingTime = 1000;
        public const int SeedsToFlour = 500;

        // Bakery
        public const int FlourToBread = 1;
        public const int WaterToBread = 1;
        public const int BakingTime = 400;

        // Food
        public const int BreadSatiate = 500;


    }
}
