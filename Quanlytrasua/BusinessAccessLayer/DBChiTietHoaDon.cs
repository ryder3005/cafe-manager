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
    public class DBChiTietHoaDon
    {
        DAL db = null;
        public DBChiTietHoaDon()
        {
            db = new DAL();
        }

        public bool InsertChiTietHoaDon(ref string err, int id_hoaDon, int id_thucUong, int SoLuong, float DonGia)
        {
            try
            {
                return db.ExecuteNonQuery("InsertChiTietHoaDon", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_hoaDon", id_hoaDon),
                    new SqlParameter("@id_thucUong", id_thucUong),
                    new SqlParameter("@SoLuong", SoLuong),
                    new SqlParameter("@DonGia", DonGia)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool UpdateChiTietHoaDon(ref string err, int id_chiTietHoaDon, int SoLuong)
        {
            try
            {
                return db.ExecuteNonQuery("UpdateChiTietHoaDon", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_chiTietHoaDon", id_chiTietHoaDon),
                    new SqlParameter("@SoLuong", SoLuong)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool DeleteChiTietHoaDon(ref string err, int id_chiTietHoaDon)
        {
            try
            {
                return db.ExecuteNonQuery("DeleteChiTietHoaDon", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@id_chiTietHoaDon", id_chiTietHoaDon)
                );
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public DataSet GetAllChiTietHoaDon(ref string err)
        {
            try
            {
                return db.ExecuteQueryDataSet("GetChiTietHoaDon", CommandType.StoredProcedure, null);
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }
    }
}
