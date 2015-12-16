﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.Infrastructure
{
    public interface ISearcherFactory<T>
    {
        ISearcher<T> CreateSearcher();
    }
}
