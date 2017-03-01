using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelService.Contract;
using System.Data.SqlClient;
using System.Data;

namespace HotelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Hotel" in both code and config file together.
    public class Hotel : IHotel
    {
        private SqlConnection _conn;
        private SqlCommand _comm;
        private SqlConnectionStringBuilder _connStringBuilder;
        private void db_connect()
        {
            _connStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-0SI1HN9\\SQLSERVER",
                InitialCatalog = "pt_california_db",
                Encrypt = true,
                TrustServerCertificate = true,
                ConnectTimeout = 30,
                AsynchronousProcessing = true,
                MultipleActiveResultSets = true,
                IntegratedSecurity = true,
            };
            _conn = new SqlConnection(_connStringBuilder.ToString());
            _comm = _conn.CreateCommand();
        }
        private Hotel()
        {
            db_connect();
        }


        public List<Vendor> findByID(int id)
        {
            var data = new List<Vendor>();
            try
            {
                _comm.CommandText = @"SELECT id, vendor_name, vendor_company, vendor_address, vendor_phone, join_date
                                      FROM vendor
                                      WHERE id = @id";
                _comm.Parameters.AddWithValue("id", id);
                _comm.CommandType = CommandType.Text;
                _conn.Open();
                SqlDataReader reader = _comm.ExecuteReader();
                while (reader.Read())
                {
                    var list = new Vendor()
                    {
                        id = Convert.ToInt16(reader[0]),
                        vendor_name = Convert.ToString(reader[1]).TrimEnd(),
                        vendor_company = Convert.ToString(reader[2]).TrimEnd(),
                        vendor_address = Convert.ToString(reader[3]).TrimEnd(),
                        vendor_phone = Convert.ToString(reader[4]).TrimEnd(),
                        join_date = Convert.ToDateTime(reader[5])
                    };
                    data.Add(list);
                }
                return data;
            }
            finally
            {
                _conn?.Close();
            }
        }
    }
}
