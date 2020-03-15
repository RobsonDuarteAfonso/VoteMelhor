using System;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Processo : Entity
    {
        public string Resumo { get; private set; }

        public string Detalhe { get; private set; }

        public DateTime DtPublicacao { get; private set; }

        public DateTime DtAtualizacao { get; private set; }

        public Situacao Situacao { get; private set; }

        public int PoliticoId { get; private set; }

        public virtual Politico Politico { get; private set; }

        public Processo(Guid id, string resumo, string detalhe, DateTime dtpublicacao, Situacao situacao, int politicoid)
        {
            Id = id;
            Resumo = resumo;
            Detalhe = detalhe;
            DtPublicacao = dtpublicacao;
            Situacao = situacao;
            PoliticoId = politicoid;
        }

        // Empty constructor for EF
        public Processo()
        {

        }
    }
}
