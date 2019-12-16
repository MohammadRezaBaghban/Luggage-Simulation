using InsuranceBuilderApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceBuilderApp.Implementations
{
    public class Insurance 
    {
        private List<IInsurancePackage> packages;

        public Insurance()
        {
            packages=new List<IInsurancePackage>();
        }
        public decimal getCost()
        {
            decimal cost=0;
            foreach (var i in packages) 
            {
                cost += i.Cost();
            }
            return cost;
        }

        public void addPackage(IInsurancePackage p)
        {
            packages.Add(p);
        }

        public List<IInsurancePackage> getPackages() 
        {
            return packages;
        }

    }
}
