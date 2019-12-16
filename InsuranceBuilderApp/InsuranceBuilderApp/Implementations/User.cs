using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBuilderApp.Implementations
{
    public class User
    {
        private string _name;
        private string _dOB;
        private Insurance _insurance;

        public User(string name, string dob) 
        {
            _name = name;
            _dOB = dob;
        }

        public string GetName() 
        {
            return this._name;
        }

        public void SetInsurance(Insurance I) 
        {
            this._insurance = I;
        }

        public string GetDOB()
        {
            return this._dOB;
        }

    }
}
