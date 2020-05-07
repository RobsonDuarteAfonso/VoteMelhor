using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Processo : Entity
    {
        public string Resumo { get; private set; }
        public string Detalhe { get; private set; }
        public DateTime DtPublicacao { get; private set; }
        public DateTime DtAtualizacao { get; private set; }
        public SituacaoEnum Situacao { get; private set; }
        public int PoliticoId { get; private set; }
        public virtual Politico Politico { get; private set; }

        public Processo(string resumo, string detalhe, SituacaoEnum situacao, int politicoid)
        {
            Resumo = resumo;
            Detalhe = detalhe;
            Situacao = situacao;
            PoliticoId = politicoid;
        }

        // Empty constructor for EF
        protected Processo()
        {

        }

        public void SetResumo(string resumo)
        {
            Resumo = resumo;
        }
        public void SetDetalhe(string detalhe)
        {
            Detalhe = detalhe;
        }
        public void AlteraSituacao(SituacaoEnum situacao) 
        {
            Situacao = situacao;
            DtAtualizacao = DateTime.Now;
        }
        public void SetDataPublicacao()
        {
            DtPublicacao = DateTime.Now;
        }
    }
}
