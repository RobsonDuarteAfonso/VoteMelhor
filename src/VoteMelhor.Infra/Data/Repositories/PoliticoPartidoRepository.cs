using System;
using System.Linq;
using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PoliticoPartidoRepository : Repository<PoliticoPartido>, IPoliticoPartidoRepository
    {
        public PoliticoPartidoRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public PoliticoPartido VerifyExist(int politicoId, Guid partidoId)
        {
            return DbSet.FirstOrDefault(c => c.PoliticoId == politicoId && c.PartidoId == partidoId);
        }

        public void SetAtual(int politicoId, int valor)
        {
            var politicos = DbSet.Where(c => c.PoliticoId == politicoId);

            foreach(var item in politicos)
            {
                var politicoPartido = new PoliticoPartido(item.Id, valor, item.PoliticoId, item.PartidoId);
                Db.Update(politicoPartido);
                Db.SaveChanges();
            }
        }
    }
}
