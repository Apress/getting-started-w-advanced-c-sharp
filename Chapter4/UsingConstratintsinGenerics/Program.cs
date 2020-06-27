using System;
using System.Collections.Generic;

namespace UsingConstratintsinGenerics
{
    interface IEmployee
    {
        string Position();
    }
    class Employee : IEmployee
    {
        public string Name;
        public int YearOfExp;
        //public Employee() { }
        public Employee(string name, int yearOfExp)
        {
            this.Name = name;
            this.YearOfExp = yearOfExp;
        }
        public string Position()
        {
            string designation;
            //C#7.0 onwards range based switch statements are allowed.
            switch (YearOfExp)
            {
                case int n when (n <= 1):
                    designation = "Fresher";
                    break;

                case int n when (n >= 2 && n <= 5):
                    designation = "Intermediate";
                    break;
                default:
                    designation = "Expert";
                    break;
            }
            return designation;
        }

    }
    //class EmployeeStoreHouse<T> where T : new(),IEmployee//error
    //The following line of code is ok when T has a public parameterless constructor
    //class EmployeeStoreHouse<T> where T : IEmployee, new()
    //class EmployeeStoreHouse<T> where T : IEmployee, new(int)//it's also error
    class EmployeeStoreHouse<T> where T : IEmployee
    {
        private List<Employee> EmpStore = new List<Employee>();
        public void AddToStore(Employee element)
        {
            EmpStore.Add(element);
        }
        public void DisplayStore()
        {
            Console.WriteLine("The store contains:");
            foreach (Employee e in EmpStore)
            {
                Console.WriteLine(e.Position());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Using constraints in generic programming.***\n");
            //Employees
            Employee e1 = new Employee("Suresh", 1);
            Employee e2 = new Employee("Jack", 5);
            Employee e3 = new Employee("Jon", 7);
            Employee e4 = new Employee("Michael", 2);
            Employee e5 = new Employee("Amit", 3);

            //Employee StoreHouse
            EmployeeStoreHouse<Employee> myEmployeeStore = new EmployeeStoreHouse<Employee>();
            myEmployeeStore.AddToStore(e1);
            myEmployeeStore.AddToStore(e2);
            myEmployeeStore.AddToStore(e3);
            myEmployeeStore.AddToStore(e4);
            myEmployeeStore.AddToStore(e5);

            //Display the Employee Positions in Store
            myEmployeeStore.DisplayStore();

            Console.ReadKey();
        }
    }
}
