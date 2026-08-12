/* WEEK 1 */
// Stack<string> stack = new Stack<string>();
// string? inputs;
// Console.WriteLine("Enter commands Type(item) or Undo(), separated by ';' or ',' (Ctrl+C to exit):");
// while ((inputs = Console.ReadLine()) != null)
// {
//     if (inputs.Contains(";"))
//     {
//         String[] inputsArray = inputs.Split(';');
//         foreach (string input in inputsArray)
//         {
//             StackManager(stack, input);
//         }
//     }
//     else
//     {
//         String[] inputArray = inputs.Split(',');
//         foreach (string input in inputArray)
//         {
//             StackManager(stack, input);
//         }
//     }
// }

// static void StackManager(Stack<string> stack, string input)
// {
//     if (input.Contains("Type("))
//     {
//         string item = input.Substring(input.IndexOf('(') + 2, input.IndexOf(')') - input.IndexOf('(') - 3);
//         stack.Push(item);
//         Console.WriteLine($"Typed {item}");
//     }
//     else if (input.Contains("Undo()"))
//     {
//         if (stack.Count > 0)
//         {
//             Console.WriteLine($"Undid {stack.Pop()}");
//         }
//         else
//         {
//             Console.WriteLine("Stack is empty");
//         }
//     }
// }

/* WEEK 2*/

Stack<string> stack = new Stack<string>(3);
string? inputs;
Console.WriteLine("Enter commands Type(item) or Undo(), separated by ';' or ',' (Ctrl+C to exit):");
while ((inputs = Console.ReadLine()) != null)
{
    if (inputs.Contains(";"))
    {
        String[] inputsArray = inputs.Split(';');
        foreach (string input in inputsArray)
        {
            StackManager(ref stack, input);
        }
    }
    else
    {
        String[] inputArray = inputs.Split(',');
        foreach (string input in inputArray)
        {
            StackManager(ref stack, input);
        }
    }
}

static void StackManager(ref Stack<string> stack, string input)
{
    if (input.Contains("Type("))
    {
        string item = input.Substring(input.IndexOf('(') + 2, input.IndexOf(')') - input.IndexOf('(') - 3);
        if (stack.Count < 3)
        {
            stack.Push(item);
            Console.WriteLine($"Typed {item}");
        }
        else
        {
            Stack<string> newStack = new Stack<string>(3);
            for (int i = 1; i >= 0; i--)
            {
                newStack.Push(stack.ElementAt(i));
            }
            newStack.Push(item);
            Console.WriteLine($"Dropped bottom, Typed {item}");
            stack.Clear();
            stack = newStack;
        }

    }
    else if (input.Contains("Undo()"))
    {
        if (stack.Count > 0)
        {
            Console.WriteLine($"Undid {stack.Pop()}");
        }
        else
        {
            Console.WriteLine("Stack is empty");
        }
    }
}
