using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Check_BirtNum
{
    class CheckNum
    {
        string BirthNumStr;
        int days;
        int year;
        int month;
        bool MainEPC = false;
        bool numCheck = false;

        public bool Check0(string a)
        {
            bool b = false;
            BirthNumStr = a;
            Int64 BirthNum;

            if (Int64.TryParse(a, out BirthNum))
            {
                BirthNumStr = a;
                b = true;
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
                        b = true;
                    }
                }
            }

            numCheck = b;
            return b;
        }

        public bool Check1()
        {
            if (BirthNumStr.Length >= 9)
            {
                return true;
            }
            return false;
        }

        public bool Check2()
        {
            if (BirthNumStr.Length <= 10)
            {
                return true;
            }
            return false;
        }

        public bool Check3()
        {
            if (BirthNumStr.Length == 9 && BirthNumStr[7] == 0 && BirthNumStr[8] == 0 && BirthNumStr[9] == 0)
            {
                return false;
            }
            return true;
        }

        public List<bool> Check4()
        {
            List<bool> helpList = new List<bool>();

            if (BirthNumStr.Length < 9 || numCheck == false)
            {
                helpList.Add(false);
                helpList.Add(false);
                return helpList;
            }

            int helpIntRC = Int32.Parse(BirthNumStr.Substring(2, 2));
            int helpIntEPC = Int32.Parse(BirthNumStr.Substring(4, 2));

            if (helpIntRC > 50)
            {
                helpIntRC -= 50;
            }

            if (helpIntRC > 20)
            {
                helpList.Add(true);
            }
            else
            {
                helpList.Add(false);
            }

            if (helpIntEPC > 40)
            {
                helpList.Add(true);
                MainEPC = true;
            }
            else
            {
                helpList.Add(false);
            }

            return helpList;
        }

        public bool Check5()
        {
            bool b = false;
            string helpStr;
            if (numCheck == false)
            {
                return b;
            }

            int helpInt = Int32.Parse(BirthNumStr.Substring(0, 2));

            if (BirthNumStr.Length == 9 && helpInt > 53 && helpInt < 100)
            {
                year = Int32.Parse("18" + helpInt.ToString());
                return true;
            }
            else if (BirthNumStr.Length == 10 && helpInt < 100 && helpInt > 53 || BirthNumStr.Length == 9 && helpInt >= 0 && helpInt < 54)
            {
                if (helpInt.ToString().Length == 1)
                {
                    helpStr = "0" + helpInt.ToString();  
                    year = Int32.Parse("19" + helpStr);
                }
                else
                {
                    year = Int32.Parse("19" + helpInt.ToString());
                }
                return true;
            }
            else if (BirthNumStr.Length == 10 && helpInt < 54 && helpInt >= 0)
            {
                if (helpInt.ToString().Length == 1) {
                    helpStr = "0" + helpInt.ToString();  
                    year = Int32.Parse("20" + helpStr);
                } else {
                    year = Int32.Parse("20" + helpInt.ToString());
                }
                return true;
            }
            return b;
        }

        public bool Check6()
        {
            bool b = false;

            if (numCheck == false || BirthNumStr.Length < 9)
            {
                return b;
            }

            int helpInt = Int32.Parse(BirthNumStr.Substring(2, 2));

            if (helpInt > 50 && helpInt < 63)
            {
                helpInt -= 50;
            }

            if (helpInt > 0 && helpInt < 13)
            {
                month = helpInt;
                return b = true;
            }
            return b;
        }

        public bool Check7()
        {
            bool b = false;

            if (numCheck == false || BirthNumStr.Length < 9)
            {
                return b;
            }

            int helpInt = Int32.Parse(BirthNumStr.Substring(4, 2));

            if (month < 13 && Int32.Parse(BirthNumStr.Substring(2, 2)) > 0 && year != 0 && month != 0)
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

            if (year < DateTime.Now.Year && year.ToString().Length == 4 && month.ToString().Length == 2 || month.ToString().Length == 1)
            {
                b = true;
            }

            return b;
        }

        public bool Check9()
        {
            bool b = true;
            int helpInt = BirthNumStr.Length;

            if (numCheck == false || BirthNumStr.Length < 9)
            {
                return b;
            }

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
            double helpInt = 0;
            int helpNumA = 0;
            int helpNumB = 0;

            if (numCheck == false)
            {
                return b;
            }

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

            helpInt = Math.Abs(helpNumA - helpNumB);
            Debug.WriteLine(Math.Abs(helpNumA - helpNumB));
            Debug.WriteLine(helpInt / 11);
            helpInt = helpInt / 11;

            if (BirthNumStr.Length == 10 && (helpInt % 1) == 0)
            {
                b = true;
            }

            if (BirthNumStr.Length == 9)
            {
                b = true;
            }

            return b;
        }
    }
}
    
