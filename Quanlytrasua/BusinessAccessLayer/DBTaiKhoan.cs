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
    public class DBTaiKhoan
    {
        DAL db = null;
        public DBTaiKhoan()
        {
            db = new DAL();
        }

        public bool InsertTaiKhoan(ref string err, string TenDangNhap, string MatKhau, string Loai)
        {
            try
            {
                return db.ExecuteNonQuery("InsertTaiKhoan", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@TenDangNhap", TenDangNhap),
                    new SqlParameter("@MatKhau", MatKhau),
                    new SqlParameter("@Loai", Loai)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool UpdateTaiKhoan(ref string err, string TenDangNhap, string MatKhau, string Loai, int TrangThai)
        {
            try
            {
                return db.ExecuteNonQuery("UpdateTaiKhoan", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@TenDangNhap", TenDangNhap),
                    new SqlParameter("@MatKhau", MatKhau),
                    new SqlParameter("@Loai", Loai),
                    new SqlParameter("@TrangThai", TrangThai)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool DeleteTaiKhoan(ref string err, string TenDangNhap)
        {
            try
            {
                return db.ExecuteNonQuery("DeleteTaiKhoan", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@TenDangNhap", TenDangNhap)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
        public bool CheckLogin(string tenDangNhap, string matKhau, ref string err)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau AND TrangThai = 1";
                SqlParameter[] param = {
            new SqlParameter("@TenDangNhap", tenDangNhap),
            new SqlParameter("@MatKhau", matKhau)
        };

                object result = db.ExecuteScalar(sql, CommandType.Text, param);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }



        public DataSet GetAllTaiKhoan(ref string err)
        {
            try
            {
                return db.ExecuteQueryDataSet("GetTaiKhoan", CommandType.StoredProcedure, null);
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }
    }
}
