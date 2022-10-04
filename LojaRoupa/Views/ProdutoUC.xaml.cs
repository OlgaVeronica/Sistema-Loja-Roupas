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
using LojaRoupa.DAOs;
using MySql.Data.MySqlClient;

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
            carregarListagem();
        }

        private void carregarListagem()
        {
            try
            {
                var dao = new ProdutoDAO();
                dtgProdutos.ItemsSource = dao.List();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var produto = dtgProdutos.SelectedItem as ProdutoModel;
                var resultado = MessageBox.Show($"Deseja realmente excluir \"{produto.Tipo}\" dos registros?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);


                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new ProdutoDAO();
                    dao.Delete(produto);
                    MessageBox.Show("Produto deletado com sucesso");
                    carregarListagem();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var produto = dtgProdutos.SelectedItem as ProdutoModel;

            _frame.Content = new CadastrarProdutoUC(_frame, produto);
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
