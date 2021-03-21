using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAttendance.model
{
    class Attendance
    {

        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public Room Room { get; set; }
        public String AttendanceDate { get; set; }
        public String StartTime { get; set; }
        public String LeaveTime { get; set; }
        public String Comment { get; set; }

        public Attendance(Teacher Teacher, Course Course, Room Room, string AttendanceDate, string StartTime, string LeaveTime,string Comment)
        {
            this.Teacher = Teacher;
            this.Course = Course;
            this.Room = Room;
            this.AttendanceDate = AttendanceDate;
            this.StartTime = StartTime;
            this.LeaveTime = LeaveTime;
            this.Comment = Comment;
        }

    }
}
