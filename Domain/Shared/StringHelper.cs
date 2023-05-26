using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public static class StringHelper
    {
        private static readonly Dictionary<char, char> specialCharactersToCleanUps = new Dictionary<char, char>()
    {
        { 'á', 'a' },
        { 'é', 'e' },
        { 'í', 'i' },
        { 'ó', 'o' },
        { 'ú', 'u' },
        { 'ñ', 'n' }
    };

        private static readonly HashSet<char> specialCharactersToRemove = new HashSet<char>()
    {
        '\'', '`', '.', ',', '!', '?', ':', ';', '(', ')', '[', ']', '{', '}', '<', '>'
    };

        public static string? CleanForSearch(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            text = text.ToLowerInvariant();
            var sb = new StringBuilder(text.Length);

            foreach (var c in text)
            {
                if (specialCharactersToCleanUps.TryGetValue(c, out var replacement))
                {
                    sb.Append(replacement);
                }
                else if (!specialCharactersToRemove.Contains(c) && !char.IsWhiteSpace(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Trim();
        }

    }
}
