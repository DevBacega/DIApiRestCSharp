using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Teste.Database;
using Teste.Domain;
using Teste.Models;

namespace Teste.Repository
{
    public class UserRepository : IUsersRepository
    {
        private ConnectionClass dbConnection = new ConnectionClass();

        public UserRepository()
        {
            this.dbConnection.Open();
        }

        public Users Create(Users request)
        {
            SqlCommand cmd = new SqlCommand("Sp_InsertUsers", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nm_Users", request.Nm_User);
            cmd.Parameters.AddWithValue("@Ps_Users", request.Ps_User);
            cmd.Parameters.AddWithValue("@Id_Access", request.Access.Id_Access);
            cmd.ExecuteReader(CommandBehavior.SingleRow);
            Users response = Select(request).First();
            dbConnection.Close();

            return response;

        }

        public List<Users> Select(Users request)
        {
            SqlCommand cmd = new SqlCommand("Sp_SelectUsers", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (request != null)
            {
                cmd.Parameters.AddWithValue("@Id_User", request.Id_User);
                cmd.Parameters.AddWithValue("@Id_Access", request.Access.Id_Access);
                cmd.Parameters.AddWithValue("@Nm_User", request.Nm_User);
                cmd.Parameters.AddWithValue("@Ps_User", request.Ps_User);
                cmd.Parameters.AddWithValue("@Active", request.Active);
            }
            SqlDataReader dr = cmd.ExecuteReader();
            List<Users> response = new List<Users>();
            while (dr.Read())
            {
                response.Add(new Users()
                {
                    Id_User = Convert.ToInt32(dr["Id_User"]),
                    Nm_User = dr["Nm_User"].ToString(),
                    Ps_User = dr["Ps_User"].ToString(),
                    Access = new Access()
                    {
                        Id_Access = Convert.ToInt32(dr["Id_Access"]),
                        Nm_Access = dr["nm_access"].ToString()

                    },
                    Active = Convert.ToInt32(dr["Active"])
                });
            }
            dr.Close();
            dbConnection.Close();
            return response;
        }

        public Users Update(Users request)
        {
            SqlCommand cmd = new SqlCommand("Sp_UpdateUsers", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_User", request.Id_User);
            cmd.Parameters.AddWithValue("@Nm_User", request.Nm_User);
            cmd.Parameters.AddWithValue("@Ps_User", request.Ps_User);
            cmd.Parameters.AddWithValue("@Id_Access", request.Access.Id_Access);
            cmd.ExecuteReader(CommandBehavior.SingleRow);
            Users response = Select(request).First();
            dbConnection.Close();
            return response;
        }

        public bool Delete(int Id_User)
        {
            SqlCommand cmd = new SqlCommand("Sp_DeleteUser", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_User", Id_User);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
            dr.Read();
            bool response = dr.RecordsAffected > 0 ? true : false;
            dr.Close();
            dbConnection.Close();
            return response;
        }

        public bool Disable(int Id_User)
        {
            SqlCommand cmd = new SqlCommand("Sp_DisableUser", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_User", Id_User);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
            dr.Read();
            bool response = dr.RecordsAffected > 0 ? true : false;
            dr.Close();
            dbConnection.Close();
            return response;

        }

    }
}
