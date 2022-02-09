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
    class Cliente
    {
        public int Id { get; set; }
        public string CustName {get;set;}
        public string Adress  { get; set; }
        public bool Status  { get; set; }
        public string CustomerType { get; set; }
        public int CustomerTypeId { get; set; }

        private string procedimiento = "SP_CUSTOMER";
        private Response response;

        public Response get(string id = "")
        {
            try
            {
                string[] parametros = {
                    "@ID",id,
                    "@OPTION","GET"
                };
                DataTable dt = Conexion.Exec_Stp(procedimiento, 'c', parametros);
                List<Cliente> clientes = new List<Cliente>();
                clientes = (from DataRow dr in dt.Rows
                            select new Cliente()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                CustName = dr["CustName"].ToString(),
                                Adress = dr["Adress"].ToString(),
                                Status = Convert.ToBoolean(dr["Status"]),
                                CustomerType = dr["CustomerType"].ToString(),
                                CustomerTypeId = Convert.ToInt32(dr["CustomerTypeId"])
                            }).ToList();

                object retorno = (clientes.Count == 1 && !String.IsNullOrEmpty(id)) ? (object)clientes[0] : clientes;
                response = new Response(isSuccess: true, tipo: Response.TYPE.SUCCESS, mensaje: "Proceso Exitoso!", response: retorno);
            }
            catch (Exception e)
            {
                response = new Response(e);
            }

            return response;

        }


        public Response AddElement(Cliente cliente)
        {
            try
            {
                string option = String.IsNullOrEmpty(cliente.Id.ToString()) ? "INS" : "UPT";
                    
                string[] parametros = {
                    "@ID",cliente.Id.ToString(),
                    "@CustName",cliente.CustName,
                    "@Adress",cliente.Adress,
                    "@Status", cliente.Status.ToString(),
                    "@CustomerTypeId", cliente.CustomerTypeId.ToString(),
                    "@OPTION", option,

                };
                DataTable dt = Conexion.Exec_Stp(procedimiento, 'm', parametros);
                response = new Response(true, Response.TYPE.SUCCESS, "Ha sido actualizado con exito", dt);
            }
            catch (Exception ex)
            {
                response = new Response(ex);
            }

            return response;

        }


        public Response DeleteElement(int id)
        {
            try
            {
                string[] parametros = {
                    "@ID",id.ToString(),
                    "@OPTION","DEL"
                };
                DataTable dt = Conexion.Exec_Stp(procedimiento, 'm', parametros);
                response = new Response(true, Response.TYPE.SUCCESS, "Ha sido eliminado con exito", dt);                
            }
            catch (Exception ex)
            {
                response = new Response(ex);
            }

            return response;

        }
    }
}
