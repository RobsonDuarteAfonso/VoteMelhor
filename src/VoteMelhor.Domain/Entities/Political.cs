using System.Collections.Generic;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Political : Entity
    {
        public int CongressmanId { get; private set; }
        public int SenatorId { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public StateEnum State { get; private set; }
        public string Image { get; private set; }
        public virtual ICollection<PoliticalParty> PoliticalPartys { get; private set; }
        public virtual ICollection<Rating> Ratings { get; private set; }
        public virtual ICollection<LawSuit> LawSuits { get; private set; }
        public virtual ICollection<Voting> Votings { get; private set; }
        public virtual ICollection<Position> Positions { get; private set; }

        public Political(int congressmanId, int senatorId, string name, string fullname, StateEnum state, string image)
        {
            CongressmanId = congressmanId;
            SenatorId = senatorId;
            Name = name;
            FullName = fullname;
            State = state;
            Image = image;
        }

        // Empty constructor for EF
        protected Political()
        {

        }

        public void SetCongresmanId(int congressmanId)
        {
            if (CongressmanId < 1)
            {
                CongressmanId = congressmanId;
            }
        }

        public void SetSenatorId(int senatorId)
        {
            if (SenatorId < 1)
            {
                SenatorId = senatorId;
            }
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetFullName(string fullname)
        {
            if (FullName == null)
            {
                FullName = fullname;
            }
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
