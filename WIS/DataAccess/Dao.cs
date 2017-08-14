using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WIS.Classes;

namespace WIS.DataAccess
{
    class Dao
    {
        private String configuration = "Data Source=DESKTOP-QR3BNEV; Initial Catalog=WIS; Integrated Security=true;";
        public SqlConnection connection;
        public Dao()
        {
            connection = new SqlConnection(configuration);
            if (connection != null)
                connection.Close();
            connection.Open();
        }

        public Student_program Student_login(string Username, string Password)
        {
            SqlCommand cmd = new SqlCommand("Login_student", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            DataTable dt = new DataTable("Users");
            dt.Load(dr);
            if (dt.Rows.Count == 1)
            {
                Student_program student = new Student_program((int)dt.Rows[0]["Student_id"], dt.Rows[0]["Student_name"].ToString(), dt.Rows[0]["Student_username"].ToString(), dt.Rows[0]["Student_password"].ToString(), dt.Rows[0]["Student_father"].ToString(), dt.Rows[0]["Student_mother"].ToString(), dt.Rows[0]["Student_past_course"].ToString(), (int)dt.Rows[0]["Student_contact"], dt.Rows[0]["Student_email"].ToString(), (int)dt.Rows[0]["Student_sibling"], (int)dt.Rows[0]["Student_program"]);
                return student;
            }
            else
            {
                return null;
            }
        }

        public Employee Employee_login(string Username, string Password)
        {
            SqlCommand cmd = new SqlCommand("Login_employee", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            DataTable dt = new DataTable("Users");
            dt.Load(dr);
            if (dt.Rows.Count == 1)
            {
                Employee employee = new Employee((int)dt.Rows[0]["Employee_id"], dt.Rows[0]["Employee_name"].ToString(), dt.Rows[0]["Employee_username"].ToString(), dt.Rows[0]["Employee_password"].ToString(), dt.Rows[0]["Employee_role"].ToString(), (int)dt.Rows[0]["Employee_function"], (int)dt.Rows[0]["Employee_enable"], dt.Rows[0]["Employee_Address"].ToString(), (int)dt.Rows[0]["Employee_number"], dt.Rows[0]["Employee_email"].ToString());
                return employee;
            }
            else
            {
                return null;
            }
        }

        public bool AddStudent(Student_program student)
        {
            string query = "INSERT INTO Student ([Student_name],[Student_father],[Student_mother],[Student_username],[Student_password],[Student_past_course],[Student_contact],[Student_email],[Student_sibling],[Student_program])VALUES('" + student.Student_name + "','" + student.Student_father + "','" + student.Student_mother + "','" + student.Student_username + "','" + student.Student_password + "','" + student.Student_past_course + "','" + student.Student_contact + "','" + student.Student_email + "','" + student.Student_sibling + "','" + student.Student_programs + "')";
            SqlCommand cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number_course = cmd1.ExecuteNonQuery();
            return (number_course == 1);
        }
        public bool DeleteStudent(Student_program student)
        {
            string query = "DELETE FROM [dbo].[Favourite_student] WHERE [Student_id]='" + student.Student_id.ToString() + "'";
            SqlCommand cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number_course = cmd1.ExecuteNonQuery();

            query = "DELETE FROM [dbo].[Student_course] WHERE Student_id ='" + student.Student_id.ToString() + "'";
            cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            cmd1.ExecuteNonQuery();
            query = "DELETE FROM [dbo].[Favourite_student] WHERE Student_id ='" + student.Student_id.ToString() + "'";
            cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            cmd1.ExecuteNonQuery();
            query = "DELETE FROM [dbo].[Student] WHERE Student_id ='" + student.Student_id.ToString() + "'";
            cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number = cmd1.ExecuteNonQuery();

            //MessageBox.Show("number:" + number + "\n number_course:" + number_course);

            return (number > 0);


        }

        public List<Program_student> FetchStudentbyProg()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            List<Program_student> list = new List<Program_student>();

            cmd.CommandText = "SELECT Student.Student_name, Student.Student_contact, Student.Student_email, Program.Program_name FROM Program INNER JOIN Student ON Program.Program_id = Student.Student_program ORDER BY Program.Program_name";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this.connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Program_student tmp = new Program_student(reader["Student_name"].ToString(), reader["Student_contact"].ToString(), reader["Student_email"].ToString(), reader["Program_name"].ToString());
                list.Add(tmp);
            }

            return list;
        }

        public List<Course_student> FetchStudentbyCourse()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            List<Course_student> list = new List<Course_student>();

            cmd.CommandText = "SELECT Course.Couse_name, Student.Student_name, Student_course.Marks_1, Student_course.Marks_2, Student_course.Marks_3, Student_course.Grade FROM Course INNER JOIN Student_course ON Course.Course_id = Student_course.Course_id INNER JOIN Student ON Student_course.Student_id = Student.Student_id order by Course.Couse_name";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this.connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Course_student tmp = new Course_student(reader["Student_name"].ToString(), reader["Couse_name"].ToString(), (int)reader["Marks_1"], (int)reader["Marks_2"], (int)reader["Marks_3"], reader["Grade"].ToString());
                list.Add(tmp);
            }

            return list;
        }

        public bool CloseConnection()
        {
            if (connection != null)
                this.connection.Close();
            connection = null;
            return true;
        }

        public bool AddCourse(Course course)
        {
            string query = "INSERT INTO [dbo].[Course] ([Couse_name],[Credits],[Fee],[Prerequsite],[Program_id]) VALUES ('" + course.Couse_name + "','" + course.Credits + "','" + course.Fee + "','" + course.Prerequsite + "','" + course.Program_id + "')";

            SqlCommand cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number_course = cmd1.ExecuteNonQuery();

            return (number_course == 1);
        }

        public Course FetchCourse(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            Course tmp;
            cmd.CommandText = "SELECT * from Course where Course_id=" + id.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this.connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tmp = new Course((int)reader[0], reader[1].ToString(), (int)reader[2], (int)reader[3], reader[4].ToString(), (int)reader[5]);
                //MessageBox.Show(tmp.Couse_name);
                return tmp;
            }

            return null;
        }

        public int UpdateCourse(Course course)
        {
            string query = "UPDATE[dbo].[Course] SET[Couse_name] = '" + course.Couse_name + "',[Credits] = '" + course.Credits + "',[Fee] = '" + course.Fee + "',[Prerequsite] ='" + course.Prerequsite + "',[Program_id] = '" + course.Program_id + "' WHERE Course_id = '" + course.Course_id + "'";
            SqlCommand cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number_course = cmd1.ExecuteNonQuery();

            return number_course;
        }


        public int UpdateEployee(Employee emp)
        {
            string query = "UPDATE [dbo].[Employee] SET [Employee_name] = '" + emp.Employee_name + "',[Employee_role] = '" + emp.Employee_role + "',[Employee_function] = '" + emp.Employee_function + "',[Employee_enable] = '" + emp.Employee_enable + "',[Employee_Address] = '" + emp.Employee_Address + "',[Employee_number] = '" + emp.Employee_number + "',[Employee_username] = '" + emp.Employee_username + "',[Employee_password] = '" + emp.Employee_password + "',[Employee_email] ='" + emp.Employee_email + "'  WHERE Employee_id='" + emp.Employee_id + "'";
            SqlCommand cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number_emp = cmd1.ExecuteNonQuery();

            return number_emp;
        }

        public int UpdateMarks(string name, string course, int Marks_1, int Marks_2, int Marks_3, string grade)
        {
            string query = "UPDATE [dbo].[Student_course] SET [Marks_1] = '" + Marks_1 + "',[Marks_2] = '" + Marks_2 + "',[Marks_3] = '" + Marks_3 + "',[Grade] = '" + grade + "' WHERE Student_id='" + name + "' and Course_id='" + course + "'";
            SqlCommand cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int stude = cmd1.ExecuteNonQuery();

            return stude;
        }

        public bool AddEmployee(Employee emp)
        {
            string query = "INSERT INTO [dbo].[Employee] ([Employee_name],[Employee_role],[Employee_function],[Employee_enable],[Employee_Address] ,[Employee_number],[Employee_username],[Employee_password],[Employee_email]) VALUES('" + emp.Employee_name + "','" + emp.Employee_role + "','" + emp.Employee_function + "','" + emp.Employee_enable + "','" + emp.Employee_Address + "','" + emp.Employee_number + "','" + emp.Employee_username + "','" + emp.Employee_password + "','" + emp.Employee_email + "')";
            SqlCommand cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number_course = cmd1.ExecuteNonQuery();
            return (number_course == 1);
        }

        public bool DeleteLecturer(int id)
        {
            string query = "DELETE FROM [Employee_course] WHERE [Employee_id]='" + id + "'";
            SqlCommand cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number_course = cmd1.ExecuteNonQuery();

            query = "DELETE FROM [Employee] WHERE Employee_id='" + id + "'";
            cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number = cmd1.ExecuteNonQuery();

            //MessageBox.Show("number:" + number + "\n number_course:" + number_course);

            return (number > 0);

        }


        public int UpdateStudent(Student_program stu)
        {
            string query = "UPDATE [dbo].[Student] SET [Student_name] = '" + stu.Student_name + "',[Student_father] = '" + stu.Student_father + "',[Student_mother] = '" + stu.Student_mother + "',[Student_username] = '" + stu.Student_username + "',[Student_password] = '" + stu.Student_password + "',[Student_past_course] = '" + stu.Student_past_course + "',[Student_contact] = '" + stu.Student_contact + "',[Student_email] = '" + stu.Student_email + "',[Student_sibling] = '" + stu.Student_sibling + "',[Student_program] = '" + stu.Student_programs + "' WHERE Student_id='" + stu.Student_id + "'";
            SqlCommand cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number_emp = cmd1.ExecuteNonQuery();

            return number_emp;
        }

        public bool AddGrade(int stud_id, int course_id, int m1, int m2, int m3, string grade)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * from Student_course where Course_id=" + course_id + " and Student_id='" + stud_id + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this.connection;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return false;
            }
            else
            {
                reader.Close();
                string query = "INSERT INTO [dbo].[Student_course] ([Student_id],[Course_id],[Marks_1],[Marks_2],[Marks_3],[Grade]) VALUES('" + stud_id + "','" + course_id + "','" + m1 + "','" + m2 + "','" + m3 + "','" + grade + "')";
                SqlCommand cmd1 = new SqlCommand(query);
                cmd1.Connection = this.connection;
                int number_course = cmd1.ExecuteNonQuery();
                return (number_course == 1);
            }
        }

        public bool AddFavourite(int student, int course)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT[Course_id],[Student_id]FROM[WIS].[dbo].[Favourite_student] where Course_id=" + course.ToString() + " and Student_id='" + student + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this.connection;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return false;
            }
            else
            {
                reader.Close();
                string query = "INSERT INTO [dbo].[Favourite_student] ([Course_id],[Student_id]) VALUES ('" + course.ToString() + "','" + student.ToString() + "')";
                SqlCommand cmd1 = new SqlCommand(query);
                cmd1.Connection = this.connection;
                int number_course = cmd1.ExecuteNonQuery();
                return (number_course == 1);
            }

        }

        public bool DeleteFavourite(int student, int course)
        {
            string query = "DELETE FROM Favourite_student WHERE Course_id=" + course.ToString() + " and Student_id='" + student + "'";
            SqlCommand cmd1 = new SqlCommand(query);
            cmd1.Connection = this.connection;
            int number_course = cmd1.ExecuteNonQuery();
            return (number_course > 0);

        }


        public Student_program FetchStudentbyID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            Student_program stud;
            cmd.CommandText = "SELECT * FROM Student where Student_id ='" + id.ToString() + "' ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this.connection;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student_program tmp = new Student_program((int)reader["Student_id"], reader["Student_name"].ToString(), reader["Student_username"].ToString(), reader["Student_password"].ToString(), reader["Student_father"].ToString(), reader["Student_mother"].ToString(), reader["Student_past_course"].ToString(), (int)reader["Student_contact"], reader["Student_email"].ToString(), (int)reader["Student_sibling"], (int)reader["Student_program"]);
                return tmp;
            }

            return null;
        }

    }
}
