using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Rail_Bag_Simulation;

namespace Simulation_Unit_Tests
{
    [TestFixture]
    public class Tests
    {
        private Node node;
        [SetUp]
        public void Setup()
        {
            node = new CheckinNode();
        }

        [Test]
        public void Peek_WhenCalled_ReturnTheAddedBagToTheQueue()
        {
            Bag b = new Bag(2, Destination.Amsterdam, "T1-G2"); 
            node.Push(b);
            var result = node.Peek();

            Assert.That(result, Is.EqualTo(b));
        }

        [Test]
        public void Remove_WhenCalledOnFullQueue_ReturnTheAddedBagToTheQueueAndRemovesItFromTheList()
        {
            Bag b = new Bag(2, Destination.Amsterdam, "T1-G2");
            node.Push(b);

            var result = node.Remove();

            Assert.That(result, Is.EqualTo(b));
            Assert.That(node.QueueCount,Is.EqualTo(0));
        }

        [Test]
        public void Remove_WhenCalledOnEmptyQueue_ReturnsNull()
        {
            Assert.That(node.Remove(), Is.Null);
        }

        [Test]
        public void Peek_WhenCalledOnEmptyQueue_ReturnsNull()
        {
            Assert.That(node.Peek(), Is.Null);
        }

        [Test]
        public void Push_WhenCalled_AddTheBagTheQueue()
        {
            Bag b = new Bag(2, Destination.Amsterdam, "T1-G2");
            node.Push(b);

            Assert.That(node.QueueCount, Is.EqualTo(1));
        }

        [Test]
        public void MoveBagToNextNode_WhenCalled_MovesTheBagToTheNextNode()
        {
            Bag b = new Bag(2, Destination.Amsterdam, "T1-G2");
            node.Push(b);
            
            ConveyorNode cn = new ConveyorNode(5);
            node.SetNext(cn);

            node.MoveBagToNextNode();
            // 2 is expected because the method add a null value after every bag
            Assert.That(cn.QueueCount, Is.EqualTo(2));
        }


        [Test]
        public void SetNext_WhenCalled_SetsTheNextNode()
        {
            ConveyorNode cn = new ConveyorNode(5);
          
            node.SetNext(cn);

            Assert.That(node.GetNext(), Is.EqualTo(cn));
        }

        [Test]
        public void GetNext_WhenCalled_GetsTheNextNode()
        {
            ConveyorNode cn = new ConveyorNode(5);
            node.SetNext(cn);

            var result = node.GetNext();

            Assert.That(result, Is.EqualTo(cn));
        }
    }
}