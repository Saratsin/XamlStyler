using System;

namespace Xavalon.XamlStyler.XamarinStudio.Extensions
{
	public static class StringExtensions
	{
		public static bool EndsWithAny(this string input, string[] endsWith, StringComparison stringComparison)
		{
			foreach (var item in endsWith)
			{
				if (input.EndsWith(item, stringComparison))
				{
					return true;
				}
			}

			return false;
		}
	}
}
