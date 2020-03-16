using VoteMelhor.ApplicationCore.Interfaces;

namespace VoteMelhor.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VoteMelhorContext _context;

        public UnitOfWork(VoteMelhorContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
