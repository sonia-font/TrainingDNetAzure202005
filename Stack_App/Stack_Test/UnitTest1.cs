using NUnit.Framework;
using Stack_App;
using Stack_App.Entities;
using System;
using System.Linq;

namespace Stack_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenPushStackOk()
        {
            Stack<TestEntity> testStackPush = new Stack<TestEntity>();
            TestEntity testEntity = new TestEntity();            

            testStackPush.Push(testEntity);

            Assert.IsNotEmpty(testStackPush);
            Assert.AreEqual(1, testStackPush.Count());            
        }

        [Test]
        public void WhenPushStackFull()
        {
            Stack<TestEntity> testStackFull = new Stack<TestEntity>();
            for (int i = 0; i < 10; i++)
            {
                TestEntity testEntity = new TestEntity();
                testStackFull.Push(testEntity);
            }

            try
            {
                TestEntity testEntity = new TestEntity();
                testStackFull.Push(testEntity);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Stack is full");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [Test]
        public void WhenPopStackOk()
        {
            Stack<TestEntity> testStackPop = new Stack<TestEntity>();
            TestEntity testEntity = new TestEntity();

            testStackPop.Push(testEntity);
            testStackPop.Pop();
                        
            Assert.IsEmpty(testStackPop);
            Assert.AreEqual(0, testStackPop.Count());
        }

        [Test]
        public void WhenPopStackEmpty()
        {
            Stack<TestEntity> testStackEmpty = new Stack<TestEntity>();            

            try
            {                
                testStackEmpty.Pop();
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Stack is empty");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        class TestEntity : Person
        {
            public override void GetName()
            {
                throw new NotImplementedException();
            }
        }
    }
}