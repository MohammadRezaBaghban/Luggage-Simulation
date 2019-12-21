using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadFactoryApp.Interfaces
{
   public interface ILabel
    {
        String PrintIngredients();
        DateTime PrintExpiryDate();
        String PrintCertification();

        int getID();

    }
}
