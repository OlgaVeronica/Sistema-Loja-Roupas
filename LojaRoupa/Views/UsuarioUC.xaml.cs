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
using LojaRoupa.DAOs;


namespace LojaRoupa.Views
{
    /// <summary>
    /// Lógica interna para UsuarioUC.xaml
    /// </summary>
    public partial class UsuarioUC : UserControl
    {
        public Frame _frame;
        private UsuarioModel _usuario = new UsuarioModel();
        public UsuarioUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            
        }
        public UsuarioUC (Frame frame, UsuarioModel usuario)
        {
            InitializeComponent ();
            _frame = frame;
            _usuario = usuario;
            Loaded += UsuarioUC_Loaded;
        }

        private void UsuarioUC_Loaded(object sender, RoutedEventArgs e)
        {
            txtCadNomeUsuario.Text = _usuario.Nome;
            txtCadCPF.Text = _usuario.CPF;
            txtCadSenha.Text = _usuario.Senha;
        }

        /*public CadastrarFornecedorUC(Frame frame, FornecedorModel fornecedor)
        {
            InitializeComponent();
            _frame = frame;
            _fornecedor = fornecedor;
            Loaded += CadastrarFornecedorUC_Loaded;
            txbFornecedor.Text = "Editar Fornecedor";
            btnCadastrar.Content = "Salvar";
        }

        private void CadastrarFornecedorUC_Loaded(object sender, RoutedEventArgs e)
        {
            txtCnpj.Text = _fornecedor.Cnpj;
            txtEmail.Text = _fornecedor.Email;
            txtEndereco.Text = _fornecedor.Endereco;
            txtNomeFantasia.Text = _fornecedor.NomeFantasia;
            txtRazaoSocial.Text = _fornecedor.RazaoSocial;
            txtTelefone.Text = _fornecedor.Telefone;

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FornecedorUC(_frame);
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            FornecedorModel fornecedor = _fornecedor;

            fornecedor.NomeFantasia = txtNomeFantasia.Text;
            fornecedor.Cnpj = txtCnpj.Text;
            fornecedor.Email = txtEmail.Text;
            fornecedor.Endereco = txtEndereco.Text;
            fornecedor.RazaoSocial = txtRazaoSocial.Text;
            fornecedor.Telefone = txtTelefone.Text;
            fornecedor.Status = "Ativo";

            try
            {
                var dao = new FornecedorDAO();

                if(fornecedor.Id > 0)
                {
                    dao.Update(fornecedor);
                    MessageBox.Show("Update Realizado!");
                    _frame.Content = new FornecedorUC(_frame);

                }
                else
                {
                    dao.Insert(fornecedor);
                    MessageBox.Show("Cadastro Realizado!");

                }
            }
            catch (MySqlException error)
            {

                MessageBox.Show(error.Message);
            }

            Clear();
        */



        private void btnSalvarUsuario_Click(object sender, RoutedEventArgs e)
        {

            UsuarioModel usuario = _usuario;
            usuario.Nome = txtCadNomeUsuario.Text;
            usuario.CPF = txtCadCPF.Text;
            usuario.Senha = txtCadSenha.Text;
            /*
            try
            {
                var dao = new ();

                if (_usuario.Senha != _usuario.Senha2)
                {
                    MessageBox.Show("As senhas informadas não coincidem, tente novamente.");
                }
                else
                {

                }
            }*/
        }
    }
}
