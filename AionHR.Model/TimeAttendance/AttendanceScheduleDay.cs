using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Model.Attendance
{
    class AttendanceScheduleDay
    {
        public int scId { get; set; }
        public short dow { get; set; }
        public string firstIn { get; set; }
        public string lastOut { get; set; }
    }
}
