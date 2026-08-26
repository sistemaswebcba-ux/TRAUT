using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Concesionaria.Clases
{
    public class cVentaProducto
    {
        public Int32 Insertar(SqlConnection con, SqlTransaction Transaccion, DateTime Fecha, Int32? CodCliente,
          Double Total)
        {
            string sql = "Insert into VentaProducto (";
            sql = sql + "Fecha,CodCliente,Total)";
            sql = sql + " values (" + "'" + Fecha.ToShortDateString() + "'";
           
            if (CodCliente != null)
                sql = sql + "," + CodCliente.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + Total.ToString().Replace(",", ".");
            
            sql = sql + ")";
            Int32 CodVenta = 0;
            CodVenta = Convert.ToInt32(cDb.EjecutarEscalarTransaccion(con, Transaccion, sql));
            return CodVenta;
        }

        public void InsertarDetalle(SqlConnection con, SqlTransaction Transaccion, Int32 codventa,
         Int32 CodProducto, int Cantidad, Double PrecioVenta, Double Subtotal)
        {
            string sql = "insert into DetalleVentaProducto(";
            sql = sql + "codventa,CodProducto,Cantidad";
            sql = sql + ",PrecioVenta,Subtotal)";
            sql = sql + " values (";
            sql = sql + codventa.ToString();
            sql = sql + "," + CodProducto.ToString();
            sql = sql + "," + Cantidad.ToString();
            sql = sql + "," + PrecioVenta.ToString().Replace(",", ".");
            sql = sql + "," + Subtotal.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetVentaProducto(DateTime FechaDesde, DateTime FechaHasta, string Cliente)
        {
            string sql = "";
            if (Cliente == "")
            {
                sql = " select v.CodVenta,";
                sql = sql + "(select c.Nombre from Cliente c where c.CodCliente = v.CodCliente) as Cliente ";
                sql = sql + ", v.Fecha, v.Total ";
                sql = sql + " from VentaProducto v ";
                sql = sql + " where v.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
                sql = sql + " and v.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
            }

            if (Cliente != "")
            {
                sql = " select v.CodVenta,";
                sql = sql + " c.Nombre  as Cliente ";
                sql = sql + ", v.Fecha, v.Total  ";
                sql = sql + " from VentaProducto v ,Cliente  c ";
                sql = sql + " where v.CodCliente =c.CodCliente ";
                sql = sql + " and v.Fecha >=" + "'" + FechaDesde.ToShortDateString() + "'";
                sql = sql + " and v.Fecha <=" + "'" + FechaHasta.ToShortDateString() + "'";
                sql = sql + " and c.Nombre like " + "'%" + Cliente + "%'";
            }

            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetVentaxCodigo(Int32 CodVenta)
        {
            string sql = "";
            sql = " select v.*,";
            sql = sql + "(select c.Nombre from Cliente c where c.CodCliente = v.CodCliente) as Cliente ";         
            sql = sql + " from VentaProducto v ";
            sql = sql + " where v.CodVenta =" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDetalle(Int32 CodVenta)
        {
            string sql = "";
            sql = "select d.CodProducto,p.Codigo,p.Nombre,";
            sql = sql + " d.Cantidad,d.PrecioVenta,d.Subtotal ";
            sql = sql + " from DetalleVentaProducto d,Producto p ";
            sql = sql + " where d.CodProducto=p.CodProducto ";
            sql = sql + " and d.CodVenta=" + CodVenta.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public void AnularVenta(Int32 CodVenta)
        {
            Int32 CodProducto = 0;
            int Cantidad = 0;
            string sql2 = "";
            string sql = "select * from DetalleVentaProducto ";
            sql = sql + " where CodVenta =" + CodVenta.ToString();
            DataTable trdo = cDb.ExecuteDataTable(sql);
            if (trdo.Rows.Count > 0)
            {
                for (int i = 0; i < trdo.Rows.Count; i++)
                {
                    CodProducto = Convert.ToInt32(trdo.Rows[i]["CodProducto"].ToString());
                    Cantidad = Convert.ToInt32(trdo.Rows[i]["Cantidad"].ToString());
                    sql2 = " update Producto set stock = isnull(stock,0) + " + Cantidad.ToString();
                    sql2 = sql2 + " where CodProducto =" + CodProducto.ToString();
                    cDb.ExecutarNonQuery(sql2);
                }
            }
            // CompraProducto
            sql = "delete from DetalleVentaProducto where CodVenta  =" + CodVenta.ToString();
            cDb.ExecutarNonQuery(sql);
            sql = "delete from VentaProducto where CodVenta  =" + CodVenta.ToString();
            cDb.ExecutarNonQuery(sql);
        }
    }
}
