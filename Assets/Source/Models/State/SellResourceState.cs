using Assets.Source.Models.Resources;
using System;
using UnityEngine;

namespace Assets.Source.Models.State
{
    internal class SellResourceState : BaseState
    {
        private Guid guid;
        private int amount;

        public SellResourceState(Guid guid, int amount)
        {
            this.guid = guid;
            this.amount = amount;
        }

        public override BaseState Update(PersonModel person)
        {
            Debug.Log("Selling resource");
            var resource = ResourceFactory.GetResource(guid);
            var seller = person;
            var buyer = person.CurrentLocation.Owner;


            var amountOfCoin = buyer.Inventory.HasAmountResource(Constants.ResourceIdCoin);
            var couldbuy = amountOfCoin / resource.SellCost;
            var canBuy = (int)Math.Floor(amountOfCoin / resource.SellCost);

            var willBuy = Math.Min(canBuy, amount);

            var cost = (int)Math.Round(resource.SellCost * willBuy);

            var resourcestack = seller.Inventory.GetResource(guid, willBuy);

            Debug.Log($"Buying: amount of coin {amountOfCoin} resourcecost {resource.SellCost} couldbuy {couldbuy} canbuy {canBuy} willbuy {willBuy}, cost {cost}, resourcestack {resourcestack.Amount}");
            buyer.Inventory.AddResource(guid, resourcestack.Amount);
            buyer.Inventory.RemoveResource(Constants.ResourceIdCoin, cost);
            seller.Inventory.AddResource(Constants.ResourceIdCoin, cost);
            return new DoNothingState();
        }
    }
}