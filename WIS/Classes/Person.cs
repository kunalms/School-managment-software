namespace WIS.Classes
{
    public class Person
    {
        public Person(int id, string name, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.name = name;
        }

        int id { get; set; }
        string username { get; set; }
        string password { get; set; }
        string name { get; set; }


    }
}
