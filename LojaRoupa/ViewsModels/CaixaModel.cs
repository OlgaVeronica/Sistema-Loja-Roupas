using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class CaixaModel
    {
        public int? Id { get; set; }
        public string DataCaixa { get; set; }
        public string HoraAbertura { get; set; }
        public string HoraFechamento { get; set; }
        public string SaldoInicial { get; set; }
        public string SaldoFinal { get; set; }
    }
}
