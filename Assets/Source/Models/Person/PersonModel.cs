using Assets.Source.Models.Enums;
using Assets.Source.Models.Inventory;
using Assets.Source.Models.State;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Models
{

    public abstract class PersonModel
    {
        private Guid _guid;
        public int _age;
        public string _name;
        public List<PersonTrait> _traits;


        public Location _currentLocation;
        public Area _currentArea;
        protected List<Location> _owns;
        protected BaseState _currentState;

        public PersonModel(Guid guid, string name, Location currentLocation)
        {
            _guid = guid;
            _name = name;
            _age = 0;
            _traits = new List<PersonTrait>();
            _currentLocation = currentLocation;
            _currentArea = null;
            TargetLocation = null;
            _owns = new List<Location>();
            _currentState = new DoNothingState();
            Tiredness = 0;
            Hunger = 0;
            Inventory = new InventoryStorage();
            X = currentLocation.X;
            Y = currentLocation.Y;

        }

        public int X { get; set; }
        public int Y { get; set; }

        public virtual void Update()
        {

            _currentState = _currentState.Update(this);

            if(_currentState != null)
            {
                Hunger = Hunger + _currentState.HungryStep;
                Tiredness = Tiredness + _currentState.TiredStep;
            }
        }

        public void AddOwnerShip(Location location)
        {
            _owns.Add(location);
        }

        public int HasInTotalInventory(Guid id)
        {
            var amount = 0;
            foreach(var loc in Owns)
            {
                amount += loc.Inventory.HasAmountResource(id);
            }
            amount += Inventory.HasAmountResource(id);
            return amount;
        }

        //public int HasInTotalInventory(Guid id)
        //{
        //    var amount = 0;
        //    foreach (var loc in Owns)
        //    {
        //        amount += loc.Inventory.HasAmountResource(id);
        //    }
        //    amount += Inventory.HasAmountResource(id);
        //    return amount;
        //}


        public BaseState UpdateHomeState()
        {
            return new RestingState();
            //throw new NotImplementedException();
        }

        public Location GetInventoryWithMostLocation(Guid id)
        {
            var amount = 0;
            Location location = null;

            foreach (var loc in Owns)
            {
                var locationAmount = loc.Inventory.HasAmountResource(id); 
                if (amount < locationAmount)
                {
                    amount = locationAmount;
                    location = loc;
                }
              
            }
            return location;
        }

        public List<Location> Owns { get { return _owns; } }

        public Location CurrentLocation { get { return _currentLocation;  } set { _currentLocation = value; } }
        public Location TargetLocation { get; set; }
        public Area CurrentArea { get { return _currentArea;  } set { _currentArea = value; } }

        public InventoryStorage Inventory { get; set; }
        public Guid Id { get { return _guid; } }

        public int Hunger { get; set; }
        public int Tiredness { get; set; }

        public abstract FindWorkState GetFindWorkState();

        public Location GetHome() { return _owns.FirstOrDefault(p => p.IsHome); }

        public Location GetStorage()
        {
            var storageLocation = _owns.FirstOrDefault(p => p is Barn);
            if(storageLocation == null)
            {
                storageLocation = GetHome();
            }
            return storageLocation;
        }

        public bool RemoveResource(Guid resourceId, int amount)
        {
            if(Inventory.HasAmountResource(resourceId) >= amount)
            {
                Inventory.RemoveResource(resourceId, amount);
                return true;
            }
            if(CurrentLocation != null && Owns.Contains(CurrentLocation) && CurrentLocation.Inventory.HasAmountResource(resourceId) >= amount)
            {
                CurrentLocation.Inventory.RemoveResource(resourceId, amount);
                return true;
            }
            return false;
        }
    }
}
