using System;
using System.Collections.Generic;

namespace VoteMelhor.Domain.Entities
{
    public class Party : Entity
    {
        public string Name { get; private set; }
        public string Initials { get; private set; }
        public int Number { get; private set; }
        public string Image { get; private set; }
        public virtual ICollection<PoliticalParty> PoliticalPartys { get; private set; }

        public Party(string name, string initials, int number, string image)
        {
            Name = name;
            Initials = initials;
            Number = number;
            Image = image;
        }

        public Party(string initials)
        {
            Initials = initials;
        }

        // Empty constructor for EF
        protected Party()
        {

        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetInitials(string initials)
        {
            Initials = initials;
        }

        public void SetImage(string image)
        {
            Image = image;
        }

        public void SetNumber(int number)
        {
            Number = number;
        }        
    }
}
