using Assets.Source.Models.Resources;

namespace Assets.Source.Models.Inventory
{
    public class ResourceStack
    {

        public ResourceStack(Resource resource, int amount)
        {
            Resource = resource;
            Amount = amount;
        }

        public Resource Resource { get; }
        public int Amount { get; set;  }
    }
}