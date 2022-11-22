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
    /// Lógica interna para RelatorioVendas.xaml
    /// </summary>
    public partial class RelatorioVendas : Window
    {
        public RelatorioVendas()
        {
            InitializeComponent();
            Loaded += RelatorioVendas_Loaded;
        }

        private void RelatorioVendas_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dao = new VendaDAO();
                dtgVendas.ItemsSource = dao.List();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
