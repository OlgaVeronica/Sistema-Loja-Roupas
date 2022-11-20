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
using LojaRoupa.DAOs;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;


namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interação lógica para CadastrarFornecedorUC.xam
    /// </summary>
    public partial class CadastrarFornecedorUC : UserControl
    {
        private Frame _frame;
        private FornecedorModel _fornecedor = new FornecedorModel();
        public CadastrarFornecedorUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += CadastrarFornecedorUC_Loaded;
        }
        public CadastrarFornecedorUC(Frame frame, FornecedorModel fornecedor)
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
        }
        private void Clear()
        {
            txtCnpj.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtTelefone.Clear();
            txtNomeFantasia.Clear();
            txtRazaoSocial.Clear();
        }
    }
}
