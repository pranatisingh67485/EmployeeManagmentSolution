using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentProject
{
    public class ListService : IService
    {
        static List<Employees> employees = new List<Employees>();



        public void add()
        {
            Employees emp = new Employees();


            Console.Write("Enter Employee Id: ");
            emp.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            emp.Name = Console.ReadLine();

            Console.Write(" enter emoloyee date of birth dd/mm/yyy: ");

            emp.DOB = DateTime.Parse(Console.ReadLine());

            Console.Write(" enter employee date of joining dd/mm/yy: ");
            emp.DOJ = DateTime.Parse(Console.ReadLine());

            //Console.Write("Enter Employee Phone: ");
            //emp.Phone = long.Parse(Console.ReadLine());

            Console.Write("Enter Employee Email: ");
            emp.Email = Console.ReadLine();

            Console.Write("Enter Employee Address: ");
            emp.Address = Console.ReadLine();

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

            foreach (var emp in employees)

            {
                Console.WriteLine("\n--------------------");
                Console.WriteLine($"ID      : {emp.Id}");
                Console.WriteLine($"Name    : {emp.Name}");
                Console.WriteLine($"DOB     : {emp.DOB}");
                Console.WriteLine($"DOJ     : {emp.DOJ}");
                //Console.WriteLine($"Phone   : {emp.Phone}");
                Console.WriteLine($"Email   : {emp.Email}");
                Console.WriteLine($"Address : {emp.Address}");

            }
        }

        public void search()
        {
            Console.Write("Enter Employee ID to Search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employees emp = employees.Find(e => e.Id == id);

            if (emp != null)
            {
                Console.WriteLine($"Employee Found: {emp.Name}");
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

                //Console.Write("Enter New Phone: ");
                //emp.Phone = long.Parse(Console.ReadLine());

                Console.Write("Enter New Email: ");
                emp.Email = Console.ReadLine();

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
