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

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Lógica interna para ConsultarCaixaUC.xaml
    /// </summary>
    public partial class ConsultarCaixaUC : UserControl
    {
        public Frame _frame;
        public ConsultarCaixaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }
    }
}
