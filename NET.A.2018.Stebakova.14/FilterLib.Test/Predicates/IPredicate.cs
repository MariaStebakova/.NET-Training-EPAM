using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLib.Test.Predicates
{
    public interface IPredicate<in TSource>
    {
        bool IsMatch(TSource source);
    }
}
