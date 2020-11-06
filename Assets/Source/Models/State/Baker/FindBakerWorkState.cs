using UnityEngine;

namespace Assets.Source.Models.State
{
    public class FindBakerWorkState : FindWorkState
    {
        public override BaseState Update(PersonModel person)
        {
            var bakery = person.GetHome();
            var amountFlour = bakery.Inventory.HasAmountResource(Constants.ResourceIdFlour);
            var amountWater = bakery.Inventory.HasAmountResource(Constants.ResourceIdWater);

            Debug.Log($"Flour {amountFlour} Water {amountWater}");
            if (bakery.Inventory.HasAmountResource(Constants.ResourceIdBread) > 5 || person.Inventory.HasResource(Constants.ResourceIdBread))
            {
                return new GoSellBreadState();
            }

            if (bakery.CurrentState == null && person.HasInTotalInventory(Constants.ResourceIdFlour) > Constants.FlourToBread
                                            && person.HasInTotalInventory(Constants.ResourceIdWater) > Constants.WaterToBread)
            {
                return new GoBakeBreadState();
            }

            if (bakery.Inventory.HasAmountResource(Constants.ResourceIdWater) < Constants.WaterToBread * 10)
            {
                return new GoGetWaterState();
            }
            if (person.CurrentLocation != bakery)
            {
                return new GoHomeState();
            }


            return new DoNothingState();
        }
    }
}
