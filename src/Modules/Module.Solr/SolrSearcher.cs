using Sediment.Infrastructure;
using SolrNet;
using SolrNet.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Solr
{
    public class SolrSearcher<T> : ISearcher<T>
    {
        private ISolrOperations<T> _operator;

        public SolrSearcher()
        { }

        public SolrSearcher(ISolrOperations<T> @operator)
        {
            _operator = @operator;
        }

        protected virtual void Add(T obj)
        {
            _operator.Add(obj);
        }

        protected virtual void Update(T obj)
        {
            _operator.Add(obj);
        }

        protected virtual void Delete(T obj)
        {
            _operator.Delete(obj);
        }

        public void Indexing(T obj, IndexingType indexingType)
        {
            switch (indexingType)
            {
                case IndexingType.Add:
                    Add(obj);
                    break;

                case IndexingType.Update:
                    Update(obj);
                    break;

                case IndexingType.Delete:
                    Delete(obj);
                    break;
            }
        }

        public IEnumerable<T> Search(ISearchQuery query)
        {
            return _operator.Query(new SolrQueryAdapter(query));
        }
    }

    public class SolrQueryAdapter: ISolrQuery
    {
        // 对象适配器

        ISearchQuery _query;

        public SolrQueryAdapter(ISearchQuery query)
        {
            _query = query;
        }
    }
}
