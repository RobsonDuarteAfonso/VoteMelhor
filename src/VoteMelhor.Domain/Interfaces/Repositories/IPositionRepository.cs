using System;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
        Position VerifyExist(Position position);
        void UpdateCurrent(Guid id ,int politicalId);
    }
}
