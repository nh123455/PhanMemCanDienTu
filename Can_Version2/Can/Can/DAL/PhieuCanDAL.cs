using Can.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.DAL
{
    public class PhieuCanDAL
    {
        public Int64 InsertPhieuCanLan1(string connectString, PhieuCanDTO item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string insertSql = "INSERT INTO E_PhieuCan (SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang," +
                        " TenHang, KhoHang, GhiChu, KieuCan, KhoiLuongCan1, " +
                        "SoMay, LanCan, ThoiGianCan1, Image1_1, Image1_2, Image1_3) " +

                        "VALUES (@SoPhieu, @BienSoXe, @NguoiBan, @NguoiMua, @LaiXe, @MaHang, " +
                        "@TenHang, @KhoHang, @GhiChu, @KieuCan, @KhoiLuongCan1, " +
                        "@SoMay, @LanCan, @ThoiGianCan1, @Image1_1, @Image1_2, @Image1_3)";

                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@SoPhieu", item.SoPhieu));
                        cmd.Parameters.Add(new SqlParameter("@BienSoXe", item.BienSoXe));
                        cmd.Parameters.Add(new SqlParameter("@NguoiBan", item.NguoiBan));
                        cmd.Parameters.Add(new SqlParameter("@NguoiMua", item.NguoiMua));
                        cmd.Parameters.Add(new SqlParameter("@LaiXe", item.LaiXe));

                        cmd.Parameters.Add(new SqlParameter("@MaHang", item.MaHang));
                        cmd.Parameters.Add(new SqlParameter("@TenHang", item.TenHang));
                        cmd.Parameters.Add(new SqlParameter("@KhoHang", item.KhoHang));
                        cmd.Parameters.Add(new SqlParameter("@GhiChu", item.GhiChu));
                        cmd.Parameters.Add(new SqlParameter("@KieuCan", item.KieuCan));

                        cmd.Parameters.Add(new SqlParameter("@KhoiLuongCan1", item.KhoiLuongCan1));

                        cmd.Parameters.Add(new SqlParameter("@ThoiGianCan1", item.ThoiGianCan1));

                        cmd.Parameters.Add(new SqlParameter("@SoMay", item.SoMay));
                        cmd.Parameters.Add(new SqlParameter("@LanCan", item.LanCan));

                        //cmd.Parameters.Add(new SqlParameter("@NhanVienCanLan1", item.NhanVienCanLan1));
                        //cmd.Parameters.Add(new SqlParameter("@NhanVienCanLan2", item.NhanVienCanLan2));

                        cmd.Parameters.Add(new SqlParameter("@Image1_1", item.Image1_1));
                        cmd.Parameters.Add(new SqlParameter("@Image1_2", item.Image1_2));
                        cmd.Parameters.Add(new SqlParameter("@Image1_3", item.Image1_2));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return 1;
                }
            }
            catch(Exception ex)
            {
                return 0;
            }

        }
        public bool InsertPhieuCanLan(string connectString, PhieuCanDTO item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string string1 = "INSERT INTO E_PhieuCan(SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, TenHang, KhoHang, GhiChu, KieuCan, SoMay, LanCan, created_at, status_show";
                    string string2 = "VALUES (@SoPhieu, @BienSoXe, @NguoiBan, @NguoiMua, @LaiXe, @MaHang, @TenHang, @KhoHang, @GhiChu, @KieuCan, @SoMay, @LanCan, @created_at, @status_show";

                    if(!String.IsNullOrEmpty(item.KhoiLuongCan1.ToString()))
                    {
                        string1 = string1 + ", KhoiLuongCan1";
                        string2 = string2 + ", @KhoiLuongCan1";
                    }
                    if (!String.IsNullOrEmpty(item.KhoiLuongCan2.ToString()))
                    {
                        string1 = string1 + ", KhoiLuongCan2";
                        string2 = string2 + ", @KhoiLuongCan2";
                    }
                    if (!String.IsNullOrEmpty(item.ThoiGianCan1.ToString()))
                    {
                        string1 = string1 + ", ThoiGianCan1";
                        string2 = string2 + ", @ThoiGianCan1";
                    }

                    if (!String.IsNullOrEmpty(item.ThoiGianCan2.ToString()))
                    {
                        string1 = string1 + ", ThoiGianCan2";
                        string2 = string2 + ", @ThoiGianCan2";
                    }
                    if (!String.IsNullOrEmpty(item.NhanVienCanLan1))
                    {
                        string1 = string1 + ", NhanVienCanLan1";
                        string2 = string2 + ", @NhanVienCanLan1";
                    }
                    if (!String.IsNullOrEmpty(item.NhanVienCanLan2))
                    {
                        string1 = string1 + ", NhanVienCanLan2";
                        string2 = string2 + ", @NhanVienCanLan2";
                    }
                    if (item.Image1_1 != null)
                    {
                        string1 = string1 + ", Image1_1";
                        string2 = string2 + ", @Image1_1";
                    }
                    if (item.Image1_2 != null)
                    {
                        string1 = string1 + ", Image1_2";
                        string2 = string2 + ", @Image1_2";
                    }
                    if (item.Image1_3 != null)
                    {
                        string1 = string1 + ", Image1_3";
                        string2 = string2 + ", @Image1_3";
                    }
                    if (item.Image2_1 != null)
                    {
                        string1 = string1 + ", Image2_1";
                        string2 = string2 + ", @Image2_1";
                    }
                    if (item.Image2_2 != null)
                    {
                        string1 = string1 + ", Image2_2";
                        string2 = string2 + ", @Image2_2";
                    }
                    if (item.Image2_3 != null)
                    {
                        string1 = string1 + ", Image2_3";
                        string2 = string2 + ", @Image2_3";
                    }

                    string1 = string1 + ")";
                    string2 = string2 + ")";

                    string insertSql = string1 + string2;

                    //string insertSql = "INSERT INTO E_PhieuCan (SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang," +
                    //    " TenHang, KhoHang, GhiChu, KieuCan, KhoiLuongCan2, " +
                    //    "SoMay, LanCan, ThoiGianCan2) " +

                    //    "VALUES (@SoPhieu, @BienSoXe, @NguoiBan, @NguoiMua, @LaiXe, @MaHang, " +
                    //    "@TenHang, @KhoHang, @GhiChu, @KieuCan, @KhoiLuongCan2, " +
                    //    "@SoMay, @LanCan, @ThoiGianCan2)";

                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@SoPhieu", item.SoPhieu));
                        cmd.Parameters.Add(new SqlParameter("@BienSoXe", item.BienSoXe));
                        cmd.Parameters.Add(new SqlParameter("@NguoiBan", item.NguoiBan));
                        cmd.Parameters.Add(new SqlParameter("@NguoiMua", item.NguoiMua));
                        cmd.Parameters.Add(new SqlParameter("@LaiXe", item.LaiXe));
                        cmd.Parameters.Add(new SqlParameter("@MaHang", item.MaHang));
                        cmd.Parameters.Add(new SqlParameter("@TenHang", item.TenHang));
                        cmd.Parameters.Add(new SqlParameter("@KhoHang", item.KhoHang));
                        cmd.Parameters.Add(new SqlParameter("@GhiChu", item.GhiChu));
                        cmd.Parameters.Add(new SqlParameter("@KieuCan", item.KieuCan));
                        cmd.Parameters.Add(new SqlParameter("@SoMay", item.SoMay));
                        cmd.Parameters.Add(new SqlParameter("@LanCan", item.LanCan));
                        cmd.Parameters.Add(new SqlParameter("@created_at", item.created_at));
                        cmd.Parameters.Add(new SqlParameter("@status_Show", item.status_show));

                        if(item.KhoiLuongCan1 != null)
                            cmd.Parameters.Add(new SqlParameter("@KhoiLuongCan1", item.KhoiLuongCan1));
                        if(item.KhoiLuongCan2 != null)
                            cmd.Parameters.Add(new SqlParameter("@KhoiLuongCan2", item.KhoiLuongCan2));

                        if(!String.IsNullOrEmpty(item.NhanVienCanLan1))
                            cmd.Parameters.Add(new SqlParameter("@NhanVienCanLan1", item.NhanVienCanLan1));
                        if(!String.IsNullOrEmpty(item.NhanVienCanLan2))
                            cmd.Parameters.Add(new SqlParameter("@NhanVienCanLan2", item.NhanVienCanLan2));

                        if(item.ThoiGianCan1 != null)
                            cmd.Parameters.Add(new SqlParameter("@ThoiGianCan1", item.ThoiGianCan1));
                        if(item.ThoiGianCan2 != null)
                            cmd.Parameters.Add(new SqlParameter("@ThoiGianCan2", item.ThoiGianCan2));

                        if(item.Image1_1 != null)
                            cmd.Parameters.Add(new SqlParameter("@Image1_1", item.Image1_1));
                        if(item.Image1_2 != null)
                            cmd.Parameters.Add(new SqlParameter("@Image1_2", item.Image1_2));
                        if(item.Image1_3 != null)
                            cmd.Parameters.Add(new SqlParameter("@Image1_3", item.Image1_3));

                        if(item.Image2_1 != null)
                            cmd.Parameters.Add(new SqlParameter("@Image2_1", item.Image2_1));
                        if(item.Image2_2 != null)
                            cmd.Parameters.Add(new SqlParameter("@Image2_2", item.Image2_2));
                        if(item.Image2_3 != null)
                            cmd.Parameters.Add(new SqlParameter("@Image2_3", item.Image2_3));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<PhieuCanDTO> GetPhieuCan(string connectString)
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "select SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, TenHang, KhoHang, GhiChu, KieuCan, KhoiLuongCan1, KhoiLuongCan2, ThoiGianCan1, ThoiGianCan2, SoMay, LanCan, NhanVienCanLan1, NhanVienCanLan2, ABS(KhoiLuongCan1 - KhoiLuongCan2) as KhoiLuongCan from E_PhieuCan ORDER BY created_at DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                obj.LanCan =Convert.ToInt32(reader["LanCan"]);
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));

                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));
                                if ((reader["KhoiLuongCan"]).ToString() != "")
                                    obj.KhoiLuongCan = Convert.ToInt32((reader["KhoiLuongCan"]));
                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public List<PhieuCanDTO> GetPhieuCanByDate(string connectString, DateTime fromDate, DateTime toDate, int soMay)
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    
                    string query = "SELECT SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, TenHang, KhoHang, GhiChu, KieuCan, KhoiLuongCan1, KhoiLuongCan2, ThoiGianCan1, ThoiGianCan2, LanCan, NhanVienCanLan1, NhanVienCanLan2, ABS(KhoiLuongCan1 - KhoiLuongCan2) as KhoiLuongCan, TenDiemCan " +
                        " FROM E_PhieuCan " +
                        " left join E_DiemCan on E_DiemCan.SoMay = E_PhieuCan.SoMay" +
                        " where created_at between @fromDate and @toDate and status_show = 'SHOW' and E_PhieuCan.SoMay =@SoMay";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@fromDate", fromDate));
                        command.Parameters.Add(new SqlParameter("@toDate", toDate));
                        command.Parameters.Add(new SqlParameter("@SoMay", soMay));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                obj.LanCan = Convert.ToInt32(reader["LanCan"]);
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["TenDiemCan"]).ToString() != "")
                                    obj.TenDiemCan = (reader["TenDiemCan"]).ToString();

                                if ((reader["KhoiLuongCan"]).ToString() != "")
                                    obj.KhoiLuongCan = Convert.ToInt32((reader["KhoiLuongCan"]));

                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public List<PhieuCanDTO> GetPhieuCanByDateOff(DateTime fromDate, DateTime toDate)
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();

                    string query = "SELECT SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, TenHang, KhoHang, GhiChu, KieuCan, KhoiLuongCan1, KhoiLuongCan2, ThoiGianCan1, ThoiGianCan2, LanCan, NhanVienCanLan1, NhanVienCanLan2, ABS(KhoiLuongCan1 - KhoiLuongCan2) as KhoiLuongCan, TenDiemCan" +
                        " FROM E_PhieuCan " +
                        " left join E_DiemCan on E_DiemCan.SoMay = E_PhieuCan.SoMay" +
                        " where created_at between @fromDate and @toDate and status_show = 'SHOW'";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.Add(new SQLiteParameter("@fromDate", fromDate));
                        command.Parameters.Add(new SQLiteParameter("@toDate", toDate));
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                obj.LanCan = Convert.ToInt32(reader["LanCan"]);
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["TenDiemCan"]).ToString() != "")
                                    obj.TenDiemCan = (reader["TenDiemCan"]).ToString();

                                if ((reader["KhoiLuongCan"]).ToString() != "")
                                    obj.KhoiLuongCan = Convert.ToInt32((reader["KhoiLuongCan"]));

                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public List<PhieuCanDTO> GetPhieuCanLan1(string connectString)
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = $"select SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, TenHang, KhoHang, GhiChu, KieuCan, KhoiLuongCan1, KhoiLuongCan2, ThoiGianCan1, ThoiGianCan2, SoMay, LanCan, NhanVienCanLan1, NhanVienCanLan2 from E_PhieuCan where LanCan = 1 and status_show='SHOW' ORDER BY created_at DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                obj.LanCan = Convert.ToInt32(reader["LanCan"]);
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));
                                if ((reader["NhanVienCanLan1"]).ToString() != "")
                                    obj.NhanVienCanLan1 = (reader["NhanVienCanLan1"]).ToString();
                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public List<PhieuCanDTO> GetPhieuCanLan1Sqlite()
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connecttion = new SQLiteConnection(sqliteConnectionString))
                {
                    connecttion.Open();
                    string query = $"select SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, TenHang, KhoHang, GhiChu, KieuCan, KhoiLuongCan1, KhoiLuongCan2, ThoiGianCan1, ThoiGianCan2, SoMay, LanCan, NhanVienCanLan1, NhanVienCanLan2, sync from E_PhieuCan where LanCan = 1 and status_show='SHOW' ORDER BY created_at DESC";
                    using (SQLiteCommand command = new SQLiteCommand(query, connecttion))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                obj.LanCan = Convert.ToInt32(reader["LanCan"]);
                                obj.sync = (reader["sync"]).ToString();
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));
                                if ((reader["NhanVienCanLan1"]).ToString() != "")
                                    obj.NhanVienCanLan1 = (reader["NhanVienCanLan1"]).ToString();
                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public List<PhieuCanDTO> GetPhieuCanLan2(string connectString)
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "select top 100 SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, " +
                        " TenHang, KhoHang, GhiChu, KieuCan, KhoiLuongCan1, KhoiLuongCan2, ThoiGianCan1, " +
                        " ThoiGianCan2, SoMay, LanCan, NhanVienCanLan1, NhanVienCanLan2, ABS(KhoiLuongCan1 - KhoiLuongCan2) as KhoiLuongCan " +
                        " from E_PhieuCan where status_show ='SHOW' " +
                        " ORDER BY created_at DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                obj.LanCan = Convert.ToInt32(reader["LanCan"]);
                                obj.NhanVienCanLan1 = reader["NhanVienCanLan1"].ToString();
                                obj.NhanVienCanLan2 = reader["NhanVienCanLan2"].ToString();
                                obj.LanCan = Convert.ToInt32(reader["LanCan"]);
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));
                                if ((reader["KhoiLuongCan"]).ToString() != "")
                                    obj.KhoiLuongCan = Convert.ToInt32((reader["KhoiLuongCan"]));

                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public List<PhieuCanDTO> GetPhieuCanLan2Sqlite()
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connecttion = new SQLiteConnection(sqliteConnectionString))
                {
                    connecttion.Open();
                    string query = "select SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, " +
                        "TenHang, KhoHang, GhiChu, KieuCan, KhoiLuongCan1, KhoiLuongCan2, ThoiGianCan1, ThoiGianCan2, " +
                        "SoMay, LanCan, NhanVienCanLan1, NhanVienCanLan2, ABS(KhoiLuongCan1 - KhoiLuongCan2) as KhoiLuongCan, sync " +
                        "from E_PhieuCan " +
                        "where status_show ='SHOW' " +
                        "ORDER BY created_at DESC " +
                        "LIMIT 100";
                    using (SQLiteCommand command = new SQLiteCommand(query, connecttion))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                obj.LanCan = Convert.ToInt32(reader["LanCan"]);
                                obj.NhanVienCanLan1 = reader["NhanVienCanLan1"].ToString();
                                obj.NhanVienCanLan2 = reader["NhanVienCanLan2"].ToString();
                                obj.LanCan = Convert.ToInt32(reader["LanCan"]);
                                obj.sync = (reader["sync"]).ToString();
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));
                                if ((reader["KhoiLuongCan"]).ToString() != "")
                                    obj.KhoiLuongCan = Convert.ToInt32((reader["KhoiLuongCan"]));

                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public List<PhieuCanDTO> GetReportBySoPhieuAndLanCan1(string connectString, string soPhieu)
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM E_PhieuCan CROSS JOIN E_CongTy where SoPhieu='{soPhieu}' and LanCan = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));

                                if ((reader["Image1_1"]).ToString() != "")
                                    obj.Image1_1 = (byte[])(reader["Image1_1"]);

                                if ((reader["Image1_2"]).ToString() != "")
                                    obj.Image1_2 = (byte[])(reader["Image1_2"]);

                                if ((reader["Image1_3"]).ToString() != "")
                                    obj.Image1_3 = (byte[])(reader["Image1_3"]);

                                if ((reader["Image2_1"]).ToString() != "")
                                    obj.Image2_1 = (byte[])(reader["Image2_1"]);

                                if ((reader["Image2_2"]).ToString() != "")
                                    obj.Image2_2 = (byte[])(reader["Image2_2"]);

                                if ((reader["Image2_3"]).ToString() != "")
                                    obj.Image2_3 = (byte[])(reader["Image2_3"]);

                                obj.Companyname = (reader["Companyname"]).ToString();
                                obj.Adress = (reader["Adress"]).ToString();
                                obj.Phone = (reader["Phone"]).ToString();
                                obj.Fax = (reader["Fax"]).ToString();

                                obj.NhanVienCanLan1 = (reader["NhanVienCanLan1"]).ToString();
                                obj.NhanVienCanLan2 = (reader["NhanVienCanLan2"]).ToString();
                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public List<PhieuCanDTO> GetReportBySoPhieuAndLanCan1Off(string soPhieu)
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM E_PhieuCan where SoPhieu='{soPhieu}' and LanCan = 1";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));

                                if ((reader["Image1_1"]).ToString() != "")
                                    obj.Image1_1 = (byte[])(reader["Image1_1"]);

                                if ((reader["Image1_2"]).ToString() != "")
                                    obj.Image1_2 = (byte[])(reader["Image1_2"]);

                                if ((reader["Image1_3"]).ToString() != "")
                                    obj.Image1_3 = (byte[])(reader["Image1_3"]);

                                if ((reader["Image2_1"]).ToString() != "")
                                    obj.Image2_1 = (byte[])(reader["Image2_1"]);

                                if ((reader["Image2_2"]).ToString() != "")
                                    obj.Image2_2 = (byte[])(reader["Image2_2"]);

                                if ((reader["Image2_3"]).ToString() != "")
                                    obj.Image2_3 = (byte[])(reader["Image2_3"]);

                                //obj.Companyname = (reader["Companyname"]).ToString();
                                //obj.Adress = (reader["Adress"]).ToString();
                                //obj.Phone = (reader["Phone"]).ToString();
                                //obj.Fax = (reader["Fax"]).ToString();

                                obj.NhanVienCanLan1 = (reader["NhanVienCanLan1"]).ToString();
                                obj.NhanVienCanLan2 = (reader["NhanVienCanLan2"]).ToString();
                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public List<PhieuCanDTO> GetReportBySoPhieuAndLanCan2(string connectString, string soPhieu)
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = $"DECLARE @Temp  TABLE (SoPhieu nvarchar(255), NhanVienCanLan1 nvarchar(255)," +
                        $" KhoiLuongCan1 int, ThoiGianCan1 Datetime) " +
                        $"INSERT INTO @Temp select SoPhieu,NhanVienCanLan1, KhoiLuongCan1, ThoiGianCan1 " +
                        $"from E_PhieuCan where LanCan = 1 and SoPhieu='{soPhieu}' " +
                        $"DECLARE @Image  TABLE (SoPhieu nvarchar(255), Image1_1 varbinary(max), Image1_2 varbinary(max), " +
                        $"Image1_3 varbinary(max)) " +
                        $"INSERT INTO @Image select SoPhieu,Image1_1, Image1_2, Image1_3 from E_PhieuCan " +
                        $"where LanCan = 1 and SoPhieu='{soPhieu}' " +
                        $"SELECT t2.SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, TenHang," +
                        $" KhoHang, GhiChu, KieuCan, t1.KhoiLuongCan1, KhoiLuongCan2, t1.ThoiGianCan1, " +
                        $"ThoiGianCan2, SoMay, LanCan, t1.NhanVienCanLan1, NhanVienCanLan2, ig.Image1_1, ig.Image1_2," +
                        $" ig.Image1_3, t2.Image2_1, t2.Image2_2, t2.Image2_3, ct.Adress, ct.Companyname, ct.Email, ct.Fax, " +
                        $"ct.Phone FROM E_PhieuCan t2 inner join @Temp t1 on t2.SoPhieu = t1.SoPhieu " +
                        $"inner join @Image ig on ig.SoPhieu = t2.SoPhieu CROSS JOIN E_CongTy ct " +
                        $"where t2.SoPhieu='{soPhieu}' and LanCan= 2";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));

                                if ((reader["Image1_1"]).ToString() != "")
                                    obj.Image1_1 = (byte[])(reader["Image1_1"]);

                                if ((reader["Image1_2"]).ToString() != "")
                                    obj.Image1_2 = (byte[])(reader["Image1_2"]);

                                if ((reader["Image1_3"]).ToString() != "")
                                    obj.Image1_3 = (byte[])(reader["Image1_3"]);

                                if ((reader["Image2_1"]).ToString() != "")
                                    obj.Image2_1 = (byte[])(reader["Image2_1"]);

                                if ((reader["Image2_2"]).ToString() != "")
                                    obj.Image2_2 = (byte[])(reader["Image2_2"]);

                                if ((reader["Image2_3"]).ToString() != "")
                                    obj.Image2_3 = (byte[])(reader["Image2_3"]);

                                obj.Companyname = (reader["Companyname"]).ToString();
                                obj.Adress = (reader["Adress"]).ToString();
                                obj.Phone = (reader["Phone"]).ToString();
                                obj.Fax = (reader["Fax"]).ToString();

                                obj.NhanVienCanLan1 = (reader["NhanVienCanLan1"]).ToString();
                                obj.NhanVienCanLan2 = (reader["NhanVienCanLan2"]).ToString();
                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public List<PhieuCanDTO> GetReportBySoPhieuAndLanCan2Off(string soPhieu)
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();
                    string query = $"CREATE TEMPORARY TABLE Temp AS " +
                        $" SELECT SoPhieu, NhanVienCanLan1, KhoiLuongCan1, ThoiGianCan1 " +
                        $" FROM E_PhieuCan " +
                        $" WHERE LanCan = 1 AND SoPhieu = '{soPhieu}'; " +
                        $" CREATE TEMPORARY TABLE Image AS " +
                        $" SELECT SoPhieu, Image1_1, Image1_2, Image1_3 FROM E_PhieuCan " +
                        $" WHERE LanCan = 1 AND SoPhieu = '{soPhieu}'; " +
                        $" SELECT t2.SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, TenHang, " +
                        $" KhoHang, GhiChu, KieuCan, t1.KhoiLuongCan1, KhoiLuongCan2, " +
                        $" t1.ThoiGianCan1, ThoiGianCan2, SoMay, LanCan, t1.NhanVienCanLan1, " +
                        $" NhanVienCanLan2, ig.Image1_1, ig.Image1_2, ig.Image1_3, t2.Image2_1, t2.Image2_2," +
                        $" t2.Image2_3 FROM E_PhieuCan t2" +
                        $" INNER JOIN Temp t1 ON t2.SoPhieu = t1.SoPhieu" +
                        $" INNER JOIN Image ig ON ig.SoPhieu = t2.SoPhieu" +
                        $" WHERE t2.SoPhieu = '{soPhieu}' AND LanCan = 2; ";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));

                                if ((reader["Image1_1"]).ToString() != "")
                                    obj.Image1_1 = (byte[])(reader["Image1_1"]);

                                if ((reader["Image1_2"]).ToString() != "")
                                    obj.Image1_2 = (byte[])(reader["Image1_2"]);

                                if ((reader["Image1_3"]).ToString() != "")
                                    obj.Image1_3 = (byte[])(reader["Image1_3"]);

                                if ((reader["Image2_1"]).ToString() != "")
                                    obj.Image2_1 = (byte[])(reader["Image2_1"]);

                                if ((reader["Image2_2"]).ToString() != "")
                                    obj.Image2_2 = (byte[])(reader["Image2_2"]);

                                if ((reader["Image2_3"]).ToString() != "")
                                    obj.Image2_3 = (byte[])(reader["Image2_3"]);

                                //obj.Companyname = (reader["Companyname"]).ToString();
                                //obj.Adress = (reader["Adress"]).ToString();
                                //obj.Phone = (reader["Phone"]).ToString();
                                //obj.Fax = (reader["Fax"]).ToString();

                                obj.NhanVienCanLan1 = (reader["NhanVienCanLan1"]).ToString();
                                obj.NhanVienCanLan2 = (reader["NhanVienCanLan2"]).ToString();
                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public Int64 UpdatePhieuCan(string connectString, PhieuCanDTO item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string insertSql = "UPDATE E_PhieuCan " +
                        "SET BienSoXe = @BienSoXe , NguoiBan = @NguoiBan, NguoiMua=@NguoiMua, LaiXe=@LaiXe," +
                        " MaHang=@MaHang, TenHang=@TenHang, KhoHang = @KhoHang, GhiChu= @GhiChu ";

                    if (!String.IsNullOrEmpty(item.KhoiLuongCan1.ToString()))
                    {
                        insertSql = insertSql + " ,KhoiLuongCan1=@KhoiLuongCan1";
                    }

                    if (!String.IsNullOrEmpty(item.KhoiLuongCan2.ToString()))
                    {
                        insertSql = insertSql + " ,KhoiLuongCan2=@KhoiLuongCan2";
                    }
                    if (!String.IsNullOrEmpty(item.ThoiGianCan1.ToString()))
                    {
                        insertSql = insertSql + " ,ThoiGianCan1=@ThoiGianCan1";
                    }
                    if (!String.IsNullOrEmpty(item.ThoiGianCan2.ToString()))
                    {
                        insertSql = insertSql + " ,ThoiGianCan2=@ThoiGianCan2";
                    }
                    insertSql = insertSql + " WHERE SoPhieu=@SoPhieu and LanCan=@LanCan";
                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@BienSoXe", item.BienSoXe));
                        cmd.Parameters.Add(new SqlParameter("@NguoiBan", item.NguoiBan));
                        cmd.Parameters.Add(new SqlParameter("@NguoiMua", item.NguoiMua));
                        cmd.Parameters.Add(new SqlParameter("@LaiXe", item.LaiXe));

                        cmd.Parameters.Add(new SqlParameter("@MaHang", item.MaHang));
                        cmd.Parameters.Add(new SqlParameter("@TenHang", item.TenHang));
                        cmd.Parameters.Add(new SqlParameter("@KhoHang", item.KhoHang));
                        cmd.Parameters.Add(new SqlParameter("@GhiChu", item.GhiChu));

                        cmd.Parameters.Add(new SqlParameter("@KhoiLuongCan1", item.KhoiLuongCan1));
                        cmd.Parameters.Add(new SqlParameter("@KhoiLuongCan2", item.KhoiLuongCan1));

                        cmd.Parameters.Add(new SqlParameter("@ThoiGianCan1", item.ThoiGianCan1));
                        cmd.Parameters.Add(new SqlParameter("@ThoiGianCan2", item.ThoiGianCan1));

                        //cmd.Parameters.Add(new SqlParameter("@NhanVienCanLan1", item.NhanVienCanLan1));
                        //cmd.Parameters.Add(new SqlParameter("@NhanVienCanLan2", item.NhanVienCanLan2));

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
        public bool UpdatePhieuCan1(string connectString, PhieuCanDTO item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string insertSql = "update E_PhieuCan set BienSoXe=@BienSoXe, NguoiBan=@NguoiBan, " +
                        "NguoiMua=@NguoiMua, LaiXe=@LaiXe, MaHang=@MaHang, TenHang=@TenHang," +
                        " KhoiLuongCan1=@KhoiLuongCan1, ThoiGianCan1=@ThoiGianCan1, KhoHang=@KhoHang," +
                        " GhiChu=@GhiChu, NhanVienCanLan1=@NhanVienCanLan1, KieuCan=@KieuCan " +
                        " where SoPhieu=@SoPhieu and LanCan = 1";

                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@SoPhieu", item.SoPhieu));
                        cmd.Parameters.Add(new SqlParameter("@BienSoXe", item.BienSoXe));
                        cmd.Parameters.Add(new SqlParameter("@NguoiBan", item.NguoiBan));
                        cmd.Parameters.Add(new SqlParameter("@NguoiMua", item.NguoiMua));
                        cmd.Parameters.Add(new SqlParameter("@LaiXe", item.LaiXe));
                        cmd.Parameters.Add(new SqlParameter("@MaHang", item.MaHang));
                        cmd.Parameters.Add(new SqlParameter("@TenHang", item.TenHang));
                        cmd.Parameters.Add(new SqlParameter("@KhoHang", item.KhoHang));
                        cmd.Parameters.Add(new SqlParameter("@GhiChu", item.GhiChu));
                        cmd.Parameters.Add(new SqlParameter("@NhanVienCanLan1", item.NhanVienCanLan1));
                        cmd.Parameters.Add(new SqlParameter("@KieuCan", item.KieuCan));
                        cmd.Parameters.Add(new SqlParameter("@KhoiLuongCan1", item.KhoiLuongCan1));
                        cmd.Parameters.Add(new SqlParameter("@ThoiGianCan1", item.ThoiGianCan1));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdatePhieuCan1Off(PhieuCanDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();

                    //string insertSql = "update E_PhieuCan set KhoiLuongCan1 = @KhoiLuongCan1, ThoiGianCan1=@ThoiGianCan1, " +
                    //    " NhanVienCanLan1=@NhanVienCanLan1 " +
                    //    " where SoPhieu=@SoPhieu and LanCan = 1";

                    string insertSql = "update E_PhieuCan set BienSoXe=@BienSoXe, NguoiBan=@NguoiBan, " +
                        "NguoiMua=@NguoiMua, LaiXe=@LaiXe, MaHang=@MaHang, TenHang=@TenHang," +
                        " KhoiLuongCan1=@KhoiLuongCan1, ThoiGianCan1=@ThoiGianCan1, KhoHang=@KhoHang," +
                        " GhiChu=@GhiChu, NhanVienCanLan1=@NhanVienCanLan1, KieuCan=@KieuCan " +
                        " where SoPhieu=@SoPhieu and LanCan = 1";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@SoPhieu", item.SoPhieu));
                        cmd.Parameters.Add(new SQLiteParameter("@BienSoXe", item.BienSoXe));
                        cmd.Parameters.Add(new SQLiteParameter("@NguoiBan", item.NguoiBan));
                        cmd.Parameters.Add(new SQLiteParameter("@NguoiMua", item.NguoiMua));
                        cmd.Parameters.Add(new SQLiteParameter("@LaiXe", item.LaiXe));
                        cmd.Parameters.Add(new SQLiteParameter("@MaHang", item.MaHang));
                        cmd.Parameters.Add(new SQLiteParameter("@TenHang", item.TenHang));
                        cmd.Parameters.Add(new SQLiteParameter("@KhoHang", item.KhoHang));
                        cmd.Parameters.Add(new SQLiteParameter("@GhiChu", item.GhiChu));
                        cmd.Parameters.Add(new SQLiteParameter("@NhanVienCanLan1", item.NhanVienCanLan1));
                        cmd.Parameters.Add(new SQLiteParameter("@KieuCan", item.KieuCan));
                        cmd.Parameters.Add(new SQLiteParameter("@KhoiLuongCan1", item.KhoiLuongCan1));
                        cmd.Parameters.Add(new SQLiteParameter("@ThoiGianCan1", item.ThoiGianCan1));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdatePhieuCan2(string connectString, PhieuCanDTO item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string insertSql = "  update E_PhieuCan set BienSoXe=@BienSoXe, NguoiBan=@NguoiBan, " +
                        " NguoiMua=@NguoiMua, LaiXe=@LaiXe, MaHang=@MaHang, TenHang=@TenHang," +
                        " KhoiLuongCan1=@KhoiLuongCan1, KhoiLuongCan2=@KhoiLuongCan2, ThoiGianCan2=@ThoiGianCan2, KhoHang=@KhoHang," +
                        " GhiChu=@GhiChu, NhanVienCanLan2=@NhanVienCanLan2, KieuCan=@KieuCan " +
                        " where SoPhieu= @SoPhieu and LanCan = 2";
                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@SoPhieu", item.SoPhieu));
                        cmd.Parameters.Add(new SqlParameter("@BienSoXe", item.BienSoXe));
                        cmd.Parameters.Add(new SqlParameter("@NguoiBan", item.NguoiBan));
                        cmd.Parameters.Add(new SqlParameter("@NguoiMua", item.NguoiMua));
                        cmd.Parameters.Add(new SqlParameter("@LaiXe", item.LaiXe));
                        cmd.Parameters.Add(new SqlParameter("@MaHang", item.MaHang));
                        cmd.Parameters.Add(new SqlParameter("@TenHang", item.TenHang));
                        cmd.Parameters.Add(new SqlParameter("@KhoHang", item.KhoHang));
                        cmd.Parameters.Add(new SqlParameter("@GhiChu", item.GhiChu));
                        cmd.Parameters.Add(new SqlParameter("@NhanVienCanLan2", item.NhanVienCanLan2));
                        cmd.Parameters.Add(new SqlParameter("@KieuCan", item.KieuCan));
                        cmd.Parameters.Add(new SqlParameter("@KhoiLuongCan2", item.KhoiLuongCan2));
                        cmd.Parameters.Add(new SqlParameter("@KhoiLuongCan1", item.KhoiLuongCan1));
                        cmd.Parameters.Add(new SqlParameter("@ThoiGianCan2", item.ThoiGianCan2));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdatePhieuCan2Off(PhieuCanDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();

                    string insertSql = "  update E_PhieuCan set BienSoXe=@BienSoXe, NguoiBan=@NguoiBan, " +
                        " NguoiMua=@NguoiMua, LaiXe=@LaiXe, MaHang=@MaHang, TenHang=@TenHang," +
                        " KhoiLuongCan1=@KhoiLuongCan1, KhoiLuongCan2=@KhoiLuongCan2, ThoiGianCan2=@ThoiGianCan2, KhoHang=@KhoHang," +
                        " GhiChu=@GhiChu, NhanVienCanLan2=@NhanVienCanLan2, KieuCan=@KieuCan " +
                        " where SoPhieu=@SoPhieu and LanCan = 2";
                    using (SQLiteCommand cmd = new SQLiteCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@SoPhieu", item.SoPhieu));
                        cmd.Parameters.Add(new SQLiteParameter("@BienSoXe", item.BienSoXe));
                        cmd.Parameters.Add(new SQLiteParameter("@NguoiBan", item.NguoiBan));
                        cmd.Parameters.Add(new SQLiteParameter("@NguoiMua", item.NguoiMua));
                        cmd.Parameters.Add(new SQLiteParameter("@LaiXe", item.LaiXe));
                        cmd.Parameters.Add(new SQLiteParameter("@MaHang", item.MaHang));
                        cmd.Parameters.Add(new SQLiteParameter("@TenHang", item.TenHang));
                        cmd.Parameters.Add(new SQLiteParameter("@KhoHang", item.KhoHang));
                        cmd.Parameters.Add(new SQLiteParameter("@GhiChu", item.GhiChu));
                        cmd.Parameters.Add(new SQLiteParameter("@NhanVienCanLan2", item.NhanVienCanLan2));
                        cmd.Parameters.Add(new SQLiteParameter("@KieuCan", item.KieuCan));
                        cmd.Parameters.Add(new SQLiteParameter("@KhoiLuongCan2", item.KhoiLuongCan2));
                        cmd.Parameters.Add(new SQLiteParameter("@KhoiLuongCan1", item.KhoiLuongCan1));
                        cmd.Parameters.Add(new SQLiteParameter("@ThoiGianCan2", item.ThoiGianCan2));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<PhieuCanDTO> GetPhieuCanSqlite()
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db"; 
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM E_PhieuCan where status_show ='SHOW' and sync = 'False' ORDER BY created_at DESC";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.SoPhieu = (reader["SoPhieu"]).ToString();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                obj.GhiChu = (reader["GhiChu"]).ToString();
                                obj.KieuCan = (reader["KieuCan"]).ToString();
                                obj.LanCan = Convert.ToInt32(reader["LanCan"]);
                                if ((reader["KhoiLuongCan1"]).ToString() != "")
                                    obj.KhoiLuongCan1 = Convert.ToInt32((reader["KhoiLuongCan1"]));
                                if ((reader["KhoiLuongCan2"]).ToString() != "")
                                    obj.KhoiLuongCan2 = Convert.ToInt32((reader["KhoiLuongCan2"]));
                                if ((reader["ThoiGianCan1"]).ToString() != "")
                                    obj.ThoiGianCan1 = Convert.ToDateTime((reader["ThoiGianCan1"]));

                                if ((reader["ThoiGianCan2"]).ToString() != "")
                                    obj.ThoiGianCan2 = Convert.ToDateTime((reader["ThoiGianCan2"]));
                                if ((reader["SoMay"]).ToString() != "")
                                    obj.SoMay = Convert.ToInt32((reader["SoMay"]));

                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }

            return resultList;
        }
        public bool InsertPhieuCanLanSqlite(PhieuCanDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
                {
                    connection.Open();

                    string string1 = "INSERT INTO E_PhieuCan(SoPhieu, BienSoXe, NguoiBan, NguoiMua, LaiXe, MaHang, TenHang, KhoHang, GhiChu, KieuCan, SoMay, LanCan, created_at, status_show, sync";
                    string string2 = "VALUES (@SoPhieu, @BienSoXe, @NguoiBan, @NguoiMua, @LaiXe, @MaHang, @TenHang, @KhoHang, @GhiChu, @KieuCan, @SoMay, @LanCan, @created_at, @status_show, @sync";

                    if (!String.IsNullOrEmpty(item.KhoiLuongCan1.ToString()))
                    {
                        string1 = string1 + ", KhoiLuongCan1";
                        string2 = string2 + ", @KhoiLuongCan1";
                    }
                    if (!String.IsNullOrEmpty(item.KhoiLuongCan2.ToString()))
                    {
                        string1 = string1 + ", KhoiLuongCan2";
                        string2 = string2 + ", @KhoiLuongCan2";
                    }
                    if (!String.IsNullOrEmpty(item.ThoiGianCan1.ToString()))
                    {
                        string1 = string1 + ", ThoiGianCan1";
                        string2 = string2 + ", @ThoiGianCan1";
                    }

                    if (!String.IsNullOrEmpty(item.ThoiGianCan2.ToString()))
                    {
                        string1 = string1 + ", ThoiGianCan2";
                        string2 = string2 + ", @ThoiGianCan2";
                    }
                    if (!String.IsNullOrEmpty(item.NhanVienCanLan1))
                    {
                        string1 = string1 + ", NhanVienCanLan1";
                        string2 = string2 + ", @NhanVienCanLan1";
                    }
                    if (!String.IsNullOrEmpty(item.NhanVienCanLan2))
                    {
                        string1 = string1 + ", NhanVienCanLan2";
                        string2 = string2 + ", @NhanVienCanLan2";
                    }
                    if (item.Image1_1 != null)
                    {
                        string1 = string1 + ", Image1_1";
                        string2 = string2 + ", @Image1_1";
                    }
                    if (item.Image1_2 != null)
                    {
                        string1 = string1 + ", Image1_2";
                        string2 = string2 + ", @Image1_2";
                    }
                    if (item.Image1_3 != null)
                    {
                        string1 = string1 + ", Image1_3";
                        string2 = string2 + ", @Image1_3";
                    }
                    if (item.Image2_1 != null)
                    {
                        string1 = string1 + ", Image2_1";
                        string2 = string2 + ", @Image2_1";
                    }
                    if (item.Image2_2 != null)
                    {
                        string1 = string1 + ", Image2_2";
                        string2 = string2 + ", @Image2_2";
                    }
                    if (item.Image2_3 != null)
                    {
                        string1 = string1 + ", Image2_3";
                        string2 = string2 + ", @Image2_3";
                    }

                    string1 = string1 + ")";
                    string2 = string2 + ")";

                    string insertSql = string1 + string2;

                    using (SQLiteCommand cmd = new SQLiteCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@SoPhieu", item.SoPhieu));
                        cmd.Parameters.Add(new SQLiteParameter("@BienSoXe", item.BienSoXe));
                        cmd.Parameters.Add(new SQLiteParameter("@NguoiBan", item.NguoiBan));
                        cmd.Parameters.Add(new SQLiteParameter("@NguoiMua", item.NguoiMua));
                        cmd.Parameters.Add(new SQLiteParameter("@LaiXe", item.LaiXe));
                        cmd.Parameters.Add(new SQLiteParameter("@MaHang", item.MaHang));
                        cmd.Parameters.Add(new SQLiteParameter("@TenHang", item.TenHang));
                        cmd.Parameters.Add(new SQLiteParameter("@KhoHang", item.KhoHang));
                        cmd.Parameters.Add(new SQLiteParameter("@GhiChu", item.GhiChu));
                        cmd.Parameters.Add(new SQLiteParameter("@KieuCan", item.KieuCan));
                        cmd.Parameters.Add(new SQLiteParameter("@SoMay", item.SoMay));
                        cmd.Parameters.Add(new SQLiteParameter("@LanCan", item.LanCan));
                        cmd.Parameters.Add(new SQLiteParameter("@created_at", item.created_at));
                        cmd.Parameters.Add(new SQLiteParameter("@status_show", item.status_show));
                        cmd.Parameters.Add(new SQLiteParameter("@sync", "False"));

                        if (item.KhoiLuongCan1 != null)
                            cmd.Parameters.Add(new SQLiteParameter("@KhoiLuongCan1", item.KhoiLuongCan1));
                        if (item.KhoiLuongCan2 != null)
                            cmd.Parameters.Add(new SQLiteParameter("@KhoiLuongCan2", item.KhoiLuongCan2));

                        if (!String.IsNullOrEmpty(item.NhanVienCanLan1))
                            cmd.Parameters.Add(new SQLiteParameter("@NhanVienCanLan1", item.NhanVienCanLan1));
                        if (!String.IsNullOrEmpty(item.NhanVienCanLan2))
                            cmd.Parameters.Add(new SQLiteParameter("@NhanVienCanLan2", item.NhanVienCanLan2));

                        if (item.ThoiGianCan1 != null)
                            cmd.Parameters.Add(new SQLiteParameter("@ThoiGianCan1", item.ThoiGianCan1));
                        if (item.ThoiGianCan2 != null)
                            cmd.Parameters.Add(new SQLiteParameter("@ThoiGianCan2", item.ThoiGianCan2));

                        if (item.Image1_1 != null)
                            cmd.Parameters.Add(new SQLiteParameter("@Image1_1", item.Image1_1));
                        if (item.Image1_2 != null)
                            cmd.Parameters.Add(new SQLiteParameter("@Image1_2", item.Image1_2));
                        if (item.Image1_3 != null)
                            cmd.Parameters.Add(new SQLiteParameter("@Image1_3", item.Image1_3));

                        if (item.Image2_1 != null)
                            cmd.Parameters.Add(new SQLiteParameter("@Image2_1", item.Image2_1));
                        if (item.Image2_2 != null)
                            cmd.Parameters.Add(new SQLiteParameter("@Image2_2", item.Image2_2));
                        if (item.Image2_3 != null)
                            cmd.Parameters.Add(new SQLiteParameter("@Image2_3", item.Image2_3));

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DongBo()
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection sqliteConnection = new SQLiteConnection(sqliteConnectionString))
                {
                    sqliteConnection.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = "SELECT * FROM E_PhieuCan where sync = 'False'";
                    using (SQLiteCommand command = new SQLiteCommand(query, sqliteConnection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Kết nối đến SQL Server     
                            using (SqlConnection sqlServerConnection = new SqlConnection(Properties.Settings.Default.connectString))
                            {
                                sqlServerConnection.Open();

                                // Chèn dữ liệu vào SQL Server
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlServerConnection))
                                {
                                    bulkCopy.ColumnMappings.Add("SoPhieu", "SoPhieu");
                                    bulkCopy.ColumnMappings.Add("BienSoXe", "BienSoXe");
                                    bulkCopy.ColumnMappings.Add("NguoiBan", "NguoiBan");
                                    bulkCopy.ColumnMappings.Add("NguoiMua", "NguoiMua");
                                    bulkCopy.ColumnMappings.Add("LaiXe", "LaiXe");
                                    bulkCopy.ColumnMappings.Add("MaHang", "MaHang");
                                    bulkCopy.ColumnMappings.Add("TenHang", "TenHang");
                                    bulkCopy.ColumnMappings.Add("KhoHang", "KhoHang");
                                    bulkCopy.ColumnMappings.Add("GhiChu", "GhiChu");
                                    bulkCopy.ColumnMappings.Add("KieuCan", "KieuCan");
                                    bulkCopy.ColumnMappings.Add("KhoiLuongCan1", "KhoiLuongCan1");
                                    bulkCopy.ColumnMappings.Add("KhoiLuongCan2", "KhoiLuongCan2");
                                    bulkCopy.ColumnMappings.Add("ThoiGianCan1", "ThoiGianCan1");
                                    bulkCopy.ColumnMappings.Add("ThoiGianCan2", "ThoiGianCan2");
                                    bulkCopy.ColumnMappings.Add("Image1_1", "Image1_1");
                                    bulkCopy.ColumnMappings.Add("Image1_2", "Image1_2");
                                    bulkCopy.ColumnMappings.Add("Image1_3", "Image1_3");
                                    bulkCopy.ColumnMappings.Add("Image2_1", "Image2_1");
                                    bulkCopy.ColumnMappings.Add("Image2_2", "Image2_2");
                                    bulkCopy.ColumnMappings.Add("Image2_3", "Image2_3");
                                    bulkCopy.ColumnMappings.Add("SoMay", "SoMay");
                                    bulkCopy.ColumnMappings.Add("LanCan", "LanCan");
                                    bulkCopy.ColumnMappings.Add("NhanVienCanLan1", "NhanVienCanLan1");
                                    bulkCopy.ColumnMappings.Add("NhanVienCanLan2", "NhanVienCanLan2");
                                    bulkCopy.ColumnMappings.Add("created_at", "created_at");
                                    bulkCopy.ColumnMappings.Add("status_show", "status_show");
                                    bulkCopy.DestinationTableName = "E_PhieuCan";

                                    DataTable dataTable = new DataTable();
                                    dataTable.Columns.Add("SoPhieu", typeof(string));
                                    dataTable.Columns.Add("BienSoXe", typeof(string));
                                    dataTable.Columns.Add("NguoiBan", typeof(string));
                                    dataTable.Columns.Add("NguoiMua", typeof(string));
                                    dataTable.Columns.Add("LaiXe", typeof(string));
                                    dataTable.Columns.Add("MaHang", typeof(string));
                                    dataTable.Columns.Add("TenHang", typeof(string));
                                    dataTable.Columns.Add("KhoHang", typeof(string));
                                    dataTable.Columns.Add("GhiChu", typeof(string));
                                    dataTable.Columns.Add("KieuCan", typeof(string));
                                    dataTable.Columns.Add("KhoiLuongCan1", typeof(Int32));
                                    dataTable.Columns.Add("KhoiLuongCan2", typeof(Int32));
                                    dataTable.Columns.Add("ThoiGianCan1", typeof(DateTime));
                                    dataTable.Columns.Add("ThoiGianCan2", typeof(DateTime));
                                    dataTable.Columns.Add("Image1_1", typeof(byte[]));
                                    dataTable.Columns.Add("Image1_2", typeof(byte[]));
                                    dataTable.Columns.Add("Image1_3", typeof(byte[]));
                                    dataTable.Columns.Add("Image2_1", typeof(byte[]));
                                    dataTable.Columns.Add("Image2_2", typeof(byte[]));
                                    dataTable.Columns.Add("Image2_3", typeof(byte[]));
                                    dataTable.Columns.Add("SoMay", typeof(Int32));
                                    dataTable.Columns.Add("LanCan", typeof(Int32));
                                    dataTable.Columns.Add("NhanVienCanLan1", typeof(string));
                                    dataTable.Columns.Add("NhanVienCanLan2", typeof(string));
                                    dataTable.Columns.Add("created_at", typeof(DateTime));
                                    dataTable.Columns.Add("status_show", typeof(string));

                                    while (reader.Read())
                                    {
                                        DataRow newRow = dataTable.NewRow();
                                        newRow["SoPhieu"] = reader["SoPhieu"].ToString();
                                        newRow["BienSoXe"] = (reader["BienSoXe"]).ToString();
                                        newRow["NguoiBan"] = (reader["NguoiBan"]).ToString();
                                        newRow["NguoiMua"] = (reader["NguoiMua"]).ToString();
                                        newRow["LaiXe"] = (reader["LaiXe"]).ToString();
                                        newRow["MaHang"] = (reader["MaHang"]).ToString();
                                        newRow["TenHang"] = (reader["TenHang"]).ToString();
                                        newRow["KhoHang"] = (reader["KhoHang"]).ToString();
                                        newRow["GhiChu"] = (reader["GhiChu"]).ToString();
                                        newRow["KieuCan"] = (reader["KieuCan"]).ToString();
                                        if ((reader["KhoiLuongCan1"]).ToString() != "")
                                            newRow["KhoiLuongCan1"] = Convert.ToInt32(reader["KhoiLuongCan1"]);
                                        if ((reader["KhoiLuongCan2"]).ToString() != "")
                                            newRow["KhoiLuongCan2"] = Convert.ToInt32(reader["KhoiLuongCan2"]);
                                        if ((reader["ThoiGianCan1"]).ToString() != "")
                                            newRow["ThoiGianCan1"] = Convert.ToDateTime(reader["ThoiGianCan1"]);
                                        if ((reader["ThoiGianCan2"]).ToString() != "")
                                            newRow["ThoiGianCan2"] = Convert.ToDateTime(reader["ThoiGianCan2"]);
                                        if ((reader["Image1_1"]).ToString() != "")
                                            newRow["Image1_1"] = (byte[])(reader["Image1_1"]);
                                        if ((reader["Image1_2"]).ToString() != "")
                                            newRow["Image1_2"] = (byte[])(reader["Image1_2"]);
                                        if ((reader["Image1_3"]).ToString() != "")
                                            newRow["Image1_3"] = (byte[])(reader["Image1_3"]);
                                        if ((reader["Image2_1"]).ToString() != "")
                                            newRow["Image2_1"] = (byte[])(reader["Image2_1"]);
                                        if ((reader["Image2_2"]).ToString() != "")
                                            newRow["Image2_2"] = (byte[])(reader["Image2_2"]);
                                        if ((reader["Image2_3"]).ToString() != "")
                                            newRow["Image2_3"] = (byte[])(reader["Image2_3"]);
                                        newRow["SoMay"] = Convert.ToInt32(reader["SoMay"]);
                                        newRow["LanCan"] = Convert.ToInt32(reader["LanCan"]);
                                        newRow["NhanVienCanLan1"] = (reader["NhanVienCanLan1"]).ToString();
                                        newRow["NhanVienCanLan2"] = (reader["NhanVienCanLan1"]).ToString();
                                        newRow["created_at"] = Convert.ToDateTime(reader["created_at"]);
                                        newRow["status_show"] = (reader["status_show"]).ToString();
                                        dataTable.Rows.Add(newRow);                               
                                    }

                                    bulkCopy.WriteToServer(dataTable);
                                }
                            }
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DongBo1Phieu(string sophieu)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection sqliteConnection = new SQLiteConnection(sqliteConnectionString))
                {
                    sqliteConnection.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = $"SELECT * FROM E_PhieuCan where sync = 'False' and SoPhieu = '{sophieu}'  ";
                    using (SQLiteCommand command = new SQLiteCommand(query, sqliteConnection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Kết nối đến SQL Server     
                            using (SqlConnection sqlServerConnection = new SqlConnection(Properties.Settings.Default.connectString))
                            {
                                sqlServerConnection.Open();

                                // Chèn dữ liệu vào SQL Server
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlServerConnection))
                                {
                                    bulkCopy.ColumnMappings.Add("SoPhieu", "SoPhieu");
                                    bulkCopy.ColumnMappings.Add("BienSoXe", "BienSoXe");
                                    bulkCopy.ColumnMappings.Add("NguoiBan", "NguoiBan");
                                    bulkCopy.ColumnMappings.Add("NguoiMua", "NguoiMua");
                                    bulkCopy.ColumnMappings.Add("LaiXe", "LaiXe");
                                    bulkCopy.ColumnMappings.Add("MaHang", "MaHang");
                                    bulkCopy.ColumnMappings.Add("TenHang", "TenHang");
                                    bulkCopy.ColumnMappings.Add("KhoHang", "KhoHang");
                                    bulkCopy.ColumnMappings.Add("GhiChu", "GhiChu");
                                    bulkCopy.ColumnMappings.Add("KieuCan", "KieuCan");
                                    bulkCopy.ColumnMappings.Add("KhoiLuongCan1", "KhoiLuongCan1");
                                    bulkCopy.ColumnMappings.Add("KhoiLuongCan2", "KhoiLuongCan2");
                                    bulkCopy.ColumnMappings.Add("ThoiGianCan1", "ThoiGianCan1");
                                    bulkCopy.ColumnMappings.Add("ThoiGianCan2", "ThoiGianCan2");
                                    bulkCopy.ColumnMappings.Add("Image1_1", "Image1_1");
                                    bulkCopy.ColumnMappings.Add("Image1_2", "Image1_2");
                                    bulkCopy.ColumnMappings.Add("Image1_3", "Image1_3");
                                    bulkCopy.ColumnMappings.Add("Image2_1", "Image2_1");
                                    bulkCopy.ColumnMappings.Add("Image2_2", "Image2_2");
                                    bulkCopy.ColumnMappings.Add("Image2_3", "Image2_3");
                                    bulkCopy.ColumnMappings.Add("SoMay", "SoMay");
                                    bulkCopy.ColumnMappings.Add("LanCan", "LanCan");
                                    bulkCopy.ColumnMappings.Add("NhanVienCanLan1", "NhanVienCanLan1");
                                    bulkCopy.ColumnMappings.Add("NhanVienCanLan2", "NhanVienCanLan2");
                                    bulkCopy.ColumnMappings.Add("created_at", "created_at");
                                    bulkCopy.ColumnMappings.Add("status_show", "status_show");
                                    bulkCopy.DestinationTableName = "E_PhieuCan";

                                    DataTable dataTable = new DataTable();
                                    dataTable.Columns.Add("SoPhieu", typeof(string));
                                    dataTable.Columns.Add("BienSoXe", typeof(string));
                                    dataTable.Columns.Add("NguoiBan", typeof(string));
                                    dataTable.Columns.Add("NguoiMua", typeof(string));
                                    dataTable.Columns.Add("LaiXe", typeof(string));
                                    dataTable.Columns.Add("MaHang", typeof(string));
                                    dataTable.Columns.Add("TenHang", typeof(string));
                                    dataTable.Columns.Add("KhoHang", typeof(string));
                                    dataTable.Columns.Add("GhiChu", typeof(string));
                                    dataTable.Columns.Add("KieuCan", typeof(string));
                                    dataTable.Columns.Add("KhoiLuongCan1", typeof(Int32));
                                    dataTable.Columns.Add("KhoiLuongCan2", typeof(Int32));
                                    dataTable.Columns.Add("ThoiGianCan1", typeof(DateTime));
                                    dataTable.Columns.Add("ThoiGianCan2", typeof(DateTime));
                                    dataTable.Columns.Add("Image1_1", typeof(byte[]));
                                    dataTable.Columns.Add("Image1_2", typeof(byte[]));
                                    dataTable.Columns.Add("Image1_3", typeof(byte[]));
                                    dataTable.Columns.Add("Image2_1", typeof(byte[]));
                                    dataTable.Columns.Add("Image2_2", typeof(byte[]));
                                    dataTable.Columns.Add("Image2_3", typeof(byte[]));
                                    dataTable.Columns.Add("SoMay", typeof(Int32));
                                    dataTable.Columns.Add("LanCan", typeof(Int32));
                                    dataTable.Columns.Add("NhanVienCanLan1", typeof(string));
                                    dataTable.Columns.Add("NhanVienCanLan2", typeof(string));
                                    dataTable.Columns.Add("created_at", typeof(DateTime));
                                    dataTable.Columns.Add("status_show", typeof(string));

                                    while (reader.Read())
                                    {
                                        DataRow newRow = dataTable.NewRow();
                                        newRow["SoPhieu"] = reader["SoPhieu"].ToString();
                                        newRow["BienSoXe"] = (reader["BienSoXe"]).ToString();
                                        newRow["NguoiBan"] = (reader["NguoiBan"]).ToString();
                                        newRow["NguoiMua"] = (reader["NguoiMua"]).ToString();
                                        newRow["LaiXe"] = (reader["LaiXe"]).ToString();
                                        newRow["MaHang"] = (reader["MaHang"]).ToString();
                                        newRow["TenHang"] = (reader["TenHang"]).ToString();
                                        newRow["KhoHang"] = (reader["KhoHang"]).ToString();
                                        newRow["GhiChu"] = (reader["GhiChu"]).ToString();
                                        newRow["KieuCan"] = (reader["KieuCan"]).ToString();
                                        if ((reader["KhoiLuongCan1"]).ToString() != "")
                                            newRow["KhoiLuongCan1"] = Convert.ToInt32(reader["KhoiLuongCan1"]);
                                        if ((reader["KhoiLuongCan2"]).ToString() != "")
                                            newRow["KhoiLuongCan2"] = Convert.ToInt32(reader["KhoiLuongCan2"]);
                                        if ((reader["ThoiGianCan1"]).ToString() != "")
                                            newRow["ThoiGianCan1"] = Convert.ToDateTime(reader["ThoiGianCan1"]);
                                        if ((reader["ThoiGianCan2"]).ToString() != "")
                                            newRow["ThoiGianCan2"] = Convert.ToDateTime(reader["ThoiGianCan2"]);
                                        if ((reader["Image1_1"]).ToString() != "")
                                            newRow["Image1_1"] = (byte[])(reader["Image1_1"]);
                                        if ((reader["Image1_2"]).ToString() != "")
                                            newRow["Image1_2"] = (byte[])(reader["Image1_2"]);
                                        if ((reader["Image1_3"]).ToString() != "")
                                            newRow["Image1_3"] = (byte[])(reader["Image1_3"]);
                                        if ((reader["Image2_1"]).ToString() != "")
                                            newRow["Image2_1"] = (byte[])(reader["Image2_1"]);
                                        if ((reader["Image2_2"]).ToString() != "")
                                            newRow["Image2_2"] = (byte[])(reader["Image2_2"]);
                                        if ((reader["Image2_3"]).ToString() != "")
                                            newRow["Image2_3"] = (byte[])(reader["Image2_3"]);
                                        newRow["SoMay"] = Convert.ToInt32(reader["SoMay"]);
                                        newRow["LanCan"] = Convert.ToInt32(reader["LanCan"]);
                                        newRow["NhanVienCanLan1"] = (reader["NhanVienCanLan1"]).ToString();
                                        newRow["NhanVienCanLan2"] = (reader["NhanVienCanLan1"]).ToString();
                                        newRow["created_at"] = Convert.ToDateTime(reader["created_at"]);
                                        newRow["status_show"] = (reader["status_show"]).ToString();
                                        dataTable.Rows.Add(newRow);
                                    }

                                    bulkCopy.WriteToServer(dataTable);
                                }
                            }
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeleteDataOffline()
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection sqliteConnection = new SQLiteConnection(sqliteConnectionString))
                {
                    sqliteConnection.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = "Delete  FROM E_PhieuCan";
                    using (SQLiteCommand command = new SQLiteCommand(query, sqliteConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdateStatusSync()
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection sqliteConnection = new SQLiteConnection(sqliteConnectionString))
                {
                    sqliteConnection.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = "UPDATE E_PhieuCan SET sync = 'True'";
                    using (SQLiteCommand command = new SQLiteCommand(query, sqliteConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool CheckSoLuongPhieuSync()
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection sqliteConnection = new SQLiteConnection(sqliteConnectionString))
                {
                    sqliteConnection.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = "SELECT count(*) FROM E_PhieuCan where sync = 'False'";
                    using (SQLiteCommand command = new SQLiteCommand(query, sqliteConnection))
                    {
                        int a =Convert.ToInt32(command.ExecuteScalar());
                        if (a > 0) return true;
                        else return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdateStatusSyncSoPhieu(string sophieu)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection sqliteConnection = new SQLiteConnection(sqliteConnectionString))
                {
                    sqliteConnection.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = $"UPDATE E_PhieuCan SET sync = 'True' where SoPhieu='{sophieu}'";
                    using (SQLiteCommand command = new SQLiteCommand(query, sqliteConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeletePhieuCan(string connectionString, PhieuCanDTO item)
        {
            try
            {
                using (SqlConnection connecttion = new SqlConnection(connectionString))
                {
                    connecttion.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = $"Delete FROM E_PhieuCan where SoPhieu='{item.SoPhieu}'";
                    using (SqlCommand command = new SqlCommand(query, connecttion))
                    {
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DeletePhieuCanOff(PhieuCanDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connecttion = new SQLiteConnection(sqliteConnectionString))
                {
                    connecttion.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = $"Delete FROM E_PhieuCan where SoPhieu='{item.SoPhieu}'";
                    using (SQLiteCommand command = new SQLiteCommand(query, connecttion))
                    {
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeletePhieuCanOffSync(PhieuCanDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connecttion = new SQLiteConnection(sqliteConnectionString))
                {
                    connecttion.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = $"Delete FROM E_PhieuCan where SoPhieu='{item.SoPhieu}' and sync = 'False'";
                    using (SQLiteCommand command = new SQLiteCommand(query, connecttion))
                    {
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdateStatusPC1(string connectionString, PhieuCanDTO item)
        {
            try
            {
                using (SqlConnection connecttion = new SqlConnection(connectionString))
                {
                    connecttion.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = $"update E_PhieuCan set status_show='HIDE' where SoPhieu='{item.SoPhieu}' and LanCan = 1";
                    using (SqlCommand command = new SqlCommand(query, connecttion))
                    {
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdateSqliteStatusPC1(PhieuCanDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connecttion = new SQLiteConnection(sqliteConnectionString))
                {
                    connecttion.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = $"update E_PhieuCan set status_show='HIDE' where SoPhieu='{item.SoPhieu}' and LanCan = 1";
                    using (SQLiteCommand command = new SQLiteCommand(query, connecttion))
                    {
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<PhieuCanDTO> GetListThongTinPhieuCan(string connectString)
        {
            List<PhieuCanDTO> resultList = new List<PhieuCanDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "select Distinct BienSoXe, LaiXe, NguoiBan, NguoiMua, KhoHang from E_PhieuCan";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandTimeout = 5;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhieuCanDTO obj = new PhieuCanDTO();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                resultList.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<PhieuCanDTO>();
            }
            return resultList;
        }
        public bool CheckPhieuCanLan1(string connectionString, PhieuCanDTO item)
        {
            try
            {
                
                using (SqlConnection connecttion = new SqlConnection(connectionString))
                {
                    connecttion.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = $"SELECT COUNT(SoPhieu) FROM E_PhieuCan where SoPhieu='{item.SoPhieu}'";
                    using (SqlCommand command = new SqlCommand(query, connecttion))
                    {
                        int rowCount = Convert.ToInt32(command.ExecuteScalar());
                        if (rowCount == 1) return true;
                        else return false;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool CheckPhieuCanLan1Sqlite(PhieuCanDTO item)
        {
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";

                using (SQLiteConnection connecttion = new SQLiteConnection(sqliteConnectionString))
                {
                    connecttion.Open();

                    // Truy vấn dữ liệu từ SQLite
                    string query = $"SELECT COUNT(SoPhieu) FROM E_PhieuCan where SoPhieu='{item.SoPhieu}'";
                    using (SQLiteCommand command = new SQLiteCommand(query, connecttion))
                    {
                        int rowCount = Convert.ToInt32(command.ExecuteScalar());
                        if (rowCount == 1) return true;
                        else return false;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
