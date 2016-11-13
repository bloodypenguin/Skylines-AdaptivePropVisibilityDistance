using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AdaptivePropVisibilityDistance.Redirection;
using AdaptivePropVisibilityDistance.Redirection.Extensions;

namespace AdaptivePropVisibilityDistance.Redirection
{

    public class AssemblyRedirector
    {
        private static Type[] _types;

        public static void Deploy()
        {
            _types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in _types)
            {
                type.Redirect();
            }
        }

        public static void Revert()
        {
            if (_types == null)
            {
                return;
            }
            foreach (var type in _types)
            {
                type.Revert();
            }
            _types = null;
        }

    }


}
