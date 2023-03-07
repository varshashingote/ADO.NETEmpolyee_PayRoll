using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Instrumentation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADONET
{
    class EmployeeRepository
    {
        public static string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=PayRollService248;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection sqlConnection = null;
        public static void GetAllEmployees()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                string query = "select*from Employee_PayRoll";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                EmployeePayRoll model = new EmployeePayRoll();
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.id = Convert.ToInt32(reader["id"] == DBNull.Value ? default : reader["id"]);
                        model.Name = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                        model.Basic_Pay = Convert.ToString(reader["Basic_Pay"] == DBNull.Value ? default : reader["Basic_Pay"]);
                        model.StartDate = (DateTime)((reader["startDate"] == DBNull.Value ? default : reader["StartDate"]));
                        model.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                        // model.PhoneNumber = Convert.ToDouble(reader["Phone"]);
                        model.Phone_Number = Convert.ToInt32(reader["Phone_Number"] == DBNull.Value ? default : reader["Phone_Number"]);
                        model.Emp_DEPT = reader["Emp_DEPT"] == DBNull.Value ? default : reader["Emp_DEPT"].ToString();
                        model.Emp_Address = reader["Emp_Address"] == DBNull.Value ? default : reader["Emp_Address"].ToString();
                        model.Taxable_Pay = Convert.ToInt64(reader["Taxable_Pay"] == DBNull.Value ? default : reader["Taxable_Pay"]);
                        model.Deduction = Convert.ToInt64(reader["Deduction"] == DBNull.Value ? default : reader["Deduction"]);
                        model.Net_Pay = Convert.ToInt64(reader["Net_Pay"] == DBNull.Value ? default : reader["Net_Pay"]);
                        model.Income_Tax = Convert.ToInt64(reader["Income_Tax"] == DBNull.Value ? default : reader["Income_Tax"]);
                        Console.WriteLine("{0},{1},{3},{4},{5},{6},{7},model.id,model.Name,model.Basic_Pay,model.StartDate,model.Gender,model.Phone_Number,model.Deparment,model.Emp_Address,model.Taxable_Pay,model.Deduction,model.Net_Pay,model.Income_Tax");
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void AddEmployee(EmployeePayRoll model)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.spAddNewEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);

                command.Parameters.AddWithValue("@basic_Pay", model.Basic_Pay);
               
                command.Parameters.AddWithValue("@Phone_Number", model.Phone_Number);
                command.Parameters.AddWithValue("@Emp_Address", model.Emp_Address);
                int num = command.ExecuteNonQuery();
                if (num != 0)

                    Console.WriteLine("Employee Added Successfully");
                else
                    Console.WriteLine("Something went Wrong");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            finally
            {
                Console.WriteLine("vjjflo");
            }

        }
        public static void UpdateEmployee(EmployeePayRoll model)
        {
            try
            {


                sqlConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("spUpdateEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@basic_Pay", model.Basic_Pay);
                command.Parameters.AddWithValue("@id", model.id);
                int num = command.ExecuteNonQuery();
                if (num != 0)

                    Console.WriteLine("Employee Updated Successfully");
                else
                    Console.WriteLine("Something went Wrong");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            finally
            {
                Console.WriteLine("connection is wrong");
            }

        }
        public static void DeleteEmployee(EmployeePayRoll model)
        {
            try
            {


                sqlConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("spDeleteEmployee", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@id", model.id);
                int num = command.ExecuteNonQuery();
                if (num != 0)

                    Console.WriteLine("Employee Delete Successfully");
                else
                    Console.WriteLine("Something went Wrong");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            finally
            {
                Console.WriteLine("connection is wrong");
            }

        }



    }
}
   

        
        

    



