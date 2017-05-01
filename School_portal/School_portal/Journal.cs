using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_portal
{
    public class Journal
    {
        public int journal_id { get; set; }
        public int groupp_id { get; set; }
        public int student_ticket_number { get; set; }
        public int teacher_id { get; set; }
        public int grade { get; set; }
        public DateTime date_a { get; set; }
        public DateTime date_b { get; set; }
        public string note { get; set; }


    }
}