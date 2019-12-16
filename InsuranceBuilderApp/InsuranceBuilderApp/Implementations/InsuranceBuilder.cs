using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBuilderApp.Implementations
{
    public class InsuranceBuilder
    {
        public Insurance MakeBasicPackage()
        {
            Insurance insurance = new Insurance();
            Basic basicInsurance = new Basic();
            basicInsurance.SetCost(100);
            basicInsurance.SetDeductable(385);

            insurance.addPackage(basicInsurance);

            return insurance;
        }
        public Insurance MakeBasicWithDental()
        {
            Insurance insurance = new Insurance();
            Dental dental = new Dental();
            dental.SetCost(150);
            dental.SetDeductable(385);
            insurance.addPackage(dental);
            return insurance;
        }


    }
}
