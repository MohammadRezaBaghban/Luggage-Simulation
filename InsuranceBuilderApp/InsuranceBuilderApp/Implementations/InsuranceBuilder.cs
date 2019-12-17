using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBuilderApp.Implementations
{
    public class InsuranceBuilder
    {
        public Insurance makeBasicPackage()
        {
            Insurance insurance = new Insurance();
            Basic basicInsurance = new Basic();
            basicInsurance.SetCost(100);
            basicInsurance.SetDeductable(385);

            insurance.addPackage(basicInsurance);

            return insurance;
        }
        public Insurance makeBasicWithDental()
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

        public Insurance makeBasicWithPhysio()
        {
            Insurance insurance = new Insurance();
            PhysioTherapy physio = new PhysioTherapy();
            Basic basicInsurance = new Basic();
            basicInsurance.SetCost(100);
            basicInsurance.SetDeductable(385);
            physio.SetCost(150);
            physio.SetDeductable(385);
            insurance.addPackage(basicInsurance);
            insurance.addPackage(physio);
            return insurance;
        }

        public Insurance makeBasicWithPhysioAndDental()
        {
            Insurance insurance = new Insurance();
            Dental dental = new Dental();
            PhysioTherapy physio = new PhysioTherapy();
            Basic basicInsurance = new Basic();
            basicInsurance.SetCost(100);
            basicInsurance.SetDeductable(385);
            dental.SetCost(100);
            dental.SetDeductable(385);
            physio.SetCost(150);
            physio.SetDeductable(385);
            insurance.addPackage(basicInsurance);
            insurance.addPackage(physio);
            insurance.addPackage(dental);
            return insurance;
        }

        public Insurance makePremiumPlus()
        {
            Insurance insurance = new Insurance();
            PremiumPlus premium = new PremiumPlus();
            premium.SetCost(400);
            premium.SetDeductable(0);

            insurance.addPackage(premium);

            return insurance;
        }

        public Insurance makeBasicPremium()
        {
            Insurance insurance = new Insurance();
            BasicPremium premium = new BasicPremium();
            premium.SetCost(450);
            premium.SetDeductable(0);

            insurance.addPackage(premium);

            return insurance;
        }


    }
}
