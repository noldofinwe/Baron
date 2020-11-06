using System.Linq;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class FindFarmWorkState : FindWorkState
    {
        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Finding farm work");
            var farmer = (Farmer)person;

            //Debug.Log($"Inventory space: {farmer.Inventory.TotalAmount()}");
            if (farmer.Inventory.HasAmountResource(Constants.ResourceIdWheatPlant) > 10)
            {
                return new GoBringHarvestHomeState();
            }


            if(farmer.CurrentLocation != null && farmer.CurrentLocation.Inventory.HasResource(Constants.ResourceIdWheatPlant))
            {
                return new GoThreshingState();
            }
            
            if(farmer.GetStorage().Inventory.HasAmountResource(Constants.ResourceIdWheatSeed)> 500 || farmer.Inventory.HasAmountResource(Constants.ResourceIdWheatSeed) > 250)
            {
                return new GoBringWheatToMillState();
            }

            var fields = farmer.Owns.OfType<Field>().ToList();
            var fieldReadyForHarvest = fields.FirstOrDefault(p => p.IsReadyForHarvest());

            if (fieldReadyForHarvest != null)
            {
                return new GoHarvestState(fieldReadyForHarvest);
            }
            Debug.Log("No fields to harvest");
            var fieldNeedsSeeding = fields.FirstOrDefault(p => !p.IsSeeded());

            if(fieldNeedsSeeding != null)
            {
                Debug.Log("Field found");
                return new GoSeedFieldState(fieldNeedsSeeding);
            }
            Debug.Log("No fields to seed, going home");

            if (person.CurrentLocation != person.GetHome())
            {
                return new GoHomeState();
            }
            return person.UpdateHomeState();
        }
    }
}