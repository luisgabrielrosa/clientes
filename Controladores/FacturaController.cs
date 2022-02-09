using Cliente.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cliente.Controladores
{
    class FacturaController
    {
        private Response response;

        public void GetAllRegistros()
        {
            response = new Modelos.Factura().get();

            if (response.isSuccess)
            {
                Utilities.GetCurrentWindow(typeof(Vistas.Factura), out Window window);
                Utilities.InitGridRegistros<Modelos.Factura>((window as Vistas.Factura).gvRegistros, (List<Modelos.Factura>)response.RESPONSE);
            }
            else
            {
                Utilities.ShowMessageNotSuccess(response);
            }
        }

        public void SearchById(int id)
        {
            response = new Modelos.Factura().get(id.ToString());
            Response responseDetalle = new Modelos.DetalleFactura().get(id.ToString());

            if (response.isSuccess || responseDetalle.isSuccess)
            {
                LlenarCamposFormulario((Modelos.Factura)response.RESPONSE, responseDetalle.RESPONSE);                
            }
            else
            {
                if(!response.isSuccess) Utilities.ShowMessageNotSuccess(response);
                if(!responseDetalle.isSuccess) Utilities.ShowMessageNotSuccess(responseDetalle);
            }
        }

        public void LlenarCamposFormulario(object factura, object detalle)
        {
            Vistas.FrmFactura window = new Vistas.FrmFactura();
            window.Show();
            window.txtCodigo.Text = ((Modelos.Factura)factura).Id.ToString();
            window.txtCliente.Text = ((Modelos.Factura)factura).CustName.ToString();
            window.txtTotalItbis.Text = ((Modelos.Factura)factura).TotalItbis.ToString();
            window.txtSubTotal.Text = ((Modelos.Factura)factura).SubTotal.ToString();
            window.txtTotal.Text = ((Modelos.Factura)factura).Total.ToString();
            window.gvDetalleFactura.ItemsSource = (List<Modelos.DetalleFactura>)detalle;
            window.Focus();
        }


    }
}
