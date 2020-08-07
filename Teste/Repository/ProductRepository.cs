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
    public class ProductRepository : IProductRepository
    {
        private ConnectionClass dbConnection = new ConnectionClass();

        public ProductRepository()
        {
            this.dbConnection.Open();
        }

        public Products Create(Products request)
        {
            SqlCommand cmd = new SqlCommand("Sp_InsertProducts", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ds_Product", request.Ds_Product);
            cmd.Parameters.AddWithValue("@Id_Category", request.Categories.Id_Category);
            cmd.ExecuteReader(CommandBehavior.SingleRow);
            Products response = Select(request).First();

            dbConnection.Close();

            return response;

        }

        public List<Products> Select(Products request)
        {
            SqlCommand cmd = new SqlCommand("Sp_SelectProduct", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if(request != null) 
            { 
                cmd.Parameters.AddWithValue("@IdProduct", request.Id_Product);
                cmd.Parameters.AddWithValue("@IdCategory", request.Categories.Id_Category);
                cmd.Parameters.AddWithValue("@DsProduct", request.Ds_Product);
                cmd.Parameters.AddWithValue("@Active", request.Active);
            }
            SqlDataReader dr = cmd.ExecuteReader();
            List<Products> response = new List<Products>();
            while (dr.Read())
            {
                response.Add(new Products()
                {
                    Id_Product = Convert.ToInt32(dr["Id_Product"]),
                    Ds_Product = dr["Ds_Product"].ToString(),
                    Categories = new Categories()
                    {
                        Id_Category = Convert.ToInt32(dr["Id_Category"].ToString()),
                        Ds_Category = dr["Ds_Category"].ToString()

                    },
                    Active = Convert.ToInt32(dr["Active"])
                });
            }
            dr.Close();
            dbConnection.Close();
            return response;
        }

        public Products Update(Products request)
        {

            SqlCommand cmd = new SqlCommand("Sp_UpdateProduct", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Product", request.Id_Product);
            cmd.Parameters.AddWithValue("@Ds_product", request.Ds_Product);
            cmd.Parameters.AddWithValue("@Id_Category", request.Categories.Id_Category);
            cmd.ExecuteReader(CommandBehavior.SingleRow); ;
            Products response = Select(request).First();

            dbConnection.Close();
            return response;
        }

        public bool Delete(int Id_Product)
        {
            SqlCommand cmd = new SqlCommand("Sp_DeleteProduct", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Product", Id_Product);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
            dr.Read();
            bool response = dr.RecordsAffected > 0 ? true : false;
            dr.Close();
            dbConnection.Close();
            return response;

        }

        public bool Disable(int Id_Product)
        {
            SqlCommand cmd = new SqlCommand("Sp_DisableProduct", dbConnection.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Products", Id_Product);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
            dr.Read();
            bool response = dr.RecordsAffected > 0 ? true : false;
            dr.Close();
            dbConnection.Close();
            return response;

        }
    }
}
