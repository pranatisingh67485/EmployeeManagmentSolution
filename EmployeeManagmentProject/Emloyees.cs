using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EmployeeManagmentProject
{
    //employee model class
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string PhoneNo { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
    }
}