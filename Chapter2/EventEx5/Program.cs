using System;

namespace EventEx5
{
    interface IMyInterface
    {
        //An interface event
        event EventHandler MyIntChanged;
    }
    class Sender : IMyInterface
    {
        //Declare the event here and raise from your intended location
        public event EventHandler MyIntChanged;
        private int myInt;
        public int MyInt
        {
            get
            {
                return myInt;
            }
            set
            {
                //Setting a new value prior to raise the event.
                myInt = value;
                OnMyIntChanged();
            }
        }

        protected virtual void OnMyIntChanged()
        {
            if (MyIntChanged != null)
            {
                MyIntChanged(this, EventArgs.Empty);
            }
        }
    }
    class Receiver
    {
        public void GetNotificationFromSender(Object sender, System.EventArgs e)
        {
            Console.WriteLine("Receiver receives a notification: Sender recently has changed the myInt value . ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Exploring an event with an interface.***");
            Sender sender = new Sender();
            Receiver receiver = new Receiver();
            //Receiver is registering for a notification from sender
            sender.MyIntChanged += receiver.GetNotificationFromSender;

            sender.MyInt = 1;
            sender.MyInt = 2;
            //Unregistering now
            sender.MyIntChanged -= receiver.GetNotificationFromSender;
            //No notification sent for the receiver now.             
            sender.MyInt = 3;        

            Console.ReadKey();
        }
    }
}
