using FoobarExercise;

var ngawi = new Foobar();
ngawi.AddRule(3, "foo");
ngawi.AddRule(4, "baz");
ngawi.AddRule(5, "bar");
ngawi.AddRule(7, "jazz");
ngawi.AddRule(9, "huzz");

Console.WriteLine(ngawi.Evaluate(105));
Console.WriteLine(ngawi.GenerateSequence(15, 45));