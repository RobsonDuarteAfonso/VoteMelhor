using System.Linq;
using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;

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

        public void SetAtual(int politicoId, int valor)
        {
            var cargos = DbSet.Where(c => c.PoliticoId == politicoId);

            foreach (var item in cargos)
            {
                var cargo = new Cargo(item.Id, item.Nome, valor, item.PoliticoId);
                Db.Update(cargo);
                Db.SaveChanges();
            }
        }
    }
}
