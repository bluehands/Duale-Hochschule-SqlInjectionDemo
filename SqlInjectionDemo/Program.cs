using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SampleApp
{
    class Program
    {
        private const string ConnectionString = @"Data Source=.;Initial Catalog=SqlInjectionDemo;Integrated Security=True";

        static void Main()
        {
            var con = GetConnection();
            con.Open();
            while (true)
            {
                #region Get user & pwd
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Logon and show user details");
                Console.WriteLine("------------------------------------");
                Console.Write("Username: ");
                string user = Console.ReadLine();
                if (string.IsNullOrEmpty(user)) { break; }
                Console.Write("PWD: ");
                string pwd = Console.ReadLine();
                #endregion

                string sql = "Select * from Users where UserName='" + user + "' and  Password='" + pwd + "';";

                #region Print sql

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------------------------------------");
                Console.WriteLine(sql);
                Console.WriteLine("------------------------------------");
                Console.ResetColor();

                #endregion

                try
                {
                    using (var cmd = GetCommand(con, sql))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            Print(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void Print(IDataReader reader)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                sb.Append(reader.GetName(i));
                sb.Append("\t");
            }
            Console.WriteLine(sb.ToString());
            while (reader.Read())
            {
                sb = new StringBuilder();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    sb.Append(reader.GetValue(i));
                    sb.Append("\t");
                }
                Console.WriteLine(sb.ToString());
            }

        }
        static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        static SqlCommand GetCommand(SqlConnection con, string sql)
        {
            return new SqlCommand(sql, con);

        }

    }
}
