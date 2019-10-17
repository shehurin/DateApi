using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReplyLogRepository : IRepository<ReplyLog>
    {
        DateDB db = new DateDB();

        public void Create(ReplyLog newItem)
        {
            db.ReplyLog.Add(newItem);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.ReplyLog.Remove(Get(id));
            db.SaveChanges();
        }

        public ReplyLog Get(int id)
        {
            return db.ReplyLog.Find(id);
        }

        public IEnumerable<ReplyLog> GetAll()
        {
            return db.ReplyLog.ToList();
        }

        public void Update(ReplyLog newItem)
        {
            db.ReplyLog.AddOrUpdate(newItem);
            db.SaveChanges();
        }
    }
}
