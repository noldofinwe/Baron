using UnityEngine;

namespace Assets.Source.Models.State
{
    public class BakeBreadState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Baking bread");
            var bakery = person.CurrentLocation;

            person.RemoveResource(Constants.ResourceIdFlour, Constants.FlourToBread);
            person.RemoveResource(Constants.ResourceIdWater, Constants.WaterToBread);

            bakery.CurrentState = new BakeryLocationState();
            return new DoNothingState();
        }
    }
}