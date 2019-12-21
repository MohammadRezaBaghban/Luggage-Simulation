using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

using BreadFactoryApp;
using BreadFactoryApp.Implementations;
using Assert = NUnit.Framework.Assert;

namespace BreadFactoryAppTests
{
    [TestFixture]
    public class BrownBreadFactoryTests
    {
        
        BrownBreadFactory _factory;
        [SetUp]
        public void Setup()
        {
            _factory = new BrownBreadFactory();
        }
        [Test]
        public void CreateBakingFlour_WhenCalled_ShouldReturnANewObjectOfTypeBrownBreadFlour()
        {
            var Flour = _factory.CreateBakingFlour();
            
           Assert.That(Flour, Is.InstanceOf(typeof(BrownBreadFlour)));
        }

        [Test]
        public void CreateLabel_WhenCalled_ShouldReturnANewObjectOfTypeBrownBreadLabel()
        {
            var Label = _factory.CreateLabel();

            Assert.That(Label, Is.InstanceOf(typeof(BrownBreadLabel)));
        }
       [Test]
        public void CreatePackage_WhenCalled_ShouldReturnANewObjectOfTypeBrownBreadPackage()
        {
            var Package = _factory.CreatePackage();

            Assert.That(Package, Is.InstanceOf(typeof(BrownBreadPackage)));
        }
        

    }
}
