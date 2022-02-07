using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Helpers
{
    class Response
    {
        public object RESPONSE { get; set; }
        public enum TYPE {
            INFO,
            ALERT,
            ERROR,
            SUCCESS
        };
        public string MENSAJE { get; set; }
        public TYPE TIPO { get; set; }
        public bool isSuccess {get;set;}

        public Response(bool isSuccess, TYPE tipo, string mensaje, object response)
        {
            this.isSuccess = isSuccess;
            this.TIPO = tipo;
            this.MENSAJE= mensaje;
            this.RESPONSE = response;
        }

        public Response(Exception e)
        {
            this.isSuccess = false;
            this.TIPO = Response.TYPE.ERROR;
            this.MENSAJE = e.Message;
            this.RESPONSE = e;
        }

    }
}
