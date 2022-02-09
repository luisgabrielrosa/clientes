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
    delegate DetalleFactura GetDetalle(string id);

    class Factura
    {
        public int Id { get; set; }
        public int CustomerId {get;set;}
        public string CustName{ get;set;}
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
                    "@OPTION","GET"
                };
                DataTable dt = Conexion.Exec_Stp(procedimiento, 'c', parametros);
                List<Factura> facturas = new List<Factura>();
                facturas = (from DataRow dr in dt.Rows
                            select new Factura()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                CustName = dr["CustName"].ToString(),
                                CustomerId = Convert.ToInt32(dr["CustomerId"].ToString()),
                                TotalItbis= Convert.ToDouble(dr["TotalItbis"].ToString()),
                                SubTotal= Convert.ToDouble(dr["SubTotal"]),
                                Total = Convert.ToDouble(dr["Total"].ToString()),
                            }).ToList();

                object retorno = (facturas.Count == 1 && !String.IsNullOrEmpty(id))? (object)facturas[0] : facturas;
                
                response = new Response(isSuccess: true, tipo: Response.TYPE.SUCCESS, mensaje: "Proceso Exitoso!", response: retorno);
            }
            catch (Exception e)
            {
                response = new Response(e);
            }

            return response;

        }

    }
}
