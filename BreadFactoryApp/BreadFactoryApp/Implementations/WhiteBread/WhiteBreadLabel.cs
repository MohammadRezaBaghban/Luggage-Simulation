using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp.Implementations
{
    class WhiteBreadLabel: ILabel
    {

        Random r = new Random();
        DateTime rDate;
        public WhiteBreadLabel()
        {
            rDate = new DateTime(r.Next(2019, 2020), r.Next(1, 12), r.Next(1, 28));

        }

        public String PrintIngredients()
        {
            return $"White Bread";
        }

        public DateTime PrintExpiryDate()
        {
            return rDate;

        }

        public string PrintCertification()
        {
            return $"Dutch certified";
        }
    }
}
