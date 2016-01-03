using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class AdminInfo
    {

        string id, name, username, email, password, permition;

        public string Permition
        {
            get { return permition; }
            set { permition = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public AdminInfo(string id, string name, string username, string password, string email, string permition)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
            this.email = email;
            this.permition = permition;
        }
    }
