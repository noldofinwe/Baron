namespace Assets.Source.Models.Resources
{
    public class Flour : Resource
    {
        public Flour() : base(Constants.ResourceIdFlour)
        {
            BuyCost = 2.00;
            SellCost = 1.0;
        }
    }
}
