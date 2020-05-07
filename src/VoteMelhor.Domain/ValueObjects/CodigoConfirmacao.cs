using System;
using System.Linq;

namespace VoteMelhor.Domain.ValueObjects
{
    public class CodigoConfirmacao : ValueObject
    {
        public DateTime DtExpiraCodigo { get; private set; }
        public string Codigo { get; private set; }

        public CodigoConfirmacao()
        {
            DtExpiraCodigo = DateTime.Now.AddDays(2);
            Codigo = GerarCodigoConfirmacao(70);
        }

        private static string GerarCodigoConfirmacao(int tamanho)
        {
            var chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}