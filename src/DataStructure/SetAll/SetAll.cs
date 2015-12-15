namespace DataStructures.SetAll
{
    public class SetAll<T>
    {
        private int _version;
        private ValueHolder _all;
        private readonly ValueHolder[] _values;

        public T this[int index]
        {
            get
            {
                var valueHolder = _values[index];
                if (valueHolder == null)
                {
                    if (_all == null)
                        return default(T);
                    return _all.Value;
                }
                if (_all == null || valueHolder.Version >= _all.Version)
                    return valueHolder.Value;
                return _all.Value;
            }
            set
            {
                ValueHolder valueHolder1 = _values[index];
                if (valueHolder1 != null)
                {
                    valueHolder1.Value = value;
                    valueHolder1.Version = _version;
                }
                else
                {
                    ValueHolder[] valueHolderArray = _values;
                    int index1 = index;
                    ValueHolder valueHolder2 = new ValueHolder {Value = value};
                    int num = _version;
                    valueHolder2.Version = num;
                    valueHolderArray[index1] = valueHolder2;
                }
            }
        }

        public SetAll(int size)
        {
            _values = new ValueHolder[size];
        }

        public void SetAllValues(T value)
        {
            if (_all == null)
                _all = new ValueHolder();
            _all.Value = value;
            ValueHolder valueHolder = _all;
            int num1 = _version + 1;
            _version = num1;
            int num2 = num1;
            valueHolder.Version = num2;
        }

        private class ValueHolder
        {
            public T Value { get; set; }

            public int Version { get; set; }
        }
    }
}
