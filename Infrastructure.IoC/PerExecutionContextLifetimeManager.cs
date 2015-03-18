using Microsoft.Practices.Unity;
using System;
using System.Web;

namespace le0zh.Infrastructure.IoC
{
    public class PerExecutionContextLifetimeManager : LifetimeManager
    {
        private Guid _key;

        public PerExecutionContextLifetimeManager() : this(Guid.NewGuid()) { }

        private PerExecutionContextLifetimeManager(Guid key)
        {
            if (key == Guid.Empty)
                throw new ArgumentException();
            _key = key;
        }

        public override object GetValue()
        {
            object result = null;

            if (HttpContext.Current != null)
            {
                var obj = HttpContext.Current.Items[_key.ToString()];
                if (obj != null)
                    result = obj;
            }

            return result;
        }

        public override void RemoveValue()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items.Contains(_key.ToString()))
                    HttpContext.Current.Items.Remove(_key.ToString());
            }
        }

        public override void SetValue(object newValue)
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items[_key.ToString()] == null)
                    HttpContext.Current.Items[_key.ToString()] = newValue;
            }
        }
    }
}
