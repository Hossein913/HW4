using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UsersManegment.DataStorage;
using UsersManegment.Models;
using UsersManegment.Services;

namespace UsersManegment
{
    class Program
    {

        public static DataStorageRepository DSR ;

        static void Main(string[] args)
        {
            try
            {
                DSR = new DataStorageRepository();
                EntryPoint();
            }
            catch (Exception msg)
	        {

                Console.WriteLine(msg.Message);
                Console.ReadLine();
            }

        }


        private static void EntryPoint()
        {
            bool menuFlag;
            string menuInput = "";

            Console.Clear();
            Console.WriteLine(":: Wellcome to UserManegment system ::");
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
                    EditeUserMenu();
                    break;
                case "4":
                    DeleteUserMenu();
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

            bool validationFlag = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("to Go previous menu write Q");
            Console.ResetColor();

            do
            {

                if (validationFlag)
                {
                    Console.WriteLine();
                    validationFlag = false;
                }

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

                try
                {
                    validationFlag = Validation.NewUserVaildat(name, phoneNumber, birthDate);
                }
                catch (System.Exception msg)
                {

                    Console.WriteLine(msg.Message);
                    validationFlag = false;
                }


            } while (!validationFlag);

           // User user = new User(Id, name, phoneNumber, Convert.ToDateTime(birthDate),DateTime.Now.Date);

            try
            {
                //DSR.Insert(user);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User have Registered");
                Console.ResetColor();
                Thread.Sleep(3000);
                EntryPoint();
            }
            catch (System.Exception msg)
            {

                Console.WriteLine(msg.Message);
                Thread.Sleep(3000);
                NewUser();
            }



        }

        private static void ShowUserList()
        {
            User selectedUser;
            int Printcounter=1;
            string UserId;
            string menuInput;
            bool menuFlag = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("to Go previous menu write Q");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(@"[ID]  [Name]   [PhoneNumber]     [BirthDate]     [CreationDate]");
            Console.WriteLine("_____________________________________________________________________");
            DSR.GetAllRipository().ForEach(
            item => {
                if (Printcounter%2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(item.ToString());
                Console.ResetColor();
                Printcounter++;
            });

            Console.WriteLine();
            Console.WriteLine("select user to Edite or Delete");
            do
            {
                List<User> userTemperList = DSR.GetAllRipository();
                int id;

                Console.Write("Insert ID to select:");
                UserId = Console.ReadLine();
                if (!int.TryParse(UserId.Trim(), out id))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid ID!");
                    Console.WriteLine();
                    menuFlag = true;
                }
                else if(DSR.GetById(id)==null)
                {
                    Console.WriteLine();
                    Console.WriteLine("User not found!");
                    Console.WriteLine();
                    menuFlag = true;

                }

            } while (menuFlag);

            selectedUser = DSR.GetById(int.Parse(UserId));
            Console.WriteLine();
            Console.WriteLine("selected user is:");
            Console.WriteLine(@"[ID]  [Name]   [PhoneNumber]     [BirthDate]     [CreationDate]");
            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine(selectedUser.ToString());

            Console.WriteLine();
            Console.WriteLine("select menu: ");
            Console.WriteLine("[1]. Edite user");
            Console.WriteLine("[2]. delete user");
            Console.WriteLine("[3]. back");
            Console.WriteLine();
            do
            {
                Console.Write("Insert menu number:");
                menuInput = Console.ReadLine();
                try
                {
                    menuFlag = Validation.MenuControl(menuInput, 3);
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
                    EntryPoint();
                    break;

            }


        }

        private static void DeleteUserMenu()
        {
            User selectedUser;
            string name;
            bool menuFlag = false;
            char deleteFlag = 'N';

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("to Go previous menu write Q");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("select user to Delete");
            do
            {
                Console.Write("Insert Use Name:");
                name = Console.ReadLine();
                if (name == "Q")
                {
                    EntryPoint();
                }

                if (DSR.GetByName(name) == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("User not found!");
                    Console.WriteLine();
                    menuFlag = true;

                }


            } while (menuFlag);

            Console.WriteLine();
            selectedUser = DSR.GetByName(name);
            Console.WriteLine();
            Console.WriteLine("selected user is:");
            Console.WriteLine(@"[ID]  [Name]   [PhoneNumber]     [BirthDate]     [CreationDate]");
            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine(selectedUser.ToString());
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Are sure to delete user? Y/N");
            Console.ResetColor();
            deleteFlag = Convert.ToChar(Console.ReadLine().Substring(0, 1));
            if (deleteFlag =='Y')
            {
                DSR.Delete(selectedUser);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User have deleted");
                Console.ResetColor();
                Thread.Sleep(1000);
                DeleteUserMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("User did not delete");
                Console.ResetColor();
                Thread.Sleep(1000);
                DeleteUserMenu();
            }

            /*
           //Console.WriteLine();
           //Console.WriteLine("select user to Delete");
           //do
           //{
           //    Console.Write("Insert Use Name:");
           //    name = Console.ReadLine();

           //    if (DSR.GetByproperty<string>
           //        (name, DSR.GetAllRipository(), (x, b) =>
           //          {
           //              foreach (var item in b)
           //              {
           //                  if (item.Name == x)
           //                  {
           //                      return item;
           //                  }
           //              }
           //              return null;
           //          }
           //        ) == null)
           //    {
           //        Console.WriteLine();
           //        Console.WriteLine("User not found!");
           //        Console.WriteLine();
           //        menuFlag = true;

           //    }

           //} while (menuFlag);
           */


        }

        private static void EditeUserMenu()
        {
            throw new NotImplementedException();
        }
        private static void EditeUser()
        {
            throw new NotImplementedException();
        }







    }
}
