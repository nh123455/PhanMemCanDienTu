using Can.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.DAL
{
    public class DiemCanDAL
    {
        public bool InsertDiemCan(string connectString, DiemCanDTO item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string insertSql = "insert into E_DiemCan (SoMay, TenDiemCan, MAC) values (@SoMay, @TenDiemCan, @MAC)";

                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@SoMay", item.SoMay));
                        cmd.Parameters.Add(new SqlParameter("@TenDiemCan", item.TenDiemCan));
                        cmd.Parameters.Add(new SqlParameter("@MAC", item.MAC));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        
        public bool UpdateDiemCan(string connectString, DiemCanDTO item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string insertSql = "update E_DiemCan set SoMay = @SoMay, TenDiemCan = @TenDiemCan where MAC=@MAC";

                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@SoMay", item.SoMay));
                        cmd.Parameters.Add(new SqlParameter("@TenDiemCan", item.TenDiemCan));
                        cmd.Parameters.Add(new SqlParameter("@MAC", item.MAC));
                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        public bool KiemTraSoMay(string connectString, Int32 SoMay)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string insertSql = "select count(*) from E_DiemCan where SoMay= @SoMay";

                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@SoMay", SoMay));
                        int a = Convert.ToInt32(cmd.ExecuteScalar());
                        if (a == 0) return true;
                        else return false;

                    }
                }
            }
            catch
            {
                return false;
            }

        }
        public bool InsertDiemCanOff(DiemCanDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();

                    string insertSql = "insert into E_DiemCan (SoMay, TenDiemCan, MAC) values (@SoMay, @TenDiemCan, @MAC)";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@SoMay", item.SoMay));
                        cmd.Parameters.Add(new SQLiteParameter("@TenDiemCan", item.TenDiemCan));
                        cmd.Parameters.Add(new SQLiteParameter("@MAC", item.MAC));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        public bool UpdateDiemCanOff(DiemCanDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();

                    string insertSql = "update E_DiemCan set SoMay = @SoMay, TenDiemCan = @TenDiemCan where MAC=@MAC";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@SoMay", item.SoMay));
                        cmd.Parameters.Add(new SQLiteParameter("@TenDiemCan", item.TenDiemCan));
                        cmd.Parameters.Add(new SQLiteParameter("@MAC", item.MAC));
                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        public DiemCanDTO GetThongTinDiemCanOff(string MAC)
        {
            DiemCanDTO item = new DiemCanDTO();
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();
                    string query = "select * from E_DiemCan where MAC =@MAC";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.Add(new SQLiteParameter("@MAC", MAC));
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DiemCanDTO obj = new DiemCanDTO();
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));
                                obj.TenDiemCan = (reader["TenDiemCan"]).ToString();
                                obj.MAC = (reader["MAC"]).ToString();

                                item = obj;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new DiemCanDTO();
            }
            return item;
        }

        public DiemCanDTO GetThongTinDiemCan(string connecString, string MAC)
        {
            DiemCanDTO item = new DiemCanDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(connecString))
                {
                    connection.Open();
                    string query = "select * from E_DiemCan where MAC =@MAC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@MAC", MAC));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DiemCanDTO obj = new DiemCanDTO();
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));
                                obj.TenDiemCan = (reader["TenDiemCan"]).ToString();
                                obj.MAC = (reader["MAC"]).ToString();

                                item = obj;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new DiemCanDTO();
            }
            return item;
        }
        public List<DiemCanDTO> GetThongTinDiemCanToanBo(string connecString)
        {
            List<DiemCanDTO> item = new List<DiemCanDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connecString))
                {
                    connection.Open();
                    string query = "select * from E_DiemCan";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DiemCanDTO obj = new DiemCanDTO();
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));
                                obj.TenDiemCan = (reader["TenDiemCan"]).ToString();
                                obj.MAC = (reader["MAC"]).ToString();

                                item.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<DiemCanDTO>();
            }
            return item;
        }
    }
}
