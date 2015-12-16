using System.Collections.Generic;
using DataStructures.Trees.Enumerators;

namespace DataStructures.Trees
{
    public class BinaryTree<T> : ITree<T>
        //where T : IComparable
    {
        private Node<T> _root;

        public Node<T> Root { get { return _root; } set { _root = value; } }
        
        public Node<T> FindNode(T value)
        {
            if (_root == null)
                return null;

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Value.Equals(value))
                    return node;

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
            return null;
        }

        //public void AddNode(T newValue, T parentValue = default(T))
        //{
        //    if (parentValue == null)
        //    {
        //        if (_root != null)
        //            throw new InvalidOperationException("Tree already has a root");

        //        _root = new Node<T> {Value = newValue};
        //    }

        //    var parentNode = FindNode(parentValue);
        //    if (parentNode == null)
        //        throw new InvalidOperationException("Parent value was not found in tree");


        //}

        public IEnumerator<Node<T>> GetPreOrderEnumerator()
        {
            return new PreOrderEnumerator<T>(this);
        }

        public IEnumerator<Node<T>> GetInOrderEnumerator()
        {
            return new InOrderEnumerator<T>(this);
        }

        public IEnumerator<Node<T>> GetLevelOrderEnumerator()
        {
            return new LevelOrderEnumerator<T>(this);
        }
    }
}