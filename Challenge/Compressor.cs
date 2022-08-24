using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    public class Compressor
    {
		/// <summary>
		///	Compresses an input string consisting of only alphabetic characters by shortening its length. 
		/// </summary>
		/// <param name="alphabeticCharacters">user input</param>
		/// <returns>Compressed string.</returns>
		public (string msg,string result) compressString(string alphabeticCharacters)
		{
			if (string.IsNullOrEmpty(alphabeticCharacters))
			{
				 return ("Error", "Invalid input");
			}

			int count = 0; // Counts the number of consecutive duplicate letters.
			string compressedString = string.Empty;

			for (int i = 1; i < alphabeticCharacters.Length; i++)
			{
				// Get the current and previous char of the string.
				var thisChar = alphabeticCharacters[i];
				var prevChar = alphabeticCharacters[i - 1];

				// Check if both chars are the same. In that case we add "thisChar" to the compressedString and one to the count.
				if (thisChar == prevChar)
				{
					compressedString += thisChar;
					count++;
				}

				// Check if both chars are not the same or if we are in the last loop. In that case we add "prevChar" to the compressedString and reset the count to 0.
				if (thisChar != prevChar || i == alphabeticCharacters.Length - 1)
				{
					compressedString += prevChar;

					// Check if the count is greater than 1. In that case we delete the last characters base on the count value and replaced them with that value in the string
					if (count > 1)
					{
						compressedString = compressedString.Substring(0, compressedString.Length - count);
						compressedString += (count + 1).ToString();

					}
					count = 0;

				}

				// Check if both chars are not the same and we are in the last loop. In that case we add "thisChar" to the compressedString and end the loop.
				if (thisChar != prevChar && i == alphabeticCharacters.Length - 1)
				{
					compressedString += thisChar;
				}
			}

			// Result
			if(alphabeticCharacters == compressedString)
            {
				return ("String is already compressed: ", compressedString);
			}
            else
            {
				return ("String compressed successfully: ", compressedString);
			}
		}
	}
}
