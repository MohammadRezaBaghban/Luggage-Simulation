using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rail_Bag_Simulation;

namespace Simulation_Unit_Tests
{
    [TestFixture]
    class SecurityNodeTests
    {
        private SecurityNode node;
        [SetUp]
        public void Setup()
        {
            node = new SecurityNode();
        }

        [Test]
        public void Remove_WhenCalledOnSuspiciousBag_ReturnsNullAndAddTheBagToStorage()
        {
            Bag b = new Bag(SuspiciousBagtype.Drug,2, Destination.Amsterdam, "T1-G2");
            node.Push(b);

            var result = node.Remove();

            Assert.That(result, Is.Null);
            Assert.That(Storage.GetNumberOfBagsInStorage(), Is.EqualTo(1));
        }
    }
}
