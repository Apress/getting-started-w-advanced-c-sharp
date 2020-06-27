using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace TestingDisconnectedArchitecture
{
    class Program
    {
        static string connectMe = String.Empty;
        static string sqlCommand = String.Empty;
        static MySqlDataAdapter mySqlDataAdapter = null;
        static MySqlCommandBuilder mySqlCommandBuilder = null;
        static DataSet localDataSet = null;

        static void Main(string[] args)
        {
            Console.WriteLine("***Connecting and retrieving details from a MySQL database table.***");
            Console.WriteLine("***Testing the disconnected architecture now.***");

            try
            {
                //Get a local copy of Employee table
                DataTable localDataTable = CreateLocalTable();
                //Display from the client-side(local)table.
                DisplayRecordsFromEmployeeTable(localDataTable);
                /*Insert a new record into local table and 
                 sync it with the database.*/
                InsertRecordIntoEmployeeTable(localDataTable);
                Console.WriteLine("**After Inserting a record into the Employee table...**");
                DisplayRecordsFromEmployeeTable(localDataTable);
                /* Delete an existing record from local table and 
                sync it with the database.*/
                DeleteRecordIntoEmployeeTable(localDataTable);
                Console.WriteLine("**After deleting a record into the Employee table...**");
                DisplayRecordsFromEmployeeTable(localDataTable);
                //Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught exception.Here is the problem details.");
                Console.WriteLine(ex.Message);
                //Console.ReadKey();
            }
            Console.ReadKey();
        }

        private static void DeleteRecordIntoEmployeeTable(DataTable localDataTable)
        {
            try
            {
                Console.WriteLine("Now deleting the record for EmpId4.");
                DataTable dataTable = localDataSet.Tables["Employee"];
                //Deleting a record
                DataRow deleteRow = dataTable.Rows.Find(4);
                deleteRow.Delete();
                /* If deletion performs successfully , 
                 print this message.*/
                Console.WriteLine("Successfully deleted the record from local buffer where EmpId was 4.");
                //Apply the change to MySQL
                mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
                Console.WriteLine("Syncing with remote database table");
                mySqlDataAdapter.Update(localDataSet, "Employee");
                Console.WriteLine("Successfullly updated the remote table.\n");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Could not delete the record.Here is the problem details.");
                Console.WriteLine(ex.Message);
                //Console.ReadKey();
            }
        }

        private static void InsertRecordIntoEmployeeTable(DataTable localDataTable)
        {
            try
            {
                /* Creates a new record with the same schema 
                 as the table. */
                DataRow currentRow = localDataTable.NewRow();
                currentRow["EmpId"] = 4;
                currentRow["Name"] = "Jack";
                currentRow["Age"] = 40;
                currentRow["Salary"] = 2500.75;

                //Also works
                //currentRow[0] = 4;
                //currentRow[1] = "Jack";
                //currentRow[2] = 40;
                //currentRow[3] = 2500.75;

                //Add this record to local table
                localDataTable.Rows.Add(currentRow);
                Console.WriteLine("Successfully added a record into local buffer.");
                int noOfRecords = localDataTable.Rows.Count;
                Console.WriteLine("Local table currently has {0} number of records.", noOfRecords);
                //Apply the change to MySQL
                mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
                Console.WriteLine("Syncing with remote database table");
                mySqlDataAdapter.Update(localDataSet, "Employee");
                Console.WriteLine("Successfullly updated the remote table");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Could not insert the record.Here is the problem details.");
                Console.WriteLine(ex.Message);
                //Console.ReadKey();
            }

        }

        private static void DisplayRecordsFromEmployeeTable(DataTable localDataTable)
        {
            try
            {
                int noOfRecords = localDataTable.Rows.Count;
                Console.WriteLine("Here is the table for you:");
                Console.WriteLine("EmployeeId\t" + "EmployeeName\t" + "Age\t" + "Salary");
                Console.WriteLine("___________________________________________");
                for (int currentRow = 0; currentRow < noOfRecords; currentRow++)
                {
                    Console.WriteLine(
                       localDataTable.Rows[currentRow]["EmpId"] + "\t\t" +
                       localDataTable.Rows[currentRow]["Name"] + "\t\t" +
                       localDataTable.Rows[currentRow]["Age"] + "\t" +
                       localDataTable.Rows[currentRow]["Salary"]
                       );
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Cannot show the records.Here is the problem details.");
                Console.WriteLine(ex.Message);
                //Console.ReadKey();
            }
        }

        private static DataTable CreateLocalTable()
        {
            connectMe = "datasource=localhost;port=3306;database=test;username=root;password=admin";
            sqlCommand = "select * from Employee";
            mySqlDataAdapter = new MySqlDataAdapter(sqlCommand, connectMe);
            //Also works
            //mySqlConnection = new MySqlConnection(connectMe);
            //mySqlDataAdapter = new MySqlDataAdapter(sqlCommand, mySqlConnection);
            //Create a DataSet instance
            /*I recommend you to use the following overloaded constructor 
             of DataSet to use.*/
            localDataSet = new DataSet("LocalDataSet");
            //Retrieve details from 'Employee' table
            mySqlDataAdapter.FillSchema(localDataSet, SchemaType.Source, "Employee");
            mySqlDataAdapter.Fill(localDataSet, "Employee");
            //Create new instance of DataTable
            DataTable dataTable = localDataSet.Tables["Employee"];
            int noOfRecords = dataTable.Rows.Count;
            Console.WriteLine("Created a local DataTable.Total number of records in this table is:{0}", noOfRecords);
            return dataTable;
        }
    }
}
