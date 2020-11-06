using System;

namespace Assets.Source.Models.State
{
    public class FindWorkState : BaseState
    {
        public override BaseState Update(PersonModel person)
        {
            if (person.Tiredness > Constants.TiredLimit)
            {
                return new GoRestState();
            }
            if (person.HasInTotalInventory(Constants.ResourceIdBread) < Constants.Minimumfood)
            {
                return new GoBuyFood();
            }
            if (person.Hunger > Constants.HungryLimit)
            {
                return new GoEatState();
            }
           
            return null;
        }
    }
}