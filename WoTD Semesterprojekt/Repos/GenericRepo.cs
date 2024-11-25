using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOutToDO.Repos
{
    public class GenericRepo<T> : IRepo<T> where T : class
    {
        private int _nextId = 1;
        private readonly List<T> _entities = new();
        private readonly Func<T, int> _idSelector;
        public GenericRepo() { }
        public GenericRepo(Func<T, int> idSelector)
        {
            _idSelector = idSelector;
        }
        public IEnumerable<T> GetAll()
        {
            return new List<T>(_entities);
        }
        public T? GetById(int id)
        {
            return _entities.FirstOrDefault(entity => _idSelector(entity) == id);
        }

        public IEnumerable<T> Get(Func<T, bool>? filter = null, Func<IEnumerable<T>, IOrderedEnumerable<T>>? orderby = null)
        {
            IEnumerable<T> result = _entities;
            if (filter != null)
            {
                result = result.Where(filter);
            }
            if (orderby != null)
            {
                result = orderby(result);
            }
            return result;

        }
        public T Add(T entity)
        {
            var idProperty = typeof(T).GetProperty("id");
            if (idProperty != null && idProperty.PropertyType == typeof(int))
            {
                idProperty.SetValue(entity, _nextId++);
            }
            _entities.Add(entity);
            return entity;
        }
        public T Update(T entity)
        {
            var id = _idSelector(entity);
            var existingEntity = GetById(id);
            if (existingEntity != null)
            {
                var index = _entities.IndexOf(existingEntity);
                _entities[index] = entity;
                return entity;
            }
            throw new KeyNotFoundException("Entity not found");
        }
        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
    }
}
