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
        public CadastrarFuncionarioUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            FuncionarioModel funcionario = new FuncionarioModel();
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
                dao.Insert(funcionario);
                MessageBox.Show("Cadastro Realizado!");
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
