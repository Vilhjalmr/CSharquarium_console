using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    //public static class PseudoLink<T>
    //{
    //    public static int Count(List<T> list, string str)
    //    {
    //        int count = 0;
    //        foreach (var item in list)
    //        {
    //            if (item.GetType().Name.Equals(str))
    //                ++count;
    //        }
    //        return count;
    //    }
    //}


    public static class PseudoLink<T, X>
    {
        public static int Count (List<T> list)
        {
            int count = 0;
            foreach (T item in list)
            {
                if (item is X)
                    ++count;
            }
            return count;
        }

        public static List<T> GetSubset(List<T> list)
        {
            List<T> FishSubset = new List<T>();
            foreach (T item in list)
            {
                if (item is X)
                    FishSubset.Add(item);
            }

            return FishSubset;
        }
    }

}



