using System.Security.Cryptography;
using System.Text;

namespace VoteMelhor.Domain.ValueObjects
{
    public class Senha : ValueObject
    {
        public string Codigo { get; private set; }

        public Senha(string strValue)
        {
            Codigo = GerarSha256Hash(strValue);
        }

        private static string GerarSha256Hash(string strValue)  
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(strValue));  
  
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString();  
            }  
        }

        public bool isEqual(string value)
        {
            var senhaEncrypt = GerarSha256Hash(value);

            if(Codigo == senhaEncrypt)
            {
                return true;
            }

            return false;

        }
    }
}