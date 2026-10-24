
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("текст");

        List<char> chars = new List<char>();
        string line;

        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            chars.AddRange(line + "\n");

        var (vowels, consonants) = Count(chars);
        Console.WriteLine($"Гл: {vowels}, согл: {consonants}");
    }

    static (int vowels, int consonants) Count(List<char> chars)
    {
        string vowels = "аеёиоуыэюяaeiouy";
        int v = 0, c = 0;

        foreach (char ch in chars)
        {
            char lower = char.ToLower(ch);

            if (vowels.IndexOf(lower) >= 0)
                v++;
            else if (char.IsLetter(ch))
                c++;
        }

        return (v, c);
    }
}
