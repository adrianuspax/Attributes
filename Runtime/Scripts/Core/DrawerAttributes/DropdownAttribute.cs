using System;
using System.Collections;
using System.Collections.Generic;

namespace ASPax.Attributes.Drawer
{
    public interface IDropdownList : IEnumerable<KeyValuePair<string, object>> { }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class DropdownAttribute : DrawerAttribute
    {
        private readonly string _valuesName;

        public DropdownAttribute(string valuesName)
        {
            _valuesName = valuesName;
        }

        public string ValuesName => _valuesName;
    }

    public class DropdownList<T> : IDropdownList
    {
        private readonly List<KeyValuePair<string, object>> _values;

        public DropdownList()
        {
            _values = new();
        }

        public void Add(string displayName, T value)
        {
            _values.Add(new KeyValuePair<string, object>(displayName, value));
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static explicit operator DropdownList<object>(DropdownList<T> target)
        {
            var result = new DropdownList<object>();

            foreach (var kvp in target)
                result.Add(kvp.Key, kvp.Value);

            return result;
        }
    }
}
