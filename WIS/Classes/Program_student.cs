namespace WIS.Classes
{
    public class Program_student
    {
        public Program_student(string student_name, string student_contact, string student_email, string program_name)
        {
            Student_name = student_name;
            Student_contact = student_contact;
            Student_email = student_email;
            Program_name = program_name;
        }

        public string Student_name { get; set; }
        public string Student_contact { get; set; }
        public string Student_email { get; set; }
        public string Program_name { get; set; }

    }
}
