using System.ComponentModel;

namespace VoteMelhor.Domain.Enumations
{
    public enum UserStatusEnum
    {
        [Description("Cadastrado")]
        CAD,
        [Description("Confirmado")]
        CFM,
        [Description("Bloqueado")]
        BLC
    }
}