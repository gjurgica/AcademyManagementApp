using AcademyClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyClasses.RoleClasses
{
    public class Admin : User
    {
        public Admin(string firstName,string lastName,string userName,string password,Role role) : base(firstName, lastName, userName, password, role)
        {

        }
    }
}
