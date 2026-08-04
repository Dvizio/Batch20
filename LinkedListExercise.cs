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
        LinkedList<string> linkedList = new LinkedList<string>();
        string inputs;
        Console.WriteLine("Enter commands Append(item) or Print(), separated by ';' or ',' (Ctrl+C to exit):");
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

    public static void LinkedListManager(LinkedList<string> linkedList, string input)
    {
        if (input.Contains("Append("))
        {
            string item = input.Substring(input.IndexOf('(') + 1, input.IndexOf(')') - input.IndexOf('(') - 1);
            linkedList.AddLast(item);
            Console.WriteLine($"Appended {item}");
        } else if (input.Contains("Print"))
        {
            if (linkedList.Count > 0)
            {
                
                Console.Write($"Sequence {linkedList.First.Value}");
                LinkedListNode<string> currentNode = linkedList.First;
                currentNode =currentNode.Next;
                while (currentNode != null)
                {
                    Console.Write($" -> {currentNode.Value}");
                    currentNode = currentNode.Next;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Linked list is empty");
            }
        }
    }
}