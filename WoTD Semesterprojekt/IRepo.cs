using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOutToDO
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        IEnumerable<T> Get(Func<T, bool>? Filter = null, Func<IEnumerable<T>, IOrderedEnumerable<T>>? orderBy = null);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

    }
}
