using System;

namespace VoteMelhor.Domain.Entities
{
    public class Position : Entity
    {
        public string Name { get; private set; }
        public bool Current { get; private set; }
        public Guid PoliticalId { get; private set; }
        public virtual Political Political { get; private set; }

        public Position(string name, bool current, Guid politicalId)
        {
            Name = name;
            Current = current;
            PoliticalId = politicalId;
        }

        public void MarkCurrent()
        {
            Current = true;
        }

        public void UnMarkCurrent()
        {
            Current = false;
        }

        // Empty constructor for EF
        protected Position()
        {

        }
    }
}
