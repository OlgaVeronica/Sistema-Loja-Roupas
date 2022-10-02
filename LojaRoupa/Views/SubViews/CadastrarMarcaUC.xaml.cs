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
using LojaRoupa.ViewsModels;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interaction logic for CadastrarMarcaUC.xaml
    /// </summary>
    public partial class CadastrarMarcaUC : UserControl
    {
        private Frame _frame;
        public CadastrarMarcaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new MarcaUC(_frame);
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            MarcaModel marca = new MarcaModel();
            marca.Nome = txtNome.Text;
            marca.Logo = txtLogo.Text;
        }
    }
}
