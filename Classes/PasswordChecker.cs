using System;
using System.Linq;

namespace ProjectManager.Classes
{
	internal class PasswordChecker
	{
		public static bool PasswordValidete(string password)
		{
			if (password.Length > 7 && password.Length < 20) return true;
			if (!password.Any(Char.IsLower)) return false;
			if (!password.Any(Char.IsUpper)) return false;
			if (!password.Any(Char.IsDigit)) return false;
			if (password.Intersect("#$%^&_!?").Count() == 0) return false;
			return true;
		}
	}
}