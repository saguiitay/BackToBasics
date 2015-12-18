using System.Collections;
using System.Collections.Generic;
using DataStructures.LinkedList.Enumerators;

namespace DataStructures.LinkedList
{
    public class SingleLinkedList<T> : IEnumerable<T>
    {
        public SingleLinkNode<T> Head { get; private set; }

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new SingleLinkNode<T>(value);
                return;
            }
            var node = Head;
            while (node.Next != null)
                node = node.Next;

            node.Next = new SingleLinkNode<T>(value);
        }

        public void Reverse()
        {
            Stack<SingleLinkNode<T>> stack = new Stack<SingleLinkNode<T>>();

            var node = Head;
            while (node != null)
            {
                stack.Push(node);
                node = node.Next;
            }

            // Set Head to the last node
            node = Head = stack.Pop();
            while (stack.Count > 0)
            {
                // Attach each node to the previous node
                node.Next = stack.Peek();
                node = stack.Pop();
            }

            // Mark the last node as last
            node.Next = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SingleLinkedListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}