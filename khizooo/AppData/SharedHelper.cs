using System;
namespace khizooo.AppData
{
	public class SharedHelper
	{

        private static readonly string[] NumberWords = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
        private Random random = new Random();

        public string GetRandomNumberWord()
        {
            int index = random.Next(0, NumberWords.Length);
            return NumberWords[index];
        }

	}
}
