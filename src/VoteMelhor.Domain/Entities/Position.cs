namespace VoteMelhor.Domain.Entities
{
    public class Position : Entity
    {
        public string Name { get; private set; }
        public int Current { get; private set; }
        public int PoliticalId { get; private set; }
        public virtual Political Political { get; private set; }

        public Position(string name, int current, int politicalId)
        {
            Name = name;
            Current = current;
            PoliticalId = politicalId;
        }

        public void MarkCurrent()
        {
            Current = 1;
        }

        public void UnMarkCurrent()
        {
            Current = 0;
        }

        // Empty constructor for EF
        protected Position()
        {

        }
    }
}
