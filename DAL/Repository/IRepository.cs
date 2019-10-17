using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Delete(int id);
        void Update(T newItem);
        void Create(T newItem);
    }
}
