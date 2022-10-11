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
using LojaRoupa.DAOs;
using MySql.Data.MySqlClient;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interação lógica para CadastrarLojaUC.xam
    /// </summary>
    public partial class CadastrarLojaUC : UserControl
    {
        public Frame _frame;

        public CadastrarLojaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += CadastrarLojaUC_loaded; 
        }

        private void CadastrarLojaUC_loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
