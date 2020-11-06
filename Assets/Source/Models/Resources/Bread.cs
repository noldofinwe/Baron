namespace Assets.Source.Models.Resources
{
    public class Bread : Resource
    {
        public Bread() : base(Constants.ResourceIdBread)
        {
            BuyCost = 3.00;
            SellCost = 2.0;
        }
    }
}
