using LojaRoupa.ViewsModels;
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
        private List<FuncionarioModel> _list; 
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
            funcionario.Telefoe = txtTelefone.Text;
            funcionario.Sexo = txtSexo.Text;
            funcionario.Email = txtEmail.Text;
            funcionario.Endereco = txtEndereco.Text;
            funcionario.Funcao = txtFuncao.Text;
            funcionario.Salario = txtSalario.Text;

            _list.Add(funcionario);
            MessageBox.Show(_list.ToString());
        }
    }
}
