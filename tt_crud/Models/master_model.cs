using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tt_crud.Models
{
    public partial class master_model
    {
        public int MT_ID { get; set; }
        public string MT_HN { get; set; }
        public string MT_Fname { get; set; }
        public string MT_Lname { get; set; }
        public string MT_Phone { get; set; }
        public string MT_Email { get; set; }
    }
}