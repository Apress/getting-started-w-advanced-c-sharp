using System;

namespace EventsEx3
{
    //Create a subclass of System.EventArgs
    class JobNoEventArgs : EventArgs
    {
        int jobNo = 0;
        public int JobNo
        {
            get { return jobNo; }
            set { jobNo = value; }
        }      
    }

    //Create a delegate.    
    delegate void MyIntChangedEventHandler(Object sender, JobNoEventArgs eventArgs);
    //Create a Sender or Publisher for the event.
    class Sender
    {
        //Create the event based on your delegate.
        public event MyIntChangedEventHandler MyIntChanged;
        //#region Equivalent code
        //private MyIntChangedEventHandler myIntChanged;
        //public event MyIntChangedEventHandler MyIntChanged
        //{
        //    add
        //    {
        //        //Console.WriteLine("***Inside add accessor.Entry point.***");
        //        myIntChanged += value;
        //    }
        //    remove
        //    {
        //        myIntChanged -= value;
        //        //Console.WriteLine("***Inside remove accessor.Exit point.***");
        //    }
        //}

        //#endregion


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
                //Whenever you set a new value, the event will fire.
                OnMyIntChanged();
            }
        }

        /*
        In the standard practise, the method name is the event name with a prefix 'On'.
        For example, MyIntChanged(event name) is prefixed with 'On' here.
        Also, in normal practises, instead of making the method 'public', 
        you make the method 'protected virtual'.
        */
        protected virtual void OnMyIntChanged()
        {
            if (MyIntChanged != null)
            {   //Combine your data with the event argument
                JobNoEventArgs jobNoEventArgs = new JobNoEventArgs();
                jobNoEventArgs.JobNo = myInt;
                MyIntChanged(this, jobNoEventArgs);
            }            
        }
    }
    //Create a Receiver or Subscriber for the event.
    class Receiver
    {
        public void GetNotificationFromSender(Object sender, JobNoEventArgs e)
        {
            Console.WriteLine("Receiver receives a notification: Sender recently has changed the myInt value to {0}.",e.JobNo);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Passing data in the event argument.***");
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
