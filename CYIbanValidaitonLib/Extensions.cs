namespace CYIbanValidaitonLib
{
    static class Extensions
    {
		public static string SafeSubstring(this string s, int startIndex, int length)
		{
			if (s == null)
				return null;

			if (startIndex > s.Length)
				return string.Empty;

			if (startIndex + length > s.Length)
				return s.Substring(startIndex, s.Length - startIndex);
			else
				return s.Substring(startIndex, length);
		}
	}
}
