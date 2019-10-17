namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReplyLog
    {
        public int Id { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime DateOfRequest { get; set; }

        [Column(TypeName = "date")]
        public DateTime RequestedDateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime RequestedDateTo { get; set; }

        public string Result { get; set; }
    }
}
