using System;

public class Program
{
	public static void Main()
	{
		String str = "клавиатура";
		String tiara = str.Substring(6, 1) + str.Substring(4, 2) + str.Substring(8); 
		String hand = str.Substring(8, 1) + str.Substring(7, 1) + str.Substring(0, 1) + str.Substring(2, 1);
		Console.WriteLine("Исходное слово: " + str);
		Console.WriteLine("Получившиеся слова: " + tiara + ", " + hand);
	}
}