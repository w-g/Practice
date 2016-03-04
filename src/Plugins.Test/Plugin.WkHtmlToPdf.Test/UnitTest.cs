using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sediment.HtmlToPdf;

namespace Plugin.WkHtmlToPdf.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            IHtmlToPdfConverter converter = new WkHtmlToPdfConverter();
            var content = converter.Convert("http://www.sina.com/");
            Assert.IsNotNull(content);
        }
    }
}
