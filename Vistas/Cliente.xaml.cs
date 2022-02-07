﻿using Cliente.Helpers;
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
    public partial class Cliente : Window
    {
        public Cliente()
        {
            InitializeComponent();
            new Controladores.ClienteController().GetAllRegistros();
            //if (response.TIPO == Response.TYPE.SUCCESS)
            //{
            //    dgClientes.DataContext = response.RESPONSE;
            //}
            //else
            //{
            //    MessageBox.Show(response.MENSAJE);
            //}
        }


        public static void SelectRowByIndex(DataGrid dataGrid, int rowIndex)
        {
            DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            if (row != null)
            {
                //DataGridCell cell = GetCell(dataGrid, row, 0);
                //if (cell != null)
                //    cell.Focus();
            }
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditarElemento_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandParameter.ToString());
            //new Controller.ClienteController().SearchById(id);

        }

        private void btnDeleteElement_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandParameter.ToString());
       //     new Controller.ClienteController().DeleteElement(id);

        }

        private void btnAgregar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
