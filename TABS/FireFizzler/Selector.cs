using System.Collections.Generic;

namespace FireFizzler
{
    public delegate IEnumerable<TElement> Selector<TElement>(IEnumerable<TElement> elements);
}
