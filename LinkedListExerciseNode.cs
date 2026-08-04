using System;
namespace LinkedListExercise
{
    internal class Node
    {
        private int _value;
        private Node _next = null;

        public Node(int value)
        {
            _value = value;
        }
        public int _value { get;}
        public Node _next { get; set; }
    }
}