namespace le0zh.Infrastructure.Data.Specification
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class NotSpecification<T> : Specification<T> where T : class
    {
        Expression<Func<T, bool>> _originalCriteria;

        public NotSpecification(ISpecification<T> originalSpecification)
        {
            if (originalSpecification == (ISpecification<T>)null)
                throw new ArgumentNullException("originalSpecification");

            _originalCriteria = originalSpecification.SatisfiedBy();
        }

        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(_originalCriteria.Body), _originalCriteria.Parameters.Single());
        }
    }
}
