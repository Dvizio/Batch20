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
        Queue<string> queue = new Queue<string>();
        string inputs;
        while ((inputs = Console.ReadLine()) != null)
        {
            if (inputs.Contains(" "))
            {
                String[] inputsArray = inputs.Split(' ');
                foreach (string input in inputsArray)
                {
                    QueueManager(queue, input);
                }
            }
            else
            {
                String[] inputArray = inputs.Split(',');
                foreach (string input in inputArray)
                {
                    QueueManager(queue, input);
                }
            }
        } 
    }

    public static void QueueManager(Queue<string> queue, string input)
    {
        if (input.Contains("Enqueue("))
        {
            string item = input.Substring(input.IndexOf('(') + 1, input.IndexOf(')') - input.IndexOf('(') - 1);
            queue.Enqueue(item);
            Console.WriteLine($"Queued {item}");
        } else if (input.Contains("Process"))
        {
            if (queue.Count > 0)
            {
                Console.WriteLine($"Processed {queue.Dequeue()}");
            }
            else
            {
                Console.WriteLine("Queue is empty");
            }
        }
    }
}