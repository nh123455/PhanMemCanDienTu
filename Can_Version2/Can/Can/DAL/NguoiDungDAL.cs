using Can.GUI;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.DAL
{
    public class NguoiDungDAL
    {
        public List<TaiKhoanDTO> GetListNguoiDung()
        {
            List<TaiKhoanDTO> resultList = new List<TaiKhoanDTO>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(@"Data source =Config\SAMCO.db"))
                {
                    connection.Open();
                    string query = "SELECT * FROM TaiKhoan";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TaiKhoanDTO obj = new TaiKhoanDTO();
                                obj.TaiKhoan = (reader["TaiKhoan"]).ToString();
                                obj.HoTen = (reader["HoTen"]).ToString();
                                obj.Email = (reader["Email"]).ToString();
                                obj.Phone = (reader["Phone"]).ToString();
                                obj.Password = (reader["Password"]).ToString();

                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<TaiKhoanDTO>();
            }
            return resultList;
        }
        public Int64 InsertUser(TaiKhoanDTO item)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(@"Data source =Config\SAMCO.db"))
                {
                    connection.Open();

                    string insertSql = "INSERT INTO TaiKhoan (TaiKhoan, HoTen, Email, Phone, Password) VALUES (@TaiKhoan, @HoTen, @Email, @Phone, @Password)";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@TaiKhoan", item.TaiKhoan));
                        cmd.Parameters.Add(new SQLiteParameter("@HoTen", item.HoTen));
                        cmd.Parameters.Add(new SQLiteParameter("@Email", item.Email));
                        cmd.Parameters.Add(new SQLiteParameter("@Phone", item.Phone));
                        cmd.Parameters.Add(new SQLiteParameter("@Password", item.Password));

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
        public Int64 DeleteUserByUserName(TaiKhoanDTO item)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(@"Data source =Config\SAMCO.db"))
                {
                    connection.Open();

                    string insertSql = $"Delete from TaiKhoan where TaiKhoan='{item.TaiKhoan}'";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertSql, connection))
                    {
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
        public TaiKhoanDTO GetPassByUser(string user)
        {
            TaiKhoanDTO resultList = new TaiKhoanDTO();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(@"Data source =Config\SAMCO.db"))
                {
                    connection.Open();
                    string query = $"SELECT Password, HoTen FROM TaiKhoan where TaiKhoan='{user}'";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TaiKhoanDTO obj = new TaiKhoanDTO();
                                obj.Password = (reader["Password"]).ToString();
                                obj.HoTen = (reader["HoTen"]).ToString();

                                resultList.Password = obj.Password;
                                resultList.HoTen = obj.HoTen;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new TaiKhoanDTO();
            }
            return resultList;
        }
        public TaiKhoanDTO GetNameByUser(string user)
        {
            TaiKhoanDTO resultList = new TaiKhoanDTO();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(@"Data source =Config\SAMCO.db"))
                {
                    connection.Open();
                    string query = $"SELECT HoTen FROM TaiKhoan where TaiKhoan='{user}'";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TaiKhoanDTO obj = new TaiKhoanDTO();
                                obj.Password = (reader["Password"]).ToString();

                                resultList.Password = obj.Password;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new TaiKhoanDTO();
            }
            return resultList;
        }
    }
}
