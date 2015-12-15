using System.Collections.Generic;

namespace DataStructures.Suffix
{
    public class Node<T>
    {
        public char Char { get; set; } = '$';

        public bool IsValue { get; set; } = false;

        public Dictionary<char, Node<T>> Children { get; set; } = new Dictionary<char, Node<T>>(26);

        public T Value { get; set; }
    }
}
