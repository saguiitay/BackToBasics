using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Trees
{
    public static class BinaryTreeStringSerializer
    {
        public static string AsString<T>(BinaryTree<T> tree)
        {
            StringBuilder sb = new StringBuilder();
            
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(tree.Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node != null)
                {
                    sb.Append(node.Value + " ");

                    queue.Enqueue(node.Left);
                    queue.Enqueue(node.Right);
                }
                else
                    sb.Append("* ");
            }

            return sb.ToString();
        }

        public static string AsStringCompact<T>(BinaryTree<T> tree) where T : IComparable
        {
            StringBuilder sb = new StringBuilder();

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(tree.Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node != null)
                {
                    sb.Append(node.Value);
                    if (node.Left == null && node.Right == null)
                    {
                        sb.Append("' ");
                    }
                    else
                    {
                        sb.Append(" ");
                        queue.Enqueue(node.Left);
                        queue.Enqueue(node.Right);
                    }
                }
                else
                    sb.Append("* ");
            }

            return sb.ToString().TrimEnd(' ', '*');
        }

        public static BinaryTree<int> FromString(string str)
        {
            var values = str.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

            var tree = new BinaryTree<int>();

            if (!values.Any())
                return tree;

            int index = 0;
            var root = tree.Root = new Node<int>(int.Parse(values[index++]));

            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                var left = values[index++];

                if (left != "*")
                {
                    var leftNode = node.Left = new Node<int>(int.Parse(left));
                    queue.Enqueue(leftNode);
                }

                var right = values[index++];
                if (right != "*")
                {
                    var rightNode = node.Right = new Node<int>(int.Parse(right));
                    queue.Enqueue(rightNode);
                }
            }

            return tree;
        }

        public static BinaryTree<int> FromStringCompact(string str)
        {
            var values = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var tree = new BinaryTree<int>();

            if (!values.Any())
                return tree;

            int index = 0;
            var root = tree.Root = new Node<int>(int.Parse(values[index++]));

            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (index < values.Length)
                {
                    var left = values[index++];
                    if (left != "*")
                    {
                        var leftNode = node.Left = new Node<int>(int.Parse(left.TrimEnd('\'')));
                        if (!left.EndsWith("'"))
                            queue.Enqueue(leftNode);
                    }
                }

                if (index < values.Length)
                {
                    var right = values[index++];
                    if (right != "*")
                    {
                        var rightNode = node.Right = new Node<int>(int.Parse(right.TrimEnd('\'')));
                        if (!right.EndsWith("'"))
                            queue.Enqueue(rightNode);
                    }
                }
            }

            return tree;
        }
    }
}