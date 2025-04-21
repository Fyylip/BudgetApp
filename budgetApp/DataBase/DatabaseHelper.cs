using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace budgetApp.DataBase
{
    public class DatabaseHelper
    {
        private string _connectionString = "Data Source=DESKTOP-IM5HQGK\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public bool RecordExists(int userId, string category)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string checkQuery = "SELECT COUNT(*) FROM PieChartData WHERE UserId = @UserId AND Category = @Category";
                SqlCommand cmd = new SqlCommand(checkQuery, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Category", category);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void UpdateRecord(int userId, string category, decimal amount)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string updateQuery = "UPDATE PieChartData SET Amount = @Amount, Date = @Date WHERE UserId = @UserId AND Category = @Category";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertRecord(int userId, string category, decimal amount)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string insertQuery = "INSERT INTO PieChartData (UserId, Category, Amount, Date) VALUES (@UserId, @Category, @Amount, @Date)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteRecord(int userId, string category)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string deleteQuery = "DELETE FROM PieChartData WHERE UserId = @UserId AND Category = @Category";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTotalRecord(int userId, decimal amountToSubtract)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                string updateQuery = @"
            UPDATE Total
            SET Value = Value - @Amount
            WHERE UserId = @UserId AND Label = 'Wykres'";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Amount", amountToSubtract);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

}
