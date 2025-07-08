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
    public class DBLoaiThucUong
    {
        DAL db = null;
        public DBLoaiThucUong()
        {
            db = new DAL();
        }

        public bool InsertLoaiThucUong(ref string err, string Ten, int TrangThai)
        {
            try
            {
                return db.ExecuteNonQuery("InsertLoaiThucUong", CommandType.StoredProcedure, ref err,
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

        // Update LoaiThucUong
        public bool UpdateLoaiThucUong(ref string err, int id_loaiThucUong, string Ten, int TrangThai)
        {
            try
            {
                return db.ExecuteNonQuery("UpdateLoaiThucUong", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_loaiThucUong", id_loaiThucUong),
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

        // Delete LoaiThucUong
        public bool DeleteLoaiThucUong(ref string err, int id_loaiThucUong)
        {
            try
            {
                return db.ExecuteNonQuery("DeleteLoaiThucUong", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_loaiThucUong", id_loaiThucUong)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // Get all LoaiThucUong
        public DataSet GetAllLoaiThucUong(ref string err)
        {
            try
            {
                return db.ExecuteQueryDataSet("SELECT * FROM LoaiThucUong", CommandType.Text, null);
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }

    }
}
