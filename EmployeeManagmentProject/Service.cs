using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentProject
{
    public class Service
    {
        private Employee[] employees = new Employee[100];
        private int employeeCount=-1;
        private int nextID = 1;


        public void AddEmployee()
        {
            if (employeeCount >= employees.Length)
            {
                Console.WriteLine("Employee storage is full!");
                return;
            }

            Employee emp = new Employee();

            emp.Id = nextID;

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            { 
            emp.Name = name;
            }

            Console.Write("Enter Phone No: ");
            emp.PhoneNo = Console.ReadLine();

            Console.Write("Enter Email: ");
            emp.Email = Console.ReadLine();

            Console.Write("Enter Address: ");
            emp.Address = Console.ReadLine();
            
            employees[employeeCount] = emp;

            Console.WriteLine($"{emp.Name} Added Successfully! ID: {emp.Id}");
            employeeCount++;
            nextID++;
        }
        public void ViewEmployees()
        {
            if (employeeCount == 0)
            {
                Console.WriteLine("No Employees Found!");
                return;
            }

            Console.WriteLine("\n---------------------------------------------------------------------");
            Console.WriteLine("ID\tName\t\tPhone\t\tEmail\t\t\tAddress");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (Employee employee in employees)
            {
                if (employee != null) 
                {
                    Console.Write(employee.Id + "\t" + employee.Name + "\t" + employee.Email + "\t" + "\t" + employee.PhoneNo + "\t" + employee.Address + "\n");
                }
                   
                else
                    break;

            }
        }

        public void UpdateEmployee() {

            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < employeeCount; i++)
            {
                if (employees[i].Id == id)
                {
                    Console.Write("Enter New Name: ");
                    employees[i].Name = Console.ReadLine();

                    Console.Write("Enter New Phone No: ");
                    employees[i].PhoneNo = Console.ReadLine();

                    Console.Write("Enter New Email: ");
                    employees[i].Email = Console.ReadLine();

                    Console.Write("Enter New Address: ");
                    employees[i].Address = Console.ReadLine();

                    Console.WriteLine("Employee Updated Successfully!");
                    return;
                }
            }

            Console.WriteLine("Employee Not Found!");
        

        }

        public void GetEmployee() {

        }

        public void DeleteEmployee()
        {

        }

       
    }
}
