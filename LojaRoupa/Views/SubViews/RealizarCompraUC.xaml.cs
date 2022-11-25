using LojaRoupa.DAOs;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;
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

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interação lógica para RealizarCompraUC.xam
    /// </summary>
    public partial class RealizarCompraUC : UserControl
    {
        public Frame _frame;
        private CompraModel _compra = new CompraModel();

        private float _valorCompra = 0;

        public RealizarCompraUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += RealizarCompraUC_Loaded;
        }
        public RealizarCompraUC(Frame frame, CompraModel compra)
        {
            InitializeComponent();
            _frame = frame;
            _compra = compra;
            Loaded += RealizarCompraUC_Loaded;

        }
        private void RealizarCompraUC_Loaded(object sender, RoutedEventArgs e)
        {
            dtpData.SelectedDate = DateTime.Now;
            dtpData.IsEnabled = false;
            carregarListagemFornecedor();
            carregarListagemFuncionario();
            carregarListagemProdutos();
        }
        private void carregarListagemFuncionario()
        {
            try
            {
                var dao = new FuncionarioDAO();
                cbFuncionario.ItemsSource = dao.List();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void carregarListagemFornecedor()
        {
            try
            {
                var dao = new FornecedorDAO();
                cbFornecedor.ItemsSource = dao.List();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void carregarListagemProdutos()
        {
            try
            {
                var dao = new ProdutoDAO();
                cbProdutos.ItemsSource = dao.List();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Patrick: Pedir para o Gabriel analisar e explicar essa parte kk
        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FinanceiroUC(_frame);

        }

        

        private void btAdicionar_Click(object sender, RoutedEventArgs e)
        {
            var produto = cbProdutos.SelectedItem as ProdutoModel;
            produto.Quantidade = int.Parse(cbQuantidade.Text);
            float valorPecas = produto.Preco * float.Parse(cbQuantidade.Text);
            _valorCompra += valorPecas;
   
            dtgProdutos.Items.Add(produto);
            EnableAndDisableButtom();
        }

        private void btnRealizar_Click(object sender, RoutedEventArgs e)
        {
            DateTime? data = dtpData.SelectedDate;

            CompraModel compra = new CompraModel
            {
                Funcionario = cbFuncionario.SelectedItem as FuncionarioModel,
                Fornecedor = cbFornecedor.SelectedItem as FornecedorModel,
                Produtos = cbProdutos.ItemsSource as List<ProdutoModel>,
                Data = dtpData.SelectedDate,
                Valor = float.Parse(txtValor.Text),
                Hora = data?.ToString("HH:mm:ss")
            };

            try
            {

                var dao = new CompraDAO();
                dao.Insert(compra);
                MessageBox.Show("Venda realizada com sucesso", "Sucesso!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possíel inserir Registros", "Erro ao inserir Registros", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ClearFields();
                txtValor.Clear();
                EnableAndDisableButtom();
            }
        }

        private void EnableAndDisableButtom()
        {
            btnRealizar.IsEnabled = dtgProdutos.Items.Count > 0;
        }
        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ProdutoModel produto = dtgProdutos.SelectedItem as ProdutoModel;

            _valorCompra -= produto.Preco * produto.Quantidade;
            txtValor.Text = _valorCompra.ToString();
            dtgProdutos.Items.RemoveAt(dtgProdutos.SelectedIndex);
            EnableAndDisableButtom();

        }
        private void ClearFields()
        {
            dtgProdutos.Items.Clear();
        }
    }
}
