using System;

namespace EventsEx2
{
    //Step 1-Create a delegate.
    //You can pick an name (this name will be your event name)
    //which has the suffix EventHandler.For example, in the following case 
    //'MyIntChanged' is the event name which has the suffix 'EventHandler'

    delegate void MyIntChangedEventHandler(Object sender, EventArgs eventArgs);

    // Create a Sender or Publisher for the event.
    class Sender
    {
        //Step-2: Create the event based on your delegate.
        public event MyIntChangedEventHandler MyIntChanged;

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
                //Raise the event.
                //Whenever we set a new value, the event will fire.
                OnMyIntChanged();
            }
        }

        /* Step-3.
        In the standard practise, the method name is the event name with a prefix 'On'.
        For example, MyIntChanged(event name) is prefixed with 'On' here.
        Also, in normal practises, instead of making the method 'public', 
        you make the method 'protected virtual'.
        */
        protected virtual void OnMyIntChanged()
        {
            //if (MyIntChanged != null)
            //{
            //    MyIntChanged(this, EventArgs.Empty);
            //}
            //Alternate code
            MyIntChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    //Step-4: Create a Receiver or Subscriber for the event.
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
            Console.WriteLine("***Exploring a custom event.***");
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
