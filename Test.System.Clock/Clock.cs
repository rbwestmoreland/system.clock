using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Clock = System.Clock;

namespace Test.System
{
    [TestClass]
    public class ClockTest
    {
        [TestMethod]
        public void ByDefault_Now_ShouldEqualDateTimeNow()
        {
            //assert
            Assert.AreEqual(Clock.Now.Ticks, DateTime.Now.Ticks, 100);
        }

        [TestMethod]
        public void ByDefault_UtcNow_ShouldEqualDateTimeUtcNow()
        {
            //assert
            Assert.AreEqual(Clock.UtcNow.Ticks, DateTime.UtcNow.Ticks, 100);
        }

        [TestMethod]
        public void AfterCallingFreeze_Now_ShouldNotChange()
        {
            //act
            Clock.Freeze();
            var now = Clock.Now;
            Thread.Sleep(10);

            //assert
            Assert.AreEqual(Clock.Now, now);
        }

        [TestMethod]
        public void AfterCallingFreeze_UtcNow_ShouldNotChange()
        {
            //act
            Clock.Freeze();
            var utcNow = Clock.UtcNow;
            Thread.Sleep(10);

            //assert
            Assert.AreEqual(Clock.UtcNow, utcNow);
        }

        [TestMethod]
        public void AfterCallingFreezeWithUtcDateTime_Now_ShouldNotChange()
        {
            //arrange
            var dateTime = new DateTime(2012, 12, 21);
            var expected = dateTime.ToLocalTime();

            //act
            Clock.Freeze(dateTime);
            Thread.Sleep(10);

            //assert
            Assert.AreEqual(Clock.Now, expected);
        }

        [TestMethod]
        public void AfterCallingFreezeWithUtcDateTime_UtcNow_ShouldNotChange()
        {
            //arrange
            var expected = new DateTime(2012, 12, 21);

            //act
            Clock.Freeze(expected);
            Thread.Sleep(10);

            //assert
            Assert.AreEqual(Clock.UtcNow, expected);
        }

        [TestMethod]
        public void AfterCallingFreezeWithLocalDateTime_Now_ShouldNotChange()
        {
            //arrange
            var expected = new DateTime(2012, 12, 21);

            //act
            Clock.Freeze(expected, true);
            Thread.Sleep(10);

            //assert
            Assert.AreEqual(Clock.Now, expected);
        }

        [TestMethod]
        public void AfterCallingFreezeWithLocalDateTime_UtcNow_ShouldNotChange()
        {
            //arrange
            var dateTime = new DateTime(2012, 12, 21);
            var expected = dateTime.ToUniversalTime();

            //act
            Clock.Freeze(dateTime, true);
            Thread.Sleep(10);

            //assert
            Assert.AreEqual(Clock.UtcNow, expected);
        }

        [TestMethod]
        public void AfterCallingUnfreeze_Now_ShouldEqualDateTimeUtcNow()
        {
            //act
            Clock.Freeze();
            Thread.Sleep(10);
            Clock.Unfreeze();

            //assert
            Assert.AreEqual(DateTime.Now.Ticks, Clock.Now.Ticks, 100);
        }

        [TestMethod]
        public void AfterCallingUnfreeze_UtcNow_ShouldEqualDateTimeUtcNow()
        {
            //act
            Clock.Freeze();
            Thread.Sleep(10);
            Clock.Unfreeze();

            //assert
            Assert.AreEqual(DateTime.UtcNow.Ticks, Clock.UtcNow.Ticks, 100);
        }
    }
}
