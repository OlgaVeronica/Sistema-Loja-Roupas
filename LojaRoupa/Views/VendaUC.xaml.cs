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

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para VendaUC.xam
    /// </summary>
    public partial class VendaUC : UserControl
    {
        private Frame _frame;
        private VendaModel _venda = new VendaModel();

        private float _valorVenda = 0;


        public VendaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;

            dtpData.IsEnabled = false;
            dtpData.SelectedDate = DateTime.Now;

            carregarListagemFuncionario();
            carregarListagemCliente();
            carregarListagemProdutos()
;        }

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

        private void carregarListagemCliente()
        {
            try
            {
                var dao = new ClienteDAO();
                cbCliente.ItemsSource = dao.List();

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

        private void btnRealizar_Click(object sender, RoutedEventArgs e)
        {
            VendaModel venda = new VendaModel();
            venda.Funcionario = cbFuncionario.SelectedItem as FuncionarioModel;
            venda.Cliente = cbCliente.SelectedItem as ClienteModel;
            venda.Produto = cbProdutos.ItemsSource as List<ProdutoModel>;
            venda.Data = dtpData.SelectedDate;
            venda.Valor = float.Parse(txtValor.Text);

            try
            {

                var dao = new VendaDAO();
                dao.Insert(venda);
                MessageBox.Show("Venda realizada com sucesso", "Sucesso!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possíel inserir Registros", "Erro ao inserir Registros", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                ClearFields();
            }
        }

        private void ClearFields()
        {
            dtgProdutos.Items.Clear();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ProdutoModel produto = dtgProdutos.SelectedItem as ProdutoModel;

            _valorVenda -= produto.Preco * produto.Quantidade;
            txtValor.Text = _valorVenda.ToString();
            dtgProdutos.Items.RemoveAt(dtgProdutos.SelectedIndex);

        }


        private void btAdicionar_Click(object sender, RoutedEventArgs e)
        {
            var produto = cbProdutos.SelectedItem as ProdutoModel;
            produto.Quantidade = int.Parse(cbQuantidade.Text);
            float valorPecas = produto.Preco * float.Parse(cbQuantidade.Text);
            _valorVenda += valorPecas;

            txtValor.Text = _valorVenda.ToString();

            cbProdutos.SelectedIndex = -1;
            cbQuantidade.SelectedIndex = -1;

            dtgProdutos.Items.Add(produto);
            
        }

      
    }
}
