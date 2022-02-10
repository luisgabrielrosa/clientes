using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cliente.Vistas
{
    /// <summary>
    /// Interaction logic for FrmCliente.xaml
    /// </summary>
    public partial class FrmFactura : Window
    {
        public FrmFactura()
        {
            InitializeComponent();
        }

        private void btnGuardar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Controladores.FacturaController factura = new Controladores.FacturaController();
            //factura.AddOrUpdate();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();  
        }
    }
}
