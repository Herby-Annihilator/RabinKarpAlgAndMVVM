using System;
using System.Collections.Generic;
using System.Text;

namespace RabinKarpAlgorithm.Models
{
	public static class ModifiedRabinKarpAlgorithm
	{
		public static int[] SearchSubstringOccurrences_Modified(this string text, string substring, ulong countOfRepetitions)
		{
			List<int> substringOccurrences = new List<int>();
			ulong hashText = 0;
			ulong hashSubstring = 0;
			ulong Q = 100007;
			ulong D = 256;

			if (substring.Length > text.Length || (ulong)substring.Length * countOfRepetitions > (ulong)text.Length)
			{
				return substringOccurrences.ToArray();
			}
			for (int j = 0; (ulong)j < countOfRepetitions; j++)
			{
				for (int i = 0; i < substring.Length; i++)
				{
					hashSubstring = (hashSubstring * D + substring[i]) % Q;
				}
			}
			
			for (int i = 0; (ulong)i < (ulong)substring.Length * countOfRepetitions; i++)
			{
				hashText = (hashText * D + text[i]) % Q;
			}

			if (hashText == hashSubstring)
				substringOccurrences.Add(0);

			ulong pow = 1;

			for (int k = 1; (ulong)k <= (ulong)substring.Length * countOfRepetitions - 1; k++)
				pow = (pow * D) % Q;

			for (int j = 1; (ulong)j <= (ulong)text.Length - (ulong)substring.Length * countOfRepetitions; j++)
			{
				hashText = (hashText + Q - pow * text[j - 1] % Q) % Q;
				hashText = (hashText * D + text[j + substring.Length * (int)countOfRepetitions - 1]) % Q;

				if (hashText == hashSubstring)
				{
					bool isAnswer = true;
					int i = 0;
					while (i < (int)countOfRepetitions)
					{
						if (text.Substring(j + i, substring.Length) != substring)
						{
							isAnswer = false;
							break;
						}
						i++;
					}
					if (isAnswer)
					{
						substringOccurrences.Add(j);
					}
				}
					
			}
			return substringOccurrences.ToArray();
		}
	}
}
