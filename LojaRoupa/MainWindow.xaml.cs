using LojaRoupa.Views;
using System;
using System.Windows;


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
            //string senha = pswSenhaUsuario.Password.ToString();
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

        private void lbSenha_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
