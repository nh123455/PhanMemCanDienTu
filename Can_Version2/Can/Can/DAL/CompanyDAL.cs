using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Can.GUI;

namespace Can.DAL
{
    public class CompanyDAL
    {
        public CompanyDTO GetCompany(string connectString)
        {
            CompanyDTO resultList = new CompanyDTO();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    string query = "SELECT * FROM E_CongTy";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CompanyDTO obj = new CompanyDTO();
                                obj.Company_name = (reader["Companyname"]).ToString();
                                obj.Adress = (reader["Adress"]).ToString();
                                obj.Phone = (reader["Phone"]).ToString();
                                obj.Fax = (reader["Fax"]).ToString();
                                obj.Email = (reader["Email"]).ToString();

                                return resultList = obj;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return new CompanyDTO();
            }

            return resultList;
        }

        public Int64 UpdateCompany(string connectString, CompanyDTO item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();

                    string insertSql = "update E_CongTy set Companyname = @Companyname, Adress = @Adress, Phone = @Phone, Fax = @Fax, Email = @Email";

                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Companyname", item.Company_name));
                        cmd.Parameters.Add(new SqlParameter("@Adress", item.Adress));
                        cmd.Parameters.Add(new SqlParameter("@Phone", item.Phone));
                        cmd.Parameters.Add(new SqlParameter("@Fax", item.Fax));
                        cmd.Parameters.Add(new SqlParameter("@Email", item.Email));

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
    }
}
