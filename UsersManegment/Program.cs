using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManegment.DataStorage;
using UsersManegment.Services;

namespace UsersManegment
{
    class Program
    {
        public static DataStorageRepository DSR ;
        public Program()
        {
            DSR = new DataStorageRepository();
        }
        static void Main(string[] args)
        {
            EntryPoint();
        }


        private static void EntryPoint()
        {
            bool menuFlag;
            string menuInput = "";

            Console.Clear();
            Console.WriteLine(":: Wellcome to UserMenegment system ::");
            Console.WriteLine();
            Console.WriteLine(" -> Main Menu ");
            Console.WriteLine("[1]. Insert new user");
            Console.WriteLine("[2]. Show useres list");
            Console.WriteLine("[3]. Edite user info");
            Console.WriteLine("[4]. Delete user");
            Console.WriteLine();

            do
            {
                Console.Write("Insert menu number:");
                menuInput = Console.ReadLine();
                try
                {
                    menuFlag = Validation.MenuControl(menuInput, 4);
                }
                catch (SystemException ex)
                {
                    Console.WriteLine(ex.Message);
                    menuFlag = true;
                }

            } while (menuFlag);

            switch (menuInput)
            {
                case "1":
                    NewUser();
                    break;
                case "2":
                    ShowUserList();
                    break;
                case "3":
                    EditeUser();
                    break;
                case "4":
                    DeleteUser();
                    break;

            }
        }

        private static void NewUser()
        {
            const int idStartPoint = 1000;

            int Id = idStartPoint + DSR.UserCount + 1;
            string name;
            string phoneNumber;
            string birthDate;

            //bool validationFlag = true;
            bool existingFlag = false;


            do
            {
                //if (!validationFlag)
                //{
                //    Console.WriteLine();
                //    validationFlag = true;

                //}

                if (existingFlag)
                {
                    existingFlag = false;
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("to Go previous menu write Q");
                Console.ResetColor();

                Console.WriteLine("Fill out the registeration form:");




                Console.Write("Name: ");
                name = Console.ReadLine();
                if (name == "Q")
                {
                    EntryPoint();
                }

                Console.Write(" PhoneNumber: ");
                phoneNumber = Console.ReadLine();
                if (phoneNumber == "Q")
                {
                    EntryPoint();
                }

                Console.Write("BitrhDay: ");
                birthDate = Console.ReadLine();
                if (birthDate == "Q")
                {
                    EntryPoint();
                }

                //try
                //{
                //    validationFlag = Validation.RoleValidation(role.Trim());
                //}
                //catch (System.Exception msg)
                //{

                //    Console.WriteLine(msg.Message);
                //    validationFlag = false;
                //}

                //if (validationFlag)
                //{
                //        existingFlag = Authenticat.checkUserExist(email, password);
                //}

                //if (validationFlag && !existingFlag)
                //{
                //    reInput = false;
                //}

                existingFlag = Authenticat.checkUserExist(email, password);

                if (existingFlag)
                {
                    Console.WriteLine("Member has registered!");
                    Thread.Sleep(2000);
                }

            } while (existingFlag);

            Role curentRole = Role.Member;
            switch (role)
            {
                case "1":
                    curentRole = Role.Librarian;
                    break;
                case "2":
                    curentRole = Role.Member;
                    break;
                default:
                    break;
            }

            Person person = new Person(Id, name, email, password, curentRole);
            try
            {
                Authenticat.Register(person);
                Console.WriteLine("you have Registered ");
                Thread.Sleep(3000);
                EntryPoint();
            }
            catch (System.Exception msg)
            {

                Console.WriteLine(msg.Message);
                Thread.Sleep(3000);
                RunRegister();
            }



        }


        private static void DeleteUser()
        {
            throw new NotImplementedException();
        }

        private static void EditeUser()
        {
            throw new NotImplementedException();
        }

        private static void ShowUserList()
        {
            throw new NotImplementedException();
        }


    }
}
