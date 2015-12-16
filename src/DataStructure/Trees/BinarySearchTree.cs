using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Trees.Enumerators;

namespace DataStructures.Trees
{
    public class BinarySearchTree<T> : ITree<T>
        where T : IComparable
    {
        private int _count;
        private Node<T> _root;

        public int Count => _count;
        public Node<T> Root { get { return _root; } set { _root = value; } }

        public bool Contains(T value)
        {
            for (Node<T> node = Root; node != null; node = value.CompareTo(node.Value) >= 0 ? node.Right : node.Left)
            {
                if (node.Value.Equals(value))
                    return true;
            }
            return false;
        }


        public virtual void InsertRecursive(T value)
        {
            InsertInternal(value, ref _root);
        }

        
        public void Insert(T value)
        {
            Node<T> parentNode = null;
            for (Node<T> node = Root; node != null; parentNode = node, node = value.CompareTo(node.Value) >= 0 ? node.Right : node.Left)
            {
                if (node.Value.Equals(value))
                    return;
            }
            var newNode = new Node<T>(value) { Parent = parentNode};
            if (parentNode != null)
            {
                if (value.CompareTo(parentNode.Value) >= 0)
                    parentNode.Right = newNode;
                else
                    parentNode.Left = newNode;
            }
            else
                Root = newNode;
        }

        private void InsertInternal(T value, ref Node<T> node, Node<T> parent = null)
        {
            if (node == null)
            {
                _count++;
                node = new Node<T>(value)
                    {
                        Parent = parent
                    };
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                Node<T> left = node.Left;
                InsertInternal(value, ref left, node);
                if (node.Left != null)
                    return;
                node.Left = left;
            }
            else
            {
                Node<T> right = node.Right;
                InsertInternal(value, ref right, node);
                if (node.Right != null)
                    return;
                node.Right = right;
            }
        }


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

    public static class BinaBinarySearchTreeExtensions
    {
        public static BinarySearchTree<int> FromString(string data)
        {
            var bst = new BinarySearchTree<int>();
            var values = data.Split(' ').Select(int.Parse);
            foreach (var value in values)
                bst.Insert(value);

            return bst;
        }
    }
}