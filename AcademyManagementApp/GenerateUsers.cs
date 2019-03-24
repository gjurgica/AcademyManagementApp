using AcademyClasses.Enums;
using AcademyClasses.RoleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagementApp
{
    public class GenerateUsers
    {
        public static List<Admin> Admins()
        {
            return new List<Admin>
            {
                new Admin("Dejan","Blazevski","deko","444d",Role.Admin)
            };
        }
        public static List<Trainer> Trainers()
        {
            return new List<Trainer>
            {
                new Trainer("Igor","Mitkovski","ige","ig33",Role.Trainer),
                new Trainer("Dragan","Gelevski","drakso","drag77",Role.Trainer),
                new Trainer("Riste","Tegovski","rici","rik8",Role.Trainer)           
            };
        }
        public static List<Student> Students()
        {
            return new List<Student>
            {
                new Student("Gjurgica","Anastasovska","gjurgica","g123",Role.Student,"c#",5),
                new Student("Stefan","Stefanovski","stefan","stef4",Role.Student,"Java Script",5),
                new Student("Mario","Dedic","mario","mar2",Role.Student,"Java Script",4),
                new Student("Zorica","Aleksova","zorica","zoc66",Role.Student,"CSS",4),
                new Student("Dalibor","Mladenovski","dalibor","dali9",Role.Student,"c#",5)
            };
        }

    }
}
