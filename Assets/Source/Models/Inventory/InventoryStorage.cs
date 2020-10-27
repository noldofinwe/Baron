using Assets.Source.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Source.Models.Inventory
{
    public class InventoryStorage
    {
        public InventoryStorage()
        {

        }

        public List<ResourceStack> Stacks { get; set; } = new List<ResourceStack>();


        public ResourceStack GetResource(Guid id, int amount)
        {
            var stack = Stacks.FirstOrDefault(p => p.Resource.Id == id);
            if(stack != null)
            {
                var resourcestack = new ResourceStack(stack.Resource, 0);

                if(stack.Amount >= amount)
                {
                    stack.Amount = stack.Amount - amount;
                    resourcestack.Amount = amount;
                }
                else if(stack.Amount < amount)
                {
                    Stacks.Remove(stack);
                    resourcestack.Amount = stack.Amount;
                }

                return resourcestack;
            }
            return null;
        }

        public bool RemoveResource(Guid id, int amount)
        {
            var stack = Stacks.FirstOrDefault(p => p.Resource.Id == id);
            if (stack != null)
            {
  
                if (stack.Amount >= amount)
                {
                    stack.Amount = stack.Amount - amount;
                }
                else if (stack.Amount < amount)
                {
                    Stacks.Remove(stack);
                }

                return true;
            }
            return false;
        }


        public void AddResource(Resource resource, int amount)
        {
            var stack = Stacks.FirstOrDefault(p => p.Resource.Id == resource.Id);
            if (stack != null)
            {
                stack.Amount = stack.Amount + amount;
            }
            else
            {
                Stacks.Add(new ResourceStack(resource, amount));
            }
        }

        public void AddResource(Guid resourceId, int amount)
        {
            var stack = Stacks.FirstOrDefault(p => p.Resource.Id == resourceId);
            if (stack != null)
            {
                stack.Amount = stack.Amount + amount;
            }
            else
            {
                var resource = ResourceFactory.GetResource(resourceId);
                Stacks.Add(new ResourceStack(resource, amount));
            }
        }

        public bool HasResource(Guid id)
        {
            return Stacks.Where(p => p.Resource.Id == id).Sum(p => p.Amount) > 0;
        }

        internal int HasAmountResource(Guid id)
        {
            return Stacks.Where(p => p.Resource.Id == id).Sum(p => p.Amount);
        }

        public int TotalAmount()
        {
            return Stacks.Sum(p => p.Amount);
        }
    }
}
