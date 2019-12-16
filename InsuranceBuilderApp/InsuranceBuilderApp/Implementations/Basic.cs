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
        protected decimal _cost;
        private decimal _deductable;

        public void SetCost(decimal cost)
        {
            this._cost = cost;
        }

        public void SetDeductable(decimal deductable)
        {
            this._deductable = deductable;
        }

        public  decimal Cost()
        {
            return _cost;
        }

        public  decimal Deductable()
        {
            return _deductable;
        }
    }
}
