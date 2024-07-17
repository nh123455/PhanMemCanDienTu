using Can.GUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.DAL
{
    public class LoaiHangDAL
    {
        public List<LoaiHangDTO> GetLoaiHang(string connectString)
        {
            List<LoaiHangDTO> resultList = new List<LoaiHangDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "SELECT * FROM E_LoaiHang";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandTimeout = 5;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LoaiHangDTO obj = new LoaiHangDTO();
                                obj.id = Convert.ToInt64(reader["id"]);
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                //obj.created_at =Convert.ToDateTime(reader["created_at"]);
                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<LoaiHangDTO>();
            }

            return resultList;
        }
        public List<LoaiHangDTO> GetLoaiHangOff()
        {
            List<LoaiHangDTO> resultList = new List<LoaiHangDTO>();
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM E_LoaiHang";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.CommandTimeout = 5;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LoaiHangDTO obj = new LoaiHangDTO();
                                obj.id = Convert.ToInt64(reader["id"]);
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                //obj.created_at =Convert.ToDateTime(reader["created_at"]);
                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<LoaiHangDTO>();
            }

            return resultList;
        }
        public Int64 DeletLoaiHang(string connectString, LoaiHangDTO item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string insertSql = "DELETE FROM E_LoaiHang WHERE id=@id";

                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@id", item.id));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return 1;
                }
            }
            catch
            {
                return 0;
            }

        }
        public Int64 DeletLoaiHangOff(LoaiHangDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();

                    string insertSql = "DELETE FROM E_LoaiHang WHERE id=@id";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@id", item.id));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return 1;
                }
            }
            catch
            {
                return 0;
            }

        }
        public Int64 InsertLoaiHang(string connectString, LoaiHangDTO item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string insertSql = "INSERT INTO E_LoaiHang (MaHang, TenHang, created_at) " +
                        "VALUES (@MaHang, @TenHang, @created_at)";

                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@MaHang", item.MaHang));
                        cmd.Parameters.Add(new SqlParameter("@TenHang", item.TenHang));
                        cmd.Parameters.Add(new SqlParameter("@created_at", DateTime.Now));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public Int64 InsertLoaiHangOff(LoaiHangDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();

                    string insertSql = "INSERT INTO E_LoaiHang (MaHang, TenHang, created_at) " +
                        "VALUES (@MaHang, @TenHang, @created_at)";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@MaHang", item.MaHang));
                        cmd.Parameters.Add(new SQLiteParameter("@TenHang", item.TenHang));
                        cmd.Parameters.Add(new SQLiteParameter("@created_at", DateTime.Now));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public Int64 KiemTraMaHang(string connectString, string mahang)
        {
            LoaiHangDTO resultList = new LoaiHangDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM E_LoaiHang where MaHang = '{mahang}'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LoaiHangDTO obj = new LoaiHangDTO();
                                obj.id = Convert.ToInt64(reader["id"]);
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                //obj.created_at =Convert.ToDateTime(reader["created_at"]);
                                resultList = obj;
                            }
                        }
                        if (resultList.MaHang != null) return 1;
                        else return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
    }
}
