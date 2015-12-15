using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FillAlgo
{
    class Program
    {
        private static byte[,] _data;

        static void Main(string[] args)
        {
            var table =
                "000000000020000000000000000000000000\n" +
                "000000000020000000000000000000000000\n" +
                "000000000020000000000000000000000000\n" +
                "000000000020000000000000000000000000\n" +
                "000000000020000000000000000000000000\n" +
                "222022222220000000000000000000000000\n" +
                "002000000022222220000000000000000000\n" +
                "002000000020000002000000000000000000\n" +
                "002000200000000000000000000000000000\n" +
                "002222200020000002000000000000000000\n" +
                "000000000020000002000000000000000000\n" +
                "000000000022222222000000000000000000\n" +
                "000000000020000000000000000000000000\n" +
                "000000000020000000000000000000000000\n" +
                "000000000020000000000000000000000000\n" +
                "000000000020000000000000000000000000\n" +
                "000000000020000000000000000000000000\n" +
                "000000000020000000000000000000000000\n" +
                "000000000020000000000000000000000000\n";

            _data = ToArray(table);

            //Display(_data);

            var sw = Stopwatch.StartNew();
            FillRecursive(4, 4, 0, 1);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();

            _data = ToArray(table);

            sw = Stopwatch.StartNew();
            FillQueue(4, 4, 0, 1);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();

            _data = ToArray(table);

            sw = Stopwatch.StartNew();
            FillScanLine(4, 4, 0, 1);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();

        }

        private static void FillRecursive(int x, int y, byte currColor, byte destColor)
        {
            Display(_data);

            if (_data[x,y] == destColor)
                return;
            if (_data[x, y] != currColor)
                return;

            _data[x, y] = destColor;

            if (x + 1 < _data.GetLength(0))
                FillRecursive(x + 1, y, currColor, destColor);
            if (x - 1 >= 0)
                FillRecursive(x - 1, y, currColor, destColor);

            if (y + 1 < _data.GetLength(1))
                FillRecursive(x, y + 1, currColor, destColor);
            if (y - 1 >= 0)
                FillRecursive(x, y - 1, currColor, destColor);
        }

        private static void FillQueue(int firstX, int firstY, byte currColor, byte destColor)
        {
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create(firstX, firstY));

            var maxX = _data.GetLength(0);
                var maxY = _data.GetLength(1);
            while (q.Count > 0)
            {
                var point = q.Dequeue();
                var x = point.Item1;
                var y = point.Item2;

                if (_data[x, y] == destColor)
                    continue;
                if (_data[x, y] != currColor)
                    continue;

                _data[x, y] = destColor;

                if (x + 1 < maxX)
                    q.Enqueue(Tuple.Create(x + 1, y));
                if (x - 1 >= 0)
                    q.Enqueue(Tuple.Create(x - 1, y));

                if (y + 1 < maxY)
                    q.Enqueue(Tuple.Create(x, y + 1));
                if (y - 1 >= 0)
                    q.Enqueue(Tuple.Create(x, y - 1));

                Display(_data);
            }
        }

        private static void FillScanLine(int firstX, int firstY, byte currColor, byte destColor)
        {
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create(firstX, firstY));

            var maxX = _data.GetLength(0)-1;
            var maxY = _data.GetLength(1)-1;

            while (q.Count > 0)
            {
                var point = q.Dequeue();
                var x = point.Item1;
                var y = point.Item2;

                if (_data[x, y] == destColor)
                    continue;
                if (_data[x, y] != currColor)
                    continue;

                _data[x, y] = destColor;

                var left = x;
                var right = x;
                while (left > 0 && _data[left - 1, y] == currColor)
                    left--;
                while (right < maxX && _data[right + 1, y] == currColor)
                    right++;

                for (var i = left; i <= right; i++)
                {
                    _data[i, y] = destColor;
                    if (y > 0)
                    {
                        if (_data[i, y - 1] == currColor)
                            q.Enqueue(Tuple.Create(i, y - 1));
                    }

                    if (y < maxY)
                    {
                        if (_data[i, y + 1] == currColor)
                            q.Enqueue(Tuple.Create(i, y + 1));
                    }
                }
                Display(_data);
            }
        }

        static byte[,] ToArray(string table)
        {
            var lines = table.Split(new []{'\n'}, StringSplitOptions.RemoveEmptyEntries ).ToList();

            var result = new byte[lines.Max(x => x.Length), lines.Count];

            for (int y = 0; y < lines.Count; y++)
            {
                var line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    result[x, y] = (byte) (line[x] - '0');
                }
            }

            return result;
            //return lines.Select(l => l.ToCharArray().Select(c => (byte)(c-'0')).ToArray()).ToArray();
        }

        static void Display(byte[,] data)
        {
            Console.Clear();
            for (int y = 0; y < data.GetLength(1); y++)
            {
                for (int x = 0; x < data.GetLength(0); x++)
                {
                    Console.Write(data[x, y] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
