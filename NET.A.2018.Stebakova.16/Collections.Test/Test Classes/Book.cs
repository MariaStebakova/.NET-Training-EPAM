using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Test.Test_Classes
{
    public class Book: IComparable<Book>
    {
        public int Cost { get; }

        public Book(int cost)
        {

            Cost = cost;
        }

        public int CompareTo(Book other)
        {
            if (other == null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            return Cost.CompareTo(other.Cost);
        }

    }
}

