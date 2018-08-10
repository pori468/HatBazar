using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HatBazar.Utilities
{
    public class Utility
    {
        public bool CompareDate(string start, string end)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            if (start == null)
            {
                var dateTimeNow = DateTime.Now; // Return 00/00/0000 00:00:00
                var dateOnlyString = dateTimeNow.ToShortDateString(); //Return 00/00/0000
                startDate = Convert.ToDateTime(dateOnlyString);
                endDate = Convert.ToDateTime(end);


            }
            else if (end == null)
            {
                var dateTimeNow = DateTime.Now; // Return 00/00/0000 00:00:00
                var dateOnlyString = dateTimeNow.ToShortDateString(); //Return 00/00/0000
                endDate = Convert.ToDateTime(dateOnlyString);
                startDate = Convert.ToDateTime(start);


            }
            else
            {
                startDate = Convert.ToDateTime(start);
                endDate = Convert.ToDateTime(end);

            }


            if (endDate.Date > startDate.Date)
            {
                return true;
            }

            else return false;


        }



    }
}