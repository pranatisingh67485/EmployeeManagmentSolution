using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentProject
{
    internal interface IService
    {
        public void add();
        public void view();
        public void update();
        public void search();
        public void delete();


    }
}
