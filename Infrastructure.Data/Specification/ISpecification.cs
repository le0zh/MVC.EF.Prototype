namespace le0zh.Infrastructure.Data.Specification
{
    using System;
    using System.Linq.Expressions;

    public interface ISpecification<T> where T : class
    {
        Expression<Func<T, bool>> SatisfiedBy();
    }
}
