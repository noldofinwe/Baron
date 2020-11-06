using System;

namespace Assets.Source.Models.Resources
{
    public static class ResourceFactory
    {
        public static Resource GetResource(Guid id)
        {
            if(id == Constants.ResourceIdWheatPlant)
            {
                return new WheatPlant();
            }
            if(id == Constants.ResourceIdWheatSeed)
            {
                return new WheatSeed();
            }
            if (id == Constants.ResourceIdCoin)
            {
                return new Coin();
            }
            if (id == Constants.ResourceIdFlour)
            {
                return new Flour();
            }
            if (id == Constants.ResourceIdBread)
            {
                return new Bread();
            }
            if (id == Constants.ResourceIdWater)
            {
                return new Water();
            }
            return null;
        }

    }
}
