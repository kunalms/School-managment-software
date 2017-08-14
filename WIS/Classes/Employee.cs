namespace WIS.Classes
{
    public class Employee : Person
    {
        public Employee(int id, string name, string username, string password, string employee_role, int employee_function, int employee_enable, string employee_Address, int employee_number, string employee_email) : base(id, name, username, password)
        {
            Employee_role = employee_role;
            Employee_function = employee_function;
            Employee_enable = employee_enable;
            Employee_Address = employee_Address;
            Employee_number = employee_number;
            Employee_id = id;
            Employee_name = name;
            Employee_username = username;
            Employee_password = password;
            Employee_email = employee_email;
        }


        public string Employee_role { get; set; }
        public int Employee_function { get; set; }
        public int Employee_enable { get; set; }
        public string Employee_Address { get; set; }
        public int Employee_number { get; set; }
        public int Employee_id { get; set; }
        public string Employee_name { get; set; }
        public string Employee_username { get; set; }
        public string Employee_password { get; set; }
        public string Employee_email { get; set; }

    }
}
