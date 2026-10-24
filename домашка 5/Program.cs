
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var rnd = new Random();
        int[,] t = new int[12, 30];

        for (int i = 0; i < 12; i++)
            for (int j = 0; j < 30; j++)
                t[i, j] = rnd.Next(-20, 36);

        double[] avg = Average(t);
        for (int i = 0; i < 12; i++)
            Console.WriteLine($"Месяц {i + 1}: {avg[i]:F1}");

        Array.Sort(avg);
        Console.WriteLine("\nПо возрастанию: " + string.Join(", ", avg.Select(x => x.ToString("F1"))));
    }

    static double[] Average(int[,] t) =>
        Enumerable.Range(0, 12)
                  .Select(i => Enumerable.Range(0, 30).Average(j => t[i, j]))
                  .ToArray();
}


