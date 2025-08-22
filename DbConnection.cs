using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAdoNetDemo
{
    public class DbConnection
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeAdoDb;TrustServerCertificate=True;Integrated Security=True;";
        public DbConnection()
        {
        }
        
        public static void SqlDataReader() // Method to read data from the database using SqlDataReader
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // Create a SqlConnection object using the connection string
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Employee"; // Adjust the query as per your database schema
                    SqlCommand command = new SqlCommand(query, connection); // Create a SqlCommand object
                    SqlDataReader reader = command.ExecuteReader();// Execute the command and get a SqlDataReader
                    Console.WriteLine("ID\tName\t\tDepartment\tAddress\t\tSalary"); // Print the header for the output
                    Console.WriteLine("--------------------------------------------------------------"); // Print a separator line
                    while (reader.Read()) // Read the data from the SqlDataReader
                    {
                        Console.WriteLine($"{reader["Id"]}\t{reader["Name"]}\t{reader["Department"]}\t{reader["Address"]}\t{reader["Salary"]}");
                    }
                    reader.Close(); // Close the SqlDataReader
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void InsertSqlCommand(int id, string name, string department, string address, double salary) // Method to insert data into the database using SqlDataReader
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // Create a SqlConnection object using the connection string
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Employee (Id, Name, Department, Address, Salary) VALUES (@Id, @Name, @Department, @Address, @Salary)"; // Adjust the query as per your database schema
                    SqlCommand command = new SqlCommand(query, connection); // Create a SqlCommand object
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Department", department);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Salary", salary);
                    int rowsAffected = command.ExecuteNonQuery(); // Execute the command and get the number of rows affected
                    Console.WriteLine($"{rowsAffected} row(s) inserted successfully.");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DataSetDataAdapter()
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // Create a SqlConnection object using the connection string
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Employee"; // Adjust the query as per your database schema
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Create a SqlDataAdapter object
                    System.Data.DataSet dataSet = new System.Data.DataSet(); // Create a DataSet object
                    adapter.Fill(dataSet); // Fill the DataSet with data from the database
                    Console.WriteLine("ID\tName\t\tDepartment\tAddress\t\tSalary"); // Print the header for the output
                    Console.WriteLine("--------------------------------------------------------------");
                    dataSet.Tables[0].TableName = "Employee";
                    foreach (DataRow row in dataSet.Tables["Employee"].Rows)
                    {
                       Console.WriteLine($"{row["Id"]}\t{row["Name"]}\t{row["Department"]}\t{row["Address"]}\t{row["Salary"]}");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void InsertSPDataSetDataAdapter(int id, string name, string department, string address, double salary)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) // Create a SqlConnection object using the connection string
                {
                    connection.Open(); // Open the SqlConnection

                    SqlCommand command = new SqlCommand() // Create a SqlDataAdapter object
                    {
                        Connection = connection,
                        CommandText = "dbo.InsertEmployee",
                        CommandType = CommandType.StoredProcedure, // Use a stored procedure for inserting data
                    };
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Department", department);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Salary", salary);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet(); // Create a DataSet object
                        adapter.Fill(dataSet);// Fill the DataSet with data from the database
                        adapter.Update(dataSet); // Update the DataSet with the new data
                    }
                    connection.Close(); // Close the SqlConnection
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateEmployee(int id, string name, string department, string address, double salary)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) // Create a SqlConnection object using the connection string
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("dbo.UpdateEmployee",connection)
                    {
                        CommandType = CommandType.StoredProcedure // Use a stored procedure for updating data
                    };
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Department", department);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Salary", salary);

                    command.ExecuteNonQuery(); // Execute the command to update the data
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
