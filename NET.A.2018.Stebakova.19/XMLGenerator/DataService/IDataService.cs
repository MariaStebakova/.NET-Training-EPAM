using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGenerator.DataService
{
    /// <summary>
    /// Interface for all data services
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Transfer data of one storage to another with established changes
        /// </summary>
        void Transfer();
    }
}
