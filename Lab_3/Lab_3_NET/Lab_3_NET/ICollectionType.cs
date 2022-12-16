using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_NET
{
    internal interface ICollectionType<T>
    {
        internal void add(T x);
        internal void delete(T x);
        internal void show(CollectionType<T> CollectionType);
        internal void find(T x);
    }
}
