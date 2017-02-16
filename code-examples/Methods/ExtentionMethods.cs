using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    static class StringBuilderExtention
    {
        public static int IndexOf(this StringBuilder sb, char c)
        {
            // CLR does not check first parameter for null 
            // because we call static method.
            if (sb == null) throw new NullReferenceException();

            // goes from last to first chars
            for (var i = sb.Length - 1; i >= 0; i--)
                if (sb[i] == c) return i;

            return -1;
        }
    }

    static class EnumerableExtention
    {
        public static void ShowItem<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Console.WriteLine(item);
        }
    }

    static class ActionExtention
    {
        public static void InvokeAndCatch<TExeption>(this Action<object> d, Object o) where TExeption: Exception
        {
            try
            {
                d(o);
            }
            catch (TExeption)
            {
                // ...
            }
        }
    }
}
