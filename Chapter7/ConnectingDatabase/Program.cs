using System;
using MySql.Data.MySqlClient;

namespace ConnectingDatabase
{
    class Program
    {
        static string connectMe = String.Empty;
        static MySqlConnection mySqlConnection = null;        
        static MySqlCommand mySqlCommand = null;
        static MySqlDataReader mySqlDataReader = null;
        static void Main(string[] args)
        {
            Console.WriteLine("***Demonstration-1.Connecting and retrieving details from a MySQL database table.***");
            try
            {
                /* Open the database connection i.e. connect to a 
                 MySQL database.*/
                ConnectToMySqlDatabase();
                //Display details of Employee table.
                DisplayRecordsFromEmployeeTable();
                //Close the database connection.
                CloseDatabaseConnection();                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught exception.Here is the problem details.");
                Console.WriteLine(ex.Message);                
            }
            Console.ReadKey();
        }

        private static void DisplayRecordsFromEmployeeTable()
        {
            try
            {
                string sqlQuery = "select * from Employee ;";
                mySqlCommand = new MySqlCommand(sqlQuery,mySqlConnection);
                mySqlDataReader = mySqlCommand.ExecuteReader();
                Console.WriteLine("EmployeeId\t" + "EmployeeName\t" + "Age\t" + "Salary");
                Console.WriteLine("___________________________________________");
                while (mySqlDataReader.Read())
                {
                    Console.WriteLine(mySqlDataReader["EmpId"] + "\t\t" + mySqlDataReader["Name"] + "\t\t" + mySqlDataReader["Age"] + "\t" + mySqlDataReader["Salary"]);
                }
                mySqlDataReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Cannot show the records.Here is the problem details.");
                Console.WriteLine(ex.Message);                
            }
        }

        private static void ConnectToMySqlDatabase()
        {
            try
            {
                //The following will also work
                //connectMe = "datasource=localhost;port=3306;database=test;username=root;password=admin";
                connectMe = "server=localhost;database=test;username=root;password=admin";
                mySqlConnection = new MySqlConnection(connectMe);
                mySqlConnection.Open();
                Console.WriteLine("Connection to MySQL successful.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Could not connect to the database.Here is the problem details.");
                Console.WriteLine(ex.Message);                
            }
        }
        private static void CloseDatabaseConnection()
        {
            try
            {
                mySqlConnection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Could not close the connection.Here is the problem details.");
                Console.WriteLine(ex.Message);                
            }
        }
    }
}
