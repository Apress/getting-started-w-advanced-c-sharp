using System;

namespace SelfReferencingGenericTypeDemo
{
    interface IIdenticalEmployee<T>
    {
        string CheckEqualityWith(T obj);
        
    }
   // class Employee : IIdenticalEmployee<Employee>,IComparable<Employee>,IEquatable<Employee>
    class Employee : IIdenticalEmployee<Employee>
    {
        string deptName;
        int employeeID;
        public Employee(string deptName, int employeeId)
        {
            this.deptName = deptName;
            this.employeeID = employeeId;
        }
        public string CheckEqualityWith(Employee obj)
        {
            if (obj == null)
            {
                return "Cannot Compare with a null Object";
            }
            else
            {
                if (this.deptName == obj.deptName && this.employeeID == obj.employeeID)
                {
                    return "Same Employee.";
                }
                else
                {
                    return "Different Employees.";
                }
            }
        }
        ////Implementing IComparable<Employee> interface
        //public int CompareTo([AllowNull] Employee obj)
        //{
            
        //    throw new NotImplementedException();
        //}
        ////Implementing IEquatable<Employee> interface
        //public bool Equals([AllowNull] Employee other)
        //{
        //    throw new NotImplementedException();
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**Self-referencing generic type demo.***\n");
            Console.WriteLine("***We are checking whether two employee objects are same or different.***");
            Console.WriteLine();
            Employee emp1 = new Employee("Chemistry", 1);
            Employee emp2 = new Employee("Maths", 2);
            Employee emp3 = new Employee("Comp. Sc.", 1);
            Employee emp4 = new Employee("Maths", 2);
            Employee emp5 = null;
            Console.WriteLine("Comparing emp1 and emp3 :{0}", emp1.CheckEqualityWith(emp3));
            Console.WriteLine("Comparing emp2 and emp4 :{0}", emp2.CheckEqualityWith(emp4));
            Console.WriteLine("Comparing emp2 and emp5 :{0}", emp2.CheckEqualityWith(emp5));            
            Console.ReadKey();
        }
    }
}

