using System.Collections.Generic;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Political
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public StateEnum State { get; private set; }
        public string Image { get; private set; }
        public virtual ICollection<PoliticalParty> PoliticalPartys { get; private set; }
        public virtual ICollection<Rating> Ratings { get; private set; }
        public virtual ICollection<LawSuit> LawSuits { get; private set; }
        public virtual ICollection<Voting> Votings { get; private set; }
        public virtual ICollection<Position> Positions { get; private set; }

        public Political(int id, string name, StateEnum state, string image)
        {
            Id = id;
            Name = name;
            State = state;
            Image = image;
        }

        // Empty constructor for EF
        protected Political()
        {

        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetState(StateEnum state)
        {
            State = state;
        }

        public void SetImage(string image)
        {
            Image = image;
        }        

    }
}
