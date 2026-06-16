using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentProject
{
    internal class Program
    {
        //this is starting point of my application
        static void Main(string[] args)
        {

            IService service = new ArrayService();

            string text = "!!!!Employee Management System!!!!";

            int windowWidth = Console.WindowWidth;
            int textLength = text.Length;

            int leftPadding = (windowWidth - textLength) / 2;
            Console.WriteLine(new string(' ', leftPadding) + text);
            bool flag = true;


            while (flag) {
                Console.WriteLine();
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Get Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");

                Console.Write("\nEnter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add Employee");
                        service.add();
                        break;

                    case 2:
                        Console.WriteLine("View Employee");
                        service.view();
                        break;

                    case 3:
                        Console.WriteLine("Update Employee");
                        service.update();
                        break;

                    case 4:
                        Console.WriteLine("Get Employee");
                        service.search();
                        break;

                    case 5:
                        Console.WriteLine("Delete Employee");
                        service.delete();
                        break;

                    case 6:
                        {
                            flag = false;
                            break;
                        }
                       
                    default:
                        Console.WriteLine("Invalid Choice! Please choose the number according to screen choices");
                        break;

                }
            }
        
 
        }
        
    }
   
}
