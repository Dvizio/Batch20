/*WEEK 1*/
// Queue<string> queue = new Queue<string>();
// string? inputs;
// Console.WriteLine("Enter commands Enqueue(item) or Process(), separated by ';' or ',' (Ctrl+C to exit):");

// while ((inputs = Console.ReadLine()) != null)
// {
//     if (inputs.Contains(";"))
//     {
//         String[] inputsArray = inputs.Split(';');
//         foreach (string input in inputsArray)
//         {
//             QueueManager(queue, input);
//         }
//     }
//     else
//     {
//         String[] inputArray = inputs.Split(',');
//         foreach (string input in inputArray)
//         {
//             QueueManager(queue, input);
//         }
//     }
// }

// static void QueueManager(Queue<string> queue, string input)
// {
//     if (input.Contains("Enqueue("))
//     {
//         string item = input.Substring(input.IndexOf('(') + 1, input.IndexOf(')') - input.IndexOf('(') - 1);
//         queue.Enqueue(item);
//         Console.WriteLine($"Queued {item}");
//     }
//     else if (input.Contains("Process"))
//     {
//         if (queue.Count > 0)
//         {
//             Console.WriteLine($"Processed {queue.Dequeue()}");
//         }
//         else
//         {
//             Console.WriteLine("Queue is empty");
//         }
//     }
// }


/* WEEK 2 */
Queue<string> queue = new Queue<string>();
Queue<string> vipQueue = new Queue<string>();
string? inputs;
Console.WriteLine("Enter commands Enqueue(item)/EnqueueVip() or Process(), separated by ';' or ',' (Ctrl+C to exit):");

while ((inputs = Console.ReadLine()) != null)
{
    if (inputs.Contains(";"))
    {
        String[] inputsArray = inputs.Split(';');
        foreach (string input in inputsArray)
        {
            QueueManager(vipQueue, queue, input);
        }
    }
    else
    {
        String[] inputArray = inputs.Split(',');
        foreach (string input in inputArray)
        {
            QueueManager(vipQueue, queue, input);
        }
    }
}

static void QueueManager(Queue<string> vipQueue, Queue<string> queue, string input)
{
    if (input.Contains("Vip("))
    {
        string item = input.Substring(input.IndexOf('(') + 2, input.IndexOf(')') - input.IndexOf('(') - 3);
        vipQueue.Enqueue(item);
        Console.WriteLine($"VIP Queued {item}");
    }
    else if (input.Contains("Enqueue("))
    {
        string item = input.Substring(input.IndexOf('(') + 2, input.IndexOf(')') - input.IndexOf('(') - 3);
        queue.Enqueue(item);
        Console.WriteLine($"Queued {item}");
    }
    else if (input.Contains("Process"))
    {
        if (vipQueue.Count > 0)
        {
            Console.WriteLine($"Processed {vipQueue.Dequeue()}");
        }
        else if (queue.Count > 0)
        {
            Console.WriteLine($"Processed {queue.Dequeue()}");
        }
        else
        {
            Console.WriteLine("Queue is empty");
        }
    }
}
