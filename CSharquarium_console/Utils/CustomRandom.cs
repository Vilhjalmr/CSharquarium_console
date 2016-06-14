using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Utils
{
    public static class CustomRandom
    {
        public static Random r = new Random();

        public static int GetRandom(int v)
        {
            int result = Math.Abs(Guid.NewGuid().GetHashCode());

            while (result >= v)
            {
                // TODO: try catch pour éviter que result %/ x = 0 remplacer 10 par random entre 0 et v
                // TODO: make sure this actually works.
                // TODO: put used line numbers in static array. If nbr already picked, pick again
                int i = r.Next(v);
                try
                {
                    result %= i;
                }
                catch (DivideByZeroException)
                {
                    result = GetRandom(v);
                }
            }

            return Math.Abs(result);
        }
    }

}
