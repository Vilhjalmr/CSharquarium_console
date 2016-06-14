using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharquarium_console.Utils
{
    public delegate bool MyDelegate<T>(T thingy);

    public static class PseudoLink<T>
    {
        // Left this here as a reminder of the possibility of doing this to get same result as PseudoLink<T, X>.Count()
        //public static int Count(List<T> list, string str)
        //{
        //    int count = 0;
        //    foreach (var item in list)
        //    {
        //        if (item.GetType().Name.Equals(str))
        //            ++count;
        //    }
        //    return count;
        //}

        /// <summary>
        /// Use this to get a sublist made of the elements that answer to a condition
        /// </summary>
        /// <param name="list">List to iterate through</param>
        /// <param name="predicate">Method to apply to list</param>
        /// <returns>List, of type T, of elements that answer to a particular condition</returns>
        public static List<T> GetIf(List<T> list, MyDelegate<T> predicate)
        {
            List<T> SubCollection = new List<T>();

            foreach (T item in list)
            {
                if (predicate(item))
                {
                    SubCollection.Add(item);
                }
            }

            return SubCollection;
        }

        /// <summary>
        /// Use this to know how many elements of a list answer to a particular condition
        /// </summary>
        /// <param name="list">List to iterate through</param>
        /// <param name="predicate">Method to apply to list</param>
        /// <returns>Count of items in a given list which answer the given condition</returns>
        public static int GetCountWhen(List<T> list, MyDelegate<T> predicate)
        {
            int count = 0;

            foreach (T item in list)
            {
                if (predicate(item))
                {
                    ++count;
                }
            }

            return count;
        }
    }

    public static class PseudoLink<T, X>
    {
        /// <summary>
        /// Use this if you need to know how many elements of type X are in a list of type T
        /// </summary>
        /// <param name="list">List to iterate through</param>
        /// <returns>Count of elements of type X in a list of type T</returns>
        public static int Count(List<T> list)
        {
            int count = 0;
            foreach (T item in list)
            {
                if (item is X)
                    ++count;
            }
            return count;
        }

        /// <summary>
        /// Use this to get a subset of all the elements of type X contained in a list of type T
        /// </summary>
        /// <param name="list"></param>
        /// <returns>List of type T, containing elements of type X</returns>
        public static List<T> GetSubset(List<T> list)
        {
            List<T> Subset = new List<T>();
            foreach (T item in list)
            {
                if (item is X)
                    Subset.Add(item);
            }

            return Subset;
        }
    }
}



