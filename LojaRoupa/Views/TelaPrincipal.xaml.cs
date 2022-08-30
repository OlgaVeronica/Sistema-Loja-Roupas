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
using LojaRoupa.ViewsModels;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Lógica interna para TelaPrincipal.xaml
    /// </summary>
    public partial class TelaPrincipal : Window
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

      

        private void btnProduto_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ProdutoModel();

        }

        private void btnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new FuncionarioModel();
        }

        private void btnVenda_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new VendaModel();

        }

        private void btnFinanceiro_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new FinanceiroModel();

        }

        private void btnFornecedores_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new FornecedorModel();

        }
    }
}
