using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherAttendance.helper;
using TeacherAttendance.model;

namespace TeacherAttendance
{
    public partial class frmTeacherAttendance : Form
    {
        private AttendanceManagement attendance;
        private BindingSource bindingSource = new BindingSource();


        public frmTeacherAttendance()
        {
            InitializeComponent();
        }

        private void FrmTeacherAttendance_Load(object sender, EventArgs e)
        {
            attendance = new AttendanceManagement();
            ShowCourses();
            ShowTeachers();
            ShowRooms();
            edit.Enabled = false;
        }

        /*private void CmbCourses_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }*/

        private void ShowCourses()
        {
            cmbCourses.DataSource = null;
            cmbCourses.DisplayMember = "CourseName";
            cmbCourses.ValueMember = "CourseId";
            cmbCourses.DataSource = attendance.getAllCourses();
            cmbCourses.SelectedIndex = -1;
        }

        private void ShowTeachers()
        {
            cmbTeacherName.DataSource = null;
            cmbTeacherName.DisplayMember = "TeacherName";
            cmbTeacherName.ValueMember = "TeacherId";
            cmbTeacherName.DataSource = attendance.getAllTeachers();
            cmbTeacherName.SelectedIndex = -1;

        }

        private void ShowRooms()
        {
            cmbRoom.DataSource = null;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomId";
            cmbRoom.DataSource = attendance.getAllRooms();
            cmbRoom.SelectedIndex = -1;

        }
        private void CmbCourses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            

            string value = "";
            

            int id = ((Course)((ComboBox)sender).SelectedItem).CourseId;

            if(id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New course", "New course name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewCourse(value.Trim());
                    ShowCourses();
                }


            }
        }

        private void CmbTeacherName_SelectionChangeCommitted(object sender, EventArgs e)
        {


            string value = "";


            int id = ((Teacher)((ComboBox)sender).SelectedItem).TeacherId;

            if (id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New teacher", "New teacher name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewTeacher(value.Trim());
                    ShowTeachers();
                }


            }


        }

        private void CmbRoom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string value = "";


            int id = ((Room)((ComboBox)sender).SelectedItem).RoomId;

            if (id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New Room/Lab", "New Room/Lab name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewRoom(value.Trim());
                    ShowRooms();
                }


            }

        }

        private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*dGVEmployeeList.Rows.Add(txtId.Text, 
                         txtFirstName.Text,
                         txtLastName.Text, 
                         txtBirthDate.Text, 
                         txtAddress.Text,
                         deptComboBox.Text); */

            dataGridView1.DataSource = null;
            attendance.addAttendance(
                                    (Teacher)cmbTeacherName.SelectedItem,
                                    (Course)cmbCourses.SelectedItem,
                                    (Room)cmbRoom.SelectedItem,
                                    attendanceDate.Value.ToString(),
                                    startTime.Value.ToString(),
                                    leaveTime.Value.ToString(),
                                    textBox2.Text);

            bindingSource.DataSource = attendance.getAllAttendance();
            dataGridView1.DataSource = bindingSource;
          

        }


        public void clearFields()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(ComboBox))
                {
                    ctrl.Text = "";
                }
            }
        }

      
    
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            Attendance current = attendance.getAttendanceByIndex(index);
            cmbTeacherName.SelectedItem = current.Teacher;
            cmbRoom.SelectedItem = current.Room;
            cmbCourses.SelectedItem = current.Course;
            attendanceDate.Value = Convert.ToDateTime(current.AttendanceDate);
            startTime.Value = Convert.ToDateTime(current.StartTime);
            leaveTime.Value = Convert.ToDateTime(current.LeaveTime);
            textBox2.Text = current.Comment;

            edit.Enabled = true;


        }

        private void edit_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            dataGridView1.DataSource = null;

            Attendance current = attendance.getAttendanceByIndex(index);
            current.Teacher =(Teacher) cmbTeacherName.SelectedItem;
            current.Room = (Room) cmbRoom.SelectedItem;
            current.Course = (Course)  cmbCourses.SelectedItem;
            current.AttendanceDate = attendanceDate.Value.ToString();
            current.StartTime = startTime.Value.ToString();
            current.LeaveTime = leaveTime.Value.ToString();
            current.Comment = textBox2.Text ;
            bindingSource.DataSource = attendance.getAllAttendance();
            dataGridView1.DataSource = bindingSource;

        }
    }
}
