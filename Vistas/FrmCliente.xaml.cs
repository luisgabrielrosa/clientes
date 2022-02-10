using System.Windows;
using System.Windows.Input;

namespace Cliente.Vistas
{
    /// <summary>
    /// Interaction logic for FrmCliente.xaml
    /// </summary>
    public partial class FrmCliente : Window
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Controladores.ClienteController cliente = new Controladores.ClienteController();
            cliente.AddOrUpdate();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
