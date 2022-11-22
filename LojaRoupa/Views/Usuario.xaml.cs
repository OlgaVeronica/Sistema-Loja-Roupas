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
using LojaRoupa.ViewsModels;
using LojaRoupa.Views.SubViews;
using LojaRoupa.DAOs;
using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;
namespace LojaRoupa.Views

{
    /// <summary>
    /// Interação lógica para Usuarioxaml.xam
    /// </summary>
    public partial class Usuarioxaml : UserControl
    {
        private Frame _frame;
        private List<Usuarioxaml> _productsInGrid;
        public Usuarioxaml(Frame frame)
        {
            InitializeComponent();
            _frame = frame;

            Loaded += Usuarioxaml_Loaded;
        }

        private void Usuarioxaml_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnSalvarUsuario_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("aaa");
        }
    }
}