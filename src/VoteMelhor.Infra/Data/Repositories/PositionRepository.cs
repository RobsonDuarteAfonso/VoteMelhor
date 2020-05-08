using System;
using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Queries;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public Position VerifyExist(Position position)
        {
            return DbSet.FirstOrDefault(PositionQueries.VerifyExist(position));
        }

        public void UpdateCurrent(Guid id, int politicalId)
        {
            using var transaction = Db.Database.BeginTransaction();            
            try
            {
                var positions = DbSet.Where(c => c.PoliticalId == politicalId);

                foreach (var item in positions)
                {
                    if(item.Id == id)
                    {
                        item.MarkCurrent();
                    }
                    else
                    {
                        item.UnMarkCurrent();
                    }

                    Db.Update(item);
                    Db.SaveChanges();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }
    }
}
