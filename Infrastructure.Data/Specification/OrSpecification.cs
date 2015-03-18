namespace le0zh.Infrastructure.Data.Specification
{
    using System;
    using System.Linq.Expressions;

    public class OrSpecification<T> : CompositeSpecification<T> where T : class
    {
        private ISpecification<T> _leftSideSpecification;
        private ISpecification<T> _rightSideSpecification;

        public override ISpecification<T> LeftSideSpecification
        {
            get { return _leftSideSpecification; }
        }

        public override ISpecification<T> RightSideSpecification
        {
            get { return _rightSideSpecification; }
        }

        public OrSpecification(ISpecification<T> leftSideSpecification, ISpecification<T> rightSideSpecification)
        {
            this._leftSideSpecification = leftSideSpecification;
            this._rightSideSpecification = rightSideSpecification;
        }

        public override System.Linq.Expressions.Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = _leftSideSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = _rightSideSpecification.SatisfiedBy();

            return left.Or(right);
        }
    }
}
