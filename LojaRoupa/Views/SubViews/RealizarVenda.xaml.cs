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
    /// Interação lógica para RealizarVenda.xam
    /// </summary>
    public partial class RealizarVenda : UserControl
    {
        public RealizarVenda()
        {
            InitializeComponent();
            Loaded += RealizarVenda_Loaded;
        }

        private void RealizarVenda_Loaded(object sender, RoutedEventArgs e)
        {
            var produtos = new[]
            {
                new{Descricao = "Camisa", Tamanho = "GG"},
                new{Descricao = "Calça", Tamanho = "40"},
                new{Descricao = "Bermuda jeans", Tamanho = "PP"},
                new{Descricao = "camisa", Tamanho = "GG"}
            };
        }


        private void btnRealizarVenda_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
