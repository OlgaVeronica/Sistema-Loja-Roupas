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
            Loaded += TelaPrincipal_Loaded;
        }

        private void TelaPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            //DataContext = new CaixaModel();
            _frame.Content = new ProdutoUC(_frame);
        }

        private void btnProduto_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ProdutoUC(_frame);

        }

        private void btnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FuncionarioUC(_frame);
        }

        private void btnVenda_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new VendaUC(_frame);

        }

        private void btnFinanceiro_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FinanceiroUC(_frame);

        }

        private void btnFornecedores_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FornecedorUC(_frame);

        }

        private void btnCaixa_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CaixaUC(_frame);
        }

        private void BtnDrag(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void BtnClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnMax(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void btnPerfil_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
