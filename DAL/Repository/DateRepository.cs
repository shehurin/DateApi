using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DateRepository : IRepository<Dates>
    {
        DateDB db = new DateDB();

        public void Create(Dates newItem)
        {
            db.Dates.Add(newItem);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Dates.Remove(Get(id));
            db.SaveChanges();
        }

        public Dates Get(int id)
        {
            return db.Dates.Find(id);
        }

        public IEnumerable<Dates> GetAll()
        {
            return db.Dates.ToList();
        }

        public void Update(Dates newItem)
        {
            db.Dates.AddOrUpdate(newItem);
            db.SaveChanges();
        }
    }
}
