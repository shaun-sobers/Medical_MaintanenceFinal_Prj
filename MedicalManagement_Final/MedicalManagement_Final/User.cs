using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MedicalManagement_Final
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        

        public string generateUniqueID()
        {
            return Guid.NewGuid().ToString("N");
        }

    }



}