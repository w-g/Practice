using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sediment.Common.Test
{
    [TestClass]
    public class DateTimeExtensionsTest
    {
        [TestMethod]
        public void ToFriendlyDateString()
        {
            DateTime time = new DateTime(2007, 1, 1);

            Assert.AreEqual(time.ToFriendlyDateString(), "下周一");
        }
    }
}
