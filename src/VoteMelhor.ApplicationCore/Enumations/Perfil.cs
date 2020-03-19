using System.Runtime.Serialization;

namespace VoteMelhor.ApplicationCore.Enumations
{
    public enum Perfil
    {
        [EnumMember(Value = "Administrador")]
        ADM = 1,
        [EnumMember(Value = "Editor")]
        EDT = 2,
        [EnumMember(Value = "Usuário")]
        USR = 9
    }
}
