using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Data.SqlClient;
namespace SQL_Coding.Sql_Models
{
    public class SQLinject : ISQLinject
    {
        public StringBuilder Sql = new StringBuilder();
        private readonly IRecurringJobManager recurringJobManager;
        public SQLinject()
        {

        }
        public SQLinject(IRecurringJobManager recurringJobManager)
        {
            this.recurringJobManager = recurringJobManager;
        }
        public SQLinject Select(string NameTable)
        {
            var x = Sql.Append("Select * from " + NameTable);
            Console.WriteLine(x);
            return this;
        }

        public string Builder()
        {
            return Sql.ToString().Trim();
        }

        public void Execute(string connectionString, string query)
        {
            StreamWriter writer = new StreamWriter("userData.txt");
            object obj;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           obj  = new 
                            {
                                Id = reader.GetGuid("Id"),
                                firstName = reader.GetString("FirstName"),
                                lastName = reader.GetString("LastName"),
                                Email = reader.GetString("Email"),
                                Role = reader.GetInt32("Role"),
                            };
                            Console.WriteLine(obj);
                            writer.WriteLine(obj);

                        }
                        writer.Close();
                    }
                }
            }
        }
        public void Task_function(string db)
        {
            recurringJobManager.AddOrUpdate(
                "test",
                () => Execute(db, Select("users").Builder()),
                Cron.Monthly // تنفيذ كل دقيقة لتحسين الأداء
            );
        }
        
    }
}