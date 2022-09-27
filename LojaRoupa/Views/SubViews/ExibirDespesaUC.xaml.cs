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
    /// Interação lógica para ExibirDespesaUC.xam
    /// </summary>
    public partial class ExibirDespesaUC : Page
    {
        public Frame _frame;

        public ExibirDespesaUC(Frame Frame)
        {
            InitializeComponent();
            _frame = Frame;
        }
    }
}
