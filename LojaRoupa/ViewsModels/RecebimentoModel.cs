using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class RecebimentoModel
    {
        public int Id { get; set;}
        public string DataAbertura { get; set;}
        public string Data { get; set;}
        public double Valor { get; set;}
        public string Hora { get; set; }
        public string FormaReceb { get; set;}
        public string StatusReceb { get; set;}
        public CaixaModel Caixa { get; set;} = new CaixaModel();
        public VendaModel Venda { get; set;} = new VendaModel();

        public ClienteModel Cliente { get; set; } = new ClienteModel();
        
    }
}
