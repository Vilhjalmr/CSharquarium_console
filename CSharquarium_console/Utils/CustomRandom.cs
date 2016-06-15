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

            result %= v;

            return result;
        }
    }

}
