using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IRepository<T>
    {
        public Task<T> CreateAsync(T _object);

        public void Update(int id, T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int id);

        public void Delete(T _object);
    }
}
