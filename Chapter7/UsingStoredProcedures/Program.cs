using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace UsingStoredProcedures
{
    class Program
    {
        static string connectMe = String.Empty;
        static MySqlConnection mySqlConnection = null;
        static MySqlCommand mySqlCommand = null;        
        static MySqlDataReader mySqlDataReader = null;
        static void Main(string[] args)
        {
            Console.WriteLine("***Demonstration-4.Using stored procedure now.***");
            try
            {
                /*Open the database connection i.e. connect to a 
                 MySQL database.*/
                ConnectToMySqlDatabase();
                //Display details of Employee table.
                DisplayRecordsFromEmployeeTable();
                //Insert a new record in Employee table.
                InsertNewRecordIntoEmployeeTable();
                //Delete a record from the Employee table.
                DeleteRecordFromEmployeeTable();
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
                #region old code( which you saw in previous demonstrations)
                //string sqlQuery = "select * from Employee ;";
                //mySqlCommand = new MySqlCommand(sqlQuery, mySqlConnection);                
                #endregion
                #region new code
                //The following lines are moved to a common place
                //mySqlCommand = new MySqlCommand();     
                //mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = "SelectAllEmployees";//Using Stored Procedure
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                #endregion
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
        private static void InsertNewRecordIntoEmployeeTable()
        {
            try
            {
                // Old code in demonstration2
                //mySqlCommand = new MySqlCommand("insert into Employee values(4,'John',27,975);", mySqlConnection);

                #region new code
                //The following lines are moved to a common place
                //mySqlCommand = new MySqlCommand();
                //mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = "InsertOneNewrecord";//Using Stored Procedure
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                #endregion

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
        private static void DeleteRecordFromEmployeeTable()
        {
            try
            {
                Console.WriteLine("Enter the employee name to be deleted from Employee table.");
                string empNameToDelete = Console.ReadLine();                

                #region new code
                MySqlParameter deleteParameter = new MySqlParameter("NameToBeDeleted", MySqlDbType.VarChar);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                //Using Stored Procedure
                mySqlCommand.CommandText = "DeleteOneRecord";
                /*The following code segment will also work but in that case , 
                you have to add the value to the parameter first.*/
                //deleteParameter.Value = empNameToDelete;
                //mySqlCommand.Parameters.Add(deleteParameter);
                mySqlCommand.Parameters.AddWithValue("NameToBeDeleted", empNameToDelete);

                #endregion
                if (mySqlCommand.ExecuteNonQuery()==1)
                {
                    //If deletion performs successfully , print this message.
                    Console.WriteLine("One record is deleted from employee table.");
                }
                else
                {
                    Console.WriteLine("Couldn't delete the record from employee table.");
                }

               Console.WriteLine("Here is the current table:");
               DisplayRecordsFromEmployeeTable();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Cannot delete the record.Here is the problem details.");
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
                /*Initializing Command here to remove 
                duplicate codes.*/
                mySqlCommand = new MySqlCommand();
                mySqlCommand.Connection = mySqlConnection;
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

