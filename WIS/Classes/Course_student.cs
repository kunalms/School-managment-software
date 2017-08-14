namespace WIS.Classes
{
    public class Course_student
    {
        public Course_student(string student_name, string course_name, int mark1, int mark2, int mark3, string grade)
        {
            Student_name = student_name;
            Course_name = course_name;
            Mark1 = mark1;
            Mark2 = mark2;
            Mark3 = mark3;
            Grade = grade;
        }

        public string Student_name { get; set; }
        public string Course_name { get; set; }
        public int Mark1 { get; set; }
        public int Mark2 { get; set; }
        public int Mark3 { get; set; }
        public string Grade { get; set; }
    }
}
