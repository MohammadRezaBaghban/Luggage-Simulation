using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp.Implementations
{
    class BrownBreadLabel : ILabel
    {

        Random r = new Random();
        DateTime rDate ;
        public BrownBreadLabel()
        {
             rDate = new DateTime(r.Next(2019, 2020), r.Next(1, 12), r.Next(1, 28));

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
    }
}
