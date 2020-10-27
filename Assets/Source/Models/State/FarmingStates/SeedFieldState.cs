using System;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class SeedFieldState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Seeding field");
            var field = (Field)person.CurrentLocation;

            var hasSeeds = person.Inventory.HasResource(Constants.ResourceIdWheatSeed);

            if(!hasSeeds)
            {
                Debug.Log("No more seeds");
                return new DoNothingState();
            }   
            else if(field.IsSeeded())
            {
                Debug.Log("Done seeding");
                return new DoNothingState();
            }
            else
            {
                field.Seed();
                person.Inventory.RemoveResource(Constants.ResourceIdWheatSeed, 1);
                return this;
            }
        }
    }
}