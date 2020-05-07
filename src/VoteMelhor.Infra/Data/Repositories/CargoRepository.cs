using System;
using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public Cargo VerifyExist(Cargo cargo)
        {
            return DbSet.FirstOrDefault(x => x.PoliticoId == cargo.PoliticoId && x.Nome == cargo.Nome);
        }

        public void UpdateAtual(Guid id, int politicoId)
        {
            using var transaction = Db.Database.BeginTransaction();            
            try
            {
                var cargos = DbSet.Where(c => c.PoliticoId == politicoId);

                foreach (var item in cargos)
                {
                    if(item.Id == id)
                    {
                        item.MarqueAtual();
                    }
                    else
                    {
                        item.DesmarqueAtual();
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
