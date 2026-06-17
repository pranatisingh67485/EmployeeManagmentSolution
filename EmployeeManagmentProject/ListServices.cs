using System;
using System.Collections.Generic;

namespace EmployeeManagmentProject
{
    public class ListServices : IService
    {
        static List<Employees> employees = new List<Employees>();

        private int nextID = 1;

        public void add()
        {
            if (employees.Count >= 100)
            {
                Console.WriteLine("Employee storage is full!");
                return;
            }

            Employees emp = new Employees();

            emp.Id = nextID++;

            while (true)
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    emp.Name = name;
                    break;
                }

                Console.WriteLine("Name cannot be empty!");
            }

            while (true)
            {
                Console.Write("Enter DOB (yyyy-MM-dd): ");
                string dob = Console.ReadLine();

                if (DateTime.TryParse(dob, out DateTime parsedDob))
                {
                    emp.DOB = parsedDob;
                    break;
                }

                Console.WriteLine("Invalid DOB!");
            }

            while (true)
            {
                Console.Write("Enter DOJ (yyyy-MM-dd): ");
                string doj = Console.ReadLine();

                if (DateTime.TryParse(doj, out DateTime parsedDoj))
                {
                    emp.DOJ = parsedDoj;
                    break;
                }

                Console.WriteLine("Invalid DOJ!");
            }

            while (true)
            {
                Console.Write("Enter Phone No: ");
                string phone = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(phone) &&
                    phone.Length == 10 &&
                    long.TryParse(phone, out _))
                {
                    emp.PhoneNo = phone;
                    break;
                }

                Console.WriteLine("Phone number must contain exactly 10 digits.");
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

                Console.WriteLine("Invalid Email!");
            }

            while (true)
            {
                Console.Write("Enter Address: ");
                string address = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(address))
                {
                    emp.Address = address;
                    break;
                }

                Console.WriteLine("Address cannot be empty!");
            }

            employees.Add(emp);

            Console.WriteLine("Employee Added Successfully!");
        }

        public void view()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No Employees Found.");
                return;
            }

            foreach (Employees emp in employees)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"ID      : {emp.Id}");
                Console.WriteLine($"Name    : {emp.Name}");
                Console.WriteLine($"DOB     : {emp.DOB:dd/MM/yyyy}");
                Console.WriteLine($"DOJ     : {emp.DOJ:dd/MM/yyyy}");
                Console.WriteLine($"Phone   : {emp.PhoneNo}");
                Console.WriteLine($"Email   : {emp.Email}");
                Console.WriteLine($"Address : {emp.Address}");
                Console.WriteLine("--------------------------------");
            }
        }
        public void search()
        {
            Console.Write("Enter Employee ID to Search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employees emp = employees.Find(e => e.Id == id);

            if (emp != null)
            {
                Console.WriteLine("\nEmployee Found");
                Console.WriteLine("-----------------------");
                Console.WriteLine($"ID      : {emp.Id}");
                Console.WriteLine($"Name    : {emp.Name}");
                Console.WriteLine($"DOB     : {emp.DOB:dd/MM/yyyy}");
                Console.WriteLine($"DOJ     : {emp.DOJ:dd/MM/yyyy}");
                Console.WriteLine($"Phone   : {emp.PhoneNo}");
                Console.WriteLine($"Email   : {emp.Email}");
                Console.WriteLine($"Address : {emp.Address}");
            }
            else
            {
                Console.WriteLine("Employee Not Found.");
            }
        }

        public void update()
        {
            Console.Write("Enter Employee ID to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employees emp = employees.Find(e => e.Id == id);

            if (emp != null)
            {
                Console.Write("Enter New Name: ");
                emp.Name = Console.ReadLine();

                Console.Write("Enter New Phone No: ");
                emp.PhoneNo = Console.ReadLine();

                Console.Write("Enter New Email: ");
                emp.Email = Console.ReadLine();

                Console.Write("Enter New Address: ");
                emp.Address = Console.ReadLine();

                Console.WriteLine("Employee Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Employee Not Found.");
            }
        }

        public void delete()
        {
            Console.Write("Enter Employee ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employees emp = employees.Find(e => e.Id == id);

            if (emp != null)
            {
                employees.Remove(emp);

                Console.WriteLine("Employee Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Employee Not Found.");
            }
        }
    }
}