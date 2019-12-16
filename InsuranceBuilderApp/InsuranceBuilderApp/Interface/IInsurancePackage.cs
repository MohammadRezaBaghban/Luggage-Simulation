using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBuilderApp.Interface
{
    public interface IInsurancePackage
    {
        decimal Cost();
        decimal Deductable();

        void SetCost(decimal cost);
        void SetDeductable(decimal deductable);

    }
}
