using System;
using System.Text.RegularExpressions;
using Challenge;

public class Program
{
	public static void Main()
	{
        Compressor compressor = new Compressor();
		var alphabeticCharacters = Console.ReadLine();
		var result = compressor.compressString(alphabeticCharacters);
		Console.WriteLine(result.msg + "" + result.result);
	}

	
}