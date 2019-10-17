using BLL.DTO;
using BLL.Service;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DateApi.Controllers
{
    public class DateWebApiController : ApiController
    {
        IService<DateDTO> dates;
        IService<ReplyLogDTO> log;

        public DateWebApiController(IService<DateDTO> dates, IService<ReplyLogDTO> log)
        {
            this.dates = dates;
            this.log = log;
        }

        // GET api/<controller>
        public IEnumerable<Diapasone> Get()
        {
            return dates.GetAllDiapasones();
        }

        //2. Принимает интервал дат (две даты с-по) и возвращает список интервалов,
        //   которые были сохранены с помощью первого веб-метода и пересекаются с ним
        //  +Логирование в базу запросов – ответов 
        // GET api/date1/date2
        public HttpResponseMessage Get(string firstParam, string secondParam)
        {
            IEnumerable<Diapasone> searchedDates = dates.GetMatches(firstParam, secondParam);

            if (searchedDates.Count() > 0)
            {
                foreach(var i in searchedDates)
                {
                    log.Add(new ReplyLogDTO
                    {
                        Result = $"{i.From}/{i.To}",
                        DateOfRequest = DateTime.Now,
                        RequestedDateFrom = Convert.ToDateTime(firstParam),
                        RequestedDateTo = Convert.ToDateTime(secondParam)
                    });
                }
            }
            else
            {
                log.Add(new ReplyLogDTO
                {
                    Result = "",
                    DateOfRequest = DateTime.Now,
                    RequestedDateFrom = Convert.ToDateTime(firstParam),
                    RequestedDateTo = Convert.ToDateTime(secondParam)
                });
            }

            return Request.CreateResponse(HttpStatusCode.OK, searchedDates);
        }

        //1. Принимает интервал дат (две даты с-по) и сохраняет их в базе данных
        // POST api/date1/date2
        public HttpResponseMessage Post(string firstParam, string secondParam)
        {
            dates.Add(new DateDTO { DateFrom = Convert.ToDateTime(firstParam), DateTo = Convert.ToDateTime(secondParam) });

            return Request.CreateResponse(HttpStatusCode.OK);
        }





        // PUT api/<controller>/5
        public void Put(int id, [FromBody]DateDTO value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            dates.Delete(id);
        }
    }
}