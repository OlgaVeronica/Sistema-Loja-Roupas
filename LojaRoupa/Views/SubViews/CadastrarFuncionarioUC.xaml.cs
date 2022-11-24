using LojaRoupa.DAOs;
using LojaRoupa.ViewsModels;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interação lógica para CadastrarFuncionarioUC.xam
    /// </summary>
    public partial class CadastrarFuncionarioUC : UserControl
    {
        private Frame _frame;
        private FuncionarioModel _funcionario = new FuncionarioModel();
        private ImageSource _imageSourceFuncionario;
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
            txbFuncionario.Text = "Editar Funcionário";
            btnCadastrar.Content = "Salvar";

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
            imgFuncionario.ImageSource = _funcionario.Avatar != null ? new BitmapImage(new Uri(_funcionario.Avatar)) : imgFuncionario.ImageSource;
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
            funcionario.Avatar = imgFuncionario.ImageSource.ToString();

            try
            {
                var dao = new FuncionarioDAO();

                if(funcionario.Id > 0)
                {
                    dao.Update(funcionario);
                    MessageBox.Show("Update Realizado!");
                    _frame.Content = new FuncionarioUC(_frame);

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
            imgFuncionario.ImageSource = _imageSourceFuncionario; 
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FuncionarioUC(_frame);
        }

        private void btnEscolherImg_Click(object sender, RoutedEventArgs e)
        {
            _imageSourceFuncionario = imgFuncionario.ImageSource;
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp; *.jpg; *.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                imgFuncionario.ImageSource = new BitmapImage(new Uri(openDialog.FileName));
            }
        }



        private void imgFuncionario_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
