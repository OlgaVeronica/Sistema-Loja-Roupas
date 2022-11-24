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
using LojaRoupa.Database;
using LojaRoupa.Helpers;
using LojaRoupa.Properties;
using LojaRoupa.Views;
using MySql.Data.MySqlClient;
using Microsoft.Win32;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Lógica interna para UsuarioUC.xaml
    /// </summary>
    public partial class UsuarioUC : UserControl
    {
        public Frame _frame;
        private UsuarioModel _usuario = new UsuarioModel();
        private ImageSource _imageSourceUsuario;

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
            pwbCadSenha.Password = _usuario.Senha;
        }

        private void btnEscolherImg_Click(object sender, RoutedEventArgs e)
        {
            _imageSourceUsuario = imgUsuario.ImageSource;
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp; *.jpg; *.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                imgUsuario.ImageSource = new BitmapImage(new Uri(openDialog.FileName));
            }
        }

        private void Clear()
        {
            txtCadNomeUsuario.Clear();
            txtCadCPF.Clear();
            pwbCadSenha.Clear();
            pwbCadConfirmarSenha.Clear();
            cbCadTipoUsuario.SelectedIndex = -1;
            imgUsuario.ImageSource = _imageSourceUsuario;
        }


        private void btnSalvarUsuario_Click(object sender, RoutedEventArgs e)
        {

            UsuarioModel usuario = _usuario;
            usuario.Nome = txtCadNomeUsuario.Text;
            usuario.CPF = txtCadCPF.Text;
            usuario.Senha = pwbCadSenha.Password;
            usuario.Tipo = cbCadTipoUsuario.Text;
            usuario.Avatar = imgUsuario.ImageSource.ToString();
            try
            {
                var dao = new UsuarioDAO();

                if (pwbCadSenha.ToString() != pwbCadConfirmarSenha.ToString())
                {
                    MessageBox.Show("As senhas informadas não coincidem, tente novamente.");
                }
                else
                {
                    dao.Insert(usuario);
                    MessageBox.Show("Cadastro de usuário realizado!");
                    
                }
            }
            catch (MySqlException error)
            {

                MessageBox.Show(error.Message);
            }

            Clear();
        }
    }
}
