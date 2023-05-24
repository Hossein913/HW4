using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersManegment.Services
{
    public static class Validation
    {

        public static bool MenuControl(string input, int endnum)
        {

            int menuInput;
            bool flag = false;

            flag = int.TryParse(input.Trim(), out menuInput);
            if (!flag)
            {
                throw new InvalidCastException("Input is not a number");
            }
            if (flag = true && (menuInput < 1 || menuInput > endnum))
            {
                flag = false;
                throw new ArgumentOutOfRangeException("input number is out of Range");
            }
            return flag;

        }

        internal static bool NewUserVaildat(string name, string phonenumstring, string birthDate)
        {
            long phonenumber;
            DateTime BirthDate ;

            if (name.Length > 30)
            {
                return false;
                throw new ArgumentOutOfRangeException("User name can't be greater than 30 character!");
            }
            else if (!Int64.TryParse(phonenumstring.Trim(),out phonenumber))
            {
                return false;
                throw new ArgumentOutOfRangeException("Invalid phonenumber!");
            }
            if (!DateTime.TryParse(birthDate.Trim(),out BirthDate))
            {
                return false;
                throw new ArgumentOutOfRangeException("Invalid Data has inserted as BirthDate!");
            }
            if ( DateTime.Compare(BirthDate, DateTime.Now) >= 0 )
            {
                return false;
                throw new ArgumentOutOfRangeException("Invalid Date has inserted as BirthDate!");
            }
            return true;
        }
    }
}
