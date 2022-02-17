using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Check_BirtNum
{
    class CheckNum
    {
        private protected Int64 BirthNum;
        public bool Check0(string a)
        {
            bool b = false;

            if (Int64.TryParse(a, out BirthNum))
            {
                return b = true;
            }
            else
            {
                if (Regex.IsMatch(a, "/"))
                {
                    int helpInt = a.IndexOf("/");
                    a = a.Substring(0, helpInt) + a.Substring(helpInt + 1);

                    if (Int64.TryParse(a, out BirthNum))
                    {
                        return b = true;
                    }
                    else
                    {
                        return b;
                    }
                }
                else
                {
                    return b;
                }
            }
        }

        public bool Check1()
        {
            bool b = false;

            if (BirthNum.ToString().Length >= 9)
            {
                return b = true;
            }
            return b;
        }

        public bool Check2()
        {
            bool b = false;

            if (BirthNum.ToString().Length <= 10)
            {
                return b = true;
            }
            return b;
        }

        public bool Check3()
        {
            bool b = false;

            if (BirthNum.ToString().Length == 9 && BirthNum.ToString()[7] == 0 && BirthNum.ToString()[8] == 0 && BirthNum.ToString()[9] == 0)
            {
                return b;
            }
            return b = true;
        }

        public bool Check4()
        {
            bool b = false;
            bool epc = false;
            bool rcPlus = false;
            int helpIntRC = Int32.Parse(BirthNum.ToString().Substring(2, 2));
            int helpIntEPC = Int32.Parse(BirthNum.ToString().Substring(4, 2));

            if (BirthNum.ToString().Length < 5)
            {
                return b;
            }

            if (helpIntRC > 50)
            {
                helpIntRC -= 50;
            }

            if (helpIntRC > 20)
            {
                rcPlus = true;
            }

            if (helpIntEPC > 40)
            {
                epc = true;
            }

            if (epc && rcPlus)
            {
                return b;
            }
            return b = true;
        }

        public bool Check5()
        {
            bool b = false;
            int helpInt = Int32.Parse(BirthNum.ToString().Substring(0, 2));

            if (BirthNum.ToString().Length == 10 && helpInt >= 0 && helpInt <= 99 || BirthNum.ToString().Length == 9 && helpInt > 53)
            {
                return b = true;
            }
            return b;
        }

        public bool Check6()
        {
            bool b = false;
            int helpInt = Int32.Parse(BirthNum.ToString().Substring(2, 2));

            if (BirthNum.ToString().Length == 10 && BirthNum.ToString().Length == 9 && helpInt > 0 && helpInt < 13)
            {
                return b = true;
            }
            return b;
        }
    }
}
