using AcademyClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyClasses.RoleClasses
{
    public class Student : User
    {
        public string Subject { get; set; }
        public int Grade { get; set; }
        public Student(string firstName, string lastName, string userName, string password, Role role,string subject,int grade) : base(firstName, lastName, userName, password, role)
        {
            Subject = subject;
            Grade = grade;
        }
    }
}
