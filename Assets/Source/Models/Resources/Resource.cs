using System;

namespace Assets.Source.Models.Resources
{
    public class Resource
    {
        public Resource(Guid guid)
        {
            Id = guid;
        }
        public Guid Id { get; internal set; }

        public double BuyCost { get; set; }
        public double SellCost { get; set; }
    }
}
