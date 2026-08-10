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

string? inputs;
int integer;
Console.WriteLine("Enter an integer:");
while ((inputs = Console.ReadLine()) != null)
{
    if (int.TryParse(inputs, out integer))
    {
        var results = new List<string>();

        for (int i = 1; i <= integer; i++)
        {
            string output = "";

            if (i % 3 == 0)
                output += "foo";
            if (i % 5 == 0)
                output += "bar";
            if (i % 7 == 0)
                output += "jazz";

            if (string.IsNullOrEmpty(output))
            {
                output = i.ToString();
            }

            results.Add(output);
        }
        Console.WriteLine(string.Join(", ", results));
    }
    else
    {
        Console.WriteLine("INTEGER ONLY!");
    }
}