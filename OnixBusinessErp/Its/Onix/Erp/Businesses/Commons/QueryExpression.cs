using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Its.Onix.Erp.Businesses.Commons
{        
    public delegate Expression GetExpressionDelegate (ParameterExpression param, string property, string value);

    public static class QueryExpression
    {
        private static Dictionary<string, GetExpressionDelegate> exprDelegateMap = new Dictionary<string, GetExpressionDelegate>();

        static QueryExpression()
        {
            exprDelegateMap["="] = GetEqualsExprInt;
            exprDelegateMap["EQUAL"] = GetEqualsExprStr;
            exprDelegateMap["CONTAIN"] = GetLikeExpr;
            exprDelegateMap["IS_NULL"] = GetNullExpr;
        }

        private static Expression ConvertToNullable(Expression expr1, Expression expr2)
        {
            Type t = expr2.Type;
            bool isNullable = t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);

            if (isNullable)
            {
                return Expression.Convert(expr1, expr2.Type);
            }

            return expr1;
        }

        public static GetExpressionDelegate GetExprDelegate(string opr)
        {
            if (!exprDelegateMap.ContainsKey(opr))
            {
                return GetEqualsExprStr;
            }

            return exprDelegateMap[opr];
        }

        private static Expression GetExpression(ParameterExpression param, string property)
        {
            Expression body = param;
            foreach (var member in property.Split('.')) 
            {
                body = Expression.PropertyOrField(body, member);
            }
        
            return(body);
        }

        private static Expression GetEqualsExprStr(ParameterExpression param, string property, string value)
        {
            Expression body = GetExpression(param, property);
            Expression val = Expression.Constant(value);

            val = ConvertToNullable(val, body);

            return Expression.Equal(body, val);
        }

        private static Expression GetEqualsExprInt(ParameterExpression param, string property, string value)
        {
            int v = Int32.Parse(value);

            Expression body = GetExpression(param, property);
            Expression val = Expression.Constant(v);

            val = ConvertToNullable(val, body);

            return Expression.Equal(body, val);
        }        

        private static Expression GetNullExpr(ParameterExpression param, string property, string value)
        {
            Expression body = GetExpression(param, property);
            Expression val = Expression.Constant(null);

            val = ConvertToNullable(val, body);

            if (value.Equals("Y"))
            {
                return Expression.Equal(body, val);    
            }

            return Expression.NotEqual(body, val);
        }        
        
        private static Expression GetLikeExpr(ParameterExpression param, string property, string value)
        {
            Expression body = GetExpression(param, property);
            Expression val = Expression.Constant(value);

            val = ConvertToNullable(val, body);

            Type[] arr = new Type[1] {typeof(string)};
            Expression expr = Expression.Call(body, typeof(string).GetMethod("Contains", arr), val);
            return(expr);
        }
    }
}