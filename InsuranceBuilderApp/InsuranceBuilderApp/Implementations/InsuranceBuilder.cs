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
            Basic basicInsurance = new Basic();
            basicInsurance.SetCost(100);
            basicInsurance.SetDeductable(385);
            dental.SetCost(150);
            dental.SetDeductable(385);
            insurance.addPackage(basicInsurance);
            insurance.addPackage(dental);
            return insurance;
        }

        public Insurance MakeBasicWithPhysio()
        {
            Insurance insurance = new Insurance();
            PhysioTherapy physio = new PhysioTherapy();
            physio.SetCost(150);
            physio.SetDeductable(385);
            insurance.addPackage(physio);
            return insurance;
        }

        public Insurance MakeBasicWithPhysioAndDental()
        {
            Insurance insurance = new Insurance();
            Dental dental = new Dental();
            PhysioTherapy physio = new PhysioTherapy();
            dental.SetCost(100);
            dental.SetDeductable(385);
            physio.SetCost(150);
            physio.SetDeductable(385);
            insurance.addPackage(physio);
            insurance.addPackage(dental);
            return insurance;
        }


    }
}
