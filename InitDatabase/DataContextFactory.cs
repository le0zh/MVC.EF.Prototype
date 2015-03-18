using le0zh.Repository;

namespace InitDatabase
{
    public sealed class DataContextFactory
    {
        private static readonly DataContext _dataContext = new DataContext("dbConStr");

        public static DataContext DataContext
        {
            get
            {
                return _dataContext;
            }
        }
    }
}
