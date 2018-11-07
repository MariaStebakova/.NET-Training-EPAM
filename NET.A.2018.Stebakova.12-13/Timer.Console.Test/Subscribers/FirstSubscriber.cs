using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLibrary;

namespace Timer.Console.Test.Subscribers
{
    public class FirstSubscriber
    {
        public void Subscribe(TimerLibrary.Timer timer)
        {
            CheckTimer(timer);
            timer.TimerEnded += ReceiveMessage;
        }

        public void Unsubscribe(TimerLibrary.Timer timer)
        {
            CheckTimer(timer);
            timer.TimerEnded -= ReceiveMessage;
        }

        private void ReceiveMessage(object sender, TimerEventArgs message)
        {
            System.Console.WriteLine($"First subscriber has recieved '{message.Message}'");
        }

        private void CheckTimer(TimerLibrary.Timer timer)
        {
            if (timer == null)
                throw new ArgumentNullException($"{nameof(timer)} can't be null");
        }
    }
}
