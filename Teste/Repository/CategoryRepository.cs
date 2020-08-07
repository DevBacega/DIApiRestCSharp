using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Teste.Database;
using Teste.Domain;
using Teste.Models;

namespace Teste.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private ConnectionClass dbConnection = new ConnectionClass();

        public CategoryRepository()
        {
            this.dbConnection.Open();
        }

        public Categories Create(Categories request)
        {
            SqlCommand cmd = new SqlCommand("Sp_InsertCategory", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ds_Category", request.Ds_Category);
            cmd.ExecuteReader(CommandBehavior.SingleRow);
            Categories response = Select(request).First();
            dbConnection.Close();
            return response;
        }

        public bool Delete(int Id_Category)
        {
            SqlCommand cmd = new SqlCommand("Sp_DeleteCategory", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Category", Id_Category);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
            dr.Read();
            bool response = dr.RecordsAffected > 0 ? true : false;
            dr.Close();
            dbConnection.Close();
            return response;

        }

        public List<Categories> Select(Categories request)
        {
            SqlCommand cmd = new SqlCommand("Sp_SelectCategory", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if(request != null)
            { 
                cmd.Parameters.AddWithValue("@Id_Category", request.Id_Category);
                cmd.Parameters.AddWithValue("@Ds_Category", request.Ds_Category);
            }
            SqlDataReader dr = cmd.ExecuteReader();

            List<Categories> response = new List<Categories>();

            while (dr.Read())
            {
                response.Add(new Categories()
                {
                    Id_Category = Convert.ToInt32(dr["Id_Category"]),
                    Ds_Category = dr["Ds_Category"].ToString()
                });
            }
            dr.Close();
            return response;

        }

        public Categories Update(Categories request)
        {
            SqlCommand cmd = new SqlCommand("Sp_UpdateCategory", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Category", request.Id_Category);
            cmd.Parameters.AddWithValue("@Ds_Category", request.Ds_Category);
            cmd.ExecuteReader(CommandBehavior.SingleRow);
            Categories response = Select(request).First();
            dbConnection.Close();
            return response;
        }
    }
}
