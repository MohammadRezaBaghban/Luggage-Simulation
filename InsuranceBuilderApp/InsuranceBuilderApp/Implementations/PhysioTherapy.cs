using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBuilderApp.Implementations
{
    public class PhysioTherapy : Basic
    {
        private string _hospital;

        public void SetHospital(string hospital) 
        {
            this._hospital = hospital;
        }

        public string GetHospital()
        {
            return _hospital;
        }
    }
}
