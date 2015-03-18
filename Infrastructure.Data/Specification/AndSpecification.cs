namespace le0zh.Infrastructure.Data.Specification
{
    using System;
    using System.Linq.Expressions;

    public sealed class AndSpecification<T> : CompositeSpecification<T> where T : class
    {
        private Specification<T> _leftSideSpecification;
        private Specification<T> _rightSideSpecification;

        public override ISpecification<T> LeftSideSpecification
        {
            get { return _leftSideSpecification; }
        }

        public override ISpecification<T> RightSideSpecification
        {
            get { return _rightSideSpecification; }
        }

        public AndSpecification(Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
        {
            if (leftSideSpecification == (ISpecification<T>)null)
                throw new ArgumentNullException("leftSideSpecification");

            if (rightSideSpecification == (ISpecification<T>)null)
                throw new ArgumentNullException("rightSideSpecification");

            this._leftSideSpecification = leftSideSpecification;
            this._rightSideSpecification = rightSideSpecification;
        }

        public override System.Linq.Expressions.Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = _leftSideSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = _rightSideSpecification.SatisfiedBy();

            return left.And(right);
        }
    }
}
