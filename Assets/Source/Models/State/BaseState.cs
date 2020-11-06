namespace Assets.Source.Models
{
    public abstract class BaseState
    {
        public abstract BaseState Update(PersonModel person);

        public virtual int HungryStep { get; } = 1;
        public virtual int TiredStep { get; } = 1;
    }
}
