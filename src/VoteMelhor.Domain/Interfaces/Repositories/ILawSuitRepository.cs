﻿using System;
using System.Collections.Generic;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface ILawSuitRepository : IRepository<LawSuit>
    {
        IEnumerable<LawSuit> GetAllByPoliticalId(Guid id);
    }   
}
