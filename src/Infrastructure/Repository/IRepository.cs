using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sediment.Common
{
    public interface IRepository<T>
    {
        /* 数据仓储层提供数据的仓储服务：
         * 业务层“告诉”仓储层：“我要****的数据”或者“我要****（操作）数据”
         */

        /* 业务逻辑层提供业务逻辑服务：
         * 业务逻辑基于业务需求，业务需求是发展的、变化的
         * 程序应尽可能地适应需求的变化，同时程序不应需求的变化而出现很大的变化，即程序应是可扩展的
         * 业务需求的变化应该只会引起业务逻辑层的变更，而不会影响数据仓储层
         * 那么，业务逻辑就不应当被延迟到数据仓储层去实现
         */

        /* ORM是数据仓储层的实现工具，而非数据仓储层本身
         * 数据仓储层的实现并不限于关系数据库，可能是NoSql或者XML，甚至是文件
         * predicate（谓词逻辑） 应由业务逻辑层提供
         * 数据仓储层应提供数据的增、改、删、查实例、查实例列表、查计数
         */

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Get(int id);

        T Get(Expression<Func<T, bool>> predicate);

        int Count(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order);

        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int skip, int count);
    }
}
