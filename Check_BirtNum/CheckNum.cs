using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_BirtNum
{
    class CheckNum
    {
        bool Check0(string a)
        {
            bool b = false;
            int c;

            try
            {
                c = Convert.ToInt32(a);
            }
            catch (Exception)
            {

                
            }

            return b;
        }
    }
}
