using BLL.DTO;
using DAL;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ReplyLogService : IService<ReplyLogDTO>
    {
        IRepository<ReplyLog> repo;

        public ReplyLogService(IRepository<ReplyLog> repo)
        {
            this.repo = repo;
        }

        public ReplyLogDTO Add(ReplyLogDTO entity)
        {
            ReplyLog newLog = new ReplyLog
            {
                DateOfRequest = entity.DateOfRequest,
                RequestedDateFrom = entity.RequestedDateFrom,
                RequestedDateTo = entity.RequestedDateTo,
                Result = entity.Result
            };
            repo.Create(newLog);

            return entity;
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public ReplyLogDTO Get(int id)
        {
            ReplyLogDTO logDTO = new ReplyLogDTO
            {
                Result = repo.Get(id).Result,
                RequestedDateTo = repo.Get(id).RequestedDateTo,
                RequestedDateFrom = repo.Get(id).RequestedDateFrom,
                DateOfRequest = repo.Get(id).DateOfRequest,
                Id = repo.Get(id).Id
            };

            return logDTO;
        }

        public IEnumerable<ReplyLogDTO> GetAll()
        {
            return repo.GetAll().Select(x => new ReplyLogDTO
            {
                Result = x.Result,
                DateOfRequest = x.DateOfRequest,
                RequestedDateFrom = x.RequestedDateFrom,
                RequestedDateTo = x.RequestedDateTo,
                Id = x.Id
            });
        }

        public ReplyLogDTO Update(ReplyLogDTO entity)
        {
            ReplyLog newLog = new ReplyLog
            {
                Id = entity.Id,
                Result = entity.Result,
                RequestedDateFrom = entity.RequestedDateFrom,
                RequestedDateTo = entity.RequestedDateTo,
                DateOfRequest = entity.DateOfRequest
            };
            repo.Update(newLog);

            return entity;
        }

        public IEnumerable<Diapasone> GetAllDiapasones()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diapasone> GetMatches(string stringDateFrom, string stringDateFromDateTo)
        {
            throw new NotImplementedException();
        }
    }
}
