using System;
using System.Linq.Expressions;

namespace TeamCitySharp.Util
{
    internal static class ReflectionUtil
    {
        public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            var expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }
    }
}
