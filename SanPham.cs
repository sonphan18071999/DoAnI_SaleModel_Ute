using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace WindowsFormsApp1
{
   class SanPham
    {
        MY_DB mydb = new MY_DB();
        SqlDataAdapter ad = new SqlDataAdapter();

        public DataTable getSanpham(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
          
            DataTable table = new DataTable();
            ad.Fill(table);
            return table;
        }
        public bool themSP(string msp,string tensp,string dvt,string dgia,string sl, MemoryStream picture)
        {
            mydb.openConnection();
            SqlCommand command = new SqlCommand("INSERT INTO SanPham (MaSP,TenSP,DonViTinh,DonGia,SoLuong,AnhSanPham) VALUES(@masp,@tensp,@dvt,@dongia,@sl,@asp)", mydb.getConnection);
            command.Parameters.Add("@masp", SqlDbType.NChar).Value = msp;
            command.Parameters.Add("@tensp", SqlDbType.NChar).Value = tensp;
            command.Parameters.Add("@dvt", SqlDbType.NChar).Value = dvt;
            command.Parameters.Add("@dongia", SqlDbType.Float).Value = dgia;
            command.Parameters.Add("@sl", SqlDbType.Int).Value =sl ;
            command.Parameters.Add("@asp", SqlDbType.Image).Value = picture.ToArray();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();      
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoaSP(string msp)
        {
            mydb.openConnection();
            SqlCommand command = new SqlCommand("Delete from SanPham where MaSP='" + msp + "'", mydb.getConnection);
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool chinhsuaSP(string msp, string tensp, string dvt, string dgia, string sl, MemoryStream picture)
        {
            mydb.openConnection();
            SqlCommand command = new SqlCommand("update SanPham set TenSP=@tensp,DonViTinh=@dvt,DonGia=@dongia,SoLuong=@sl,AnhSanPham=@asp where MaSP=@masp", mydb.getConnection);
            command.Parameters.Add("@masp", SqlDbType.NChar).Value = msp;
            command.Parameters.Add("@tensp", SqlDbType.NChar).Value = tensp;
            command.Parameters.Add("@dvt", SqlDbType.NChar).Value = dvt;
            command.Parameters.Add("@dongia", SqlDbType.Float).Value = dgia;
            command.Parameters.Add("@sl", SqlDbType.Int).Value = sl;
            command.Parameters.Add("@asp", SqlDbType.Image).Value = picture.ToArray();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable KTtonTai(string msp)
        {
            DataTable dbt = new DataTable();
            mydb.openConnection();
            SqlCommand command = new SqlCommand("select * from SanPham where MaSP='"+msp+"'", mydb.getConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dbt);
            return dbt;
        }
    }
}
