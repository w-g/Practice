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
            DateTime time = DateTime.Now.AddDays(-1);

           Assert.AreEqual(time.ToFriendlyDateString(), "1天前");
        }
    }
}
