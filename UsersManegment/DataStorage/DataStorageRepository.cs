using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManegment.Models;
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
            get { return users.Count; }
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
            catch (Exception)
            {

                throw new NullReferenceException("There is problem with access to storage file!Run the aplication again");
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


        public List<User> GetAllRipository()
        {
            List<User> Temp = null;
            if (users.Count != 0)
            {
                return users;
            }
            else
            {

            }
            return Temp;


        }

        public void Update(User olduser, User newuser)
        {
            if (ExistUser(olduser))
            {
                List<User> UserTemp = users;
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

        }


        public void Delete(User user)
        {
            if (ExistUser(user))
            {
                users.Remove(user);
                WriteOnFile();
            }


        }

        public void Insert(User user)
        {
            if (!ExistUser(user))
            {
                users.Add(user);
                WriteOnFile();
            }
        }





    }
}
