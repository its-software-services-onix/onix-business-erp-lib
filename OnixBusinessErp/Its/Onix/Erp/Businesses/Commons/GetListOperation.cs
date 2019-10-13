using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Its.Onix.Core.Business;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Core.Utils;

namespace Its.Onix.Erp.Businesses.Commons
{
    public abstract class GetListOperation : BusinessOperationBase
    {
        protected BaseDbContext context = null;
        protected QueryRequestParam queryParam = null;

        protected abstract IQueryable<BaseModel> Query(ParameterExpression startParam, Expression expr);
        protected abstract int GetTotalRecord(ParameterExpression startParam, Expression expr);
        protected abstract Type GetModelType();

        private int GetTotalPage(int totalRec)
        {
            return totalRec;
        }

        private Expression ConstructWhereExpr(ParameterExpression startParam, QueryRequestParam param)
        {
            Expression expr = Expression.Constant(true);

            int idx = 0;
            foreach (var filter in param.Filters)
            {
                Expression e = null;
                var func = QueryExpression.GetExprDelegate(filter.Operator);
                e = func(startParam, filter.FieldName, filter.Value);

                if (idx == 0)
                {
                    expr = e;
                }
                else
                {
                    expr = Expression.And(expr, e);
                }

                idx++;
            }

            return expr;
        }

        private string GetOrderCommand(int idx, string orderType)
        {
            string command = "";
            if (idx <= 0)
            {
                command = "OrderBy";
                if (orderType.Equals("DESC"))
                {
                    command = "OrderByDescending";
                }                
            }
            else
            {
                command = "ThenBy";
                if (orderType.Equals("DESC"))
                {
                    command = "ThenByDescending";
                }                  
            }

            return command;
        }

        private IQueryable<BaseModel> ApplyOrderBy(IQueryable<BaseModel> query, Type type, QueryRequestParam param)
        {
            var expression = query.Expression;

            int cnt = 0;
            foreach (var order in param.OrderBy)
            {
                var parameter = Expression.Parameter(type, "m");
                string command = GetOrderCommand(cnt, order.Order);

                var property = type.GetProperty(order.FieldName);

                if (property == null)
                {
                    LogUtils.LogWarning(GetLogger(), "Property [{0} not found!!!]", order.FieldName);
                    continue;
                }

                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExpression = Expression.Lambda(propertyAccess, parameter);

                expression = Expression.Call(
                    typeof(Queryable), 
                    command, 
                    new Type[] { type, property.PropertyType },
                    expression, 
                    orderByExpression);    

                cnt++;            
            }
                                
            return query.Provider.CreateQuery<BaseModel>(expression);
        }

        public QueryResponseParam Apply(QueryRequestParam param)
        {
            queryParam = param;
            context = GetDatabaseContext();

            Type mt = GetModelType();             
            ParameterExpression startParam = Expression.Parameter(mt);
            var expr = ConstructWhereExpr(startParam, param);
            
            int totalRec = GetTotalRecord(startParam, expr);

            QueryResponseParam qrp = new QueryResponseParam();
            qrp.Results = new List<BaseModel>();

            var results = Query(startParam, expr);
            results = ApplyOrderBy(results, mt, param);

            foreach (var r in results)
            {
                qrp.Results.Add(r);
            }

            qrp.RecordCount = qrp.Results.Count;
            qrp.TotalRecord = totalRec;
            qrp.TotalPage = GetTotalPage(totalRec);

            return qrp;
        }
    }
}
