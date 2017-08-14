namespace WIS.Classes
{
    public class Student_program : Person
    {
        public Student_program(int id, string name, string username, string password, string student_father, string student_mother, string student_past_course, int student_contact, string student_email, int student_sibling, int student_program) : base(id, name, username, password)
        {
            Student_id = id;
            Student_name = name;
            Student_username = username;
            Student_password = password;
            Student_father = student_father;
            Student_mother = student_mother;
            Student_past_course = student_past_course;
            Student_contact = student_contact;
            Student_email = student_email;
            Student_sibling = student_sibling;
            Student_programs = student_program;
        }

        public int Student_id { get; set; }
        public string Student_name { get; set; }
        public string Student_username { get; set; }
        public string Student_password { get; set; }
        public string Student_father { get; set; }
        public string Student_mother { get; set; }
        public string Student_past_course { get; set; }
        public int Student_contact { get; set; }
        public string Student_email { get; set; }
        public int Student_sibling { get; set; }
        public int Student_programs { get; set; }


    }
}
