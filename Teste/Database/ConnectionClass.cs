using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain;

namespace Teste.Database
{
    public class ConnectionClass : IDatabase
    {
        public SqlConnection Connection = new SqlConnection();

        public void Open()
        {
            Connection.ConnectionString = "Password=AdminRoot1;Persist Security Info=True;User ID=sa;Initial Catalog=RFSystem;Data Source=localhost;MultipleActiveResultSets=true;";
            Connection.Open();
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
