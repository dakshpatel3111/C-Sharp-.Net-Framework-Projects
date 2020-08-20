using System;
using System.Collections.Generic;
using System.Printing.IndexedProperties;
using System.Runtime.CompilerServices;
using System.Text;

namespace Midterm
{
    
    class Login
    {
        public static List<Login> ulist = new List<Login>();
        private int id;
        private string username;
        private string password;
        private int superuser;
        public static Login currentuser;
        public Login(int id,string username,string password,int superuser)
        {
            Id = id;
            Username = username;
            Password = password;
            Superuser = superuser;
        }
        public Login()
        {

        }
        public int Id {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public int Superuser
        {
            get { return this.superuser; }
            set { this.superuser = value; }
        }

        public static void SetCurrentUser(Login login)
        {
            currentuser = login;
        }

        public static Login GetCurrentUSer()
        {
            return currentuser;
        }
        public static void getcredentials()
        {
       
                ulist.Add(new Login(1,"daksh","patel",1));
            ulist.Add(new Login(2, "John", "1234", 0));
            ulist.Add(new Login(3, "jack", "pass123", 1));
            ulist.Add(new Login(4, "c#", ".net", 0));
            ulist.Add(new Login(5, "java", "prog", 1));


        }
    }
}
