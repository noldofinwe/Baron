namespace Assets.Source.Models.State
{
    public class GoHarvestState : BaseState
    {
        public GoHarvestState(Field fieldReadyForHarvest)
        {
            FieldReadyForHarvest = fieldReadyForHarvest;
        }



        public Field FieldReadyForHarvest { get; }

        public override BaseState Update(PersonModel person)
        {
            if (person.CurrentLocation != FieldReadyForHarvest)
            {
                person.TargetLocation = FieldReadyForHarvest;
                return new TravelState();

            }
            else
            {
                return new HarvestState();
            }
        }
    }
}