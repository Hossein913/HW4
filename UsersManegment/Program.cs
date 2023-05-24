using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManegment.Services;

namespace UsersManegment
{
    class Program
    {
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
            throw new NotImplementedException();
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
