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
        private Response response;

        public void GetAllRegistros()
        {
            response = new Modelos.Cliente().get();

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

        public void SearchById(int id)
        {

            
            response = new Modelos.Cliente().get(id.ToString());

            if (response.isSuccess)
            {
                LlenarCamposFormulario((Modelos.Cliente)response.RESPONSE);
            }
            else
            {
                Utilities.ShowMessageNotSuccess(response);
            }
        }

        public void LlenarCamposFormulario(object cliente)
        {
            Vistas.FrmCliente window = new Vistas.FrmCliente();
            window.Show();
            window.txtNombre.Text = ((Modelos.Cliente)cliente).CustName.ToString();
            window.txtCodigo.Text = ((Modelos.Cliente)cliente).Id.ToString();
            window.txtDireccion.Text = ((Modelos.Cliente)cliente).Adress.ToString();
            window.cbTipo.SelectedValuePath = ((Modelos.Cliente)cliente).CustomerTypeId.ToString();
            window.cbEstado.SelectedValuePath = ((Modelos.Cliente)cliente).Status.ToString();
            window.Focus();
        }


        public void GetValuesFormulario(out object cliente)
        {
            cliente = new Modelos.Cliente();
            Utilities.GetCurrentWindow(typeof(Vistas.FrmCliente), out Window window);

            ((Modelos.Cliente)cliente).Id = Utilities.ParseToIntOrCero((window as Vistas.FrmCliente).txtCodigo.Text);
            ((Modelos.Cliente)cliente).CustName = (window as Vistas.FrmCliente).txtNombre.Text;
            ((Modelos.Cliente)cliente).Adress = (window as Vistas.FrmCliente).txtDireccion.Text;
            ((Modelos.Cliente)cliente).CustomerTypeId = Utilities.ParseToIntOrCero((window as Vistas.FrmCliente).cbTipo.Text);
            ((Modelos.Cliente)cliente).Status = Convert.ToBoolean(Utilities.ParseToIntOrCero((window as Vistas.FrmCliente).cbEstado.Text));
            window.Close();
        }



        public void AddOrUpdate()
        {
            GetValuesFormulario(out object obj);
            Modelos.Cliente cliente = ((Modelos.Cliente)obj);
            response = cliente.AddElement(cliente);
            if (response.isSuccess)
            {
                Utilities.GetCurrentWindow(typeof(Vistas.FrmCliente), out Window window);
                window.Close();
                MessageBox.Show(response.MENSAJE, "REGISTRO", MessageBoxButton.OK, MessageBoxImage.Information);

                GetAllRegistros();
            }
            else
            {
                Utilities.ShowMessageNotSuccess(response);
            }
        }



        public void DeleteElement(int id)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Está seguro que desea borrar este registro permanentemente?", "Confirmación de borrado", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                response = new Modelos.Cliente().DeleteElement(id);
                if (response.isSuccess)
                {
                    MessageBox.Show(response.MENSAJE, "REGISTRO ELIMINADO", MessageBoxButton.OK, MessageBoxImage.Information);
                    GetAllRegistros();
                }
                else
                    Utilities.ShowMessageNotSuccess(response);
            }
        }


        public void CargarComboBoxCliente(System.Windows.Controls.ComboBox comboBox)
        {
            response = new Modelos.Cliente().get();

            if (response.isSuccess)
            {
                comboBox.ItemsSource = (List<Modelos.Cliente>)response.RESPONSE;
            }
            else
                Utilities.ShowMessageNotSuccess(response);
        }

    }
}
