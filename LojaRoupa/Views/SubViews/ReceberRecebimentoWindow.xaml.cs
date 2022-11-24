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
using LojaRoupa.DAOs;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Lógica interna para ReceberRecebimentoWindow.xaml
    /// </summary>
    public partial class ReceberRecebimentoWindow : Window
    {
        RecebimentoModel _recebimento;
        public ReceberRecebimentoWindow(RecebimentoModel recebimento)
        {
            InitializeComponent();
            _recebimento = recebimento;
            Loaded += ReceberRecebimentoWindow_Loaded;

            BtnReceber.IsEnabled = recebimento.StatusReceb == "Aberto";
        }

        private void ReceberRecebimentoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtData.Text = _recebimento.DataAbertura;
            txtstatus.Text = _recebimento.StatusReceb;
            txtValor.Text = _recebimento.Valor.ToString();
            txtVenda.Text = _recebimento.Venda.Id.ToString();

            
            List<CaixaModel> lista = new List<CaixaModel>();
            try
            {
                var dao = new CaixaDAO();
                lista = dao.List("Abertos");
            }
            catch
            {
                cbNumCaixa.Text = "Não Há caixas abertos no momento";
            }
            cbNumCaixa.ItemsSource = lista as List<CaixaModel>;
            EnableOrDisableButton();
        }

        private void EnableOrDisableButton()
        {
            BtnReceber.IsEnabled = cbNumCaixa.SelectedIndex != -1;
        }

        private void BtnReceber_Click(object sender, RoutedEventArgs e)
        {
            RecebimentoModel recebimento = new RecebimentoModel
            {
                Id = _recebimento.Id,
                StatusReceb = "Recebido"
            };

            

            try
            {
                var dao = new RecebimentoDAO();
                dao.Update(recebimento);
            }
            catch
            {
                
            }
            finally
            {
                this.Close();
            }
        }

        private void cbNumCaixa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableOrDisableButton();
        }
    }
}
