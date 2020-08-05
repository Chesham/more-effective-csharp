using System;
using System.Linq.Expressions;

namespace item43
{
    public class Item43
    {
        public static dynamic Add(dynamic left, dynamic right)
        {
            return left + right;
        }

        //呼叫端一直重複程式
        public static TResult AddT<T1, T2, TResult>(T1 left, T2 right, Func<T1, T2, TResult> AddMethod)
        {
            return AddMethod(left, right);
        }

        //直觀實作，不能使用相異型別的引數
        public static T AddExpression<T>(T left, T right)
        {
            ParameterExpression leftOperand = Expression.Parameter(typeof(T), "left");
            ParameterExpression rightOperand = Expression.Parameter(typeof(T), "right");
            BinaryExpression body = Expression.Add(leftOperand, rightOperand);
            Expression<Func<T, T, T>> adder = Expression.Lambda<Func<T, T, T>>(body, leftOperand, rightOperand);
            Func<T, T, T> theDelegate = adder.Compile();
            return theDelegate(left, right);
        }
        //稍微改善，每次呼叫都要編譯演算式為委派
        public static TResult AddExpression2<T1, T2, TResult>(T1 left, T2 right)
        {
            var leftOperand = Expression.Parameter(typeof(T1), "left");
            var rightOperand = Expression.Parameter(typeof(T2), "right");
            var body = Expression.Add(leftOperand, rightOperand);
            var adder = Expression.Lambda<Func<T1, T2, TResult>>(body, leftOperand, rightOperand);
            return adder.Compile()(left, right);
        }
    }
    //處理許多限制
    public static class BinaryOperator<T1, T2, TResult>
    {
        static Func<T1, T2, TResult> compiledExpression;

        public static TResult Add(T1 left,T2 right)
        {
            if (compiledExpression == null)
                createFunc();

            return compiledExpression(left, right);
        }

        private static void createFunc()
        {
            var leftOperand = Expression.Parameter(typeof(T1), "left");
            var rightOperand = Expression.Parameter(typeof(T2), "right");
            var body = Expression.Add(leftOperand, rightOperand);
            var adder = Expression.Lambda<Func<T1, T2, TResult>>(body, leftOperand, rightOperand);
            compiledExpression = adder.Compile();
        }
        //修正一個問題導致別的問題
        //double+int OK; string+double =string OK; DateTime+TimeSpan !OK
        public static TResult AddExpressionWithConversion(T1 left,T2 right)
        {
            var leftOperand = Expression.Parameter(typeof(T1), "left");
            Expression convertedLeft = leftOperand;
            if (typeof(T1) != typeof(TResult))
            {
                convertedLeft = Expression.Convert(leftOperand, typeof(TResult));
            }
            var rightOperand = Expression.Parameter(typeof(T2), "right");
            Expression convertedRight = rightOperand;
            if(typeof(T2)!= typeof(TResult))
            {
                convertedRight = Expression.Convert(rightOperand, typeof(TResult));
            }

            var body = Expression.Add(convertedLeft, convertedRight);
            var adder = Expression.Lambda<Func<T1, T2, TResult>>(body, leftOperand, rightOperand);
            return adder.Compile()(left, right);
        }
    }

    //建議
    public static class BinaryOperators<T>
    {
        static Func<T, T, T> compiledExpression;

        public static T Add(T left,T right)
        {
            if(compiledExpression == null)
                createFunc();

            return compiledExpression(left, right);
        }

        private static void createFunc()
        {
            var leftOperand = Expression.Parameter(typeof(T), "left");
            var rightOperand = Expression.Parameter(typeof(T), "right");
            var body = Expression.Add(leftOperand, rightOperand);
            var adder = Expression.Lambda<Func<T, T, T>>(body, leftOperand, rightOperand);
            compiledExpression = adder.Compile();
        }
    }
}
