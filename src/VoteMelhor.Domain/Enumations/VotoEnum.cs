using System.ComponentModel;

namespace VoteMelhor.Domain.Enumations
{
    public enum VotoEnum
    {
        [Description("Sim")]
        SIM,
        [Description("Não")]
        NAO,
        [Description("Abstenção")]
        ABS,
        [Description("Não Registrou Voto")]
        NRV,
        [Description("Ausente")]
        AUS,
        [Description("Licença Saúde")]
        LCS,
        [Description("Licença Maternidade")]
        LCM,
        [Description("Licença Adotante")]
        LCA,
        [Description("Licença Paternidade")]
        LCP,
        [Description("Presidente")]
        PRE,
    }
}
