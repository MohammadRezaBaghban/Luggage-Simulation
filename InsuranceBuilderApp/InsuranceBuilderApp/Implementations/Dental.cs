using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBuilderApp.Implementations
{
    public class Dental: Basic
    {
        private string _clinic;

        public void SetClinic(string clinic)
        {
            this._clinic = clinic;
        }

        public string GetClinic()
        {
            return _clinic;
        }
       

    }
}
