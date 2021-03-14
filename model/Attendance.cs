using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAttendance.model
{
    class Attendance
    {

        public String TeacherId { get; set; }
        public String CourseId { get; set; }
        public String RoomId { get; set; }
        public String AttendanceDate { get; set; }
        public String StartTime { get; set; }
        public String LeaveTime { get; set; }
        public String Comment { get; set; }

        public Attendance(string TeacherId, string CourseId, string RoomId, string AttendanceDate, string StartTime, string LeaveTime,string Comment)
        {
            this.TeacherId = TeacherId;
            this.CourseId = CourseId;
            this.RoomId = RoomId;
            this.AttendanceDate = AttendanceDate;
            this.StartTime = StartTime;
            this.LeaveTime = LeaveTime;
            this.Comment = Comment;
        }

    }
}
