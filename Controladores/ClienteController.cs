using Cliente.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cliente.Controladores
{
    class ClienteController
    {
        public Response get()
        {
            return new Modelos.Cliente().get();
        }


        public void GetAllRegistros()
        {
            Modelos.Cliente cliente = new Modelos.Cliente();
            Response response = new Modelos.Cliente().get();

            if (response.isSuccess)
            {
                Utilities.GetCurrentWindow(typeof(Vistas.Cliente), out Window window);
                Utilities.InitGridRegistros<Modelos.Cliente>((window as Vistas.Cliente).gvRegistros, (List<Modelos.Cliente>)response.RESPONSE);
            }
            else
            {
                Utilities.ShowMessageNotSuccess(response);
            }
        }

    }
}
