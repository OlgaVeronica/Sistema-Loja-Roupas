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
    /// Interaction logic for CadastrarProdutoUC.xaml
    /// </summary>
    public partial class CadastrarProdutoUC : UserControl
    {
        private Frame _frame;
        public CadastrarProdutoUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }
    }
}
