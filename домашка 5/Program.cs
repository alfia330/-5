using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var a = Make(new[] { new[] { 1, 2 }, new[] { 3, 4 } });
        var b = Make(new[] { new[] { 5, 6 }, new[] { 7, 8 } });

        var c = Multiply(a, b);
        Print(c);
    }

    static LinkedList<LinkedList<int>> Make(int[][] rows)
    {
        var result = new LinkedList<LinkedList<int>>();

        foreach (var row in rows)
            result.AddLast(new LinkedList<int>(row));

        return result;
    }

    static int Get(LinkedList<LinkedList<int>> m, int i, int j)
    {
        return m.ElementAt(i).ElementAt(j);
    }

    static int Rows(LinkedList<LinkedList<int>> m) => m.Count;

    static int Cols(LinkedList<LinkedList<int>> m) => m.First.Value.Count;

    static LinkedList<LinkedList<int>> Multiply(
        LinkedList<LinkedList<int>> a,
        LinkedList<LinkedList<int>> b)
    {
        if (Cols(a) != Rows(b))
            throw new Exception("разм матр не тот");

        var c = new LinkedList<LinkedList<int>>();

        for (int i = 0; i < Rows(a); i++)
        {
            var row = new LinkedList<int>();

            for (int j = 0; j < Cols(b); j++)
            {
                int sum = 0;

                for (int k = 0; k < Cols(a); k++)
                    sum += Get(a, i, k) * Get(b, k, j);

                row.AddLast(sum);
            }

            c.AddLast(row);
        }

        return c;
    }
    static void Print(LinkedList<LinkedList<int>> m)
    {
        foreach (var row in m)
        {
            foreach (var x in row)
                Console.Write(x + " ");

            Console.WriteLine();
        }
    }
}
