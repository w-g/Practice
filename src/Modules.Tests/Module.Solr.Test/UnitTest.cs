using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sediment.Common;
using Sediment.Infrastructure;

namespace Module.Solr.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var user = new User { Id = Guid.NewGuid(), Username = "zb.wang", Name = "王志斌" };

            var searcher = new SolrSearcherFactory<User>().CreateSearcher();

            searcher.Indexing(user, IndexingType.Add);
        }
    }
}
