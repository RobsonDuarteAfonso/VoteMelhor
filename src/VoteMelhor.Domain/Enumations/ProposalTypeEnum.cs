using System.ComponentModel;

namespace VoteMelhor.Domain.Enumations
{
    public enum ProposalTypeEnum
    {
        [Description("PROPOSTA DE EMENDA À CONSTITUIÇÃO")]
        PEC,
        [Description("PROJETO DE LEI")]
        PJL,
        [Description("PROJETO DE LEI DA CÂMARA")]
        PLC,
        [Description("PROJETO DE LEI DO SENADO")]
        PLS,
        [Description("MEDIDA PROVISÓRIA")]
        MPV,
        [Description("DECRETO")]
        DCT,
        [Description("DECRETO LEGISLATIVO")]
        DLG,
        [Description("DECRETO LEI")]
        DCL,
        [Description("RESOLUÇÃO DO SENADO")]
        RSS,
        [Description("RESOLUÇÃO DA CÂMARA")]
        RSC,
        [Description("REQUERIMENTO")]
        REQ,
        [Description("LEI COMPLEMENTAR")]
        LCP,
        [Description("LEI ORDINÁRIA")]
        LOD,        
        [Description("VET - VETO")]
        VET
   }
}
