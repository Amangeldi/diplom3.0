using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_portal
{
    public partial class Timetable
    {
        public DateTime data { get; set; }
        public int subject_id { get; set; }
        public int teacher_id { get; set; }
        public int group_id { get; set; }

    }
}