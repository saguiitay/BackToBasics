using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList.Enumerators
{
    public class SingleLinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly SingleLinkedList<T> _linkedList;
        private SingleLinkNode<T> _node; 
        private SingleLinkNode<T> _nextNode; 

        public SingleLinkedListEnumerator(SingleLinkedList<T> linkedList)
        {
            _linkedList = linkedList;
            _nextNode = _linkedList.Head;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _node = _nextNode;
            if (_nextNode != null)
                _nextNode = _nextNode.Next;

            return _node != null;
        }

        public void Reset()
        {
            _node = null;
            _nextNode = _linkedList.Head;
        }

        public T Current { get { return _node.Value; } }

        object IEnumerator.Current => Current;
    }
}