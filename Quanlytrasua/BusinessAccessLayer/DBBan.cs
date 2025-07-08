using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
namespace BusinessAccessLayer
{
    public class DBBan
    {
        DAL db = null;
        public DBBan()
        {
            db = new DAL();
        }

        public bool InsertBan(ref string err, string Ten, int TrangThai)
        {
            try
            {
                return db.ExecuteNonQuery("InsertBan", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@Ten", Ten),
                    new SqlParameter("@TrangThai", TrangThai)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool UpdateBan(ref string err, int id_ban, string Ten, int TrangThai)
        {
            try
            {
                return db.ExecuteNonQuery("UpdateBan", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_ban", id_ban),
                    new SqlParameter("@Ten", Ten),
                    new SqlParameter("@TrangThai", TrangThai)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool DeleteBan(ref string err, int id_ban)
        {
            try
            {
                return db.ExecuteNonQuery("DeleteBan", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_ban", id_ban)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public DataSet GetAllBan(ref string err)
        {
            try
            {
                return db.ExecuteQueryDataSet("GetBan", CommandType.StoredProcedure,null);
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }
    }
}
