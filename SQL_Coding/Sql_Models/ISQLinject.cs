using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Coding.Sql_Models
{
    public interface ISQLinject
    {
        SQLinject Select(string NameTable);
        void Execute(string connectionString, string query);
        void Task_function(string db);
    }
}
