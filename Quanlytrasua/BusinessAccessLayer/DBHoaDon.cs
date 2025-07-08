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
    public class DBHoaDon
    {
        DAL db = null;
        public DBHoaDon()
        {
            db = new DAL();
        }

        public int InsertHoaDon(ref string err, int id_ban, string TenDangNhap, int trangThai)
        {
            try
            {
                SqlParameter[] parameters = {
            new SqlParameter("@id_ban", id_ban),
            new SqlParameter("@TenDangNhap", TenDangNhap),
            new SqlParameter("@TrangThai", trangThai),
            new SqlParameter("@id_hoaDon", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            }
        };

                string result = db.ExecuteNonQueryGetOrderId("InsertHoaDon", CommandType.StoredProcedure, ref err, parameters);

                if (!string.IsNullOrEmpty(result) && int.TryParse(result, out int idHoaDon))
                {
                    return idHoaDon; // Trả về ID hóa đơn vừa tạo
                }
                return -1; // Trả về -1 nếu không lấy được ID
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return -1;
            }
        }

        public bool UpdateHoaDon(ref string err, int id_hoaDon, float TongTien, int TrangThai)
        {
            try
            {
                return db.ExecuteNonQuery("UpdateHoaDon", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_hoaDon", id_hoaDon),
                    new SqlParameter("@TongTien", TongTien),
                    new SqlParameter("@TrangThai", TrangThai)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool DeleteHoaDon(ref string err, int id_hoaDon)
        {
            try
            {
                return db.ExecuteNonQuery("DeleteHoaDon", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_hoaDon", id_hoaDon)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public DataSet GetAllHoaDon(ref string err)
        {
            try
            {
                return db.ExecuteQueryDataSet("GetHoaDon", CommandType.StoredProcedure, null);
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }
    }
}
