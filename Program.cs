using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAdoNetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SqlDataReaderDemo(); // Call the method to demonstrate SqlDataReader functionality
            //InsertSqlCommandDemo(); // Call the method to demonstrate inserting data using SqlDataReader
            //DataSetDataApapterDemo(); // Call the method to demonstrate DataSet and DataAdapter functionality
            //InsertSPDataSetDataAdapterDemo(); // Call the method to demonstrate inserting data using DataSet and DataAdapter
            //UpdateEmployeeDemo(); // Call the method to update employee data
        }
        public static void SqlDataReaderDemo()
        {
            DbConnection.SqlDataReader(); // Call the method to read data from the database
        }
        public static void InsertSqlCommandDemo()
        {
           Console.WriteLine("Enter Employee ID:");
           int id = Convert.ToInt32(Console.ReadLine());
           Console.WriteLine("Enter Employee Name:");
           string name = Console.ReadLine();
           Console.WriteLine("Enter Employee Department:");
           string department = Console.ReadLine();
           Console.WriteLine("Enter Employee Address:");
           string address = Console.ReadLine();
           Console.WriteLine("Enter Employee Salary:");
           double salary = Convert.ToDouble(Console.ReadLine());
           DbConnection.InsertSqlCommand(id, name, department, address, salary); // Call the method to insert data into the database
        }

        public static void DataSetDataApapterDemo()
        {
            DbConnection.DataSetDataAdapter(); // Call the method to demonstrate DataSet and DataAdapter functionality
        }

        public static void InsertSPDataSetDataAdapterDemo()
        {
            Console.WriteLine("Enter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Employee Department:");
            string department = Console.ReadLine();
            Console.WriteLine("Enter Employee Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary:");
            double salary = Convert.ToDouble(Console.ReadLine());
            DbConnection.InsertSPDataSetDataAdapter(id, name, department, address, salary); // Call the method to insert data into the database
        }

        public static void UpdateEmployeeDemo()
        {
            Console.WriteLine("Enter Employee ID to update:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Employee Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new Employee Department:");
            string department = Console.ReadLine();
            Console.WriteLine("Enter new Employee Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter new Employee Salary:");
            double salary = Convert.ToDouble(Console.ReadLine());
            DbConnection.UpdateEmployee(id, name, department, address, salary); // Call the method to update employee data
        }
    }
}
