using System;

namespace Expression_BodiedPropertiesDemo
{
    class Employee
    {
        private int empId;
        private string company = "XYZ Ltd.";
        private string name = String.Empty;

        //Usual implementation of a constructor.
        //public Employee(int id)
        //{
        //    empId = id;
        //}
        //Following shows an expression-bodied constructor
        public Employee(int id) => empId = id;//ok  


        //Usual implementation of a read-only property
        //public string Company
        //{
        //    get
        //    {
        //        return company;
        //    }
        //}
        //Read-only property.C#6.0 onwards.
        public string Company => company;

        //Usual implementation
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;
        //    }
        //}

        //C#7.0 onwards , we can use expression-body definition //for the get and set accessors
        public string Name
        {
            get => name;
            set => name = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Experimenting lambda expressions with expression-bodied properties.***");
            Employee empOb = new Employee(1);
            //Error.Company is read-only
            //empOb.Company = "ABC Co."; 
            empOb.Name = "Rohan Roy ";//ok
            Console.WriteLine("{0} works in {1} as an employee.", empOb.Name, empOb.Company);
            Console.ReadKey();
        }
    }
}


