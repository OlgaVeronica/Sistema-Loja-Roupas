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
using LojaRoupa.ViewsModels;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Lógica interna para UsuarioUC.xaml
    /// </summary>
    public partial class UsuarioUC : UserControl
    {
        public Frame _frame;
        private UsuarioModel _model = new UsuarioModel();
        public UsuarioUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            
        }

        



        private void btnSalvarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (_model.Senha1 != _model.Senha2)
            {
                MessageBox.Show("As senhas informadas não coincidem, tente novamente.");
            }
            
        }
    }
}
