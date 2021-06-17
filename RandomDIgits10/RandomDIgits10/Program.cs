using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RandomDIgits10
{
    internal static class Program
    {
        private static void Main()
        {
            using var streamReader = new StreamReader("random_integers.txt");
            using var streamWriter = new StreamWriter("result.txt");

            Console.WriteLine("Обрабатываю данные");

            var longestDigitsSequence = new List<int>();

            var sequencesCount = 0;
            var printedLinesCount = 0;
            var signNumbers = new List<int>();

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                
                if (line == null)
                    break;

                var digits = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse);
                
                foreach (var currDigit in digits)
                {
                    if (signNumbers.Count == 0)
                    {
                        signNumbers.Add(currDigit);
                        continue;
                    }
                    
                    var lastDigit = signNumbers.LastOrDefault();
                    
                    var signCurr = Math.Sign(currDigit);
                    var signPrev = Math.Sign(lastDigit);
                    
                    if (signCurr == signPrev)
                    {
                        signNumbers.Add(currDigit);
                        continue;
                    }
                    
                    if (signNumbers.Count <= 0) 
                        continue;

                    sequencesCount++;
                    
                    if (signNumbers.Count > longestDigitsSequence.Count) 
                        longestDigitsSequence = signNumbers.ToList();

                    streamWriter.WriteLine(GetDigitsOutput(signNumbers));

                    signNumbers.Clear();
                    signNumbers.Add(currDigit);
                    
                    if (printedLinesCount == 5 - 1) 
                        Console.Write('.');
                    printedLinesCount = (printedLinesCount + 1) % 5;
                }
            }
            
            if (signNumbers.Count > 0)
            {
                sequencesCount++;
                
                if (signNumbers.Count > longestDigitsSequence.Count) 
                    longestDigitsSequence = signNumbers.ToList();
                
                streamWriter.WriteLine(GetDigitsOutput(signNumbers));
                
                if (printedLinesCount == 5 - 1) 
                    Console.Write('.');
            }

            Console.WriteLine();
            Console.WriteLine("Обработка данных завершена");
            Console.WriteLine($"Обнаружено последовательностей чисел одного знака: {sequencesCount}");
            Console.WriteLine("Самая длинная последовательность:");
            Console.WriteLine(GetDigitsOutput(longestDigitsSequence));
        }

        private static string GetDigitsOutput(List<int> numbers)
        {
            if (numbers.Count == 0)
                return "Ошибка";
            
            var signPrev = Math.Sign(numbers.LastOrDefault());
                    
            var numbersRepr = string.Join(' ', numbers);
            var signRepr = signPrev == 0 
                ? "" 
                : signPrev > 0 
                    ? "+" 
                    : "-";

            return $"{numbers.Count}{signRepr}: {numbersRepr}";
        }
    }
}