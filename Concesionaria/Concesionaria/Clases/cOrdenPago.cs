using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Concesionaria.Clases
{
    public class cOrdenPago
    {
        public Int32 Insertar(SqlConnection con, SqlTransaction Transaccion, DateTime Fecha,Double Efectivo,Double Tranferencia, Double Total, Int32 CodCuentaProveedor)
        {
            Int32 CodOrden = 0;
            string sql = "insert into OrdenPago(";
            sql = sql + " Fecha,Efectivo,Tranferencia,Total,CodCuentaProveedor)";
            sql = sql + " values (" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + "," + Efectivo.ToString().Replace(",", ".");
            sql = sql + "," + Tranferencia.ToString().Replace(",", ".");
            sql = sql + "," + Total.ToString().Replace(",", ".");
            sql = sql + "," + CodCuentaProveedor.ToString();
            sql = sql + ")";
            CodOrden = cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
            return CodOrden;
        }

        public void  InsertarDetalle(SqlConnection con, SqlTransaction Transaccion, Int32 CodOrden, Int32 CodDeuda , Double Importe)
        {
            string sql = "insert into DetalleOrdenPago ";
            sql = sql + " (CodOrden,CodDeuda,Importe)";
            sql = sql + " values (";
            sql = sql + CodOrden.ToString();
            sql = sql + "," + CodDeuda.ToString();
            sql = sql + "," + Importe.ToString().Replace(",", ".");
            sql = sql + ")";
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetOrdenesxFecha (DateTime FechaDesde,DateTime FechaHasta)
        {
            string sql = "";
            sql = "select o.CodOrden ,c.Nombre as Cuenta ,p.Nombre as Proveedor, o.Fecha ,o.Efectivo,o.Tranferencia ,o.Total ";
            sql = sql + " from OrdenPago o , CuentaProveedor c , Proveedor p ";
            sql = sql + " where o.CodCuentaProveedor = c.CodCuenta ";
            sql = sql + " and c.CodProveedor = p.CodProveedor ";
            sql = sql + " and o.Fecha >= " + "'" + FechaDesde + "'";
            sql = sql + " and o.Fecha <= " + "'" + FechaHasta + "'";
            return cDb.ExecuteDataTable(sql);

        }

        public DataTable GetOrdenxCodigo (Int32 CodOrden)
        {
            string sql = "";
            sql = "select o.Fecha ,o.Efectivo ,o.Tranferencia, o.total ";
            sql = sql + " from OrdenPago o , DetalleOrdenPago d ";
            sql = sql + " where o.CodOrden = d.CodOrden ";
            sql = sql + " and o.CodOrden = " + CodOrden.ToString();
            return cDb.ExecuteDataTable(sql);
        }

        public DataTable GetDetalleOrdenxCodigo(Int32 CodOrden)
        {
            string sql = "";
            sql = " select c.Nombre as Cuenta ,de.Concepto ,d.Importe  ";
            sql = sql + " from detalleordenpago d , DeudaProveedor  de, CuentaProveedor c ";
            sql = sql + " where d.CodDeuda = de.CodDeuda ";
            sql = sql + " and de.CodCuentaProveedor = c.CodCuenta ";
            sql = sql + " and d.CodOrden = " + CodOrden.ToString();
            return cDb.ExecuteDataTable(sql);
        }
    }
}
