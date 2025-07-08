using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.Data.SqlClient;

namespace BusinessAccessLayer
{
    public class DBThucUong
    {
        DAL db = null;
        public DBThucUong()
        {
            db = new DAL();
        }

        // Thêm tham số Anh kiểu byte[] để lưu dữ liệu ảnh
        public bool InsertThucUong(ref string err, string Ten, int id_loaiThucUong, float Gia, int TrangThai, byte[] Anh = null)
        {
            try
            {
                return db.ExecuteNonQuery("InsertThucUong", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@Ten", Ten),
                    new SqlParameter("@id_loaiThucUong", id_loaiThucUong),
                    new SqlParameter("@Gia", Gia),
                    new SqlParameter("@TrangThai", TrangThai),
                    new SqlParameter("@Anh", Anh == null ? (object)DBNull.Value : Anh) // Xử lý NULL nếu không có ảnh
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        // Thêm tham số Anh kiểu byte[] để cập nhật dữ liệu ảnh
        public bool UpdateThucUong(ref string err, int id_thucUong, string Ten, int id_loaiThucUong, float Gia, int TrangThai, byte[] Anh = null)
        {
            try
            {
                return db.ExecuteNonQuery("UpdateThucUong", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_thucUong", id_thucUong),
                    new SqlParameter("@Ten", Ten),
                    new SqlParameter("@id_loaiThucUong", id_loaiThucUong),
                    new SqlParameter("@Gia", Gia),
                    new SqlParameter("@TrangThai", TrangThai),
                    new SqlParameter("@Anh", Anh == null ? (object)DBNull.Value : Anh) // Xử lý NULL nếu không có ảnh
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool DeleteThucUong(ref string err, int id_thucUong)
        {
            try
            {
                return db.ExecuteNonQuery("DeleteThucUong", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_thucUong", id_thucUong)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public DataSet GetAllThucUong(ref string err)
        {
            try
            {
                return db.ExecuteQueryDataSet("GetThucUong", CommandType.StoredProcedure, null);
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }
    }
}