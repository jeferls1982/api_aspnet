using System;
using System.Web.Optimization;

namespace WEB_API_TAREFAS
{
    internal class DbContext<T> : Bundle
    {
        private Func<object, object> p;

        public DbContext(Func<object, object> p)
        {
            this.p = p;
        }
    }
}