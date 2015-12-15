using System.Collections.Generic;

namespace DataStructures.Suffix
{
    public class Suffix<T>
    {
        public Node<T> Root { get; set; } = new Node<T>();

        public Node<T> Insert(string text)
        {
            Node<T> node1 = Root;
            foreach (char key in text)
            {
                Node<T> node2;
                if (!node1.Children.TryGetValue(key, out node2))
                {
                    node2 = new Node<T>
                        {
                            Char = key
                        };
                    node1.Children[key] = node2;
                }
                node1 = node2;
            }
            node1.IsValue = true;
            return node1;
        }

        public bool Contains(string text)
        {
            Node<T> node1 = Root;
            foreach (char key in text)
            {
                Node<T> node2;
                if (!node1.Children.TryGetValue(key, out node2))
                    return false;

                node1 = node2;
            }
            return node1.IsValue;
        }

        public IEnumerable<Node<T>> Values(string suffix)
        {
            Node<T> current = Root;
            string str = suffix;
            for (int index = 0; index < str.Length; ++index)
            {
                char c = str[index];
                Node<T> nextCurrent;
                if (!current.Children.TryGetValue(c, out nextCurrent))
                    yield break;

                current = nextCurrent;
            }

            foreach (var node in Scan(current))
            {
                yield return node;
            }
        }

        private IEnumerable<Node<T>> Scan(Node<T> node)
        {
            if (node.IsValue)
                yield return node;

            foreach (var keyValuePair in node.Children)
            {
                foreach (var node1 in Scan(keyValuePair.Value))
                {
                    yield return node1;
                }
            }
        }
    }
}