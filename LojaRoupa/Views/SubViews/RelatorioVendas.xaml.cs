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
using System.IO;

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



            //PrintDialog Printdlg = new PrintDialog();
            //if (Printdlg.ShowDialog().GetValueOrDefault())
            //{
            //    Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
            //    // sizing of the element.
            //    dtgVendas.Measure(pageSize);
            //    dtgVendas.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
            //    Printdlg.PrintVisual(dtgVendas, Title);
            //}

            var lista = dtgVendas.ItemsSource;



        }
    }
}
