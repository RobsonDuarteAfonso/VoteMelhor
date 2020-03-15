﻿using System;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Classificacao : Entity
    {
        public Rate Rate { get; private set; }

        public int UsuarioId { get; private set; }

        public int PoliticoId { get; private set; }

        public virtual Usuario Usuario { get; private set; }

        public virtual Politico Politico { get; private set; }

        public Classificacao(Guid id, Rate rate, int usuarioid, int politicoid)
        {
            Id = id;
            Rate = rate;
            UsuarioId = usuarioid;
            PoliticoId = politicoid;
        }

        // Empty constructor for EF
        public Classificacao()
        {

        }
    }
}