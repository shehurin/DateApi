using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Service
{
    public interface IService<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Delete(int id);
        T Add(T entity);
        T Update(T entity);

        IEnumerable<Diapasone> GetAllDiapasones();
        IEnumerable<Diapasone> GetMatches(string stringDateFrom, string stringDateFromDateTo);
    }
}
