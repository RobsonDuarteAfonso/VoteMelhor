using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Queries
{
    public static class PoliticalQueries
    {
        public static Expression<Func<Political, bool>> VerifyExist(int congressmanId, int senatorId )
        {
            return x => (x.CongressmanId == congressmanId && x.CongressmanId != 0) || (x.SenatorId == senatorId && x.SenatorId != 0);
        }

        public static Expression<Func<Political, bool>> VerifyExistFullName(string fullName)
        {
            return x => x.FullName == fullName;
        }

        public static Expression<Func<Political, bool>> SearchPoliticals(string name, string state)
        {

            if ((name != null) && (state != null))
            {
                return x => x.Name.Contains(name.ToUpper()) && x.State == (StateEnum)Enum.Parse(typeof(StateEnum), state.ToUpper());
            }
            else if (name != null)
            {
                return (x => x.Name.Contains(name.ToUpper()));
            }
            else
            {
                return x => x.State == (StateEnum)Enum.Parse(typeof(StateEnum), state.ToUpper());
            }
        }
    }
}