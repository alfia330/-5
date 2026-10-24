
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
                            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        var rnd = new Random();

        var temps = months.ToDictionary(
            m => m,
            m => Enumerable.Range(0, 30).Select(_ => rnd.Next(-20, 36)).ToArray()
        );

        foreach (var p in temps.OrderBy(p => p.Value.Average()))
            Console.WriteLine($"{p.Key}: {p.Value.Average():F1}");
    }
}
