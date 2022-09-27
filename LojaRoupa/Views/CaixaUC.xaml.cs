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
using LojaRoupa.Views.SubViews;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para CaixaUC.xam
    /// </summary>
    public partial class CaixaUC : UserControl
    {
        public Frame _frame;
        public CaixaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void btnConsultarCaixa_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ConsultarCaixaUC(_frame);
        }
    }
}
