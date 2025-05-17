using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public static class DatabaseHelper
{
    private static readonly string connectionString = "Server=MONSTER\\SQLEXPRESS;Database=KutuphaneYonetim;Trusted_Connection=True;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public static DataTable ExecuteSelectCommand(string query)
    {
        using (SqlConnection conn = GetConnection())
        {
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public static void ExecuteNonQuery(string query, SqlParameter[] parameters)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }
    }
}
