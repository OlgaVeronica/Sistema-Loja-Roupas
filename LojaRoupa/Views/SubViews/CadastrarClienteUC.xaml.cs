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
        public CadastrarClienteUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }
        public CadastrarClienteUC(Frame frame, ClienteModel cliente)
        {
            InitializeComponent();
            _frame = frame;
            _cliente = cliente;
            Loaded += CadastrarClienteUC_Loaded;
        }

        private void CadastrarClienteUC_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _cliente.Nome;
            txtTelefone.Text = _cliente.Telefone;
            txtCpf.Text = _cliente.Cpf;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            ClienteModel cliente = _cliente;
            cliente.Nome = txtNome.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Status = "Ativo";

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
    }
}
