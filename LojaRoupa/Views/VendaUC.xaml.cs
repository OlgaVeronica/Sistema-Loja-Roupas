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
using LojaRoupa.Views.SubViews;

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
            Loaded += VendaUC_Loaded;

         }

        private void VendaUC_Loaded(object sender, RoutedEventArgs e)
        {
            dtpData.SelectedDate = DateTime.Now;
            dtpData.IsEnabled = false;

            carregarListagemFuncionario();
            carregarListagemCliente();

            carregarListagemProdutos();
            EnableAndDisableButtom();
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

        private void EnableAndDisableButtom()
        {
            btnRealizar.IsEnabled = dtgProdutos.Items.Count > 0;
        }

        private void btnRealizar_Click(object sender, RoutedEventArgs e)
        {
            DateTime? data = dtpData.SelectedDate;

            VendaModel venda = new VendaModel
            {
                Funcionario = cbFuncionario.SelectedItem as FuncionarioModel,
                Cliente = cbCliente.SelectedItem as ClienteModel,
                Produto = cbProdutos.ItemsSource as List<ProdutoModel>,
                Data = dtpData.SelectedDate,
                Valor = float.Parse(txtValor.Text),
                Hora = data?.ToString("HH:mm:ss")
            };

            try
            {

                var dao = new VendaDAO();
                dao.Insert(venda);
                MessageBox.Show("Venda realizada com sucesso", "Sucesso!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show( $"Não foi possíel inserir Registros {ex.Message}", "Erro ao inserir Registros", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                ClearFields();
                txtValor.Clear();
                EnableAndDisableButtom();
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
            EnableAndDisableButtom();
        }


        private void btAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if(cbQuantidade.Text == String.Empty)
            {
                MessageBox.Show("Erro ao inserir produtos");
            }else
            {
                var produto = cbProdutos.SelectedItem as ProdutoModel;
                produto.Quantidade = int.Parse(cbQuantidade.Text);
                float valorPecas = produto.Preco * float.Parse(cbQuantidade.Text);
                _valorVenda += valorPecas;

                txtValor.Text = _valorVenda.ToString();

                cbProdutos.SelectedIndex = -1;
                cbQuantidade.SelectedIndex = -1;

                dtgProdutos.Items.Add(produto);
                EnableAndDisableButtom();
            }

        }

        private void btnNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CadastrarClienteUC(_frame);
        }

        private void BtnRelatorio_Click(object sender, RoutedEventArgs e)
        {
            RelatorioVendas relVendas = new RelatorioVendas();

            relVendas.Show();
        }

        private void cbProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            var dao = new VendaDAO();

            var produto = cbProdutos.SelectedItem == null? null : cbProdutos.SelectedItem as ProdutoModel;

            if (produto != null)
            {


                var numeroItems = dao.BuscaSimplesQuantidade(produto.Id);

                List<int> lista = new List<int>();

                for(var item = 1; item <= numeroItems; item++)
                {
                    lista.Add(item);
                }


                cbQuantidade.ItemsSource = lista;
            }
        }
    }
}
