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



    }
}
