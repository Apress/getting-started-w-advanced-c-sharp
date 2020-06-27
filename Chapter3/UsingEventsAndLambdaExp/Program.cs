using System;

namespace UsingEventsAndLambdaExp
{
    class Sender
    {
        private int myInt;
        public int MyInt
        {
            get
            {
                return myInt;
            }
            set
            {
                myInt = value;
                //Whenever we set a new value, the event will fire.
                OnMyIntChanged();
            }
        }
        //EventHandler is a predefined delegate which is used to handle simple events.
        //It has the following signature:
        //delegate void System.EventHandler(object sender,System.EventArgs e)
        //where the sender tells who is sending the event and
        //EventArgs is used to store information about the event.
        public event EventHandler MyIntChanged;
        public void OnMyIntChanged()
        {
            if (MyIntChanged != null)
            {
                MyIntChanged(this, EventArgs.Empty);
            }
        }

        public void GetNotificationItself(Object sender, System.EventArgs e)
        {
            Console.WriteLine("Sender himself send a notification: I have changed myInt value  to {0} ", myInt);
        }
    }
    //class Receiver
    //{
    //    public void GetNotificationFromSender(Object sender, System.EventArgs e)
    //    {
    //        Console.WriteLine("Receiver receives a notification: Sender recently has changed the myInt value . ");
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Demonstration-.Exploring events with lambda expression.***");
            Sender sender = new Sender();

            //Using lambda expression as an event handler
            //Bad practise
            //sender.MyIntChanged += (Object sender, System.EventArgs e) =>
            // Console.WriteLine("Using lambda expression, inside Main method, received a notification: Sender recently has changed the myInt value . ");
            //Better practise
            EventHandler myEvent = (object sender, EventArgs e) =>
              Console.WriteLine("Using lambda expression, inside Main method, received a notification: Sender recently has changed the myInt value . ");
            sender.MyIntChanged += myEvent;            
            sender.MyInt = 1;
            sender.MyInt = 2;
            //Unregistering now
            //sender.MyIntChanged -= receiver.GetNotificationFromSender;
            //No notification sent for the receiver now.
            //but no guarantee if you follow the bad practise
            //sender.MyIntChanged -= (Object sender, System.EventArgs e) =>
            // Console.WriteLine("Unregistered event notification.");

            //But now it can remove the event properly.
            sender.MyIntChanged -= myEvent;
            sender.MyInt = 3;
           

            Console.ReadKey();

        }
    }
}
