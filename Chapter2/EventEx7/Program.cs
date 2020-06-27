using System;

namespace EventsEx7
{
    abstract class Sender
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
        //Abstract event.The containing class becomes abstract for this.
        public abstract event EventHandler MyIntChanged;
        protected virtual void OnMyIntChanged()
        {
            Console.WriteLine("Sender.OnMyIntChanged");

        }
    }
    class ConcreteSender : Sender
    {
        public override event EventHandler MyIntChanged;
        protected override void OnMyIntChanged()        
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
        Console.WriteLine("***Exploring an abstract event.***");
        Sender sender = new ConcreteSender();
        Receiver receiver = new Receiver();
        //Receiver is registering for a notification from sender
        sender.MyIntChanged += receiver.GetNotificationFromSender;
        ////For Q&A Session
        //sender.MyIntChanged += new EventHandler(receiver.GetNotificationFromSender);

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
