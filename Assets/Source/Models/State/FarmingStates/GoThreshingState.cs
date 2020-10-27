using System;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class GoThreshingState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
  
            var amount = person.CurrentLocation.Inventory.HasAmountResource(Constants.ResourceIdWheatPlant);
            Debug.Log($"Threshing wheat {amount}");

            if (amount == 0)
            {
                return new DoNothingState();
            }

            person.CurrentLocation.Inventory.RemoveResource(Constants.ResourceIdWheatPlant, 1);
            person.CurrentLocation.Inventory.AddResource(Constants.ResourceIdWheatSeed, 10);

            return this;
        }
    }
}