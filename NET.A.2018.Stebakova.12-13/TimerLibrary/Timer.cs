using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace TimerLibrary
{
    /// <summary>
    /// Class for providing timer functionality
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Event that occurs when timer is up
        /// </summary>
        public event EventHandler<TimerEventArgs> TimerEnded;

        /// <summary>
        /// Method for setting up the timer
        /// </summary>
        /// <param name="timeInSeconds">Time for timing in seconds</param>
        /// <param name="message">Message for sending to subscribers of <see cref="TimerEnded"/> event</param>
        public void StartTimer(int timeInSeconds, string message)
        {
            if (timeInSeconds == 0)
                throw new ArgumentException($"{nameof(timeInSeconds)} can't be 0");

            Start(timeInSeconds);

            TimerEnded?.Invoke(this, new TimerEventArgs(message));
        }

        private void Start(int time)
        {

            for (int i = time; i > 0; i--)
            {
                Thread.Sleep(1000);
            }
        }    
    }
}
