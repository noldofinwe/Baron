using System.Linq;

namespace Assets.Source.Models.State
{
    public class GoGetWaterState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            if (person.Inventory.HasResource(Constants.ResourceIdWater))
            {
                if (person.CurrentLocation == person.GetHome())
                {
                    return new StoreResourceState(Constants.ResourceIdWater);
                }
                else
                {
                    return new GoHomeState();
                }
            }

            if (person.CurrentLocation is Well)
            {
                return new GetWaterState();
            }
            else
            {
                person.TargetLocation = person.CurrentLocation.Area.Locations.FirstOrDefault(p => p is Well);
                if(person.TargetLocation != null)
                {
                    return new TravelState();
                }
                else
                {
                    return new GoHomeState();
                }
            }
        }
    }
}