using AcademyClasses.Enums;
using AcademyClasses.RoleClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagementApp
{
    public class Methods
    {
        public static string UserName()
        {
            string userName = "";
            Console.WriteLine("Enter your user name");
            userName = Console.ReadLine();
            return userName;
        }
        public static string Pass()
        {
            string password = "";
            Console.WriteLine("Enter your password");
            password = Console.ReadLine();
            return password;
        }
        public string  CheckValidations(string name,string pass,List<User> users,Role role)
        {
            try
            {
                var adminRole = users.Where(user => user.Role == Role.Admin).ToList();
                var trainerRole = users.Where(user => user.Role == Role.Trainer).ToList();
                var studentRole = users.Where(user => user.Role == Role.Student).ToList();
                foreach (var user in users)
                {
                    if (name == user.UserName && pass == user.Password && role == user.Role)
                    {
                        return "Successful logIn";
                    }
                }
                return "Invalid data";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public static Role CheckRole(string role)
        {
            if(role == "1")
            {
                return Role.Admin;
            }else if(role == "2")
            {
                return Role.Trainer;
            }else
            {
                return Role.Student;
            }
        }
        public static Role  ListsOfUsers(List<User> users,string list)
        {
            int count = 1;
                if (list == "1")
                {
                    Console.WriteLine("\nAdmins:");
                    var adminRole = users.Where(user => user.Role == Role.Admin).ToList();
                    foreach(var user in adminRole)
                    {
                        Console.WriteLine($"{count++}.{user.FirstName} {user.LastName}");
                    }
                    return Role.Admin;
                }
                else if (list == "2")
                {
                    Console.WriteLine("\nTrainers:");
                    var trainerRole = users.Where(user => user.Role == Role.Trainer).ToList();
                    foreach (var user in trainerRole)
                    {
                        Console.WriteLine($"{count++}.{user.FirstName} {user.LastName}");
                    }
                    return Role.Trainer;
                }
                else if (list == "3")
                {
                    Console.WriteLine("\nStudents:");
                    var studentRole = users.Where(user => user.Role == Role.Student).ToList();
                    foreach (var user in studentRole)
                    {
                        Console.WriteLine($"{count++}.{user.FirstName} {user.LastName}");
                    }
                    return Role.Student;
                }
                else
                {
                    throw new Exception("Please enter a nuber from 1 to 3");
                }
            
        }
        public void AddUser()
        {
            Console.WriteLine("Enter a first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter a last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter a user name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter a password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter a role");
            string stringRole = Console.ReadLine();
            if (stringRole== "admin")
            {
                Admin added = new Admin(firstName, lastName, userName, password, Role.Admin);
            }
            else if (stringRole == "trainer")
            {
                Trainer added = new Trainer(firstName, lastName, userName, password, Role.Trainer);
            }
            else if (stringRole == "student")
            {
                Console.WriteLine("Enter a subject");
                string subject = Console.ReadLine();
                Console.WriteLine("Enter a grade");
                string grade = Console.ReadLine();
                int convertGrade = int.Parse(grade);
                Student added = new Student(firstName, lastName, userName, password, Role.Student, subject, convertGrade);
            }
        }
        public void RemoveUser(List<User> users)
        {
            Console.WriteLine("Enter a password of user who would be removed");
            string removed = Console.ReadLine();
            foreach(var user in users)
            {
                if(removed == user.Password)
                {
                    users.Remove(user);
                }
            }
        }
        public void ShowLists(List<Student> students,string show)
        {
            int count = 1;
            try
            {
                if (show == "1")
                {
                    foreach(var student in students)
                    {
                        Console.WriteLine($"{count++} {student.FirstName} {student.LastName}");
                    }
                    Console.WriteLine("Enter a name of student");
                    string name = Console.ReadLine();
                    foreach(var student in students)
                    {
                        if(name == student.FirstName)
                        {
                            Console.WriteLine(student.Subject);
                        }
                    }
                }
                else if (show == "2")
                {
                    Dictionary<string,int> subjects = new Dictionary<string, int>();
                    foreach(var student in students)
                    {
                        if (!student.Subject.Contains(student.Subject))
                        {
                            subjects.Add(student.Subject, 1);
                        }
                        else
                        {
                            int num = 0;
                            subjects.TryGetValue(student.Subject, out num);
                            subjects.Remove(student.Subject);
                            subjects.Add(student.Subject, num + 1);
                        }
                    }
                    foreach (KeyValuePair<string, int> entry in subjects)
                    {
                        Console.WriteLine(entry.Key + " - " + entry.Value);
                    }
                }
                else
                {
                    throw new Exception("Please choose beetwin 1 or 2");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string StudentsInfo(string users)
        {
            var pass = Pass();
            foreach (var student in GenerateUsers.Students())
            {
                if (student.Password == pass)
                {
                    return $"{student.Subject} - {student.Grade}";
                }
            }
            throw new Exception("This student didn't exist in this academy");
            
        }
    }
}
