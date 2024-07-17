using Can.DAL;
using Can.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.BUS
{
    public class CompanyBUS
    {
        public CompanyDTO GetCompany(string connectString)
        {
            CompanyDAL cDAL = new CompanyDAL();
            return cDAL.GetCompany(connectString);
        }
        public Int64 UpdateCompany(string connectString, CompanyDTO item)
        {
            CompanyDAL cDAL = new CompanyDAL();
            return cDAL.UpdateCompany(connectString, item);
        }
    }
}
