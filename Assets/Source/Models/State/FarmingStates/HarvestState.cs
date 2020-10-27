using System;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class HarvestState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {

            Debug.Log("Harvesting");

            var field = (Field)person.CurrentLocation;

            if (!field.IsReadyForHarvest())
            {
                Debug.Log("Done harvesting");
                return new DoNothingState();
            }
            else
            {
                var result = field.Harvest();
                if (result)
                {
                    person.Inventory.AddResource(Constants.ResourceIdWheatPlant, 1);
                }
                return this;
            }
        }
    }
}