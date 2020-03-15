using System.ComponentModel;

namespace VoteMelhor.ApplicationCore.Enumations
{
    public enum Situacao
    {
        [Description("Arquivado")]
        AQ,
        [Description("Inocentado")]
        IN,
        [Description("Condenado 1a Instância")]
        C1,
        [Description("Condenado 2a Instância")]
        C2,
        [Description("Condenado 3a Instância")]
        C3,
        [Description("Condenado Última Instância")]
        C4,
        [Description("Prescrito")]
        PR,
        [Description("Denúnciado")]
        DE
    }
}
