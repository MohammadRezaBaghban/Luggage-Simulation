using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBuilderApp.Interface
{
    interface IInsurancePackage
    {
        string Name();
        decimal Cost();
        decimal Deductable();
        bool Upgradable();
    }
}
