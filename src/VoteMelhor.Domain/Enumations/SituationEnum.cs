using System.ComponentModel;

namespace VoteMelhor.Domain.Enumations
{
    public enum SituationEnum
    {
        [Description("Arquivado")]
        ARQ,
        [Description("Inocentado")]
        INC,
        [Description("Condenado 1a Instância")]
        CD1,
        [Description("Condenado 2a Instância")]
        CD2,
        [Description("Condenado 3a Instância")]
        CD3,
        [Description("Condenado Última Instância")]
        CD4,
        [Description("Prescrito")]
        PRC,
        [Description("Denúnciado")]
        DEN
    }
}
