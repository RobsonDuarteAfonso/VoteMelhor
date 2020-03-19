using System.ComponentModel;

namespace VoteMelhor.ApplicationCore.Enumations
{
    public enum Rate
    {
        [Description("Excelente")]
        EXC,
        [Description("Bom")]
        BOM,
        [Description("Indiferente")]
        IND,
        [Description("Ruim")]
        RUI,
        [Description("Péssimo")]
        PSM
    }
}
