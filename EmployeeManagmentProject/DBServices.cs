using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentProject
{
    public class DBServices : IService
    {
        public static string ConnectionString =
      @"Server=DESKTOP-GDO6TJI\SQLEXPRESS;
      Database=EmployeeDB;
      Trusted_Connection=True;
      TrustServerCertificate=True;";


        public void add()
        {
            Employees emp = new Employees();

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter DOB (yyyy-MM-dd): ");
            emp.DOB = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter DOJ (yyyy-MM-dd): ");
            emp.DOJ = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Phone No: ");
            emp.PhoneNo = Console.ReadLine();

            Console.Write("Enter Email: ");
            emp.Email = Console.ReadLine();

            Console.Write("Enter Address: ");
            emp.Address = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = @"INSERT INTO Employees
                        (Name, DOB, DOJ, PhoneNo, Email, Address)
                         VALUES
                        (@Name, @DOB, @DOJ, @PhoneNo, @Email, @Address)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@DOB", emp.DOB);
                cmd.Parameters.AddWithValue("@DOJ", emp.DOJ);
                cmd.Parameters.AddWithValue("@PhoneNo", emp.PhoneNo);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Address", emp.Address);

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Employee Added Successfully!");
                else
                    Console.WriteLine("Failed to add employee.");
            }
        }

        public void view()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Employees";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No Employees Found.");
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"ID      : {reader["Id"]}");
                    Console.WriteLine($"Name    : {reader["Name"]}");
                    Console.WriteLine($"DOB     : {Convert.ToDateTime(reader["DOB"]):dd/MM/yyyy}");
                    Console.WriteLine($"DOJ     : {Convert.ToDateTime(reader["DOJ"]):dd/MM/yyyy}");
                    Console.WriteLine($"Phone   : {reader["PhoneNo"]}");
                    Console.WriteLine($"Email   : {reader["Email"]}");
                    Console.WriteLine($"Address : {reader["Address"]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }

        public void update()
        {
            Console.Write("Enter Employee ID to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter New Phone No: ");
            string phone = Console.ReadLine();

            Console.Write("Enter New Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter New Address: ");
            string address = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = @"UPDATE Employees
                         SET Name=@Name,
                             PhoneNo=@PhoneNo,
                             Email=@Email,
                             Address=@Address
                         WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@PhoneNo", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Employee Updated Successfully!");
                else
                    Console.WriteLine("Employee Not Found.");
            }
        }

        public void get()
        {
            Console.Write("Enter Employee ID to Search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Employees WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine("\nEmployee Found");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine($"ID      : {reader["Id"]}");
                    Console.WriteLine($"Name    : {reader["Name"]}");
                    Console.WriteLine($"DOB     : {Convert.ToDateTime(reader["DOB"]):dd/MM/yyyy}");
                    Console.WriteLine($"DOJ     : {Convert.ToDateTime(reader["DOJ"]):dd/MM/yyyy}");
                    Console.WriteLine($"Phone   : {reader["PhoneNo"]}");
                    Console.WriteLine($"Email   : {reader["Email"]}");
                    Console.WriteLine($"Address : {reader["Address"]}");
                }
                else
                {
                    Console.WriteLine("Employee Not Found.");
                }
            }
        }

        public void delete()
        {
            Console.Write("Enter Employee ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "DELETE FROM Employees WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Employee Deleted Successfully!");
                else
                    Console.WriteLine("Employee Not Found.");
            }
        }
    }
}
