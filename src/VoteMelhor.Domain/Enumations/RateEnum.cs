using System.ComponentModel;

namespace VoteMelhor.Domain.Enumations
{
    public enum RateEnum
    {
        [Description("Excelente")]
        EXC,
        [Description("Bom")]
        BOM,
        [Description("Regular")]
        REG,
        [Description("Ruim")]
        RUI,
        [Description("Péssimo")]
        PES
    }
}
