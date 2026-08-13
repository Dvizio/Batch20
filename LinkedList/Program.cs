using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using LinkedListExercise;
public class Program
{
    static void Main(string[] args)
    {
        LinkedListActualList linkedList = new LinkedListActualList();
        string? inputs;
        Console.WriteLine("Enter commands Append(item), Print(), PrintReverse(), or Clear(), separated by ';' or ',' (Ctrl+C to exit):");
        while ((inputs = Console.ReadLine()) != null)
        {
            if (inputs.Contains(";"))
            {
                String[] inputsArray = inputs.Split(';');
                foreach (string input in inputsArray)
                {
                    LinkedListManager(linkedList, input);
                }
            }
            else
            {
                String[] inputArray = inputs.Split(',');
                foreach (string input in inputArray)
                {
                    LinkedListManager(linkedList, input);
                }
            }
        }
    }
    public static void LinkedListManager(LinkedListActualList linkedList, string input)
    {
        if (input.Contains("Append("))
        {
            try
            {
                int item = int.Parse(input.Substring(input.IndexOf('(') + 1, input.IndexOf(')') - input.IndexOf('(') - 1));
                linkedList.Append(item);
                Console.WriteLine($"Appended {item}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid integer.");
            }
        }
        else if (input.Contains("PrintReverse"))
        {
            linkedList.PrintReverse(); return;
        }
        else if (input.Contains("Print"))
        {
            linkedList.Print(); return;
        } else if (input.Contains("Clear"))
        {
            linkedList.Clear();return;
        }
    }
}