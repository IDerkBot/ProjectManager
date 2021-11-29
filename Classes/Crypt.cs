using System.Security.Cryptography;
using System.Text;

namespace ProjectManager.Classes
{
	internal class Crypt
	{
		public static string ToSHA256(string textToCrypt)
		{
			using (var sha256 = SHA256.Create())
			{
				byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(textToCrypt));
				var sb = new StringBuilder();
				foreach (byte b in bytes)
					sb.Append(b.ToString("x2"));
				return sb.ToString();
			}
		}
	}
}
