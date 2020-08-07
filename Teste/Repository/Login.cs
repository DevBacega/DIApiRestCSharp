using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Teste.Database;
using Teste.Models;
namespace Teste.Services
{
    public class Login
    {
        public Users Run(string nmUser, string psUser)
        {
            ConnectionClass connection = new ConnectionClass();
            connection.Open();
            SqlCommand cmd = new SqlCommand("Sp_Login", connection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nm_User", nmUser);
            cmd.Parameters.AddWithValue("@ps_User", psUser);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
            try
            {
                dr.Read();
                Users _users = new Users()
                {
                    Id_User = Convert.ToInt32(dr["Id_User"]),
                    Nm_User = dr["Nm_User"].ToString(),
                    Ps_User = null,
                    Active = Convert.ToInt32(dr["Active"])
                };
                dr.Close();
                return _users;
            }
            catch
            {
                throw new System.ArgumentException("Usuario não encontrado.");
            }

        }
    }
}
