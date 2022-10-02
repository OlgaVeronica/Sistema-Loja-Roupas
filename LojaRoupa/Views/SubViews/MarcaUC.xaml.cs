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
    /// Interaction logic for MarcaUC.xaml
    /// </summary>
    public partial class MarcaUC : UserControl
    {
        private Frame _frame;
        public MarcaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ProdutoUC(_frame);
        }
    }
}
