﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadFactoryApp.Interfaces;

namespace BreadFactoryApp.Implementations
{
    public class BrownBreadPackage :  IPackage
    {
        private string status;
        private int id;
        private static int IdToGive;
        public void Pack()
        {
            status = "Brown bread packed";
            id= ++IdToGive;
        }

        public void Seal()
        {
            status = "Brown bread sealed";
        }

        public string GetStatus()
        {
            return status;
        }

        public int getID()
        {
            return id;
        }
    }
}
