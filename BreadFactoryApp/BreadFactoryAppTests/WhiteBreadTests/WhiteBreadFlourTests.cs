using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BreadFactoryApp;
using BreadFactoryApp.Implementations;
using BreadFactoryApp.Interfaces;
using NUnit.Framework;

namespace BreadFactoryAppTests.WhiteBreadTests
{
    [TestFixture]
    class WhiteBreadFlourTests
    {
        private WhiteBreadFactory factory;
        IFlour Flour;
        [SetUp]
        public void Setup()
        {
            factory = new WhiteBreadFactory();
            Flour = factory.CreateBakingFlour();
        }

        [Test]
        public void Bake_WhenCalled_ShouldChangeTheStatusToBaking()
        {

            Flour.Bake();

            Assert.That(Flour.GetStatus(), Does.Contain("bak").IgnoreCase);
        }

        [Test]
        public void Freeze_WhenCalled_ShouldChangeTheStatusToFreezing()
        {
            Flour.Freeze();

            Assert.That(Flour.GetStatus(), Does.Contain("freez").IgnoreCase);
        }

        [Test]
        public void UnFreeze_WhenCalled_ShouldChangeTheStatusToUnfreezing()
        {
            Flour.UnFreeze();

            Assert.That(Flour.GetStatus(), Does.Contain("unfree").IgnoreCase);
        }

        [Test]
        public void Mix_WhenCalled_ShouldChangeTheStatusToUnMixing()
        {
            Flour.Mix();

            Assert.That(Flour.GetStatus(), Does.Contain("mix").IgnoreCase);
        }

        [Test]
        public void Slice_WhenCalled_ShouldChangeTheStatusToSlicing()
        {
            Flour.Slice();

            Assert.That(Flour.GetStatus(), Does.Contain("slic").IgnoreCase);
        }
        
        [Test]
        public void Prepare_WhenCalled_ShouldChangeTheStatusToPrepairing()
        {
            Flour.Prepare();

            Assert.That(Flour.GetStatus(), Does.Contain("prepar").IgnoreCase);
        }

        [Test]
        public void GetStatus_WhenCalled_ShouldChangeTheLatestStatus()
        {
            Flour.Prepare();
            var result1 = Flour.GetStatus();

            Flour.Mix(); 
            var result2 = Flour.GetStatus();

            Assert.That(result1, Does.Contain("prepar").IgnoreCase);
            Assert.That(result2, Does.Contain("mix").IgnoreCase);
        }

    }
}
