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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LojaRoupa.Views.SubViews;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para FuncionarioUC.xam
    /// </summary>
    public partial class FuncionarioUC : UserControl
    {
        public Frame _frame;

        public FuncionarioUC(Frame frame)
        {

            InitializeComponent();
            _frame = frame;
            Loaded += FuncionarioUC_Loaded;

            
        }

        private void FuncionarioUC_Loaded(object sender, RoutedEventArgs e)
        {
            var funcionarios = new[]{
                new {Nome = "José Maria", Telefone = "3333-3333", Email = "josemaria@email.com"},
                new {Nome = "Antonio Carlos", Telefone = "4444-4444", Email = "antonio@email.com"},
                new {Nome = "Pedro Henrique", Telefone = "5555-5555", Email = "pedro@email.com"},
                new {Nome = "Augusto Cesar", Telefone = "6666-6666", Email = "augusto@email.com"},
                new {Nome = "Carlos Silva", Telefone = "7777-7777", Email = "carlos@email.com"}
            };

            dtgFuncionarios.ItemsSource = funcionarios;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CadastrarFuncionarioUC(_frame);
        }
    }
}
