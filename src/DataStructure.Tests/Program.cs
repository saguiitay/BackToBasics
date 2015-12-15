using System;
using DataStructures.Trees;

namespace DataStructure.Tests
{
    class Program
    {
        static void Main()
        {
            MainTree();

            MainSetAll();
        }


        static void MainSetAll()
        {
            var setAll = new DataStructures.SetAll.SetAll<int>(10);
            setAll[2] = 200;
            setAll[4] = 400;

            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0}: {1}", i, setAll[i]);

            setAll.SetAllValues(5);

            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0}: {1}", i, setAll[i]);

            setAll[6] = 600;
            setAll[8] = 800;

            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0}: {1}", i, setAll[i]);

            setAll.SetAllValues(-5);

            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0}: {1}", i, setAll[i]);

        }

        static void MainTree()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(5);
            bst.Insert(1);
            bst.Insert(8);
            bst.Insert(2);
            bst.Insert(6);
            bst.Insert(9);

            //        5
            //      /  \
            //     1    8
            //    / \  / \
            //      2  6  9

            // Depth PreOrder: 5 1 2 8 6 9

            for (int i = 0; i < 12; i++)
                Console.WriteLine("Contains {0}: {1}", i, bst.Contains(i));

            Console.WriteLine("PreOrder: ");
            var preOrder = bst.GetPreOrderEnumerator();
            while (preOrder.MoveNext())
                Console.Write(" {0} ", preOrder.Current.Value);

        }
    }
}
