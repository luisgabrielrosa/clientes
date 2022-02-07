using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Cliente.Helpers
{
    class Utilities
    {
        public static int ParseToIntOrCero(string value)
        {
            return int.TryParse(value, out int result) ? result : 0;
        }

        public static float ParseToFloatOrCero(string value)
        {
            return float.TryParse(value, out float result) ? result : 0;
        }


        public static bool GetCurrentWindow(Type type, out Window current)
        {
            bool isSuccess = false;
            current = new Window();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == type)
                {
                    current = window;
                    isSuccess = true;
                    break;
                }
            }

            return isSuccess;
        }

        public static void ShowMessageNotSuccess(Response response)
        {
            if (response.TIPO == Response.TYPE.ALERT)
            {
                MessageBox.Show(response.MENSAJE, "Alerta!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show(response.MENSAJE, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public static void InitGridRegistros<T>(System.Windows.Controls.DataGrid gvRegistros, List<T> registros)
        {
            gvRegistros.ItemsSource = registros;
        }

        public static void CargarComboBox<T>(System.Windows.Controls.ComboBox comboBox, List<T> registros, string campoMostrarCombobox = "")
        {
            comboBox.ItemsSource = registros;
            comboBox.DisplayMemberPath = campoMostrarCombobox;


        }

        public static void SelectedItemCbxById<T>(int id, System.Windows.Controls.ComboBox combobox)
        {
            foreach (T item in
                from item
                    in (IEnumerable<T>)combobox.ItemsSource
                where item.GetType().GetProperty("ID").GetValue(item).ToString() == id.ToString()
                select item)
            {
                combobox.SelectedItem = item;
                break;
            }
        }

        public static void FindChildGroup<T>(DependencyObject parent, string childName, ref List<T> list) where T : DependencyObject
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                T child_Test = child as T;
                if (child_Test == null)
                {
                    FindChildGroup<T>(child, childName, ref list);
                }
                else
                {
                    FrameworkElement child_Element = child_Test as FrameworkElement;
                    if (child_Element.Name == childName)
                    {
                        list.Add(child_Test);
                    }
                    FindChildGroup<T>(child, childName, ref list);
                }
            }

            return;
        }
    }
}
