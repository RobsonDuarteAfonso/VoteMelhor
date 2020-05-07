using System;
using System.Linq;

namespace VoteMelhor.Domain.ValueObjects
{
    public class ConfirmationCode : ValueObject
    {
        public DateTime CodeExpirationDate { get; private set; }
        public string Code { get; private set; }

        public ConfirmationCode()
        {
            CodeExpirationDate = DateTime.Now.AddDays(2);
            Code = CreateConfirmationCode(70);
        }

        private static string CreateConfirmationCode(int length)
        {
            var chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}