using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace WordGame
{
    public class Word
    {
        public string FindWord(string input, string dictionary)
        {

            var letters = input.Select(c => new Letter
            {
                Character = c,
                Found = false
            }).ToList();


            foreach (var character in dictionary)
            {
                var matched = letters.FirstOrDefault(l => l.Character == character && l.Found == false);
                if (matched != null)
                {
                    matched.Found = true;
                }
            }

            var countOfMatched = letters.Count(l => l.Found);
            if (countOfMatched == dictionary.Length)
            {
                return dictionary;
            }

            return string.Empty;
        }

        public string FindWord(string input, string[] dictionary)
        {
            var result = string.Empty;
            foreach (var searchWord in dictionary)
            {
                var foundWord = FindWord(input, searchWord);
                if (result.Length < foundWord.Length)
                {
                    result = foundWord;
                }
            }

            return result;
        }
    }


    public class Letter
    {
        public char Character { get; set; }
        public bool Found { get; set; }
    }
}
