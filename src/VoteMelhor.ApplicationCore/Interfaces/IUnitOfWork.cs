using System;

namespace VoteMelhor.ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
