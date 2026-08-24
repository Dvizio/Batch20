using System.Runtime.InteropServices;
using QueueExercise;


var ngawi = new QueueEx();
ngawi.AddRule("urgent", 10);
ngawi.AddRule("normal", 5);
ngawi.Enqueue("blablabla normal");
ngawi.Enqueue("blablablabla urgent");
ngawi.Process();
ngawi.Process();
ngawi.Process();