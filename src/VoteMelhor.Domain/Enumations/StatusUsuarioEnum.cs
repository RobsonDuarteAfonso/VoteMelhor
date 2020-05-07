using System.ComponentModel;

namespace VoteMelhor.Domain.Enumations
{
    public enum StatusUsuarioEnum
    {
        [Description("Cadastrado")]
        CAD,
        [Description("Confirmado")]
        CFM,
        [Description("Bloqueado")]
        BLC
    }
}