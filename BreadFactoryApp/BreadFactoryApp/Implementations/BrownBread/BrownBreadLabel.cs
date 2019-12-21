using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp.Implementations
{
    public class BrownBreadLabel : ILabel
    {
        private  int id;
        private static int IdToGive;

        Random r = new Random();
        DateTime rDate ;
        TimeSpan ts = new TimeSpan(10, 30, 0);
        public BrownBreadLabel()
        {

            rDate = new DateTime(r.Next(2019, 2020), r.Next(1, 12), r.Next(1, 28)) +ts;
            id= ++IdToGive;

        }
        public string PrintIngredients()
        {
            return $"Brown Bread";
        }

        public DateTime PrintExpiryDate()
        {
            return rDate;
        }

        public string PrintCertification()
        {
            return $"French certified";
        }

        public int getID()
        {
            return id;
        }
    }
}
