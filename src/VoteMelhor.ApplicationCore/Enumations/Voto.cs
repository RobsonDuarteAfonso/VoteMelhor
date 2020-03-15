using System.ComponentModel;

namespace VoteMelhor.ApplicationCore.Enumations
{
    public enum Voto
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
        [Description("Licença Adodante")]
        LCA,
        [Description("Licença Paternidade")]
        LCP,
        [Description("Presidente")]
        PRE,
    }
}
