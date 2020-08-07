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
    public class AccessRepository : IAccessRepository
    {
        ConnectionClass dbConnection = new ConnectionClass();


        public Access Create(Access request)
        {
            SqlCommand cmd = new SqlCommand("Sp_InsertAccess", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nm_Access", request.Nm_Access);
            cmd.ExecuteReader(CommandBehavior.SingleRow);
            Access response = Select(request).First();
            dbConnection.Close();
            return response;
        }

        public List<Access> Select(Access request)
        {
            SqlCommand cmd = new SqlCommand("Sp_SelectAccess", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (request != null)
            {
                cmd.Parameters.AddWithValue("@Id_Access", request.Id_Access);
                cmd.Parameters.AddWithValue("@Nm_Access", request.Nm_Access);
            }
            SqlDataReader dr = cmd.ExecuteReader();
            List<Access> response = new List<Access>();
            while (dr.Read())
            {
                response.Add(new Access()
                {
                    Id_Access = Convert.ToInt32(dr["Id_Access"]),
                    Nm_Access = dr["Nm_Access"].ToString()
                });
            }
            dr.Close();
            return response;
        }

        public bool Delete(int Id_Access)
        {
            SqlCommand cmd = new SqlCommand("Sp_DeleteAccess", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Access", Id_Access);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
            dr.Read();
            bool response = dr.RecordsAffected > 0 ? true : false;
            dr.Close();
            dbConnection.Close();
            return response;
        }

        public Access Update(Access request)
        {
            SqlCommand cmd = new SqlCommand("Sp_UpdateAccess", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Access", request.Id_Access);
            cmd.Parameters.AddWithValue("@Nm_Access", request.Nm_Access);
            cmd.ExecuteReader(CommandBehavior.SingleRow);
            Access response = Select(request).First();
            dbConnection.Close();
            return response;
        }
    }
}
