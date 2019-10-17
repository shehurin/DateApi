using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ReplyLogDTO
    {
        public int Id { get; set; }
        public DateTime DateOfRequest { get; set; }
        public DateTime RequestedDateFrom { get; set; }
        public DateTime RequestedDateTo { get; set; }
        public string Result { get; set; }
    }
}
