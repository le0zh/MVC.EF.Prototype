namespace le0zh.Infrastructure.Data.Specification
{
    using System;
    using System.Linq.Expressions;

    public sealed class DirectSpecification<T> : Specification<T> where T : class
    {
        Expression<Func<T, bool>> _matchingCriteria;

        public DirectSpecification(Expression<Func<T, bool>> matchingCriteria)
        {
            if (matchingCriteria == (Expression<Func<T, bool>>)null)
                throw new ArgumentNullException("matchingCriteria");

            _matchingCriteria = matchingCriteria;
        }

        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            return _matchingCriteria;
        }
    }
}
