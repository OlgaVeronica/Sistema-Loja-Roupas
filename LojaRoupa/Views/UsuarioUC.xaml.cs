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

        
        private void btnSalvarUsuario_Click(object sender, RoutedEventArgs e)
        {

            UsuarioModel usuario = _usuario;
            usuario.Nome = txtCadNomeUsuario.Text;
            usuario.CPF = txtCadCPF.Text;
            usuario.Senha = txtCadSenha.Text;
            
            try
            {
                var dao = new UsuarioDAO();

                if (_usuario.Senha != _usuario.Senha2)
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
        }
    }
}
