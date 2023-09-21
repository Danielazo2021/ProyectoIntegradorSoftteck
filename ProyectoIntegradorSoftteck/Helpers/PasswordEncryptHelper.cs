using System.Security.Cryptography;
using System.Text;

namespace ProyectoIntegradorSoftteck.Helpers
{
    /// <summary>
    /// Clase de utilidad para el cifrado de contraseñas.
    /// </summary>
    public class PasswordEncryptHelper
    {
        /// <summary>
        /// Método que cifra una contraseña utilizando una técnica de salting.
        /// </summary>
        /// <param name="password">La contraseña a cifrar.</param>
        /// <param name="nombre">Un valor único relacionado con el usuario (por ejemplo, su nombre).</param>
        /// <returns>La contraseña cifrada como una cadena hexadecimal.</returns>        
        public static string EncryptPassword(string password, string email)
        {
            var salt = CreateSalt(email);
            string saltAndPwd = String.Concat(password, salt);
            var sha256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            var stream = Array.Empty<byte>();
            var sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(saltAndPwd));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Método privado para generar un salt único basado en el nombre del usuario.
        /// </summary>
        /// <param name="nombre">Un valor único relacionado con el usuario (por ejemplo, su nombre).</param>
        /// <returns>Una cadena que representa el salt generado.</returns>
        private static string CreateSalt(string email)
        {
            var salt = email;
            byte[] saltBytes;
            string saltStr;
            saltBytes = ASCIIEncoding.ASCII.GetBytes(salt);
            long XORED = 0x00;

            foreach (int x in saltBytes)
            {
                XORED = XORED ^ x;
            }

            Random rand = new Random(Convert.ToInt32(XORED));
            saltStr = rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();
            saltStr += rand.Next().ToString();
            return saltStr;
        }
    }
}
