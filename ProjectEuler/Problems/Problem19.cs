using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem19:IProblem
    {
        String[] days = { "Sun", "mon", "tues", "wed", "thurs", "fri", "sat" };
        public string Run()
        {
            int day = 1;
            int sundays = 0;
            for (int i = 1900; i < 2001; i++)
            {
                for (int month = 0; month < 12; month++)
                {
                    if (day == 0)
                        sundays++;
                    if (month == 1)
                    {
                        day = (i % 4 == 0 && (i % 100 != 0 || i % 400 == 0))? day + 1 : day;
                    }
                    else if (month == 3 || month == 5 || month == 10 || month==8)
                    {
                        day = (day + 2) % 7;
                    }
                    else
                    {
                        day = (day + 3) % 7;
                    }
                }
            }
            return sundays.ToString();
        }
    }
}
