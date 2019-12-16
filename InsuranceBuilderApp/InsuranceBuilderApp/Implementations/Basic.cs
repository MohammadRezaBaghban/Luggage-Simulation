using InsuranceBuilderApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBuilderApp.Implementations
{
    public class Basic : IInsurancePackage
    {
        public decimal Cost()
        {
            throw new NotImplementedException();
        }

        public decimal Deductable()
        {
            throw new NotImplementedException();
        }

        public string Name()
        {
            throw new NotImplementedException();
        }

        public bool Upgradable()
        {
            throw new NotImplementedException();
        }
    }
}
