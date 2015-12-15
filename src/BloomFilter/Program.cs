namespace BloomFilter
{
    class Program
    {
        static void Main()
        {
            var bloom = new Bloom(102400) {Hashes = 10};

            for (char a = 'a'; a < 'z'; a++)
                for (char b = 'a'; b < 'z'; b++)
                    for (var l = 1; l < 10; l++)
                    {
                        var str = new string(a, l) + new string(b, l);
                        bloom.Add(str);
                    }

            var x1 = bloom.MayContains("aaabbb");
            var x2 = bloom.MayContains("ccdd");
            var x3 = bloom.MayContains("aaabbc");
        }
    }
}
