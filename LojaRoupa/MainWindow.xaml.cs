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
using LojaRoupa.Views;


namespace LojaRoupa
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

        }

        private void brLogar_Click(object sender, RoutedEventArgs e)
        {
            string login = txtNomeUsuario.Text;
            string senha = pswSenhaUsuario.Password.ToString();
            TelaPrincipal tela = new TelaPrincipal();
            this.Close();
            tela.ShowDialog();

            //if(login == "Olga" && senha == "123")
            //{
            //    MessageBox.Show($"Usuário '{login}' logado com sucesso!", "PDS - 2022, 3º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);
            //    WinCadastro cadastro = new WinCadastro();
            //    cadastro.ShowDialog();
            //}
            //else
            //    MessageBox.Show($"O usuário ou a senha está incorreta ou não existe! Tente novamente", "PDS - 2022, 1º Bimestre", MessageBoxButton.OK, MessageBoxImage.Error);

            //txtNomeUsuario.Clear();
            //pswSenhaUsuario.Clear();

        }

    }
}
