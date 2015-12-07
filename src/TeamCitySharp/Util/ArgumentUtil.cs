using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.Util
{
    using System.Linq.Expressions;

    internal static class ArgumentUtil
    {
        public static void CheckNotNull<T>(params Expression<Func<T>>[] memberExpressions)
        {
            foreach (var expression in memberExpressions)
            {
                CheckNotNull(expression);
            }
        }

        public static void CheckNotNull<T>(Expression<Func<T>> memberExpression)
        {
            if (memberExpression.Compile().Invoke() == null)
            {
                throw new ArgumentNullException(ReflectionUtil.GetMemberName(memberExpression));
            }
        }
    }
}
