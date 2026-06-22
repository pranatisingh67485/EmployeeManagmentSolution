using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmployeeManagmentProject
{
    public interface IService
    {
         void add();
         void view();
         void update();
         void get();
         void delete();


    }
}
