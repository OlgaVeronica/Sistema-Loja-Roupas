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
using LojaRoupa.ViewsModels;
using LojaRoupa.DAOs;
using MySql.Data.MySqlClient;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interaction logic for CadastrarProdutoUC.xaml
    /// </summary>
    public partial class CadastrarProdutoUC : UserControl
    {
        private Frame _frame;
        private ProdutoModel _produto = new ProdutoModel();

        public CadastrarProdutoUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            carregarListagem();

        }
        public CadastrarProdutoUC(Frame frame, ProdutoModel produto)
        {
            InitializeComponent();
            _frame = frame;
            _produto = produto;
            Loaded += CadastrarProdutoUC_Loaded;
            txbRoupa.Text = "Editar Peça de Roupa";
            btnCadastrar.Content = "Salvar";
        }

        private void CadastrarProdutoUC_Loaded(object sender, RoutedEventArgs e)
        {
            
            txtDescricao.Text = _produto.Descricao;
            txtTecido.Text = _produto.Tecido;
            txtTipo.Text = _produto.Tipo;
            txtColecao.Text = _produto.Colecao;
            txtTamanho.Text = _produto.Tamanho;
            txtEstampa.Text = _produto.Estampa;
            cbMarca.SelectedItem = _produto.Marca;
            txtPreco.Text = _produto.Preco.ToString();
            carregarListagem();

        }

        private void carregarListagem()
        {
            try
            {
                var dao = new MarcaDAO();
                cbMarca.ItemsSource = dao.List();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            ProdutoModel produto = _produto;

            if (
                String.IsNullOrWhiteSpace(txtDescricao.Text) ||
                String.IsNullOrWhiteSpace(txtTecido.Text) ||
                String.IsNullOrWhiteSpace(txtColecao.Text) ||
                String.IsNullOrWhiteSpace(txtTamanho.Text) ||
                String.IsNullOrWhiteSpace(txtTipo.Text) ||
                String.IsNullOrWhiteSpace(txtEstampa.Text) ||
                String.IsNullOrWhiteSpace(txtPreco.Text) ||
                String.IsNullOrWhiteSpace(cbMarca.Text)                 )
            {
                MessageBox.Show("Existem campos em branco que precisam ser preenchidos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (cbMarca.SelectedItem != null)
                {
                    produto.Marca = cbMarca.SelectedItem as MarcaModel;
                }

                produto.Descricao = txtDescricao.Text;
                produto.Tecido = txtTecido.Text;
                produto.Tipo = txtTipo.Text;
                produto.Colecao = txtColecao.Text;
                produto.Tamanho = txtTamanho.Text;
                produto.Estampa = txtEstampa.Text;
                produto.Status = "ativo";
                produto.Marca = cbMarca.SelectedItem as MarcaModel;
                produto.Preco = float.Parse(txtPreco.Text);
                produto.Estoque = 0;
                try
                {
                    var dao = new ProdutoDAO();

                    if (produto.Id > 0)
                    {
                        dao.Update(produto);
                        MessageBox.Show("Produto Atualizado Com Sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);
                        _frame.Content = new ProdutoUC(_frame);

                    }
                    else
                    {
                        dao.Insert(produto);
                        MessageBox.Show("Produto Cadastrado Com Sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
                catch (MySqlException error)
                {

                    MessageBox.Show(error.Message);
                }

                Clear();
            }
        }

        private void Clear()
        {
            txtDescricao.Clear();
            txtTecido.Clear();
            txtTipo.Clear();
            txtColecao.Clear();
            txtTamanho.Clear();
            txtEstampa.Clear();
            cbMarca.SelectedIndex = -1;
            txtPreco.Clear();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ProdutoUC(_frame);
        }
    }
}
