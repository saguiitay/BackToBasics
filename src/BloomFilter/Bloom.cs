using System;
using System.Collections;

namespace BloomFilter
{
    public class Bloom
    {
        private readonly BitArray _data;

        public int Hashes { get; set; }

        public Bloom(int size)
        {
            _data = new BitArray(size);
        }

        public void Add(string item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            var primaryHash = item.GetHashCode();
            var secondaryHash = item.Substring(0, item.Length / 2).GetHashCode() + item.Substring(item.Length / 2 + 1).GetHashCode();
            for (int i = 1; i <= Hashes; i++)
            {
                var hash = ComputeHash(primaryHash, secondaryHash, i);
                _data[hash] = true;
            }
        }

        public bool MayContains(string item)
        {
            var primaryHash = item.GetHashCode();
            var secondaryHash = item.Substring(0, item.Length / 2).GetHashCode() + item.Substring(item.Length / 2 + 1).GetHashCode();
            for (int i = 1; i <= Hashes; i++)
            {
                var hash = ComputeHash(primaryHash, secondaryHash, i);
                if (!_data[hash])
                    return false;
            }

            return true;
        }

        private int ComputeHash(int primary, int secondary, int count)
        {
            return Math.Abs(primary*(secondary*count))%_data.Length;
        }

    }
}