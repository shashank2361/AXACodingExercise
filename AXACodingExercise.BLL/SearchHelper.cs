 
namespace AXACodingExercise.BLL
{
    public static class SearchHelper
    {

        public static List<string> FindPartialMatchingStrings(IEnumerable<string> strings, string searchString)
        {
            List<string> matchingStrings = new List<string>();

            foreach (string str in strings)
            {
                if (KMPMatch(str, searchString))
                {
                    matchingStrings.Add(str);
                }
            }

            return matchingStrings;
        }

        static bool KMPMatch(string text, string pattern)
        {
            int[] prefixTable = BuildPrefixTable(pattern);

            int textIndex = 0;
            int patternIndex = 0;

            while (textIndex < text.Length)
            {
                if (pattern[patternIndex] == text[textIndex])
                {
                    patternIndex++;
                    textIndex++;

                    if (patternIndex == pattern.Length)
                    {
                        return true; // Match found
                    }
                }
                else if (patternIndex > 0)
                {
                    patternIndex = prefixTable[patternIndex - 1];
                }
                else
                {
                    textIndex++;
                }
            }

            return false; // No match found
        }

        static int[] BuildPrefixTable(string pattern)
        {
            int[] prefixTable = new int[pattern.Length];
            int length = 0;
            int i = 1;

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    prefixTable[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = prefixTable[length - 1];
                    }
                    else
                    {
                        prefixTable[i] = length;
                        i++;
                    }
                }
            }
            return prefixTable;
        }
    }
}
