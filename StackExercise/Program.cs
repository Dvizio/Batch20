Stack<string> stack = new Stack<string>();
string? inputs;
Console.WriteLine("Enter commands Type(item) or Undo(), separated by ';' or ',' (Ctrl+C to exit):");
while ((inputs = Console.ReadLine()) != null)
{
    if (inputs.Contains(";"))
    {
        String[] inputsArray = inputs.Split(';');
        foreach (string input in inputsArray)
        {
            StackManager(stack, input);
        }
    }
    else
    {
        String[] inputArray = inputs.Split(',');
        foreach (string input in inputArray)
        {
            StackManager(stack, input);
        }
    }
}

static void StackManager(Stack<string> stack, string input)
{
    if (input.Contains("Type("))
    {
        string item = input.Substring(input.IndexOf('(') + 2, input.IndexOf(')') - input.IndexOf('(') - 3);
        stack.Push(item);
        Console.WriteLine($"Typed {item}");
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
