using Cliente.Database;
using Cliente.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Modelos
{
    internal class DetalleFactura
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double TotalItbis { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }

        private string procedimiento = "SP_INVOICE";

        private Response response;
        public Response get(string id = "")
        {
            try
            {
                string[] parametros = {
                    "@INVOICEID",id,
                    "@OPTION","GEF"
                };
                DataTable dt = Conexion.Exec_Stp(procedimiento, 'c', parametros);
                List<DetalleFactura> detalleFactura = new List<DetalleFactura>();
                detalleFactura = (from DataRow dr in dt.Rows
                            select new DetalleFactura()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Qty = Convert.ToInt32(dr["Qty"].ToString()),
                                Price = Convert.ToDouble(dr["Price"].ToString()),
                                TotalItbis = Convert.ToDouble(dr["TotalItbis"].ToString()),
                                SubTotal = Convert.ToDouble(dr["SubTotal"]),
                                Total = Convert.ToDouble(dr["Total"].ToString()),
                            }).ToList();

                

                response = new Response(isSuccess: true, tipo: Response.TYPE.SUCCESS, mensaje: "Proceso Exitoso!", response: detalleFactura);
            }
            catch (Exception e)
            {
                response = new Response(e);
            }

            return response;

        }

    }
}
