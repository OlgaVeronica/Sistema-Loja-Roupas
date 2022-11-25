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
    /// Interaction logic for CadastrarClienteUC.xaml
    /// </summary>
    public partial class CadastrarClienteUC : UserControl
    {
        private Frame _frame;
        private ClienteModel _cliente = new ClienteModel();
        private List<ClienteModel> _productsInGrid;
        public CadastrarClienteUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            carregarListagem();
        }
        public CadastrarClienteUC(Frame frame, ClienteModel cliente)
        {
            InitializeComponent();
            _frame = frame;
            _cliente = cliente;
            Loaded += CadastrarClienteUC_Loaded;
            txbCliente.Text = "Editar Cliente";
            btnCadastrar.Content = "Salvar";
        }

        private void CadastrarClienteUC_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _cliente.Nome;
            txtTelefone.Text = _cliente.Telefone;
            txtCpf.Text = _cliente.Cpf;
            carregarListagem();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            ClienteModel cliente = _cliente;
            if (
               String.IsNullOrWhiteSpace(txtNome.Text) ||
               String.IsNullOrWhiteSpace(txtTelefone.Text) ||
               String.IsNullOrWhiteSpace(txtCpf.Text)
               )
            {
                MessageBox.Show("Preencha todos os campos!", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {


                cliente.Nome = txtNome.Text;
                cliente.Telefone = txtTelefone.Text;
                cliente.Cpf = txtCpf.Text;
                cliente.Status = "Ativo";


                try
                {
                    var dao = new ClienteDAO();

                    if (cliente.Id > 0)
                    {
                        dao.Update(cliente);
                        MessageBox.Show("Cliente Atualizado Com Sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);
                        _frame.Content = new CadastrarClienteUC(_frame);

                    }
                    else 
                    {
                        dao.Insert(cliente);
                        MessageBox.Show("Cliente Cadastrado Com Sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);


                    }
                }
                catch (MySqlException error)
                {

                    MessageBox.Show(error.Message);
                }
                finally
                {
                    carregarListagem();
                }

            }
            Clear();
        }

        private void Clear()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            txtCpf.Clear();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new VendaUC(_frame);
        }

        private void carregarListagem()
        {
            try
            {
                var dao = new ClienteDAO();
                _productsInGrid = dao.List();
                dtgCliente.ItemsSource = dao.List();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cliente = dtgCliente.SelectedItem as ClienteModel;
                var resultado = MessageBox.Show($"Deseja realmente excluir \"{cliente.Nome}\" dos registros?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);


                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();
                    dao.Delete(cliente);
                    MessageBox.Show("Cliente deletado com sucesso");
                    MessageBox.Show("Cliente Deletado Com Sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var cliente = dtgCliente.SelectedItem as ClienteModel;

            _frame.Content = new CadastrarClienteUC(_frame, cliente);
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txt = txtFilter;
            List<ClienteModel> list = _productsInGrid;

            if (!String.IsNullOrWhiteSpace(txt.Text))
            {
                List<ClienteModel> listaFiltrada = list.FindAll(item =>
                {
                    return item.Nome.ToLower().StartsWith(txt.Text.ToLower());
                });

                dtgCliente.ItemsSource = listaFiltrada;
            }
            else
            {
                dtgCliente.ItemsSource = _productsInGrid;
            }

        }

    }
}
