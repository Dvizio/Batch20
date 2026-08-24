/* WEEK 1 */

// int n = int.Parse(Console.ReadLine());
// for (int i = 1; i <= n; i++)
// {
//     if (i % 3 == 0 && i % 5 == 0)
//     {
//         Console.Write("foobar, ");
//     }
//     else if (i % 3 == 0)
//     {
//         Console.Write("foo, ");
//     }
//     else if (i % 5 == 0)
//     {
//         Console.Write("bar, ");
//     }
//     else
//     {
//         Console.Write(i + ", ");
//     }
// }

/* WEEK 2 */

// string? inputs;
// int integer;
// Console.WriteLine("Enter an integer:");
// while ((inputs = Console.ReadLine()) != null)
// {
//     if (int.TryParse(inputs, out integer))
//     {
//         var results = new List<string>();

//         for (int i = 1; i <= integer; i++)
//         {
//             string output = "";

//             if (i % 3 == 0)
//                 output += "foo";
//             if (i % 5 == 0)
//                 output += "bar";
//             if (i % 7 == 0)
//                 output += "jazz";

//             if (string.IsNullOrEmpty(output))
//             {
//                 output = i.ToString();
//             }

//             results.Add(output);
//         }
//         Console.WriteLine(string.Join(", ", results));
//     }
//     else
//     {
//         Console.WriteLine("INTEGER ONLY!");
//     }
// }

/* WEEK 3 */
// string? inputs;
// int integer;
// Console.WriteLine("Enter an integer:");
// while ((inputs = Console.ReadLine()) != null)
// {
//     if (int.TryParse(inputs, out integer))
//     {
//         var results = new List<string>();

//         for (int i = 1; i <= integer; i++)
//         {
//             string output = "";

//             if (i % 3 == 0)
//                 output += "foo";
//             if (i % 4 == 0)
//                 output += "baz";
//             if (i % 5 == 0)
//                 output += "bar";
//             if (i % 7 == 0)
//                 output += "jazz";
//             if (i % 9 == 0)
//                 output += "huzz";

//             if (string.IsNullOrEmpty(output))
//             {
//                 output = i.ToString();
//             }

//             results.Add(output);
//         }
//         Console.WriteLine(string.Join(", ", results));
//     }
//     else
//     {
//         Console.WriteLine("INTEGER ONLY!");
//     }
// }

/* Week 4 */

namespace FoobarExercise;

public class Foobar
{
    private readonly SortedDictionary<int, string> _rules = new SortedDictionary<int, string>();
    public void AddRule(int divisor, string output)
    {
        if (divisor <= 0)
        {
            throw new ArgumentException("Divisor must be greater than zero.", nameof(divisor));
        }

        if (string.IsNullOrEmpty(output))
        {
            throw new ArgumentException("Output string cannot be null or empty.", nameof(output));
        }


        _rules[divisor] = output;
    }
    public string Evaluate(int number)
    {
        string output = string.Empty;

        foreach (var rule in _rules)
        {
            if (number % rule.Key == 0)
            {
                output += rule.Value;
            }
        }

        return string.IsNullOrEmpty(output) ? number.ToString() : output;
    }

    public string GenerateSequence(int start, int end)
    {
        var results = new List<string>();

        for (int i = start; i <= end; i++)
        {
            results.Add(Evaluate(i));
        }

        return string.Join(", ", results);
    }
}