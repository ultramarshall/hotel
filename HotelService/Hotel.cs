using System;
using System.Collections.Generic;
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
                //DataSource = "DESKTOP-0SI1HN9\\SQLSERVER", //laptop
                DataSource = "DESKTOP-3RKCN07", // pc
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


        public List<Vendor> FindVendors()
        {
            var data = new List<Vendor>();
            try
            {
                _comm.CommandText = @"SELECT id, vendor_name, vendor_company, vendor_address, vendor_phone, join_date
                                      FROM vendor";
                //_comm.Parameters.AddWithValue("id", id);
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
                _conn.Close();
            }
        }


        // category 
        public List<ItemCategory> FindCategory()
        {
            var data = new List<ItemCategory>();
            try
            {
                _comm.CommandText = @"SELECT id, category_code, category_name
                                      FROM item_category";
                
                
                //_comm.Parameters.AddWithValue("id", id);
                _comm.CommandType = CommandType.Text;
                _conn.Open();
                SqlDataReader reader = _comm.ExecuteReader();
                while (reader.Read())
                {
                    var list = new ItemCategory()
                    {
                        id = Convert.ToInt16(reader[0]),
                        category_code = Convert.ToString(reader[1]).TrimEnd(),
                        category_name = Convert.ToString(reader[2]).TrimEnd(),
                        
                    };
                    data.Add(list);
                }
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        public List<ItemCategory> FindItemCategory()
        {
            var data = new List<ItemCategory>();
            try
            {
                _comm.CommandText = @"SELECT        item_category.category_name, item.item_code, item.item_name
                                      FROM          item_category INNER JOIN
                                                    item ON item_category.id = item.id_item_category";


                //_comm.Parameters.AddWithValue("id", id);
                _comm.CommandType = CommandType.Text;
                _conn.Open();
                SqlDataReader reader = _comm.ExecuteReader();
                while (reader.Read())
                {
                    var list = new ItemCategory()
                    {
                        category_name = Convert.ToString(reader[0]).TrimEnd(),
                        Item = new Item()
                        {
                            item_code = reader[1].ToString().TrimEnd(),
                            item_name = reader[2].ToString().TrimEnd()
                        }
                    };
                    data.Add(list);
                }
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // item
        public List<Item> SelectAllItems()
        {
            var data = new List<Item>();
            try
            {
                _comm.CommandText = @"SELECT    id, 
                                                item_code,
                                                item_name,
                                                item_prize,
                                                added_by_date,
                                                edit_by_date,
                                                id_vendor,
                                                id_item_category                                       
                                      FROM      item";
                _comm.CommandType = CommandType.Text;
                _conn.Open();
                SqlDataReader reader = _comm.ExecuteReader(); while (reader.Read())
                {
                    var list = new Item()
                    {
                        id = Convert.ToInt16(reader[0]),
                        item_code = Convert.ToString(reader[1]).TrimEnd(),
                        item_name = Convert.ToString(reader[2]).TrimEnd(),
                        item_prize = Convert.ToDecimal(reader[3]),
                        added_by_date = Convert.ToDateTime(reader[4] != DBNull.Value ? reader[4] : new DateTime().ToString("")),
                        create_by_date = Convert.ToDateTime(reader[5] != DBNull.Value ? reader[5] : new DateTime().ToString()),
                        Vendor = new Vendor() { id = Convert.ToInt16(reader[6]) },
                        ItemCategory = new ItemCategory() { id = Convert.ToInt16(reader[7]) }
                    };
                    data.Add(list);
                }
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }



    }
}
