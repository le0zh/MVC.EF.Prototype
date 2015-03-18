namespace le0zh.Infrastructure.Data.Specification
{
    using System;
    using System.Linq.Expressions;

    public abstract class Specification<T> : ISpecification<T> where T : class
    {

        #region ISpecification<TEntity> Members

        public abstract Expression<Func<T, bool>> SatisfiedBy();

        #endregion

        public static Specification<T> operator &(Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
        {
            return new AndSpecification<T>(leftSideSpecification, rightSideSpecification);
        }

        public static Specification<T> operator |(Specification<T> leftSideSpecification, Specification<T> rightSideSpecifation)
        {
            return new OrSpecification<T>(leftSideSpecification, rightSideSpecifation);
        }

        public static Specification<T> operator !(Specification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }

        public static bool operator false(Specification<T> specification)
        {
            return false;
        }

        public static bool operator true(Specification<T> specification)
        {
            return true;
        }
    }
}
