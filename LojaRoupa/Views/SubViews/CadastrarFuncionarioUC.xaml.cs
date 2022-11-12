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
    /// Interação lógica para CadastrarFuncionarioUC.xam
    /// </summary>
    public partial class CadastrarFuncionarioUC : UserControl
    {
        private Frame _frame;
        private FuncionarioModel _funcionario = new FuncionarioModel();
        public CadastrarFuncionarioUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += CadastrarFuncionarioUC_Loaded;
        }

        

        public CadastrarFuncionarioUC(Frame frame, FuncionarioModel funcionario)
        {
            InitializeComponent();
            _frame = frame;
            _funcionario = funcionario;
            Loaded += CadastrarFuncionarioUC_Loaded;

        }

        private void CadastrarFuncionarioUC_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _funcionario.Nome;
            txtCPF.Text = _funcionario.Cpf;
            txtRG.Text = _funcionario.RG;
            txtTelefone.Text = _funcionario.Telefone;
            txtSexo.Text = _funcionario.Sexo;
            txtEmail.Text = _funcionario.Email;
            txtEndereco.Text = _funcionario.Endereco;
            txtFuncao.Text = _funcionario.Funcao;
            txtSalario.Text = _funcionario.Salario;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            FuncionarioModel funcionario = _funcionario;
            funcionario.Nome = txtNome.Text;
            funcionario.Cpf = txtCPF.Text;
            funcionario.RG = txtRG.Text;
            funcionario.Telefone = txtTelefone.Text;
            funcionario.Sexo = txtSexo.Text;
            funcionario.Email = txtEmail.Text;
            funcionario.Endereco = txtEndereco.Text;
            funcionario.Funcao = txtFuncao.Text;
            funcionario.Salario = txtSalario.Text;
            funcionario.Status = "ativo";

            try
            {
                var dao = new FuncionarioDAO();

                if(funcionario.Id > 0)
                {
                    dao.Update(funcionario);
                    MessageBox.Show("Update Realizado!");

                }
                else
                {
                    dao.Insert(funcionario);
                    MessageBox.Show("Cadastro Realizado!");

                }
            } catch(MySqlException error)
            {

                MessageBox.Show(error.Message);
            }

            Clear();
        }

        private void Clear()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtRG.Clear();
            txtTelefone.Clear();
            txtSexo.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtFuncao.Clear();
            txtSalario.Clear();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FuncionarioUC(_frame);
        }
    }
}
