//6.1
//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.Write("текст");
//        string text = Console.ReadLine() ?? "";

//        string vowels = "аеёиоуыэюяАЕЁИОУЫЭЮЯaeiouyAEIOUY";
//        int vowelCount = 0;
//        int consonantCount = 0;

//        foreach (char ch in text)
//        {
//            if (!char.IsLetter(ch)) continue;

//            if (vowels.Contains(ch))
//                vowelCount++;
//            else
//                consonantCount++;
//        }

//        Console.WriteLine($"Гл: {vowelCount}");
//        Console.WriteLine($"Согл: {consonantCount}");
//    }
//}
//6.2
//using System;
//class Program
//{
//    static void Main()
//    {
//        int[,] a = new int[2, 2];
//        int[,] b = new int[2, 2];
//        int[,] c = new int[2, 2];

//        Console.WriteLine("1 матрица:");
//        for (int i = 0; i < 2; i++)
//        {
//            for (int j = 0; j < 2; j++)
//            {
//                Console.Write($"Строка {i + 1}, столбец {j + 1}: ");
//                a[i, j] = int.Parse(Console.ReadLine());
//            }
//        }

//        Console.WriteLine("2 матрица:");
//        for (int i = 0; i < 2; i++)
//        {
//            for (int j = 0; j < 2; j++)
//            {
//                Console.Write($"Строка {i + 1}, столбец {j + 1}: ");
//                b[i, j] = int.Parse(Console.ReadLine());
//            }
//        }

//        Console.WriteLine("Рез:");
//        for (int i = 0; i < 2; i++)
//        {
//            for (int j = 0; j < 2; j++)
//            {
//                for (int k = 0; k < 2; k++)
//                    c[i, j] += a[i, k] * b[k, j];

//                Console.Write(c[i, j] + "\t");
//            }

//            Console.WriteLine();
//        }
//    }
//}
//6.3
//using System;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        var rnd = new Random();
//        int[,] t = new int[12, 30];

//        for (int i = 0; i < 12; i++)
//            for (int j = 0; j < 30; j++)
//                t[i, j] = rnd.Next(-20, 36);

//        double[] avg = Average(t);
//        for (int i = 0; i < 12; i++)
//            Console.WriteLine($"Месяц {i + 1}: {avg[i]:F1}");

//        Array.Sort(avg);
//        Console.WriteLine("\nПо возрастанию: " + string.Join(", ", avg.Select(x => x.ToString("F1"))));
//    }

//    static double[] Average(int[,] t) =>
//        Enumerable.Range(0, 12)
//                  .Select(i => Enumerable.Range(0, 30).Average(j => t[i, j]))
//                  .ToArray();
//}
//}
//6.1 с помощью List
//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("текст");

//        List<char> chars = new List<char>();
//        string line;

//        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
//            chars.AddRange(line + "\n");

//        var (vowels, consonants) = Count(chars);
//        Console.WriteLine($"Гл: {vowels}, согл: {consonants}");
//    }

//    static (int vowels, int consonants) Count(List<char> chars)
//    {
//        string vowels = "аеёиоуыэюяaeiouy";
//        int v = 0, c = 0;

//        foreach (char ch in chars)
//        {
//            char lower = char.ToLower(ch);

//            if (vowels.IndexOf(lower) >= 0)
//                v++;
//            else if (char.IsLetter(ch))
//                c++;
//        }

//        return (v, c);
//    }
//}
//6.2 с линкед
//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        var a = Make(new[] { new[] { 1, 2 }, new[] { 3, 4 } });
//        var b = Make(new[] { new[] { 5, 6 }, new[] { 7, 8 } });

//        var c = Multiply(a, b);
//        Print(c);
//    }

//    static LinkedList<LinkedList<int>> Make(int[][] rows)
//    {
//        var result = new LinkedList<LinkedList<int>>();

//        foreach (var row in rows)
//            result.AddLast(new LinkedList<int>(row));

//        return result;
//    }

//    static int Get(LinkedList<LinkedList<int>> m, int i, int j)
//    {
//        return m.ElementAt(i).ElementAt(j);
//    }

//    static int Rows(LinkedList<LinkedList<int>> m) => m.Count;

//    static int Cols(LinkedList<LinkedList<int>> m) => m.First.Value.Count;

//    static LinkedList<LinkedList<int>> Multiply(
//        LinkedList<LinkedList<int>> a,
//        LinkedList<LinkedList<int>> b)
//    {
//        if (Cols(a) != Rows(b))
//            throw new Exception("размер не подх");

//        var c = new LinkedList<LinkedList<int>>();

//        for (int i = 0; i < Rows(a); i++)
//        {
//            var row = new LinkedList<int>();

//            for (int j = 0; j < Cols(b); j++)
//            {
//                int sum = 0;

//                for (int k = 0; k < Cols(a); k++)
//                    sum += Get(a, i, k) * Get(b, k, j);

//                row.AddLast(sum);
//            }

//            c.AddLast(row);
//        }

//        return c;
//    }
//    static void Print(LinkedList<LinkedList<int>> m)
//    {
//        foreach (var row in m)
//        {
//            foreach (var x in row)
//                Console.Write(x + " ");

//            Console.WriteLine();
//        }
//    }
//}
//6.3 класс дикшенари
//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
//                            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
//        var rnd = new Random();

//        var temps = months.ToDictionary(
//            m => m,
//            m => Enumerable.Range(0, 30).Select(_ => rnd.Next(-20, 36)).ToArray()
//        );

//        foreach (var p in temps.OrderBy(p => p.Value.Average()))
//            Console.WriteLine($"{p.Key}: {p.Value.Average():F1}");
//    }
//}
