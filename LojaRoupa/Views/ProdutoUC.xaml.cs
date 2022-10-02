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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LojaRoupa.Views;
using LojaRoupa.ViewsModels;
using LojaRoupa.Views.SubViews;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para ProdutoUC.xam
    /// </summary>
    public partial class ProdutoUC : UserControl
    {
        private Frame _frame;

        public ProdutoUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += ProdutoUC_Loaded;
        }

        private void ProdutoUC_Loaded(object sender, RoutedEventArgs e)
        {
            var produtos = new[]{
                new {Nome = "José Maria", Telefone = "3333-3333", Email = "josemaria@email.com"},
                new {Nome = "Antonio Carlos", Telefone = "4444-4444", Email = "antonio@email.com"},
                new {Nome = "Pedro Henrique", Telefone = "5555-5555", Email = "pedro@email.com"},
                new {Nome = "Augusto Cesar", Telefone = "6666-6666", Email = "augusto@email.com"},
                new {Nome = "Carlos Silva", Telefone = "7777-7777", Email = "carlos@email.com"}
            };

            dtgProdutos.ItemsSource = produtos;
        }

        private void btnCadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CadastrarProdutoUC(_frame);
        }

        private void btnMarca_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new MarcaUC(_frame);
        }
    }
}
