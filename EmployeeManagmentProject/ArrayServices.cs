using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentProject
{
    public class ArrayServices : IService

    {
        private Employee[] employees = new Employee[100];
        private int employeeCount = 0;
        private int nextID = 1;


        public void add()
        {
            if (employeeCount >= employees.Length)
            {
                Console.WriteLine("Employee storage is full!");
                return;
            }

            Employee emp = new Employee();

            emp.Id = nextID;

            while (true)
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    emp.Name = name;
                    break;
                }
                Console.WriteLine("Name cannot be empty!! Enter user  Name:");
            }

            while (true)
            {
                Console.Write("Enter Phone No: ");
                string phone = Console.ReadLine();
                if (!string.IsNullOrEmpty(phone) &&
                    phone.Length == 10 &&
                    long.TryParse(phone, out _))
                {
                    emp.PhoneNo = phone;
                    //break
                    break;
                }
                Console.WriteLine("Invalid Phone Number! PhoneNp. must be 10 digit number");

            }


            while (true)
            {

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(email) &&
                       email.EndsWith("@gmail.com"))
                {
                    emp.Email = email;
                    break;
                }
                Console.WriteLine("Invalid! Enter Correct Email");

            }


            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            while (true)
            {
                if (!string.IsNullOrEmpty(address))
                {
                    emp.Address = address;
                    break;
                }
                Console.WriteLine("Address cannot be empty!! Enter Address");
            }

            employees[employeeCount] = emp;

            Console.WriteLine($"{emp.Name} Added Successfully! ID: {emp.Id}");
            employeeCount++;
            nextID++;
        }
        public void view()
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

                    Console.Write($"{employee.Id}\t{employee.Name}\t\t{employee.PhoneNo}\t\t{employee.Email}\t\t\t{employee.Address}");
                }

                else
                    break;

            }
        }

        public void update()
        {

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

        public void search()
        {
            if (employeeCount == 0)
            {
                Console.WriteLine("No Employees Found!");
                return;
            }

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            for (int i = 0; i < employeeCount; i++)
            {
                if (employees[i].Name == name)
                {
                    Console.WriteLine("Employee Found!");
                    Console.WriteLine("ID      : " + employees[i].Id);
                    Console.WriteLine("Phone   : " + employees[i].PhoneNo);
                    Console.WriteLine("Email   : " + employees[i].Email);
                    Console.WriteLine("Address : " + employees[i].Address);

                    return;
                }
            }

            Console.WriteLine("Employee Not Found!");
        }

        public void delete()
        {
            ; if (employeeCount == 0)
            {
                Console.WriteLine("No Employee Found!!");
                return;
            }

            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < employeeCount; i++)
            {
                if (employees[i].Id == id)
                {
                    for (int j = i; j < employeeCount - 1; j++)
                    {
                        employees[j] = employees[j + 1];

                    }

                    employees[employeeCount - 1] = null;
                    employeeCount--;

                    Console.WriteLine("Employee Deleted Successfully!");
                    return;
                }
            }

            Console.WriteLine("Employee Not Found!");
        }
    }

}
