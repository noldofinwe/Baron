using Assets.Source.Models.Resources;
using JetBrains.Annotations;
using System;
using UnityEngine;

namespace Assets.Source.Models.State
{
    public class BuyResourceState : BaseState
    {
        private Guid guid;
        private int amount;
        public BuyResourceState(Guid guid, int amount)
        {
            this.guid = guid;
            this.amount = amount;
        }

        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Buying resource");
            var resource = ResourceFactory.GetResource(guid);
            var amountOfCoin = person.Inventory.HasAmountResource(Constants.ResourceIdCoin);
            var canBuy = (int)Math.Floor(amountOfCoin/ resource.BuyCost);

            var willBuy =  Math.Min(canBuy, 100);

            var cost = (int)Math.Round(resource.BuyCost* willBuy);

            var resourcestack = person.CurrentLocation.Inventory.GetResource(guid, willBuy);

            Debug.Log($"Buying: willbuy {willBuy}, cost {cost}, resourcestack {resourcestack.Amount}");
            person.Inventory.AddResource(guid, resourcestack.Amount);
            person.Inventory.GetResource(Constants.ResourceIdCoin, cost);
            person.CurrentLocation.Owner.Inventory.AddResource(Constants.ResourceIdCoin, cost);
            return new DoNothingState();

        }
    }
}