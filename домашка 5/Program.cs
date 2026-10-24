
using System;
class Program
{
    static void Main()
    {
        int[,] a = new int[2, 2];
        int[,] b = new int[2, 2];
        int[,] c = new int[2, 2];

        Console.WriteLine("1 матрица:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write($"Строка {i + 1}, столбец {j + 1}: ");
                a[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("2 матрица:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write($"Строка {i + 1}, столбец {j + 1}: ");
                b[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Рез:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                    c[i, j] += a[i, k] * b[k, j];

                Console.Write(c[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }
}

