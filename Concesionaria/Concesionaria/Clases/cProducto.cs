using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Concesionaria.Clases
{
    public class cProducto
    {
        public DataTable GetProducto(string Codigo, string Nombre)
        {
            string b = "0";
            string b1 = "0";
            if (Codigo != "")
                b = "1";
            if (Nombre != "")
                b1 = "1";
            string rdo = "";
            string sql = "";
            sql = " select CodProducto,Codigo,Nombre,Estado,Stock ";
            sql = sql + " from Producto ";
            switch(rdo)
            {
                case "01":
                    sql = sql + " where Nombre like " + "'%" + Nombre + "%'";
                    break;
                case "10":
                    sql = sql + " where Codigo like " + "'%" + Nombre + "%'";
                    break;
                case "11":
                    sql = sql + " where Codigo like " + "'%" + Nombre + "%'";
                    sql = sql + " and Nombre like " + "'%" + Nombre + "%'";
                    break;            
            }
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetProductoxCodigo(Int32 CodProducto)
        {
            string sql = "select * ";
            sql = sql + " from Producto ";
            sql = sql + " where CodProducto =" + CodProducto.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public Int32 GetMaxProducto()
        {
            Int32 CodProducto = 0;
            string sql = "select max(CodProducto) as CodProducto ";
            sql = sql + " from Producto ";
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
                CodProducto = Convert.ToInt32(trdo.Rows[0]["CodProducto"]);
            return CodProducto;
        }

        public DataTable GetProductoxCodigoEstado(string  Codigo, int CodEstado)
        {
            string sql = "";
            sql = "select * from Producto ";
            sql = sql + " where Codigo =" + "'" + Codigo + "'";
            sql = sql + " and CodEstado=" + CodEstado.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void ActualizarStock(SqlConnection con, SqlTransaction Transaccion, Int32 CodProducto, int Cantidad)
        {
            string sql = "";
            sql = " update Producto set ";
            sql = sql + " stock = isnull(stock,0) + " + Cantidad.ToString();
            sql = sql + " where CodProducto =" + CodProducto.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetProductos(string Nombre, string Version)
        {
            string rdo = "0";
            string b = "0", b1="0";
            if (Nombre != "")
                b="1";
            if (Version != "")
                b1 = "1";
            rdo = b + b1;

            string sql = "";
            sql = "select p.CodProducto,p.Codigo,p.Nombre, ";
            sql = sql + "(select m.Nombre from MarcaProducto m) as Marca , ";
            sql = sql + "p.Version,p.Estado,p.Stock,p.Costo,p.PrecioVenta ";
            sql = sql + " from Producto p ";

            switch(rdo)
            {
                case "00":
                    break;
                case "01":
                    sql = sql + " where p.Version like " + "'%" + Version + "%'";
                    break;
                case "10":
                    sql = sql + " where p.Nombre like " + "'%" + Nombre + "%'"; 
                    break;
                case "11":
                    sql = sql + " where p.Nombre like " + "'%" + Nombre + "%'";
                    sql = sql + " and p.Version like " + "'%" + Version + "%'";
                    break;
            }

            return cDb.ExecuteDataTable(sql);
        }

        public void ActualilzarPrecio(int CodProducto, Double PrecioVenta, Double Costo)
        {
            string sql = "";
            sql = "update Producto set ";
            sql = sql + " PrecioVenta =" + PrecioVenta.ToString().Replace(",", ".");
            sql = sql + " , Costo =" + Costo.ToString().Replace(",", ".");
            sql = sql + " where CodProducto=" + CodProducto.ToString();
            cDb.ExecutarNonQuery(sql);
        }
       
    }
}
