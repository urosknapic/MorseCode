using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MorseCode
{
  public static class MorseCodeDecoder
  {
    public static string Decode(string input)
    {
      if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(input.Trim()))
      {
        return string.Empty;
      }

      Regex r = new Regex("^[-. ]+$");
      var validMorseCode = r.IsMatch(input);

      if (!validMorseCode)
      {
        throw new ArgumentException("Input is not a morse code!");
      }

      return GetMorseCodeTranslation(input);
    }

    public static Dictionary<string, string> MorseCodeToAlphabetTable()
    {
      string dot = ".";
      string dash = "-";
      // International morse code
      return new Dictionary<string, string>() {
        { string.Concat(dot, dash), "A" },
        { string.Concat(dash, dot, dot, dot), "B" },
        { string.Concat(dash, dot, dash, dot), "C" },

        { string.Concat(dash, dot, dot), "D" },
        { dot, "E" },
        { string.Concat(dot, dot, dash, dot), "F" },
        { string.Concat(dash, dash, dot), "G" },
        { string.Concat(dot, dot, dot, dot), "H" },
        { string.Concat(dot, dot), "I" },
        { string.Concat(dot, dash, dash, dash), "J" },
        { "-.-.", "K" },
        { "-.-.", "L" },
        { "-.-.", "M" },
        { "-.-.", "N" },
        { "-.-.", "O" },
        { "-.-.", "P" },
        { "-.-.", "Q" },
        { "-.-.", "R" },
        { "-.-.", "S" },
        { "-.-.", "T" },
        { "-.-.", "U" },
        { "-.-.", "V" },
        { "-.-.", "W" },
        { "-.-.", "X" },
        { "-.-.", "Y" },
        { "-.-.", "Z" },
        { "-.-.", "0" },
        { "-.-.", "1" },
        { "-.-.", "2" },
        { "-.-.", "3" },
        { "-.-.", "4" },
        { "-.-.", "5" },
        { "-.-.", "6" },
        { "-.-.", "7" },
        { "-.-.", "8" },
        { "-.-.", "9" }
      };
    }

    private static string GetMorseCodeTranslation(string morseStringCode)
    {
      string fourSpaces = "    ";
      string singleSpace = " ";
      StringBuilder stringBuilder = new StringBuilder();

      var splitbyWords = morseStringCode.Split(fourSpaces);
      foreach(var word in splitbyWords)
      {
        var splitedByMorseLetters = word.Split(singleSpace);

        foreach (var morseCharacter in splitedByMorseLetters)
        {
          stringBuilder.Append(GetSingleCharacter(morseCharacter));
        }

        stringBuilder.Append(singleSpace);
      }

      return stringBuilder.ToString().Trim();
    }

    private static string GetSingleCharacter(string morseCharacter)
    {
      var morseTable = MorseCodeToAlphabetTable();

      if (morseTable.ContainsKey(morseCharacter))
      {
        return morseTable[morseCharacter];
      }

      return string.Empty;
    }
  }
}
