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
    public class DBNhanVien
    {
        DAL db = null;
        public DBNhanVien()
        {
            db = new DAL();
        }

        public bool InsertNhanVien(ref string err, string TenDangNhap, string HoTen, string GioiTinh, string DienThoai, string ChucVu)
        {
            try
            {
                return db.ExecuteNonQuery("InsertNhanVien", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@TenDangNhap", TenDangNhap),
                    new SqlParameter("@HoTen", HoTen),
                    new SqlParameter("@GioiTinh", GioiTinh),
                    new SqlParameter("@DienThoai", DienThoai),
                    new SqlParameter("@ChucVu", ChucVu)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool UpdateNhanVien(ref string err, int id_nhanVien, string HoTen, string GioiTinh, string DienThoai, string ChucVu, int TrangThai)
        {
            try
            {
                return db.ExecuteNonQuery("UpdateNhanVien", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_nhanVien", id_nhanVien),
                    new SqlParameter("@HoTen", HoTen),
                    new SqlParameter("@GioiTinh", GioiTinh),
                    new SqlParameter("@DienThoai", DienThoai),
                    new SqlParameter("@ChucVu", ChucVu),
                    new SqlParameter("@TrangThai", TrangThai)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool DeleteNhanVien(ref string err, int id_nhanVien)
        {
            try
            {
                return db.ExecuteNonQuery("DeleteNhanVien", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_nhanVien", id_nhanVien)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public DataSet GetAllNhanVien(ref string err)
        {
            try
            {
                return db.ExecuteQueryDataSet("GetNhanVien", CommandType.StoredProcedure, null);
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }
    }
}
