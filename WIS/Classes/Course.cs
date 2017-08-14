namespace WIS.Classes
{
    public class Course
    {
        public Course(int course_id, string couse_name, int credits, int fee, string prerequsite, int program_id)
        {
            Course_id = course_id;
            Couse_name = couse_name;
            Credits = credits;
            Fee = fee;
            Prerequsite = prerequsite;
            Program_id = program_id;
        }

        public int Course_id { get; set; }
        public string Couse_name { get; set; }
        public int Credits { get; set; }
        public int Fee { get; set; }
        public string Prerequsite { get; set; }
        public int Program_id { get; set; }
    }
}
