using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseCode
{
  class Program
  {
    static void Main(string[] args)
    {
      // ···· · −·−−   ·−−− ··− −·· ·
      string inputByTwoUnits = "1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011";
      string inputByOneUnit = "1010101001001101011011000000010110110110010101100110101001";
      string inputByNUnit = "110101011";

      var array = inputByTwoUnits.Split("0", StringSplitOptions.RemoveEmptyEntries);
      var dic = array.Distinct().ToDictionary(value => value, value => value.Length);
    }
  }
}
