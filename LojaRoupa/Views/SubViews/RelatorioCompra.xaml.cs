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
using LojaRoupa.DAOs;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Lógica interna para RelatorioCompra.xaml
    /// </summary>
    public partial class RelatorioCompra : Window
    {
        public RelatorioCompra()
        {
            InitializeComponent();
            Loaded += RelatorioCompra_Loaded;
        }

        private void RelatorioCompra_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dao = new CompraDAO();
                dtgCompras.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Fechar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    //printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
