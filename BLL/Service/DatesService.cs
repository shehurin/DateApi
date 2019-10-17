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
    public class DatesService : IService<DateDTO>
    {
        IRepository<Dates> repo;

        public DatesService(IRepository<Dates> repo)
        {
            this.repo = repo;
        }

        public DateDTO Add(DateDTO entity)
        {
            Dates newDates = new Dates
            {
                DateFrom = entity.DateFrom,
                DateTo = entity.DateTo
            };
            repo.Create(newDates);

            return entity;
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public DateDTO Get(int id)
        {
            DateDTO dateDTO = new DateDTO
            {
                DateFrom = repo.Get(id).DateFrom,
                DateTo = repo.Get(id).DateTo,
                Id = repo.Get(id).Id
            };

            return dateDTO;
        }

        public IEnumerable<DateDTO> GetAll()
        {
            return repo.GetAll().Select(x => new DateDTO
            {
                DateFrom = x.DateFrom,
                DateTo = x.DateTo,
                Id = x.Id
            });
        }

        public DateDTO Update(DateDTO entity)
        {
            Dates newDates = new Dates
            {
                Id = entity.Id,
                DateFrom = entity.DateFrom,
                DateTo = entity.DateTo
            };
            repo.Update(newDates);

            return entity;
        }

        public IEnumerable<Diapasone> GetAllDiapasones()
        {
            List<Diapasone> list = new List<Diapasone>();

            return repo.GetAll().Select(x => new Diapasone
            {
                From = x.DateFrom.Date.ToString("yyyy'-'MM'-'dd"),
                To = x.DateTo.Date.ToString("yyyy'-'MM'-'dd")
            });
        }

        public IEnumerable<Diapasone> GetMatches(string stringDateFrom, string stringDateFromDateTo)
        {
            DateTime dateFrom = Convert.ToDateTime(stringDateFrom);
            DateTime dateTo = Convert.ToDateTime(stringDateFromDateTo);

            List<Diapasone> list = new List<Diapasone>();

            foreach (var i in repo.GetAll())
            {
                if ((dateFrom >= i.DateFrom && dateFrom <= i.DateTo) || (dateTo >= i.DateFrom && dateTo <= i.DateTo) )
                    list.Add(new Diapasone { From = i.DateFrom.Date.ToString("yyyy'-'MM'-'dd"),
                                             To = i.DateTo.Date.ToString("yyyy'-'MM'-'dd") });
            }

            return list;
        }

    }
}
