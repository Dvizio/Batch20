using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        Stack<string> stack = new Stack<string>();
        string inputs;
        while ((inputs = Console.ReadLine()) != null)
        {
            if (inputs.Contains(" "))
            {
                String[] inputsArray = inputs.Split(' ');
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
    }

    public static void StackManager(Stack<string> stack, string input)
    {
        if (input.Contains("Type("))
        {
            string item = input.Substring(input.IndexOf('(') + 2, input.IndexOf(')') - input.IndexOf('(') - 3);
            stack.Push(item);
            Console.WriteLine($"Typed {item}");
        } else if (input.Contains("Undo()"))
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
}   