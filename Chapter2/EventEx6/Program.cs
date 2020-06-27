using System;

namespace EventEx6
{
    interface IBeforeInterface
    {
        public event EventHandler MyIntChanged;
    }
    interface IAfterInterface
    {
        public event EventHandler MyIntChanged;
    }
    class Sender : IBeforeInterface, IAfterInterface
    {
        //Craeting two separate events for two interface events
        public event EventHandler BeforeMyIntChanged;
        public event EventHandler AfterMyIntChanged;
        //Microsoft recommends this, i.e. to use a lock inside accessors
        object objectLock = new Object();

        private int myInt;
        public int MyInt
        {
            get
            {
                return myInt;
            }
            set
            {
                //Fire an event before we make a change to myInt.
                OnMyIntChangedBefore();
                Console.WriteLine("Making a change to myInt from {0} to {1}.",myInt,value);
                myInt = value;
                //Fire an event after we make a change to myInt.
                OnMyIntChangedAfter();
            }
        }
        // Explicit interface implementation required.
        // Associate IBeforeInterface's event with
        // BeforeMyIntChanged
        event EventHandler IBeforeInterface.MyIntChanged
        {
            add
            {
                lock (objectLock)
                {
                    BeforeMyIntChanged += value;
                }
            }

            remove
            {
                lock (objectLock)
                {
                    BeforeMyIntChanged -= value;
                }
            }
        }
        // Explicit interface implementation required.
        // Associate IAfterInterface's event with
        // AfterMyIntChanged

        event EventHandler IAfterInterface.MyIntChanged
        {
            add
            {
                lock (objectLock)
                {
                    AfterMyIntChanged += value;
                }
            }

            remove
            {
                lock (objectLock)
                {
                    AfterMyIntChanged -= value;
                }
            }
        }
        //This method uses BeforeMyIntChanged event
        protected virtual void OnMyIntChangedBefore()
        {
            if (BeforeMyIntChanged != null)
            {
                BeforeMyIntChanged(this, EventArgs.Empty);
            }                    
        }
        //This method uses AfterMyIntChanged event
        protected virtual void OnMyIntChangedAfter()
        {
            if (AfterMyIntChanged != null)
            {
                AfterMyIntChanged(this, EventArgs.Empty);
            }
        }
    }
    //First receiver: ReceiverBefore class
    class ReceiverBefore
    {
        public void GetNotificationFromSender(Object sender, System.EventArgs e)
        {
            Console.WriteLine("ReceiverBefore receives : Sender is about to change the myInt value . ");
        }
    }
    //Second receiver: ReceiverAfter class
    class ReceiverAfter
    {
        public void GetNotificationFromSender(Object sender, System.EventArgs e)
        {
            Console.WriteLine("ReceiverAfter receives : Sender recently has changed the myInt value . ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Handling explicit interface events.***");
            Sender sender = new Sender();
            ReceiverBefore receiverBefore = new ReceiverBefore();
            ReceiverAfter receiverAfter = new ReceiverAfter();
            //Receiver's are registering for getting notifications from Sender
            sender.BeforeMyIntChanged += receiverBefore.GetNotificationFromSender;
            sender.AfterMyIntChanged += receiverAfter.GetNotificationFromSender;

            sender.MyInt = 1;
            Console.WriteLine("");
            sender.MyInt = 2;
            //Unregistering now
            sender.BeforeMyIntChanged -= receiverBefore.GetNotificationFromSender;
            sender.AfterMyIntChanged -= receiverAfter.GetNotificationFromSender;
            Console.WriteLine("");
            //No notification sent for the receivers now.
            sender.MyInt = 3;

            Console.ReadKey();
        }
    }
}
