using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Utils
{
    public static class CustomGetTypes
    {
        public static List<Type> GetInstanciableTypes(string nmspc)
        {
            List<Type> result = new List<Type>();

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nmspc && t.BaseType.Name != "Object"
                    select t;

            result = q.ToList();

            return result;
        }

        public static List<Type> GetTypeWhenParent(string nmspc, string[] parent)
        {
            List<Type> result = new List<Type>();

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    // IndexOf returns -1 if it didn't find what it was looking for
                    where t.IsClass && t.Namespace == nmspc && Array.IndexOf(parent, t.BaseType.Name) != -1 
                    select t;

            result = q.ToList();

            return result;
        }

    }
}
