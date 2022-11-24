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
    /// Interação lógica para CadastrarPagamento.xam
    /// </summary>
    public partial class CadastrarPagamento : UserControl
    {
        public CadastrarPagamento()
        {
            InitializeComponent();
            Loaded += CadastrarPagamento_Loaded;
        }

        private void CadastrarPagamento_Loaded(object sender, RoutedEventArgs e)
        {
            //VERIFICAÇÃO DE NLO OU VAZIO DE PAGAMENTO

            /*if (
                String.IsNullOrWhiteSpace(txtNomeLoja.Text) ||
                String.IsNullOrWhiteSpace(txtCnpjLoja.Text) ||
                String.IsNullOrWhiteSpace(txtRuaLoja.Text) ||
                String.IsNullOrWhiteSpace(txtBairroLoja.Text) ||
                String.IsNullOrWhiteSpace(txtCidadeLoja.Text) ||
                String.IsNullOrWhiteSpace(txtNumeroLoja.Text) ||
                String.IsNullOrWhiteSpace(txtEstadoLoja.Text)

               )
            {
                MessageBox.Show("Existem campos em branco que precisam ser preenchidos!");
            }
            else
            {
                //aaaaaaaaaaaaa
            }*/
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
