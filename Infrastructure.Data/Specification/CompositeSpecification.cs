namespace le0zh.Infrastructure.Data.Specification
{
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        #region Properties

        public abstract ISpecification<TEntity> LeftSideSpecification { get; }

        public abstract ISpecification<TEntity> RightSideSpecification { get; }

        #endregion
    }
}
