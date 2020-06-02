using System;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
        Position VerifyExist(Guid politicalId, string name, string participation);
        void UpdateCurrent(Guid id ,Guid politicalId);
    }
}
