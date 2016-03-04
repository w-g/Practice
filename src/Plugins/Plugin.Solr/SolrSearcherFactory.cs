using Sediment.Infrastructure;
using Sediment.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Solr
{
    public class SolrSearcherFactory<T> : ISearcherFactory<T>
    {
        public ISearcher<T> CreateSearcher()
        {
            return new SolrSearcher<T>();
        }
    }
}
