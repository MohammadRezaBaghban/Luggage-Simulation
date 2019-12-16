﻿using System;
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

        public override string ToString()
        {
            string s=  "Name: " + GetName() + ", DOB: "+GetDOB();
            int index = 0;
            if (_insurance != null)
            {
                s += ", Packages: ";
                _insurance?.getPackages().ForEach(package =>
                {
                    index = package.ToString().IndexOf(".", StringComparison.Ordinal);
                    s += package.ToString().Substring(index + 17) + " - ";
                });
                s += "Price: " + _insurance?.getCost();
            }

            return s;
        }
    }
}
