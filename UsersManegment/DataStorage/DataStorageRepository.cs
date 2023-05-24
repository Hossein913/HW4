using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManegment.Models;
using UsersManegment.UserDefinedExceptions;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace UsersManegment.DataStorage
{
    class DataStorageRepository
    {

        private List<User> users;

        public int UserCount
        {
            get {
                if (users.Count==0)
                {
                    return 0;
                }
                else
                {
                  return users.Last<User>().id;
                }
            }
        }

        public DataStorageRepository()
        {
            users = new List<User>();
            CreatStoragFile();
            ReadFromFile();
        }

        private void CreatStoragFile()
        {

            if (!File.Exists(".\\FileDateStorage.csv"))
            {
                FileStream fileStream = File.Create(".\\FileDateStorage.csv");
                fileStream.Close();
                WriteOnFile();
            }

        }

        private void ReadFromFile()
        {
            try
            {
            }
            catch (Exception)
            {

                throw new NullReferenceException("There is problem with access to storage file!Run the aplication again");
            }

            using (CsvReader csvReader = new CsvReader(new StreamReader(".\\FileDateStorage.csv"), CultureInfo.InvariantCulture))
            {

                    csvReader.Read();
                    csvReader.ReadHeader();
                    while (csvReader.Read())
                    {
                        users.Add(csvReader.GetRecord<User>());

                    }

            }



        }

        private void WriteOnFile()
        {
            try
            {
                using (CsvWriter writer = new CsvWriter(new StreamWriter(".\\FileDateStorage.csv"), CultureInfo.InvariantCulture))
                {
                    writer.WriteRecords(users);
                }

            }
            catch (Exception)
            {

                throw new NullReferenceException("There is problem with access to storage file!Run the aplication again");

            }


        }

        private bool ExistUser(User user)
        {
            foreach (var item in users)
            {
                if (item == user)
                {
                    return true;
                }
            }
            return false;
        }

        //There is an unsalved probelm with return type
        public List<User> GetAllRipository()
        {
            if (users.Count != 0)
            {
                return users;
            }
            else
            {
                throw new DefinedException();

            }

        }

        public void Update(User olduser, User newuser)
        {
            if (ExistUser(olduser))
            {
                List<User> UserTemp = new List<User>() ;
                foreach (var item in users)
                {
                    UserTemp.Add(item);
                }
                users.Clear();
                foreach (var item in UserTemp)
                {
                    if (item != olduser)
                    {
                        users.Add(item);
                    }
                    else
                    {
                        users.Add(newuser);
                    }
                }

                WriteOnFile();
            }
            else
            {
                throw new ArgumentException("not found record from data storage!");

            }

        }


        public void Delete(User user)
        {
            if (ExistUser(user))
            {
                users.Remove(user);
                WriteOnFile();
            }
            else
            {
                throw new ArgumentException("not found record from data storage!");

            }

        }

        public void Insert(User user)
        {
            if (!ExistUser(user))
            {
                users.Add(user);
                WriteOnFile();
            }
            else
            {
                throw new ArgumentException("The User has insertd!can't add duplicate user");

            }
        }


        public User GetById(int id)
        {
            foreach (var item in users)
            {
                if (item.id == id)
                {
                    return item;
                }
            }
            return null;
        
        }

        public User GetByName(string name)
        {
            foreach (var item in users)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;

        }

        //public delegate User Wherecondition<T>(T prop,List<User> userlist);
        //public User GetByproperty<T>(T prop, List<User> userlist, Wherecondition<T> wherecondition)
        //{
        //    return wherecondition(prop, userlist);

        //}
    }
}
