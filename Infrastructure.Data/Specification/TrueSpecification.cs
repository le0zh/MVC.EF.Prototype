namespace le0zh.Infrastructure.Data.Specification
{
    using System;
    using System.Linq.Expressions;

    public sealed class TrueSpecification<T> : Specification<T> where T : class
    {
        public override System.Linq.Expressions.Expression<Func<T, bool>> SatisfiedBy()
        {
            bool result = true;
            Expression<Func<T, bool>> trueExpression = t => result;
            return trueExpression;
        }
    }
}
