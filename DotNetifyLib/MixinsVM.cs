using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNetify
{
    public static class MixinsVM
    {
        public static void AcceptChangedProperties(this IBaseVM vm)
        {
            vm.ChangedProperties.Clear();
        }

        public static void Ignore<T>(this IIgnoreProperties vm, Expression<Func<T>> expression)
        {
            var propertyName = ((MemberExpression)expression.Body).Member.Name;
            if (!vm.IgnoredProperties.Contains(propertyName))
                vm.IgnoredProperties.Add(propertyName);
        }
    }
}
