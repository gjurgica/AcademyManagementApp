using AcademyClasses.Enums;
using AcademyClasses.RoleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose your role:\n1.Admin\n2.Trainer\n3.Student");
            string userRole = Console.ReadLine();
            Methods MyMethods = new Methods();
            List<Admin> Administrators = GenerateUsers.Admins();
            List<Trainer> Trainers = GenerateUsers.Trainers();
            List<Student> Students = GenerateUsers.Students();
            List<User> Users = new List<User>();
            Users.AddRange(Administrators);
            Users.AddRange(Trainers);
            Users.AddRange(Students);
            string check;
            try
            {
                if(userRole == "1"){
                    check = MyMethods.CheckValidations(Methods.UserName(), Methods.Pass(), Users,Methods.CheckRole(userRole));
                    if(check == "Successful logIn")
                    {
                        Console.WriteLine("\n1.Add\n2.Remove");
                        string addOrRemove = Console.ReadLine();
                        try
                        {
                            if(addOrRemove == "1"){
                                Console.WriteLine("Choose the list:\n1.Admins\n2.Trainers\n3.Students");
                                string list = Console.ReadLine();
                                MyMethods.AddUser();
                            }
                            else if(addOrRemove == "2")
                            {
                                Console.WriteLine("Choose the list:\n1.Admins\n2.Trainers\n3.Students");
                                string list = Console.ReadLine();
                                Methods.ListsOfUsers(Users, list);
                                MyMethods.RemoveUser(Users);
                                
                            }
                            else
                            {
                                throw new Exception("Please choose 1 or 2");
                            }

                        }catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nice try");
                    }

                }
                else if(userRole == "2")
                {
                    var answer = MyMethods.CheckValidations(Methods.UserName(), Methods.Pass(), Users, Methods.CheckRole(userRole));
                    if(answer == "Successful logIn")
                    {
                        Console.WriteLine("\n1.Students\n2.Subjects");
                        string studentOrSubject = Console.ReadLine();
                        MyMethods.ShowLists(Students, studentOrSubject);
                    }
                    else
                    {
                        Console.WriteLine("You don't exist in this list");
                    }
                }
                else if (userRole == "3")
                {
                    Console.WriteLine(MyMethods.StudentsInfo(MyMethods.CheckValidations(Methods.UserName(),Methods.Pass(),Users, Methods.CheckRole(userRole))));
                   
                }
                else
                {
                    throw new Exception("Please enter a number from 1 to 3");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

    }
}
