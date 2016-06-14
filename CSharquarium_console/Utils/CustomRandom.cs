using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Utils
{
    public static class CustomRandom
    {
        public static int GetRandom(int v)
        {
            int result = Math.Abs(Guid.NewGuid().GetHashCode());

            while (result >= v)
            {
                // TODO: try catch pour éviter que v/10 = 0 remplacer 10 par random entre 0 et v
                int i = CustomRandom.GetRandom(v);
                int j = CustomRandom.GetRandom(v / 2);
                result %= v/i*j;
            }

            return Math.Abs(result);
        }
    }

}
