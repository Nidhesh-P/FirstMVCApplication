using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FirstMVCApplication.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }

        public DataSet GetProviderData()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Study\FirstMVCApplication\FirstMVCApplication\FirstMVCApplication\App_Data\ProviderDatabase.mdf;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand command = new SqlCommand("select * from Provider", conn);


            SqlDataAdapter adaptor = new SqlDataAdapter(command);

            DataSet ds = new DataSet();

            adaptor.Fill(ds);

            return ds;
        }
    }    
}
