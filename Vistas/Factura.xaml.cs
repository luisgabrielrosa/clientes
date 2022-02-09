using Cliente.Helpers;
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
    /// Lógica de interacción para Cliente.xaml
    /// </summary>
    public partial class Factura : Window
    {
        public Factura()
        {
            InitializeComponent();
            new Controladores.FacturaController().GetAllRegistros();
          
        }

       
        private void btnVerDetalle_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandParameter.ToString());
            new Controladores.FacturaController().SearchById(id);
        }

    }
}
