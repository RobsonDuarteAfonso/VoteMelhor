using System.Security.Cryptography;
using System.Text;

namespace VoteMelhor.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public string Code { get; private set; }

        public Password(string value)
        {
            Code = CreateSha256Hash(value);
        }

        private static string CreateSha256Hash(string value)  
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));  
  
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
            var passwordEncrypt = CreateSha256Hash(value);

            if(Code == passwordEncrypt)
            {
                return true;
            }

            return false;

        }

        public void SetPasswordNull()
        {
            Code = null;
        }
    }
}