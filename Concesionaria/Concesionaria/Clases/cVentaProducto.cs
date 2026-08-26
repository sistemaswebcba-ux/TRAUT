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
            sql = " select v.CodVenta,";
            sql = sql + "(select c.Nombre from Cliente c where c.CodCliente = v.CodCliente) as Cliente ";
            sql = sql + ", v.Fecha, v.Total ";
            sql = sql + " from VentaProducto v ";
            sql = sql + " where v.CodVenta >=" + CodVenta.ToString();
            
        }
    }
}
