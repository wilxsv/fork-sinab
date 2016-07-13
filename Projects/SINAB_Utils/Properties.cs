using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Routing;

namespace SINAB_Utils
{
    public static class Properties
    {
        public static PropertyInfo GetPropertyInfo<T>(this IEnumerable<T> entities, string propertyName)
        {
            var list = entities as IList<T> ?? entities.ToList();
            if (!list.Any() || string.IsNullOrEmpty(propertyName))
                return null;

            var propertyInfo = list.First().GetType().GetProperty(propertyName);
            return propertyInfo;
        }
      
    }
}
