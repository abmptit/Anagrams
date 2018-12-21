using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagrams
{
    public static class AnagramsComputer
    {
        public static List<string> GenerateAnagrams2(this List<string> wordList)
        {
            var dicAnagrams = new Dictionary<string, List<string>>();
            var sortedwordList = wordList.OrderBy(w => w).ToList();
            dicAnagrams.Add(sortedwordList.First(), new List<string>() { sortedwordList.First() });
            HashSet<string> lstanagrams =new HashSet<string>();
            lstanagrams.Add(sortedwordList.First());
            for (int i = 1; i < sortedwordList.Count; i++)
            {
                var word = sortedwordList[i];
                bool hasAnagram = false;
                foreach (var cle in lstanagrams)
                {
                    if (IsAnagram(word, cle))
                    {
                        dicAnagrams[cle].Add(word);
                        hasAnagram = true;
                        break;
                    }
                }
                //foreach (var cle in dicAnagrams.Keys)
                //{
                //    if (IsAnagram(word, cle))
                //    {
                //        dicAnagrams[cle].Add(word);
                //        hasAnagram = true;
                //        break;
                //    }
                //}
                if (!hasAnagram)
                {
                    dicAnagrams.Add(word, new List<string>() { word });
                    lstanagrams.Add(word);
                }
            }
            
            return dicAnagrams.DictionaryToString();
        }


        public static List<string> GenerateAnagrams(this List<string> wordList)
        {
            HashSet<string> lstanagrams = new HashSet<string>();
            var dicAnagrams = new Dictionary<string, List<string>>();
            var sortedwordList = wordList.OrderBy(w => w).ToList();
            var firstword = sortedwordList[0];
            var orderedFirstword = String.Concat(firstword.OrderBy(c => c));
            lstanagrams.Add(orderedFirstword);

            dicAnagrams.Add(orderedFirstword, new List<string>() { firstword });
            for (int i = 1; i < sortedwordList.Count; i++)
            {
                var word = sortedwordList[i];
                var sortedword = String.Concat(word.OrderBy(c => c));
                if (lstanagrams.Contains(sortedword))
                    dicAnagrams[sortedword].Add(word);
                else
                {
                    dicAnagrams.Add(sortedword, new List<string>() { word });
                    lstanagrams.Add(sortedword);
                }
            }

            return dicAnagrams.DictionaryToString();
        }

        private static List<string> DictionaryToString(this Dictionary<string, List<string>> dico)
        {
            List<string> listAnagram = new List<string>();
            foreach (var key in dico.Keys)
            {
                listAnagram.Add(string.Join(" ", dico[key]));
            }

            return listAnagram;
        }

        public static bool IsAnagram(string word, string wordTwo)
        {
            if (word.Length != wordTwo.Length) return false;
            var firstcharacter = word[0];
            var indexSameCaracter = wordTwo.IndexOf(firstcharacter);
            if (indexSameCaracter >= 0)
            {
                var newWordTwo = wordTwo.Remove(indexSameCaracter, 1);
                var newFirstword = word.Remove(0, 1);
                if (newFirstword.Length == 0 && newWordTwo.Length == 0) return true;
                return IsAnagram(newFirstword, newWordTwo);
            }

            return false;
        }
    }
}
