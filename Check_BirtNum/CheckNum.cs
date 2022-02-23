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
        Int64 BirthNum;
        string BirthNumStr;
        int days;
        int year;
        int month;
        bool MainEPC = false;

        public bool Check0(string a)
        {
            bool b = false;

            if (Int64.TryParse(a, out BirthNum))
            {
                BirthNumStr = a;
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
                        BirthNumStr = a;
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

            if (BirthNumStr.Length >= 9)
            {
                return b = true;
            }
            return b;
        }

        public bool Check2()
        {
            bool b = false;

            if (BirthNumStr.Length <= 10)
            {
                return b = true;
            }
            return b;
        }

        public bool Check3()
        {
            bool b = false;

            if (BirthNumStr.Length == 9 && BirthNumStr[7] == 0 && BirthNumStr[8] == 0 && BirthNumStr[9] == 0)
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
            int helpIntRC = Int32.Parse(BirthNumStr.Substring(2, 2));
            int helpIntEPC = Int32.Parse(BirthNumStr.Substring(4, 2));

            if (BirthNumStr.Length < 5)
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
                MainEPC = true;
            }

            if (epc && rcPlus)
            {
                return b = true;
            }
            return b;
        }

        public bool Check5()
        {
            bool b = false;
            string helpStr;
            int helpInt = Int32.Parse(BirthNumStr.Substring(0, 2));

            if (BirthNumStr.Length == 9 && helpInt > 53 && helpInt < 100)
            {
                year = Int32.Parse("18" + helpInt.ToString());
                return b = true;
            }
            else if (BirthNumStr.Length == 10 && helpInt < 100 && helpInt > 53 || BirthNumStr.Length == 9 && helpInt >= 0 && helpInt < 54)
            {
                if (helpInt < 10)
                {
                    helpStr = "0" + helpInt.ToString();  
                    year = Int32.Parse("19" + helpStr);
                }
                else
                {
                    year = Int32.Parse("19" + helpInt.ToString());
                }
                return b = true;
            }
            else if (BirthNumStr.Length == 10 && helpInt < 54 && helpInt >= 0)
            {
                if (helpInt < 10) {
                    helpStr = "0" + helpInt.ToString();  
                    year = Int32.Parse("20" + helpStr);
                } else {
                    year = Int32.Parse("20" + helpInt.ToString());
                }
                return b = true;
            }

            return b;
        }

        public bool Check6()
        {
            bool b = false;
            int helpInt = Int32.Parse(BirthNumStr.Substring(2, 2));

            if (helpInt > 0 && helpInt < 13 && BirthNumStr.Length == 10 || BirthNumStr.Length == 9)
            {
                month = helpInt;
                return b = true;
            }
            return b;
        }

        public bool Check7()
        {
            bool b = false;
            int helpInt = Int32.Parse(BirthNumStr.Substring(4, 2));

            if (Int32.Parse(BirthNumStr.Substring(2, 2)) < 13 && Int32.Parse(BirthNumStr.Substring(2, 2)) > 0)
            {
                days = DateTime.DaysInMonth(year, month);
            }

            if (helpInt > 0 && helpInt <= days)
            {
                b = true;
            }

            return b;
        }

        public bool Check8()
        {
            bool b = false;

            if (year < DateTime.Now.Year && month.ToString().Length == 2 && year.ToString().Length == 4)
            {
                b = true;
            }

            return b;
        }

        public bool Check9()
        {
            bool b = true;
            int helpInt = BirthNumStr.Length;
            int endInt = Int32.Parse(BirthNumStr.Substring(6, 3));

            if (MainEPC && helpInt == 9 && endInt >= 600)
            {
                b = false;
            }

            return b;
        }

        public bool Check10()
        {
            bool b = true;
            int helpInt = BirthNumStr.Length;
            int endInt = 0;

            if (BirthNumStr.Length == 10)
            {
                endInt = Int32.Parse(BirthNumStr.Substring(6, 4));
            }

            if (MainEPC && helpInt == 10 && endInt >= 6000)
            {
                b = false;
            }

            return b;
        }

        public bool Check11()
        {
            bool b = false;
            string a = BirthNumStr;
            int helpInt = 0;
            int helpNumA = 0;
            int helpNumB = 0;

            for (int i = 0; i < BirthNumStr.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    helpNumB += Int32.Parse(a[i].ToString());
                }
                else
                {
                    helpNumA += Int32.Parse(a[i].ToString());
                }
            }

            helpInt = Math.Abs(helpNumA - helpNumB) / 11;

            if (BirthNumStr.Length == 10 && (helpInt % 1) == 0)
            {
                b = true;
            }

            return b;
        }
    }
}
    
