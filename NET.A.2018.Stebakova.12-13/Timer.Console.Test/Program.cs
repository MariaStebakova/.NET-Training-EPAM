using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer.Console.Test.Subscribers;
using TimerLibrary;

namespace Timer.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerLibrary.Timer timer = new TimerLibrary.Timer();
            FirstSubscriber firstSubscriber = new FirstSubscriber();
            SecondSubscriber secondSubscriber = new SecondSubscriber();
            
            firstSubscriber.Subscribe(timer);
            secondSubscriber.Subscribe(timer);

            timer.StartTimer(10, "test");

            secondSubscriber.Unsubscribe(timer);

            timer.StartTimer(5, "test1");

            System.Console.ReadLine();
        }
    }
}
