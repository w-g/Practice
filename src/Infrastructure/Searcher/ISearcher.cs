using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.Infrastructure
{
    public interface ISearcher<T>
    {
        void Indexing(T obj, IndexingType indexingType);

        IEnumerable<T> Search(ISearchQuery query);
    }

    public interface ISearchQuery
    {
    }

    public enum IndexingType
    {
        Add,

        Update,

        Delete
    }
}
