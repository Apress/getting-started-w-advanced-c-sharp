using System;
using MySql.Data.MySqlClient;

namespace ExercisingSqlCommands
{
    class Program
    {
        static string connectMe = String.Empty;
        static MySqlConnection mySqlConnection = null;        
        static MySqlDataReader mySqlDataReader = null;        
        static MySqlCommand mySqlCommand = null;
        static void Main(string[] args)
        {
            Console.WriteLine("***Demonstration-2.Connecting and retrieving details from a MySQL database table.***");
            try
            {
                /* Open the database connection i.e. connect to a 
                 MySQL database.*/
                ConnectToMySqlDatabase();
                //Display details of Employee table.
                DisplayRecordsFromEmployeeTable();

                #region insert and delete a record                
                //Insert a new record in Employee table.
                InsertNewRecordIntoEmployeeTable();
                //Delete a record from the Employee table.
                DeleteRecordFromEmployeeTable();
                #endregion
                #region Update and reset a record
                /*
                First updating a record and then resetting the value
                So, basically there are two updates.
                */
                UpdateExistingRecordIntoEmployeeTable();                
                #endregion

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

        private static void UpdateExistingRecordIntoEmployeeTable()
        {
            try
            {
                Console.WriteLine("Updating Bob's salary to 3000.75");

                mySqlCommand = new MySqlCommand("update Employee set Salary=3000.75 where name='Bob';", mySqlConnection);
                mySqlCommand.ExecuteNonQuery();

                //If update performs successfully , print this message.
                Console.WriteLine("One record is updated in employee table.");
                Console.WriteLine("Here is the current table:");
                DisplayRecordsFromEmployeeTable();

                Console.WriteLine("Now resetting Bob's salary to 1500.00");
                mySqlCommand = new MySqlCommand("update Employee set Salary=1500.00 where name='Bob';", mySqlConnection);
                mySqlCommand.ExecuteNonQuery();               

                //If update performs successfully , print this message.
                Console.WriteLine("One record is updated in employee table.");
                Console.WriteLine("Here is the current table:");
                DisplayRecordsFromEmployeeTable();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Cannot update the record.Here is the problem details.");
                Console.WriteLine(ex.Message);
                //Console.ReadKey();
            }
        }

        private static void DeleteRecordFromEmployeeTable()
        {
            try
            {
                Console.WriteLine("Enter the employee name to be deleted from Employee table.");
                string empNameToDelete = Console.ReadLine();
                /* Additional validation required to confirm the employee name exists in the table.
                Or, whether its a valid entry or not.
                */
                mySqlCommand = new MySqlCommand("Delete from employee where name=@NameToBeDeleted", mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@NameToBeDeleted", empNameToDelete);
                mySqlCommand.Prepare();
                mySqlCommand.ExecuteNonQuery();                

                /*If deletion performs successfully , print 
                 this message.*/
                Console.WriteLine("One record is deleted from employee table.");
                Console.WriteLine("Here is the current table:");
                DisplayRecordsFromEmployeeTable();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Cannot delete the record.Here is the problem details.");
                Console.WriteLine(ex.Message);               
            }
        }

        private static void InsertNewRecordIntoEmployeeTable()
        {
            try
            {
                mySqlCommand = new MySqlCommand("insert into Employee values(4,'John',27,975);", mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                Console.WriteLine("New record insertion successful.");
                Console.WriteLine("Here is the current table:");
                DisplayRecordsFromEmployeeTable();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Cannot insert the new record.Here is the problem details.");
                Console.WriteLine(ex.Message);                
            }
        }

        private static void DisplayRecordsFromEmployeeTable()
        {
            try
            {
                string sqlQuery = "select * from Employee ;";
                mySqlCommand = new MySqlCommand(sqlQuery, mySqlConnection);
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

