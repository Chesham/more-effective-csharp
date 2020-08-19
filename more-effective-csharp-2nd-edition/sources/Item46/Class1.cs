using System;
using System.Linq;
using System.Linq.Expressions;

namespace Item46
{
    public class Class1
    {
        public int CallInterface(Expression<Func<int, int>> op)
        {
            var exp = op.Body as MethodCallExpression;
            var methodName = exp.Method.Name;
            var MethodInfo = exp.Method;

            var allParameters = from element in exp.Arguments select processArgument(element);
            if (allParameters != null)
                return (int)allParameters.FirstOrDefault().ParamVale;
            else
                return default(int);
        }

        private (Type ParamTpe, object ParamVale) processArgument(Expression element)
        {
            object argument = default(object);
            LambdaExpression expression = Expression.Lambda(Expression.Convert(element, element.Type));
            //expression = Expression.Lambda(Expression.Add(element, element));
            Type paramType = expression.ReturnType;
            argument = expression.Compile().DynamicInvoke();
            return (paramType, argument);
        }
    }
}
