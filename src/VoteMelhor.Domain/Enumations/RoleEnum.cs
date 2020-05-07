using System.Runtime.Serialization;

namespace VoteMelhor.Domain.Enumations
{
    public enum RoleEnum
    {
        [EnumMember(Value = "Administrador")]
        ADM = 1,
        [EnumMember(Value = "Editor")]
        EDT = 2,
        [EnumMember(Value = "Usuário")]
        USR = 9
    }
}
