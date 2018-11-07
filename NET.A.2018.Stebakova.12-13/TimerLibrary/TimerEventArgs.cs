using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    /// <summary>
    /// Class that provides <see cref="EventArgs"/> argument type for <see cref="Timer.TimerEnded"/>
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        private string _message;

        public string Message => _message;

        public TimerEventArgs(string message)
        {
            _message = message;
        }
    }
}
