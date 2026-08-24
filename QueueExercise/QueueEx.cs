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
// Queue<string> queue = new Queue<string>();
// Queue<string> vipQueue = new Queue<string>();
// string? inputs;
// Console.WriteLine("Enter commands Enqueue(item)/EnqueueVip() or Process(), separated by ';' or ',' (Ctrl+C to exit):");

// while ((inputs = Console.ReadLine()) != null)
// {
//     if (inputs.Contains(";"))
//     {
//         String[] inputsArray = inputs.Split(';');
//         foreach (string input in inputsArray)
//         {
//             QueueManager(vipQueue, queue, input);
//         }
//     }
//     else
//     {
//         String[] inputArray = inputs.Split(',');
//         foreach (string input in inputArray)
//         {
//             QueueManager(vipQueue, queue, input);
//         }
//     }
// }

// static void QueueManager(Queue<string> vipQueue, Queue<string> queue, string input)
// {
//     if (input.Contains("Vip("))
//     {
//         string item = input.Substring(input.IndexOf('(') + 2, input.IndexOf(')') - input.IndexOf('(') - 3);
//         vipQueue.Enqueue(item);
//         Console.WriteLine($"VIP Queued {item}");
//     }
//     else if (input.Contains("Enqueue("))
//     {
//         string item = input.Substring(input.IndexOf('(') + 2, input.IndexOf(')') - input.IndexOf('(') - 3);
//         queue.Enqueue(item);
//         Console.WriteLine($"Queued {item}");
//     }
//     else if (input.Contains("Process"))
//     {
//         if (vipQueue.Count > 0)
//         {
//             Console.WriteLine($"Processed {vipQueue.Dequeue()}");
//         }
//         else if (queue.Count > 0)
//         {
//             Console.WriteLine($"Processed {queue.Dequeue()}");
//         }
//         else
//         {
//             Console.WriteLine("Queue is empty");
//         }
//     }
// }


/* WEEK 3 */
// Queue<string> queue = new Queue<string>();
// Dictionary<int, Queue<string>> whatamidoinglol = new Dictionary<int, Queue<string>>(); ;
// List<int> priorityqueue = new List<int>();
// string? inputs;
// Console.WriteLine("Enter commands Enqueue(item)/EnqueueVip() or Process(), separated by ';' (Ctrl+C to exit):, or you can just input it one by one");
// // Calls: Enqueue("A", 1); Enqueue("B", 5); Enqueue("C", 5); Process(); Process()

// while ((inputs = Console.ReadLine()) != null)
// {
//     String[] inputsArray = inputs.Split(';');
//     foreach (string input in inputsArray)
//     {
//         QueueManager(whatamidoinglol, priorityqueue, input);
//     }
// }

// static void QueueManager(Dictionary<int, Queue<string>> whatamidoinglol, List<int> priorityqueue, string input)
// {
//     if (input.Contains("Enqueue("))
//     {
//         string item = input.Substring(input.IndexOf('(') + 2, input.LastIndexOf('\"') - input.IndexOf('\"') - 1);
//         string priority = input.Substring(input.IndexOf(',') + 1, input.IndexOf(')') - input.IndexOf(',') - 1);
//         int prio = 0;
//         if (int.TryParse(priority, out prio))
//         {
//             if (!whatamidoinglol.TryGetValue(prio, out var newqueue))
//             {
//                 newqueue = new Queue<string>();
//                 whatamidoinglol[prio] = newqueue;
//                 priorityqueue.Add(prio);
//                 priorityqueue.Sort();
//             }
//             whatamidoinglol[prio].Enqueue(item);
//             Console.WriteLine($"Queued {item} with priority {prio}");
//         }
//         else
//         {
//             Console.WriteLine("Failed to parse priority");
//             Console.WriteLine(item);
//             Console.WriteLine(priority);
//         }
//     }
//     else if (input.Contains("Process"))
//     {
//         if (priorityqueue.Count() == 0)
//         {
//             Console.WriteLine("Queue is empty");
//             return;
//         }

//         int a = priorityqueue.First();
//         // Console.WriteLine(a);
//         if (whatamidoinglol[a].Count == 0)
//         {
//             priorityqueue.Remove(a);
//             Console.WriteLine("Queue is empty");
//             return;
//         }
//         if (whatamidoinglol[a].Count != 0)
//         {
//             string output = whatamidoinglol[a].Dequeue();
//             Console.WriteLine($"Proccesed {output}");
//             if (whatamidoinglol[a].Count == 0)
//             {
//                 priorityqueue.Remove(a);
//             }
//         }
//     }
// }

namespace QueueExercise;

using System;
using System.Collections.Generic;
using System.Linq;

public class QueueEx
{
    private readonly Dictionary<int, Queue<string>> _queues = new();
    private readonly List<int> _priorities = new();
    private readonly Dictionary<string, int> _keywordRules = new(StringComparer.OrdinalIgnoreCase);
    private int _defaultPriority = 0;

    public void AddRule(string keyword, int priority)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            throw new ArgumentException("Keyword cannot be null or empty.", nameof(keyword));

        _keywordRules[keyword.Trim()] = priority;
    }


    public void Enqueue(string item)
    {
        int assignedPriority = _defaultPriority;

        foreach (var rule in _keywordRules)
        {
            if (item.Contains(rule.Key, StringComparison.OrdinalIgnoreCase))
            {
                assignedPriority = rule.Value;
                break;
            }
        }


        if (!_queues.TryGetValue(assignedPriority, out var targetQueue))
        {
            targetQueue = new Queue<string>();
            _queues[assignedPriority] = targetQueue;
            _priorities.Add(assignedPriority);
            _priorities.Sort();
        }

        targetQueue.Enqueue(item);
        Console.WriteLine($"Queued {item} with priority {assignedPriority}");
    }


    public void Process()
    {
        while (_priorities.Count > 0)
        {
            int highestPriority = _priorities.Max();

            if (_queues.TryGetValue(highestPriority, out var queue) && queue.Count > 0)
            {
                string output = queue.Dequeue();
                Console.WriteLine($"Processed {output}");


                if (queue.Count == 0)
                {
                    _priorities.Remove(highestPriority);
                }
                return;
            }
            else
            {

                _priorities.Remove(highestPriority);
            }
        }

        Console.WriteLine("Queue is empty");
    }
}